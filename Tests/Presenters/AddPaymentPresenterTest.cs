using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using DB_CourseWork.Presentation;
using DB_CourseWork.Core;

namespace DB_CourseWork.Tests
{
    [TestClass]
    public class AddPaymentPresenterTest
    {
        private Mock<IPaymentView> _parentViewMock;
        private Mock<IAddPaymentView> _viewMock;
        private Mock<IPaymentService> _paymentServiceMock;
        private Mock<ISubscriberPhoneService> _phoneServiceMock;

        [TestInitialize]
        public void InitializeTest()
        {
            _parentViewMock = new Mock<IPaymentView>();
            _viewMock = new Mock<IAddPaymentView>();
            _paymentServiceMock = new Mock<IPaymentService>();
            _phoneServiceMock = new Mock<ISubscriberPhoneService>();

            var phones = new List<SubscriberPhone>();
            _phoneServiceMock.Setup(m => m.GetAllSubscriberPhones()).Returns(phones);
        }

        [TestMethod]
        public void Run_View_dialog_shown()
        {
            var presenter = new AddPaymentPresenter(_viewMock.Object, _paymentServiceMock.Object, _phoneServiceMock.Object);

            presenter.Run(_parentViewMock.Object);

            _viewMock.Verify(m => m.ShowDialog(_parentViewMock.Object), Times.Once);
        }

        [TestMethod]
        public void BindDataSources_Get_source_from_service_and_bind_to_view()
        {
            _viewMock.SetupProperty(m => m.PhonesDataSource);
            var presenter = new AddPaymentPresenter(_viewMock.Object, _paymentServiceMock.Object, _phoneServiceMock.Object);

            Assert.IsNotNull(_viewMock.Object.PhonesDataSource);
        }

        [TestMethod]
        public void OnAddPayment_Invalid_amount_format_Error_shown()
        {
            _viewMock.Setup(m => m.PaymentAmount).Returns<decimal?>(null);
            var presenter = new AddPaymentPresenter(_viewMock.Object, _paymentServiceMock.Object, _phoneServiceMock.Object);

            presenter.Run(_parentViewMock.Object);
            presenter.OnAddPayment(this, EventArgs.Empty);

            _viewMock.Verify(m => m.ShowError(It.IsAny<string>()));
        }

        [TestMethod]
        public void OnAddPayment_Negative_amount_Error_shown()
        {
            _viewMock.Setup(m => m.PaymentAmount).Returns(-1);
            var presenter = new AddPaymentPresenter(_viewMock.Object, _paymentServiceMock.Object, _phoneServiceMock.Object);

            presenter.Run(_parentViewMock.Object);
            presenter.OnAddPayment(this, EventArgs.Empty);

            _viewMock.Verify(m => m.ShowError(It.IsAny<string>()));
        }

        [TestMethod]
        public void OnAddPayment_Zero_amount_Error_shown()
        {
            _viewMock.Setup(m => m.PaymentAmount).Returns(0);
            var presenter = new AddPaymentPresenter(_viewMock.Object, _paymentServiceMock.Object, _phoneServiceMock.Object);

            presenter.Run(_parentViewMock.Object);
            presenter.OnAddPayment(this, EventArgs.Empty);

            _viewMock.Verify(m => m.ShowError(It.IsAny<string>()));
        }

        [TestMethod]
        public void OnAddPayment_Future_date_Error_shown()
        {
            _viewMock.Setup(m => m.PaymentAmount).Returns(100);
            _viewMock.Setup(m => m.SelectedDate).Returns(DateTime.Now + TimeSpan.FromDays(1));
            var presenter = new AddPaymentPresenter(_viewMock.Object, _paymentServiceMock.Object, _phoneServiceMock.Object);

            presenter.Run(_parentViewMock.Object);
            presenter.OnAddPayment(this, EventArgs.Empty);

            _viewMock.Verify(m => m.ShowError(It.IsAny<string>()));
        }

        [TestMethod]
        public void OnAddPayment_Unknown_phone_number_Error_shown()
        {
            _viewMock.Setup(m => m.PaymentAmount).Returns(100);
            _viewMock.Setup(m => m.SelectedDate).Returns(DateTime.Now - TimeSpan.FromDays(1));
            _viewMock.Setup(m => m.PhoneNumber).Returns("999-99-99");
            var presenter = new AddPaymentPresenter(_viewMock.Object, _paymentServiceMock.Object, _phoneServiceMock.Object);

            presenter.Run(_parentViewMock.Object);
            presenter.OnAddPayment(this, EventArgs.Empty);

            _viewMock.Verify(m => m.ShowError(It.IsAny<string>()));
        }

        [TestMethod]
        public void OnAddPayment_Valid_data_No_error_shown_and_service_called()
        {
            var testPhone = new SubscriberPhone("123-45-67", null, "", "");

            _phoneServiceMock.Setup(m => m.FindSubscriberPhoneByNumber(testPhone.Number)).Returns(testPhone);
            _viewMock.Setup(m => m.PaymentAmount).Returns(100);
            _viewMock.Setup(m => m.SelectedDate).Returns(DateTime.Now - TimeSpan.FromDays(1));
            _viewMock.Setup(m => m.PhoneNumber).Returns(testPhone.Number);
            var presenter = new AddPaymentPresenter(_viewMock.Object, _paymentServiceMock.Object, _phoneServiceMock.Object);

            presenter.Run(_parentViewMock.Object);
            presenter.OnAddPayment(this, EventArgs.Empty);

            _viewMock.Verify(m => m.ShowError(It.IsAny<string>()), Times.Never);
            _paymentServiceMock.Verify(m => m.AddPayment(It.IsAny<Payment>()), Times.Once);
        }
    }
}
