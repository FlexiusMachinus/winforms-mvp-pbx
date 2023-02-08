using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using DB_CourseWork.Core;
using DB_CourseWork.Core.Data;

namespace DB_CourseWork.Tests
{
    [TestClass]
    public class ReportServiceTest
    {
        private Mock<PbxContext> _contextMock;

        [TestInitialize]
        public void InitializeTest()
        {
            DateTime now = DateTime.Now;

            var phone1 = new SubscriberPhone("123-00-01", null, "", "") { AccountBalance = -100 };
            var phone2 = new SubscriberPhone("123-00-02", null, "", "") { AccountBalance = -100 };
            var phones = new List<SubscriberPhone>() { phone1, phone2 }.AsQueryable();

            var payment1 = new Payment(phone1, 100, now);
            var payment2 = new Payment(phone2, 100, now);
            var payments = new List<Payment>() { payment1, payment2 }.AsQueryable();

            var status = new PhoneStatus("Test Status");
            phone1.StatusHistory.Add(new StatusHistoryEntry(phone1, status, now, ""));
            phone2.StatusHistory.Add(new StatusHistoryEntry(phone2, status, now, ""));

            var tariff1 = new Tariff("ABC", 0);
            var tariff2 = new Tariff("XYZ", 0);
            phone1.TariffHistory.Add(new TariffHistoryEntry(phone1, tariff1, now));
            phone2.TariffHistory.Add(new TariffHistoryEntry(phone2, tariff2, now));

            _contextMock = new Mock<PbxContext>();
            _contextMock.Setup(c => c.SubscriberPhones).Returns(phones.GetMockDbSet().Object);
            _contextMock.Setup(c => c.Payments).Returns(payments.GetMockDbSet().Object);
        }

        [TestMethod]
        public void CalculatePaymentsByTariffs_Groups_two_payments_by_tariffs()
        {
            var service = new ReportService(_contextMock.Object);

            IDictionary<Tariff, decimal> result = service.CalculatePaymentsByTariffs(DateTime.MinValue, DateTime.MaxValue);
            List<string> names = result.Keys.Select(t => t.Name).ToList();

            List<string> expectedNames = new[] { "ABC", "XYZ" }.OrderBy(n => n).ToList();
            CollectionAssert.AreEquivalent(names, expectedNames);

            foreach (decimal paymentAmount in result.Values)
            {
                Assert.AreEqual(paymentAmount, 100);
            }
        }

        [TestMethod]
        public void CalculateDebtsByTariffs_Groups_two_debts_by_tariffs()
        {
            var service = new ReportService(_contextMock.Object);

            IDictionary<Tariff, decimal> result = service.CalculateDebtsByTariffs(DateTime.MinValue, DateTime.MaxValue);
            List<string> names = result.Keys.Select(t => t.Name).ToList();

            List<string> expectedNames = new[] { "ABC", "XYZ" }.OrderBy(n => n).ToList();
            CollectionAssert.AreEquivalent(names, expectedNames);

            foreach (decimal debtAmount in result.Values)
            {
                Assert.AreEqual(debtAmount, 100);
            }
        }
    }
}
