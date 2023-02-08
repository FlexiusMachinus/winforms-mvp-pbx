using System;

namespace DB_CourseWork
{
    public interface ICheckFeesView : IDialogView
    {
        event EventHandler UpdateDebts;
        event EventHandler CalculateFees;

        object DebtorPhonesDataSource { get; set; }
        object PhoneStatusesDataSource { get; set; }

        void SetDebtsInfo(string debtsText);
        void SetFeesInfo(string feesText);
    }
}
