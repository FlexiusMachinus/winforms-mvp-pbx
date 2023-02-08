using System;

namespace DB_CourseWork.Presentation
{
    public interface IAddPaymentView : IDialogView
    {
        event EventHandler AddPayment;

        object PhonesDataSource { get; set; }

        string PhoneNumber { get; }
        DateTime SelectedDate { get; }
        decimal? PaymentAmount { get; }

        void ShowError(string message);
    }
}
