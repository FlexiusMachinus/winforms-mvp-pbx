using System;

namespace DB_CourseWork
{
    public interface IReportView : IView
    {
        event EventHandler CreateReport;
        event EventHandler SelectDate;

        DateTime SelectedDate { get; set; }
        void SetDateRange(DateTime startDate, DateTime endDate);
        void SetPaymentsInfo(decimal totalOayments, string paymentsText);
        void SetDebtsInfo(decimal totalDebts, string debtsText);
    }
}
