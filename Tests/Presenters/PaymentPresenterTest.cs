using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using DB_CourseWork.Presentation;
using DB_CourseWork.Core;

namespace DB_CourseWork.Tests
{
    [TestClass]
    public class PaymentPresenterTest
    {
        private Mock<INavigator> _navigatorMock;
        private Mock<IPaymentView> _viewMock;
        private Mock<IPaymentService> _paymentServiceMock;
        private Mock<ISubscriberPhoneService> _phoneServiceMock;

        [TestInitialize]
        public void InitializeTest()
        {
            _navigatorMock = new Mock<INavigator>();
            _viewMock = new Mock<IPaymentView>();
            _paymentServiceMock = new Mock<IPaymentService>();
            _phoneServiceMock = new Mock<ISubscriberPhoneService>();

            var payments = new List<Payment>();
            _paymentServiceMock.Setup(m => m.GetAllPayments()).Returns(payments);

            var phones = new List<SubscriberPhone>();
            _phoneServiceMock.Setup(m => m.GetAllSubscriberPhones()).Returns(phones);
        }

        [TestMethod]
        public void Run_View_shown()
        {
            var presenter = new PaymentPresenter(
                _viewMock.Object,
                _paymentServiceMock.Object,
                _phoneServiceMock.Object,
                _navigatorMock.Object
            );

            presenter.Run();

            _viewMock.Verify(m => m.Show(), Times.Once);
        }

        [TestMethod]
        public void BindDataSources_Get_sources_from_service_and_bind_to_view()
        {
            _viewMock.SetupProperty(m => m.PaymentsDataSource);
            _viewMock.SetupProperty(m => m.PhonesDataSource);
            var presenter = new PaymentPresenter(
                _viewMock.Object,
                _paymentServiceMock.Object,
                _phoneServiceMock.Object,
                _navigatorMock.Object
            );

            _paymentServiceMock.Verify(m => m.GetAllPayments(), Times.Once);
            _phoneServiceMock.Verify(m => m.GetAllSubscriberPhones(), Times.Once);
            Assert.IsNotNull(_viewMock.Object.PaymentsDataSource);
            Assert.IsNotNull(_viewMock.Object.PhonesDataSource);
        }

        [TestMethod]
        public void OnDeletePayment_Empty_selection_No_confirmation_shown()
        {
            var ids = new List<int>();

            _viewMock.Setup(m => m.SelectedPayments).Returns(ids);
            var presenter = new PaymentPresenter(
                _viewMock.Object,
                _paymentServiceMock.Object,
                _phoneServiceMock.Object,
                _navigatorMock.Object
            );

            presenter.Run();
            presenter.OnDeletePayments(this, EventArgs.Empty);

            _viewMock.Verify(m => m.ConfirmDelete(), Times.Never);
            _paymentServiceMock.Verify(m => m.RemovePaymentsByIds(It.IsAny<IEnumerable<int>>()), Times.Never);
        }

        [TestMethod]
        public void OnDeletePayment_Multiple_selection_cancel_Confirmation_shown_and_service_not_called()
        {
            var ids = new List<int>() { 1, 2, 3 };

            _viewMock.Setup(m => m.SelectedPayments).Returns(ids);
            _viewMock.Setup(m => m.ConfirmDelete()).Returns(false);
            var presenter = new PaymentPresenter(
                _viewMock.Object,
                _paymentServiceMock.Object,
                _phoneServiceMock.Object,
                _navigatorMock.Object
            );

            presenter.Run();
            presenter.OnDeletePayments(this, EventArgs.Empty);

            _viewMock.Verify(m => m.ConfirmDelete(), Times.Once);
            _paymentServiceMock.Verify(m => m.RemovePaymentsByIds(It.IsAny<IEnumerable<int>>()), Times.Never);
        }

        [TestMethod]
        public void OnDeletePayment_Multiple_selection_confirm_Confirmation_shown_and_service_called()
        {
            var ids = new List<int>() { 1, 2, 3 };

            _viewMock.Setup(m => m.SelectedPayments).Returns(ids);
            _viewMock.Setup(m => m.ConfirmDelete()).Returns(true);
            var presenter = new PaymentPresenter(
                _viewMock.Object,
                _paymentServiceMock.Object,
                _phoneServiceMock.Object,
                _navigatorMock.Object
            );

            presenter.Run();
            presenter.OnDeletePayments(this, EventArgs.Empty);

            _viewMock.Verify(m => m.ConfirmDelete(), Times.Once);
            _paymentServiceMock.Verify(m => m.RemovePaymentsByIds(ids), Times.Once);
        }

        [TestMethod]
        public void OnDeletePayment_Single_selection_confirm_Confirmation_shown_and_service_called()
        {
            var ids = new List<int>() { 69 };

            _viewMock.Setup(m => m.SelectedPayments).Returns(ids);
            _viewMock.Setup(m => m.ConfirmDelete()).Returns(true);
            var presenter = new PaymentPresenter(
                _viewMock.Object,
                _paymentServiceMock.Object,
                _phoneServiceMock.Object,
                _navigatorMock.Object
            );

            presenter.Run();
            presenter.OnDeletePayments(this, EventArgs.Empty);

            _viewMock.Verify(m => m.ConfirmDelete(), Times.Once);
            _paymentServiceMock.Verify(m => m.RemovePaymentsByIds(ids), Times.Once);
        }

        [TestMethod]
        public void SaveChanges_Service_method_called_and_message_displayed_on_view()
        {
            var presenter = new PaymentPresenter(
                _viewMock.Object,
                _paymentServiceMock.Object,
                _phoneServiceMock.Object,
                _navigatorMock.Object
            );

            presenter.Run();
            presenter.OnSaveChanges(this, EventArgs.Empty);

            _paymentServiceMock.Verify(m => m.SaveChanges(), Times.Once);
            _viewMock.Verify(m => m.ShowMessage(It.Is<string>(s => !string.IsNullOrEmpty(s))), Times.Once);
        }

        [TestMethod]
        public void OnExit_No_changes_No_confirmation_shown_and_save_not_called()
        {
            _paymentServiceMock.Setup(m => m.CheckChanges()).Returns(false);
            var presenter = new PaymentPresenter(
                _viewMock.Object,
                _paymentServiceMock.Object,
                _phoneServiceMock.Object,
                _navigatorMock.Object
            );

            presenter.Run();
            var cancel = new CancelEventArgs();
            presenter.OnExit(this, cancel);

            _viewMock.Verify(m => m.ConfirmExit(), Times.Never);
            _paymentServiceMock.Verify(m => m.SaveChanges(), Times.Never);
            Assert.IsFalse(cancel.Cancel);
        }

        [TestMethod]
        public void OnExit_Discard_changes_Cnfirmation_shown_and_save_not_called()
        {
            _paymentServiceMock.Setup(m => m.CheckChanges()).Returns(true);
            _viewMock.Setup(m => m.ConfirmExit()).Returns(false);
            var presenter = new PaymentPresenter(
                _viewMock.Object,
                _paymentServiceMock.Object,
                _phoneServiceMock.Object,
                _navigatorMock.Object
            );

            presenter.Run();
            var cancel = new CancelEventArgs();
            presenter.OnExit(this, cancel);

            _viewMock.Verify(m => m.ConfirmExit(), Times.Once);
            _paymentServiceMock.Verify(m => m.SaveChanges(), Times.Never);
            Assert.IsFalse(cancel.Cancel);
        }

        [TestMethod]
        public void OnExit_Confirm_changes_Cnfirmation_shown_and_save_called()
        {
            _paymentServiceMock.Setup(m => m.CheckChanges()).Returns(true);
            _viewMock.Setup(m => m.ConfirmExit()).Returns(true);
            var presenter = new PaymentPresenter(
                _viewMock.Object,
                _paymentServiceMock.Object,
                _phoneServiceMock.Object,
                _navigatorMock.Object
            );

            presenter.Run();
            var cancel = new CancelEventArgs();
            presenter.OnExit(this, cancel);

            _viewMock.Verify(m => m.ConfirmExit(), Times.Once);
            _paymentServiceMock.Verify(m => m.SaveChanges(), Times.Once);
            Assert.IsFalse(cancel.Cancel);
        }

        [TestMethod]
        public void OnExit_Cancel_exit_Confirmation_shown_and_event_cancel_is_true()
        {
            _paymentServiceMock.Setup(m => m.CheckChanges()).Returns(true);
            _viewMock.Setup(m => m.ConfirmExit()).Returns<bool?>(null);
            var presenter = new PaymentPresenter(
                _viewMock.Object,
                _paymentServiceMock.Object,
                _phoneServiceMock.Object,
                _navigatorMock.Object
            );

            presenter.Run();
            var cancel = new CancelEventArgs();
            presenter.OnExit(this, cancel);

            _viewMock.Verify(m => m.ConfirmExit(), Times.Once);
            _paymentServiceMock.Verify(m => m.SaveChanges(), Times.Never);
            Assert.IsTrue(cancel.Cancel);
        }

        [TestMethod]
        public void OnAddPayment_Navigator_run_called()
        {
            var presenter = new PaymentPresenter(
                _viewMock.Object,
                _paymentServiceMock.Object,
                _phoneServiceMock.Object,
                _navigatorMock.Object
            );

            presenter.Run();
            presenter.OnAddPayment(this, EventArgs.Empty);

            _navigatorMock.Verify(m => m.Run<AddPaymentPresenter, IView>(_viewMock.Object), Times.Once);
        }

        [TestMethod]
        public void OnCreateReport_Navigator_run_called()
        {
            var presenter = new PaymentPresenter(
                _viewMock.Object,
                _paymentServiceMock.Object,
                _phoneServiceMock.Object,
                _navigatorMock.Object
            );

            presenter.Run();
            presenter.OnCreateReport(this, EventArgs.Empty);

            _navigatorMock.Verify(m => m.Run<ReportPresenter>(), Times.Once);
        }

        [TestMethod]
        public void OnCheckFees_Navigator_run_called()
        {
            var presenter = new PaymentPresenter(
                _viewMock.Object,
                _paymentServiceMock.Object,
                _phoneServiceMock.Object,
                _navigatorMock.Object
            );

            presenter.Run();
            presenter.OnCheckFees(this, EventArgs.Empty);

            _navigatorMock.Verify(m => m.Run<CheckFeesPresenter, IView>(_viewMock.Object), Times.Once);
        }
    }
}
