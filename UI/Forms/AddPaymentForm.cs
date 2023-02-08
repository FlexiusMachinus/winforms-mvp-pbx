using System;
using System.Windows.Forms;
using DB_CourseWork.Presentation;

namespace DB_CourseWork.UI
{
    public partial class AddPaymentForm : Form, IAddPaymentView
    {
        public event EventHandler AddPayment;

        public AddPaymentForm()
        {
            InitializeComponent();
        }

        public object PhonesDataSource
        {
            get => _phoneCombobox.DataSource;
            set => _phoneCombobox.DataSource = value;
        }

        public string PhoneNumber => _phoneCombobox.SelectedValue as string;
        public DateTime SelectedDate => _dateTimePicker.Value;
        public decimal? PaymentAmount
        {
            get
            {
                if (decimal.TryParse(_amountTextbox.Text, out decimal amount))
                {
                    return amount;
                }

                return null;
            }
        }

        public void ShowDialog(IView parentView)
        {
            base.ShowDialog(parentView as IWin32Window);
        }

        public void ShowError(string message)
        {
            MessageBox.Show(message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void AddButtonClick(object sender, EventArgs e)
        {
            AddPayment?.Invoke(this, EventArgs.Empty);
        }

        private void CancelButtonClick(object sender, EventArgs e)
        {
            Close();
        }
    }
}
