using System;

namespace DB_CourseWork
{
    public class CheckFeesPresenter : IPresenter<IView>
    {
        private readonly ICheckFeesView _view;
        private readonly IFeeService _feeService;

        public CheckFeesPresenter(ICheckFeesView view, IFeeService feeService)
        {
            _view = view;
            _feeService = feeService;

            _view.UpdateDebts += OnUpdateDebts;
            _view.CalculateFees += OnCalculateFees;

            BindDataSources();
        }

        public void BindDataSources()
        {
            _view.DebtorPhonesDataSource = _feeService.GetDebtorPhones();
            _view.PhoneStatusesDataSource = _feeService.GetStatuses();
        }

        public void Run(IView parentView)
        {
            _view.ShowDialog(parentView);
        }

        public void OnUpdateDebts(object sender, EventArgs e)
        {
            DebtCalculationResult result = _feeService.UpdateDebts();
            string debtsText = $"Сумма выплаченных задолженностей: {result.DebtsPaid} р.\n" +
                $"Новая сумма задолженностей: {result.DebtsTotal} р.";

            if (result.DebtsSinceLastUpdate > 0)
            {
                debtsText += $" (+{result.DebtsSinceLastUpdate} р.)";
            }

            _view.SetDebtsInfo(debtsText);
            BindDataSources();
        }

        public void OnCalculateFees(object sender, EventArgs e)
        {
            FeeCalculationResult result = _feeService.CalculateFees();
            string feesText = $"Всего оплат по тарифам: {result.FeeCount}\n" +
                $"Общая сумма оплат: {result.FeesTotal}";

            _view.SetFeesInfo(feesText);
            BindDataSources();
        }
    }
}
