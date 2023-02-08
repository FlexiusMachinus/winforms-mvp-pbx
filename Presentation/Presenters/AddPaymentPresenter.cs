using System;
using DB_CourseWork.Core;

namespace DB_CourseWork.Presentation
{
    public class AddPaymentPresenter : IPresenter<IView>
    {
        private readonly IAddPaymentView _view;
        private readonly IPaymentService _paymentService;
        private readonly ISubscriberPhoneService _subscriberService;

        public AddPaymentPresenter(IAddPaymentView view, IPaymentService paymentService, ISubscriberPhoneService subscriberService)
        {
            _view = view;
            _paymentService = paymentService;
            _subscriberService = subscriberService;

            _view.AddPayment += OnAddPayment;

            BindDataSources();
        }

        public void BindDataSources()
        {
            _view.PhonesDataSource = _subscriberService.GetAllSubscriberPhones();
        }

        public void Run(IView parentView)
        {
            _view.ShowDialog(parentView);
        }

        public void OnAddPayment(object sender, EventArgs e)
        {
            try
            {
                Payment payment = CreateAndValidatePayment();
                if (payment != null)
                {
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

        private Payment CreateAndValidatePayment()
        {
            SubscriberPhone phone = _subscriberService.FindSubscriberPhoneByNumber(_view.PhoneNumber);
            if (phone == null)
            {
                _view.ShowError("Введенного телефона нет в базе.");
                return null;
            }

            decimal? paymentAmount = _view.PaymentAmount;
            if (paymentAmount == null)
            {
                _view.ShowError("Введенная сумма платежа имеет некорректный формат.");
                return null;
            }
            if (paymentAmount.Value <= 0)
            {
                _view.ShowError("Сумма платежа не может быть меньше или равна нулю.");
                return null;
            }

            DateTime dateTime = _view.SelectedDate;
            if (dateTime > DateTime.Now)
            {
                _view.ShowError("Дата платежа не может быть позже текущей даты.");
                return null;
            }

            return new Payment(phone, paymentAmount.Value, dateTime);
        }
    }
}
