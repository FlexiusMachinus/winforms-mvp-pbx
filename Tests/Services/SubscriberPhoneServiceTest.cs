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
    public class SubscriberPhoneServiceTest
    {
        private Mock<PbxContext> _contextMock;
        private List<SubscriberPhone> _phones;
        private List<PhoneStatus> _statuses;

        [TestInitialize]
        public void InitializeTest()
        {
            _phones = new List<SubscriberPhone>()
            {
                new SubscriberPhone("100-00-01", null, "", ""),
                new SubscriberPhone("100-00-02", null, "", "")
            };

            _statuses = new List<PhoneStatus>()
            { 
                new PhoneStatus("Connected"),
                new PhoneStatus("Disconnected"),
                new PhoneStatus("Debt")
            };

            Mock<DbSet<SubscriberPhone>> phonesMock = _phones.AsQueryable().GetMockDbSet();
            Mock<DbSet<PhoneStatus>> statusesMock = _statuses.AsQueryable().GetMockDbSet();

            _contextMock = new Mock<PbxContext>();
            _contextMock.Setup(c => c.SubscriberPhones).Returns(phonesMock.Object);
            _contextMock.Setup(c => c.PhoneStatuses).Returns(statusesMock.Object);
        }

        [TestMethod]
        public void GetAllSubscriberPhones_Returns_all_phones()
        {
            var service = new SubscriberPhoneService(_contextMock.Object);

            List<SubscriberPhone> returnedPhones = service.GetAllSubscriberPhones().ToList();

            CollectionAssert.AreEquivalent(_phones.ToList(), returnedPhones);
        }

        [TestMethod]
        public void GetStatuses_Returns_all_stasuses()
        {
            var service = new FeeService(_contextMock.Object);

            List<PhoneStatus> returnedStatuses = service.GetStatuses().ToList();

            CollectionAssert.AreEquivalent(returnedStatuses, _statuses.ToList());
        }

        [TestMethod]
        public void FindSubscriberPhoneByNumber_Number_does_not_exist_returns_null()
        {
            var service = new SubscriberPhoneService(_contextMock.Object);

            SubscriberPhone returnedPhone = service.FindSubscriberPhoneByNumber("999-99-99");

            Assert.IsNull(returnedPhone);
        }

        [TestMethod]
        public void FindSubscriberPhoneByNumber_Number_exists_returns_phone()
        {
            SubscriberPhone testPhone = _phones.First();
            var service = new SubscriberPhoneService(_contextMock.Object);

            SubscriberPhone returnedPhone = service.FindSubscriberPhoneByNumber(testPhone.Number);

            Assert.IsNotNull(returnedPhone);
            Assert.AreEqual(returnedPhone, testPhone);
        }
    }
}
