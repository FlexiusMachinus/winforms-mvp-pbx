using System;
using System.Windows.Forms;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using DB_CourseWork.Presentation;

namespace DB_CourseWork.UI
{
    public partial class PaymentForm : Form, IPaymentView
    {
        public event EventHandler<CancelEventArgs> Exit;
        public event EventHandler SaveChanges;
        public event EventHandler AddPayment;
        public event EventHandler DeletePayments;
        public event EventHandler CreateReport;
        public event EventHandler CheckFees;

        private readonly ApplicationContext _context;

        public PaymentForm(ApplicationContext context)
        {
            _context = context;
            InitializeComponent();
        }

        public object PaymentsDataSource
        {
            get => _paymentBindingSource.DataSource;
            set => _paymentBindingSource.DataSource = value;
        }

        public object PhonesDataSource
        {
            get => _phonesBindingSource.DataSource;
            set => _phonesBindingSource.DataSource = value;
        }

        public IEnumerable<int> SelectedPayments
        {
            get => _paymentsGrid.SelectedRows.Cast<DataGridViewRow>().Select(row => row.Cells[0].Value).Cast<int>();
        }

        public new void Show()
        {
            _context.MainForm = this;
            Application.Run(_context);
        }

        public bool ConfirmDelete()
        {
            DialogResult result = MessageBox.Show(
                $"Вы уверены, что хотите удалить записи?", "Удаление",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question
            );

            return (result == DialogResult.Yes);
        }

        public bool? ConfirmExit()
        {
            DialogResult result = MessageBox.Show(
                $"У вас есть несохраненные изменения, сохранить?", "Выход",
                MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question
            );

            if (result == DialogResult.Cancel) return null;
            return (result == DialogResult.Yes);
        }

        public void ShowMessage(string message)
        {
            MessageBox.Show(message, "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public void ShowError(string message)
        {
            MessageBox.Show(message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);

            var cancelEventArgs = new CancelEventArgs();
            Exit?.Invoke(this, cancelEventArgs);
            e.Cancel = cancelEventArgs.Cancel;
        }

        private void SaveToolStripMenuItemClick(object sender, EventArgs e)
        {
            SaveChanges?.Invoke(this, EventArgs.Empty);
        }

        private void CloseToolStripMenuItemClick(object sender, EventArgs e)
        {
            Close();
        }

        private void AddButtonClick(object sender, EventArgs e)
        {
            AddPayment?.Invoke(this, EventArgs.Empty);
        }

        private void DeleteButtonClick(object sender, EventArgs e)
        {
           DeletePayments?.Invoke(this, EventArgs.Empty);
        }

        private void CreateReportToolStripMenuItemClick(object sender, EventArgs e)
        {
            CreateReport?.Invoke(this, EventArgs.Empty);
        }

        private void CheckFeesToolStripMenuItemClick(object sender, EventArgs e)
        {
            CheckFees?.Invoke(this, EventArgs.Empty);
        }

        private void PaymentGridDataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            string columnHeader = _paymentsGrid.Columns[e.ColumnIndex].HeaderText;
            ShowError($"Возникла ошибка при обработке значения столбца \"{columnHeader}\":\n{e.Exception.Message}");
        }
    }
}
