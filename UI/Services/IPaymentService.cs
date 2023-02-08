using System;
using System.Collections.Generic;

namespace DB_CourseWork
{
    public interface IPaymentService
    {
        IList<Payment> GetAllPayments();
        IList<SubscriberPhone> GetAllSubscriberPhones();

        void AddPayment(Payment payment);
        void RemovePaymentsByIds(IEnumerable<int> paymentIds);

        bool CheckChanges();
        void SaveChanges();
    }
}
