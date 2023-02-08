﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using DB_CourseWork.Core;
using DB_CourseWork.Core.Data;

namespace DB_CourseWork.Tests
{
    [TestClass]
    public class FeeServiceTest
    {
        private PhoneStatus _connectedStatus;
        private PhoneStatus _disconnectedStatus;
        private PhoneStatus _debtStatus;
        private IQueryable<PhoneStatus> _statuses;

        private Mock<PbxContext> _contextMock;

        [TestInitialize]
        public void InitializeTest()
        {
            _connectedStatus = new PhoneStatus("Connected");
            _disconnectedStatus = new PhoneStatus("Disconnected");
            _debtStatus = new PhoneStatus("Debt");
            _statuses = new List<PhoneStatus>() { _connectedStatus, _disconnectedStatus, _debtStatus }.AsQueryable();

            _contextMock = new Mock<PbxContext>();
            _contextMock.Setup(c => c.PhoneStatuses).Returns(_statuses.GetMockDbSet().Object);
        }

        [TestMethod]
        public void GetDebtorPhones_Returns_all_phones_with_debts()
        {
            var phones = new List<SubscriberPhone>()
            {
                new SubscriberPhone("100-00-01", null, "", ""),
                new SubscriberPhone("100-00-02", null, "", "") { AccountBalance = -1 }
            }.AsQueryable();

            _contextMock.Setup(c => c.SubscriberPhones).Returns(phones.GetMockDbSet().Object);
            var service = new FeeService(_contextMock.Object);

            IList<SubscriberPhone> returnedPhones = service.GetDebtorPhones();
            SubscriberPhone phone = returnedPhones.FirstOrDefault();

            Assert.AreEqual(returnedPhones.Count, 1);
            Assert.IsNotNull(phone);
            Assert.AreEqual(phone.Number, "100-00-02");
        }

        [TestMethod]
        public void GetStatuses_Returns_all_stasuses()
        {
            var phones = new List<SubscriberPhone>().AsQueryable();

            _contextMock.Setup(c => c.SubscriberPhones).Returns(phones.GetMockDbSet().Object);
            var service = new FeeService(_contextMock.Object);

            List<PhoneStatus> returnedStatuses = service.GetStatuses().ToList();

            CollectionAssert.AreEquivalent(returnedStatuses, _statuses.ToList());
        }

        [TestMethod]
        public void UpdateDebts_Changes_both_phones_statuses_and_calculates_debt_values()
        {
            var phone1 = new SubscriberPhone("100-00-01", null, "", "") { AccountBalance = 100 };
            var phone2 = new SubscriberPhone("100-00-02", null, "", "") { AccountBalance = -1 };
            var phones = new List<SubscriberPhone>() { phone1, phone2 }.AsQueryable();

            phone1.StatusHistory.Add(new StatusHistoryEntry(phone1, _debtStatus, DateTime.Now, ""));
            phone2.StatusHistory.Add(new StatusHistoryEntry(phone2, _connectedStatus, DateTime.Now, ""));

            _contextMock.Setup(c => c.SubscriberPhones).Returns(phones.GetMockDbSet().Object);
            var service = new FeeService(_contextMock.Object);

            DebtCalculationResult result = service.UpdateDebts();
            List<PhoneStatus> returnedStatuses = service.GetStatuses().ToList();

            Assert.AreEqual(phone1.CurrentStatus, _connectedStatus);
            Assert.AreEqual(phone2.CurrentStatus, _debtStatus);
            Assert.AreEqual(result.DebtsTotal, result.NewDebts);
            Assert.AreEqual(result.DebtsTotal, 1);
            Assert.AreEqual(result.DebtsPaid, 100);
        }

        [TestMethod]
        public void MakeTariffPayments_Changes_accounts_balance_and_calculates_total_fees()
        {
            const decimal initialBalance = 100;
            const decimal fee1 = 100;
            const decimal fee2 = 200;

            var tariff1 = new Tariff("", fee1);
            var tariff2 = new Tariff("", fee2);
            DateTime now = DateTime.Now;

            // Tariff1, connected
            var phone1 = new SubscriberPhone("100-00-01", null, "", "") { AccountBalance = initialBalance };
            phone1.StatusHistory.Add(new StatusHistoryEntry(phone1, _connectedStatus, now, ""));
            phone1.TariffHistory.Add(new TariffHistoryEntry(phone1, tariff1, now));

            // Tariff2, connected
            var phone2 = new SubscriberPhone("100-00-02", null, "", "") { AccountBalance = initialBalance };
            phone2.StatusHistory.Add(new StatusHistoryEntry(phone2, _connectedStatus, now, ""));
            phone2.TariffHistory.Add(new TariffHistoryEntry(phone2, tariff2, now));

            // Tariff2 (reduced rate), connected
            var phone3 = new SubscriberPhone("100-00-03", null, "", "") { AccountBalance = initialBalance, IsReducedRate = true };
            phone3.StatusHistory.Add(new StatusHistoryEntry(phone2, _connectedStatus, now, ""));
            phone3.TariffHistory.Add(new TariffHistoryEntry(phone3, tariff2, now));

            // Disconnected
            var phone4 = new SubscriberPhone("100-00-04", null, "", "") { AccountBalance = initialBalance };
            phone4.StatusHistory.Add(new StatusHistoryEntry(phone2, _disconnectedStatus, now, ""));

            // Disconnected (debt)
            var phone5 = new SubscriberPhone("100-00-05", null, "", "") { AccountBalance = initialBalance };
            phone5.StatusHistory.Add(new StatusHistoryEntry(phone2, _debtStatus, now, ""));

            var phones = new List<SubscriberPhone>() { phone1, phone2, phone3, phone4, phone5 }.AsQueryable();
            _contextMock.Setup(c => c.SubscriberPhones).Returns(phones.GetMockDbSet().Object);

            var service = new FeeService(_contextMock.Object);

            FeeCalculationResult result = service.MakeTariffPayments();

            int connectedCount = phones.Count(p => p.CurrentStatus == _connectedStatus);
            decimal expectedFees = fee1 + fee2 + fee2 / 2;
            Assert.AreEqual(connectedCount, result.FeeCount);
            Assert.AreEqual(expectedFees, result.FeesTotal);
            Assert.AreEqual(initialBalance - fee1, phone1.AccountBalance);
            Assert.AreEqual(initialBalance - fee2, phone2.AccountBalance);
            Assert.AreEqual(initialBalance - fee2 / 2, phone3.AccountBalance);
            Assert.AreEqual(initialBalance, phone4.AccountBalance);
            Assert.AreEqual(initialBalance, phone5.AccountBalance);
        }
    }
}
