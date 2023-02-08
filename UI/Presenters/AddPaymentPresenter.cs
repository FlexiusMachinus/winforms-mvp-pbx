using System;

namespace DB_CourseWork
{
    public class AddPaymentPresenter : IPresenter<IView>
    {
        private readonly IAddPaymentView _view;
        private readonly IPaymentService _paymentService;

        public AddPaymentPresenter(IAddPaymentView view, IPaymentService paymentService)
        {
            _view = view;
            _paymentService = paymentService;

            _view.AddPayment += OnAddPayment;

            BindDataSources();
        }

        public void BindDataSources()
        {
            _view.PhonesDataSource = _paymentService.GetAllSubscriberPhones();
        }

        public void Run(IView parentView)
        {
            _view.ShowDialog(parentView);
        }

        public void OnAddPayment(object sender, EventArgs e)
        {
            try
            {
                if (ValidatePayment())
                {
                    var payment = new Payment(_view.SelectedPhone, _view.PaymentAmount.Value, _view.SelectedDate);
                    _paymentService.AddPayment(payment);
                    _paymentService.SaveChanges();
                    _view.Close();
                }
            }
            catch (Exception ex)
            {
                _view.ShowError($"Возникла ошибка при добавлении платежа:\n{ex.Message}.");
            }
        }

        private bool ValidatePayment()
        {
            if (_view.PaymentAmount == null)
            {
                _view.ShowError("Введенная сумма платежа имеет некорректный формат.");
                return false;
            }

            if (_view.PaymentAmount.Value <= 0)
            {
                _view.ShowError("Сумма платежа не может быть меньше или равна нулю.");
                return false;
            }

            if (_view.SelectedDate > DateTime.Now)
            {
                _view.ShowError("Дата платежа не может быть позже текущей даты.");
                return false;
            }

            if (_view.SelectedPhone == null)
            {
                _view.ShowError("Введенного телефона нет в базе.");
                return false;
            }

            return true;
        }
    }
}
