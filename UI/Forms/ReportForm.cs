using System;
using System.Windows.Forms;
using DB_CourseWork.Presentation;

namespace DB_CourseWork.UI
{
    public partial class ReportForm : Form, IReportView
    {
        public event EventHandler CreateReport;
        public event EventHandler SelectDate;

        public ReportForm()
        {
            InitializeComponent();
        }

        public DateTime SelectedDate
        {
            get => _monthPicker.Value;
            set => _monthPicker.Value = value;
        }

        public void SetDateRange(DateTime startDate, DateTime endDate)
        {
            _periodLabel.Text = $"{startDate.ToShortDateString()} - {endDate.ToShortDateString()}";
        }

        public void SetPaymentsInfo(decimal totalPayments, string paymentsText)
        {
            _totalPaymentsLabel.Text = totalPayments.ToString();
            _paymentsLabel.Text = paymentsText;

            if (_paymentsSplitContainer.Panel2Collapsed)
            {
                ChangePanelCollapseState(_paymentsSplitContainer, _paymentsPanel, _expandPaymentsButton);
            }
        }

        public void SetDebtsInfo(decimal totalDebts, string debtsText)
        {
            _totalDebtsLabel.Text = totalDebts.ToString();
            _debtsLabel.Text = debtsText;

            if (_debtSplitContainer.Panel2Collapsed)
            {
                ChangePanelCollapseState(_debtSplitContainer, _debtPanel, _expandDebtsButton);
            }
        }

        private void CreateButtonClick(object sender, EventArgs e)
        {
            CreateReport?.Invoke(this, EventArgs.Empty);
        }

        private void MonthPickerValueChanged(object sender, EventArgs e)
        {
            SelectDate?.Invoke(this, EventArgs.Empty);
        }

        private void ReportFormShown(object sender, EventArgs e)
        {
            _paymentsSplitContainer.Height = _paymentsSplitContainer.Panel1MinSize + 1;
            _debtSplitContainer.Height = _debtSplitContainer.Panel1MinSize + 1;
        }

        private void ExpandFeesButtonClick(object sender, EventArgs e)
        {
            ChangePanelCollapseState(_paymentsSplitContainer, _paymentsPanel, _expandPaymentsButton);
        }

        private void ExpandDebtsButtonClick(object sender, EventArgs e)
        {
            ChangePanelCollapseState(_debtSplitContainer, _debtPanel, _expandDebtsButton);
        }

        private void ChangePanelCollapseState(SplitContainer splitContainer, Panel panel, Button button)
        {
            splitContainer.Panel2Collapsed = !splitContainer.Panel2Collapsed;

            if (splitContainer.Panel2Collapsed)
            {
                splitContainer.Height = splitContainer.Panel1MinSize + 1;
                button.Text = "+";
            }
            else
            {
                splitContainer.Height = splitContainer.Panel1MinSize + panel.Height + 1;
                splitContainer.SplitterDistance = splitContainer.Panel1MinSize;
                button.Text = "-";
            }
        }
    }
}
