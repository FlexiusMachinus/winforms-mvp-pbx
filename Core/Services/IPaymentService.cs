using System;
using System.Collections.Generic;

namespace DB_CourseWork.Core
{
    public interface IPaymentService
    {
        IList<Payment> GetAllPayments();

        void AddPayment(Payment payment);
        void RemovePaymentsByIds(IEnumerable<int> paymentIds);

        bool CheckChanges();
        void SaveChanges();
    }
}
