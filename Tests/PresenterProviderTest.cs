using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using DB_CourseWork.Presentation;
using DB_CourseWork.UI;

namespace DB_CourseWork.Tests
{
    [TestClass]
    public class PresenterProviderTest
    {
        [TestMethod]
        public void Create_Parameterless_Presenter_returned_not_null()
        {
            var presenterMock = new Mock<IPresenter>();
            Type presenterType = presenterMock.Object.GetType();

            var serviceProviderMock = new Mock<IServiceProvider>();
            serviceProviderMock.Setup(m => m.GetService(presenterType)).Returns(presenterMock.Object);

            var factory = new PresenterProvider(serviceProviderMock.Object);

            IPresenter presenter = factory.Create(presenterType);

            Assert.IsNotNull(presenter);
            Assert.AreEqual(presenter, presenterMock.Object);
        }

        [TestMethod]
        public void Create_One_parameter_Presenter_returned_not_null()
        {
            var presenterMock = new Mock<IPresenter<object>>();
            Type presenterType = presenterMock.Object.GetType();

            var serviceProviderMock = new Mock<IServiceProvider>();
            serviceProviderMock.Setup(m => m.GetService(presenterType)).Returns(presenterMock.Object);

            var factory = new PresenterProvider(serviceProviderMock.Object);

            IPresenter<object> presenter = factory.Create<object>(presenterType);

            Assert.IsNotNull(presenter);
            Assert.AreEqual(presenter, presenterMock.Object);
        }

        [TestMethod]
        public void Create_Invalid_type_Exception_thrown()
        {
            Type invalidType = typeof(object);

            var presenterMock = new Mock<IPresenter>();
            Type presenterType = presenterMock.Object.GetType();

            var serviceProviderMock = new Mock<IServiceProvider>();
            serviceProviderMock.Setup(m => m.GetService(presenterType)).Returns(presenterMock.Object);

            var factory = new PresenterProvider(serviceProviderMock.Object);

            Assert.ThrowsException<InvalidOperationException>(() => factory.Create(invalidType));
        }
    }
}
