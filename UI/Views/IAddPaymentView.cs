using System;

namespace DB_CourseWork
{
    public interface IAddPaymentView : IDialogView
    {
        event EventHandler AddPayment;

        object PhonesDataSource { get; set; }

        SubscriberPhone SelectedPhone { get; }
        DateTime SelectedDate { get; }
        decimal? PaymentAmount { get; }

        void ShowError(string message);
    }
}
