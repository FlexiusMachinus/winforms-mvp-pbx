using System;
using DB_CourseWork.Core;

namespace DB_CourseWork.Presentation
{
    public interface ICheckFeesView : IDialogView
    {
        event EventHandler UpdateDebts;
        event EventHandler MakeTariffPayments;

        object DebtorPhonesDataSource { get; set; }
        object PhoneStatusesDataSource { get; set; }

        void SetDebtsInfo(string debtsText);
        void SetFeesInfo(string feesText);
    }
}
