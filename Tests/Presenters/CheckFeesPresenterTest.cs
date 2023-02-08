using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using DB_CourseWork.Core;
using DB_CourseWork.Presentation;

namespace DB_CourseWork.Tests
{
    [TestClass]
    public class CheckFeesPresenterTest
    {
        private Mock<IPaymentView> _parentViewMock;
        private Mock<ICheckFeesView> _viewMock;
        private Mock<IFeeService> _feeServiceMock;
        private Mock<IPhoneStatusService> _statusServiceMock;

        [TestInitialize]
        public void InitializeTest()
        {
            _parentViewMock = new Mock<IPaymentView>();
            _viewMock = new Mock<ICheckFeesView>();
            _feeServiceMock = new Mock<IFeeService>();
            _statusServiceMock = new Mock<IPhoneStatusService>();

            var phones = new List<SubscriberPhone>();
            _feeServiceMock.Setup(m => m.GetDebtorPhones()).Returns(phones);

            var statuses = new List<PhoneStatus>();
            _statusServiceMock.Setup(m => m.GetStatuses()).Returns(statuses);
        }

        [TestMethod]
        public void Run_View_dialog_shown()
        {
            var presenter = new CheckFeesPresenter(_viewMock.Object, _feeServiceMock.Object, _statusServiceMock.Object);

            presenter.Run(_parentViewMock.Object);

            _viewMock.Verify(m => m.ShowDialog(_parentViewMock.Object), Times.Once);
        }

        [TestMethod]
        public void BindDataSources_Get_sources_from_service_and_bind_to_view()
        {
            _viewMock.SetupProperty(m => m.DebtorPhonesDataSource);
            _viewMock.SetupProperty(m => m.PhoneStatusesDataSource);
            var presenter = new CheckFeesPresenter(_viewMock.Object, _feeServiceMock.Object, _statusServiceMock.Object);

            Assert.IsNotNull(_viewMock.Object.DebtorPhonesDataSource);
            Assert.IsNotNull(_viewMock.Object.PhoneStatusesDataSource);
        }

        [TestMethod]
        public void OnUpdateDebts_Get_info_from_service_and_display_on_view()
        {
            _feeServiceMock.Setup(m => m.UpdateDebts()).Returns(new DebtCalculationResult());
            var presenter = new CheckFeesPresenter(_viewMock.Object, _feeServiceMock.Object, _statusServiceMock.Object);

            presenter.Run(_viewMock.Object);
            presenter.OnUpdateDebts(this, EventArgs.Empty);

            _feeServiceMock.Verify(m => m.UpdateDebts(), Times.Once);
            _viewMock.Verify(m => m.SetDebtsInfo(It.Is<string>(s => !string.IsNullOrEmpty(s))), Times.Once);
        }

        [TestMethod]
        public void OnCalculateFees_Get_info_from_service_and_display_on_view()
        {
            _feeServiceMock.Setup(m => m.MakeTariffPayments()).Returns(new FeeCalculationResult());
            var presenter = new CheckFeesPresenter(_viewMock.Object, _feeServiceMock.Object, _statusServiceMock.Object);

            presenter.Run(_viewMock.Object);
            presenter.OnMakeTariffPayments(this, EventArgs.Empty);

            _feeServiceMock.Verify(m => m.MakeTariffPayments(), Times.Once);
            _viewMock.Verify(m => m.SetFeesInfo(It.Is<string>(s => !string.IsNullOrEmpty(s))), Times.Once);
        }
    }
}
