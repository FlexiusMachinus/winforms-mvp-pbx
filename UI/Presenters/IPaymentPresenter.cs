using System;
using System.Collections.Generic;

namespace DB_CourseWork
{
    public interface IPaymentPresenter : IPresenter
    {
        void AddPayment();
        void DeletePayments();

        bool Exit();
        void SaveChanges();

        void CreateReport();
        void CheckFees();
    }
}
