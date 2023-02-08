using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using DB_CourseWork.Core.Data;

namespace DB_CourseWork.Core
{
    public class PaymentService : IPaymentService
    {
        private readonly PbxContext _context;

        private readonly IPhoneStatusService _statusService;

        public PaymentService(PbxContext context, IPhoneStatusService statusService)
        {
            _context = context;
            _context.Payments.Load();

            _statusService = statusService;
        }

        public IList<Payment> GetAllPayments()
        {
            return _context.Payments.Local.ToBindingList();
        }

        public void AddPayment(Payment payment)
        {
            if (payment == null) throw new ArgumentNullException(nameof(payment));
            if (payment.Amount <= 0) throw new ArgumentException("Amount cannot be less or equal to 0.");

            _context.Payments.Add(payment);

            payment.Phone.AccountBalance += payment.Amount;
            if (payment.Phone.AccountBalance >= 0 && _statusService.IsPhoneDebtor(payment.Phone))
            {
                _statusService.SetConnectedStatus(payment.Phone);
            }
        }

        public void RemovePaymentsByIds(IEnumerable<int> paymentIds)
        {
            _context.Payments.RemoveRange(_context.Payments.Where(p => paymentIds.Contains(p.Id)));
        }

        public bool CheckChanges()
        {
            return _context.ChangeTracker.HasChanges();
        }

        public void SaveChanges()
        {
            try
            {
                _context.SaveChanges();
            }
            catch (DataException ex)
            {
                string errorMessage;
                if (ex is DbEntityValidationException validationEx)
                {
                    DbValidationError error = validationEx.EntityValidationErrors.First().ValidationErrors.First();
                    errorMessage = error.ErrorMessage;
                }
                else
                {
                    Exception inner = ex;
                    while (inner.InnerException != null)
                    {
                        inner = inner.InnerException;
                    }
                    errorMessage = inner.ToString();
                }

                throw new SaveDataException(errorMessage);
            }
        }
    }
}
