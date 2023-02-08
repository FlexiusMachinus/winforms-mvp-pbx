using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace DB_CourseWork
{
    public interface IPaymentView : IView
    {
        event EventHandler<CancelEventArgs> Exit;
        event EventHandler SaveChanges;
        event EventHandler AddPayment;
        event EventHandler DeletePayments;
        event EventHandler CreateReport;
        event EventHandler CheckFees;

        object PaymentsDataSource { get; set; }
        object PhonesDataSource { get; set; }

        IEnumerable<int> SelectedPayments { get; }

        bool ConfirmDelete();
        bool? ConfirmExit();
        void ShowMessage(string message);
        void ShowError(string message);
    }
}
