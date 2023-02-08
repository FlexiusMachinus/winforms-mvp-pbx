using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using DB_CourseWork.Core;
using DB_CourseWork.Core.Data;
using System.Data.Entity;

namespace DB_CourseWork.Tests
{
    [TestClass]
    public class PaymentServiceTest
    {
        private Mock<PbxContext> _contextMock;
        private List<Payment> _payments;
        private List<SubscriberPhone> _phones;

        private PhoneStatus _connectedStatus;
        private PhoneStatus _disconnectedStatus;
        private PhoneStatus _debtStatus;

        [TestInitialize]
        public void InitializeTest()
        {
            _payments = new List<Payment>()
            {
                new Payment(null, 100, DateTime.Now) { Id = 1 },
                new Payment(null, 150, DateTime.Now) { Id = 2 },
                new Payment(null, 200, DateTime.Now) { Id = 3 }
            };

            _phones = new List<SubscriberPhone>()
            {
                new SubscriberPhone("100-00-01", null, "", ""),
                new SubscriberPhone("100-00-02", null, "", "")
            };

            _connectedStatus = new PhoneStatus("Connected");
            _disconnectedStatus = new PhoneStatus("Disconnected");
            _debtStatus = new PhoneStatus("Debt");
            var statuses = new List<PhoneStatus>() { _connectedStatus, _disconnectedStatus, _debtStatus };

            Mock<DbSet<SubscriberPhone>> phonesMock = _phones.AsQueryable().GetMockDbSet();
            Mock<DbSet<Payment>> paymentsMock = _payments.AsQueryable().GetMockDbSet();
            Mock<DbSet<PhoneStatus>> statusesMock = statuses.AsQueryable().GetMockDbSet();

            paymentsMock.Setup(p => p.Add(It.IsAny<Payment>())).Callback<Payment>(p =>
            {
                p.Id = _payments.Count + 1;
                _payments.Add(p);
            });

            paymentsMock.Setup(m => m.RemoveRange(It.IsAny<IEnumerable<Payment>>())).Callback<IEnumerable<Payment>>(payments =>
            {
                foreach (var payment in payments.ToList())
                {
                    _payments.Remove(payment);
                }
            });

            _contextMock = new Mock<PbxContext>();
            _contextMock.Setup(c => c.SubscriberPhones).Returns(phonesMock.Object);
            _contextMock.Setup(c => c.Payments).Returns(paymentsMock.Object);
            _contextMock.Setup(c => c.PhoneStatuses).Returns(statusesMock.Object);
        }

        [TestMethod]
        public void GetAllPayments_Returns_all_payments()
        {
            var service = new PaymentService(_contextMock.Object);

            List<Payment> returnedPayments = service.GetAllPayments().ToList();

            CollectionAssert.AreEquivalent(_payments.ToList(), returnedPayments);
        }

        [TestMethod]
        public void AddPayment_Null_payment_Exception_thrown()
        {
            var service = new PaymentService(_contextMock.Object);

            Assert.ThrowsException<ArgumentNullException>(() => service.AddPayment(null));
        }

        [TestMethod]
        public void AddPayment_Negative_amount_Exception_thrown()
        {
            var service = new PaymentService(_contextMock.Object);

            var newPayment = new Payment(_phones.First(), -300, DateTime.Now);

            Assert.ThrowsException<ArgumentException>(() => service.AddPayment(newPayment));
        }

        [TestMethod]
        public void AddPayment_Correct_amount_Adds_a_payment()
        {
            SubscriberPhone testPhone = _phones.First();
            var service = new PaymentService(_contextMock.Object);

            var newPayment = new Payment(testPhone, 300, DateTime.Now);
            service.AddPayment(newPayment);

            Payment payment = _payments.LastOrDefault();
            Assert.IsNotNull(payment);
        }

        [TestMethod]
        public void AddPayment_Correct_amount_Changes_balance()
        {
            SubscriberPhone testPhone = _phones.First();
            testPhone.AccountBalance = 0;

            var service = new PaymentService(_contextMock.Object);

            var newPayment = new Payment(testPhone, 300, DateTime.Now);
            service.AddPayment(newPayment);

            Assert.AreEqual(300, testPhone.AccountBalance);
        }

        [TestMethod]
        public void AddPayment_Phone_debt_status_Sets_connected_status()
        {
            SubscriberPhone debtorPhone = _phones.First();
            debtorPhone.AccountBalance = -1;
            debtorPhone.StatusHistory.Add(new StatusHistoryEntry(debtorPhone, _debtStatus, DateTime.Now, string.Empty));

            var service = new PaymentService(_contextMock.Object);

            var newPayment = new Payment(debtorPhone, -debtorPhone.AccountBalance, DateTime.Now);
            service.AddPayment(newPayment);

            Assert.AreEqual(_connectedStatus, debtorPhone.CurrentStatus);
        }

        [TestMethod]
        public void RemovePaymentsByIds_Empty_list_Removes_no_payments()
        {
            int initialPaymentCount = _payments.Count;
            var service = new PaymentService(_contextMock.Object);

            service.RemovePaymentsByIds(Array.Empty<int>());

            Assert.AreEqual(initialPaymentCount, _payments.Count);
        }

        [TestMethod]
        public void RemovePaymentsByIds_One_id_Removes_one_payment()
        {
            int initialPaymentCount = _payments.Count;
            var service = new PaymentService(_contextMock.Object);

            service.RemovePaymentsByIds(new[] { _payments.First().Id });

            Assert.AreEqual(initialPaymentCount - 1, _payments.Count);
        }

        [TestMethod]
        public void RemovePaymentsByIds_Multiple_ids_Removes_all_payments()
        {
            int initialPaymentCount = _payments.Count;
            var service = new PaymentService(_contextMock.Object);

            service.RemovePaymentsByIds(_payments.Select(p => p.Id));

            Assert.AreNotEqual(0, initialPaymentCount);
            Assert.AreEqual(0, _payments.Count);
        }
    }
}
