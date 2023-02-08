using System;
using System.Collections.Generic;
using System.Linq;

namespace DB_CourseWork
{
    public class ReportPresenter : IPresenter
    {
        private readonly IReportView _view;
        private readonly IReportService _service;

        private DateTime _startDate;
        public DateTime _endDate;

        public ReportPresenter(IReportView view, IReportService service)
        {
            _view = view;
            _service = service;

            _view.SelectDate += OnSelectDate;
            _view.CreateReport += OnCreateReport;

            _view.SelectedDate = DateTime.Now;
            OnSelectDate(this, EventArgs.Empty);
        }

        public void Run()
        {
            _view.Show();
        }

        public void OnSelectDate(object sender, EventArgs e)
        {
            var date = _view.SelectedDate;
            _startDate = new DateTime(date.Year, date.Month, 1);
            _endDate = new DateTime(date.Year, date.Month, DateTime.DaysInMonth(date.Year, date.Month));
            _view.SetDateRange(_startDate, _endDate);
        }

        public void OnCreateReport(object sender, EventArgs e)
        {
            IDictionary<Tariff, decimal> paymentsByTariffs = _service.CalculatePaymentsByTariffs(_startDate, _endDate);
            IDictionary<Tariff, decimal> debtsByTariffs = _service.CalculateDebtsByTariffs(_startDate, _endDate);

            decimal totalPayments = paymentsByTariffs.Values.Sum();
            string paymentsText = "";
            foreach (var pair in paymentsByTariffs)
            {
                paymentsText += $"- {pair.Key.Name}: {pair.Value} руб.\n";
            }

            decimal totalDebts = debtsByTariffs.Values.Sum();
            string debtsText = "";
            foreach (var pair in debtsByTariffs)
            {
                debtsText += $"- {pair.Key.Name}: {pair.Value} руб.\n";
            }

            _view.SetPaymentsInfo(totalPayments, paymentsText);
            _view.SetDebtsInfo(totalDebts, debtsText);
        }
    }
}
