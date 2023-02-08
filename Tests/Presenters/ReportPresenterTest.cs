using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using DB_CourseWork.Core;
using DB_CourseWork.Presentation;

namespace DB_CourseWork.Tests
{
    [TestClass]
    public class ReportPresenterTest
    {
        private Mock<IReportView> _viewMock;
        private Mock<IReportService> _serviceMock;

        [TestInitialize]
        public void InitializeTest()
        {
            _viewMock = new Mock<IReportView>();
            _serviceMock = new Mock<IReportService>();
        }

        [TestMethod]
        public void Run_View_shown()
        {
            var presenter = new ReportPresenter(_viewMock.Object, _serviceMock.Object);

            presenter.Run();

            _viewMock.Verify(m => m.Show(), Times.Once);
        }

        [TestMethod]
        public void OnSelectDate_View_date_range_updated()
        {
            DateTime now = DateTime.Now;

            _viewMock.Setup(m => m.SelectedDate).Returns(now);
            var presenter = new ReportPresenter(_viewMock.Object, _serviceMock.Object);

            presenter.Run();
            presenter.OnSelectDate(this, EventArgs.Empty);

            _viewMock.Verify(m => m.SetDateRange(
                It.Is<DateTime>(dt => dt < now),
                It.Is<DateTime>(dt => dt > now))
            );
        }

        [TestMethod]
        public void OnCreateReport_View_date_rafnge_updated()
        {
            var amountByTariffs = new Dictionary<Tariff, decimal>()
            {
                { new Tariff("ABC", 0), 100 },
                { new Tariff("XYZ", 0), 200 }
            };

            _serviceMock.Setup(m => m.CalculateDebtsByTariffs(It.IsAny<DateTime>(), It.IsAny<DateTime>())).Returns(amountByTariffs).Verifiable();
            _serviceMock.Setup(m => m.CalculatePaymentsByTariffs(It.IsAny<DateTime>(), It.IsAny<DateTime>())).Returns(amountByTariffs).Verifiable();
            _viewMock.Setup(m => m.SelectedDate).Returns(DateTime.Now);
            var presenter = new ReportPresenter(_viewMock.Object, _serviceMock.Object);

            presenter.Run();
            presenter.OnCreateReport(this, EventArgs.Empty);

            _serviceMock.Verify();
            _viewMock.Verify(m => m.SetDebtsInfo(300, It.Is<string>(s => !string.IsNullOrEmpty(s))));
            _viewMock.Verify(m => m.SetPaymentsInfo(300, It.Is<string>(s => !string.IsNullOrEmpty(s))));
        }
    }
}
