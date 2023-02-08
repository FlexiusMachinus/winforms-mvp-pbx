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

        // TODO: Refactor this garbage (move to PhoneStatusService)
        private readonly List<PhoneStatus> _phoneStatuses;
        private readonly PhoneStatus _connectedStatus;
        private readonly PhoneStatus _debtStatus;

        public PaymentService(PbxContext context)
        {
            _context = context;
            _context.Payments.Load();

            _phoneStatuses = _context.PhoneStatuses.OrderBy(s => s.Id).ToList();
            _connectedStatus = _phoneStatuses[0];
            _debtStatus = _phoneStatuses[2];
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
            if (payment.Phone.AccountBalance >= 0 && payment.Phone.CurrentStatus == _debtStatus)
            {
                SetNewPhoneStatus(payment.Phone, _connectedStatus);
            }
        }

        // TODO: Move to PhoneStatusService
        private void SetNewPhoneStatus(SubscriberPhone phone, PhoneStatus newStatus, string comment = "")
        {
            var newStatusEntry = new StatusHistoryEntry(phone, newStatus, DateTime.Now, comment);
            phone.StatusHistory.Add(newStatusEntry);
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
