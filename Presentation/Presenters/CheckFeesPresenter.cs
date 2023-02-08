using System;
using System.Linq;
using DB_CourseWork.Core;

namespace DB_CourseWork.Presentation
{
    public class CheckFeesPresenter : IPresenter<IView>
    {
        private readonly ICheckFeesView _view;
        private readonly IFeeService _feeService;
        private readonly IPhoneStatusService _statusService;

        public CheckFeesPresenter(ICheckFeesView view, IFeeService feeService, IPhoneStatusService statusService)
        {
            _view = view;
            _feeService = feeService;
            _statusService = statusService;

            _view.UpdateDebts += OnUpdateDebts;
            _view.MakeTariffPayments += OnMakeTariffPayments;

            BindDataSources();
        }

        public void BindDataSources()
        {
            _view.DebtorPhonesDataSource = _feeService.GetDebtorPhones()
                .OrderBy(p => p.CurrentStatus.Id)
                .ThenBy(p =>p.AccountBalance);

            _view.PhoneStatusesDataSource = _statusService.GetStatuses();
        }

        public void Run(IView parentView)
        {
            _view.ShowDialog(parentView);
        }

        public void OnUpdateDebts(object sender, EventArgs e)
        {
            DebtCalculationResult result = _feeService.UpdateDebts();
            string debtsText = $"Выплаченные задолженности: {result.DebtsPaid} р.\n" +
                $"Новые задолженности: {result.NewDebts} р.\n" +
                $"Всего: {result.DebtsTotal} р.";

            //if (result.NewDebts > 0)
            //{
            //    debtsText += $" (+{result.NewDebts} р.)";
            //}

            _view.SetDebtsInfo(debtsText);
            BindDataSources();
        }

        public void OnMakeTariffPayments(object sender, EventArgs e)
        {
            FeeCalculationResult result = _feeService.MakeTariffPayments();
            string feesText = $"Всего оплат по тарифам: {result.FeeCount}\n" +
                $"Общая сумма оплат: {result.FeesTotal}";

            _view.SetFeesInfo(feesText);
            BindDataSources();
        }
    }
}
