using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace DB_CourseWork
{
    public class PaymentService : IPaymentService
    {
        private readonly PbxContext _context;

        public PaymentService(PbxContext context)
        {
            _context = context;
            _context.Payments.Load();
            _context.SubscriberPhones.Load();
        }

        public IList<Payment> GetAllPayments()
        {
            return _context.Payments.Local.ToBindingList();
        }

        public IList<SubscriberPhone> GetAllSubscriberPhones()
        {
            return _context.SubscriberPhones.Local.ToBindingList();
        }

        public void AddPayment(Payment payment)
        {
            _context.Payments.Add(payment);
            payment.Phone.AccountBalance += payment.Amount;
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
            _context.SaveChanges();
        }
    }
}
