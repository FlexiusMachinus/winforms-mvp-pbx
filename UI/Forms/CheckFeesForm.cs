using System;
using System.Windows.Forms;
using DB_CourseWork.Presentation;

namespace DB_CourseWork.UI
{
    public partial class CheckFeesForm : Form, ICheckFeesView
    {
        public event EventHandler UpdateDebts;
        public event EventHandler MakeTariffPayments;

        public CheckFeesForm()
        {
            InitializeComponent();
        }

        public object DebtorPhonesDataSource
        {
            get => _phonesBindingSource.DataSource;
            set
            {
                _phonesBindingSource.DataSource = value;
                _debtorGrid.Refresh();
            }
        }

        public object PhoneStatusesDataSource
        {
            get => _phoneStatusesBindingSource.DataSource;
            set => _phoneStatusesBindingSource.DataSource = value;
        }

        public void ShowDialog(IView parentView)
        {
            base.ShowDialog(parentView as IWin32Window);
        }

        public void SetDebtsInfo(string debtsText) => ShowInfo(debtsText);
        public void SetFeesInfo(string feesText) => ShowInfo(feesText);

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            ClearEmptyRows();
        }

        private void ShowInfo(string text)
        {
            MessageBox.Show(text, "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void UpdateDebtsMenuItemClick(object sender, EventArgs e)
        {
            UpdateDebts?.Invoke(this, EventArgs.Empty);
            ClearEmptyRows();
        }

        private void CalculateFeesMenuItemClick(object sender, EventArgs e)
        {
            MakeTariffPayments?.Invoke(this, EventArgs.Empty);
            ClearEmptyRows();
        }

        private void ClearEmptyRows()
        {
            if (_debtorGrid.Rows.Count == 1 && (_debtorGrid.Rows[0].Cells.Count == 0 || _debtorGrid.Rows[0].Cells[0].Value == null))
            {
                _debtorGrid.Rows.Clear();
            }
        }
    }
}
