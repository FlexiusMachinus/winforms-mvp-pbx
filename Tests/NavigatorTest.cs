using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using DB_CourseWork.Presentation;

namespace DB_CourseWork.Tests
{
    [TestClass]
    public class NavigatorTest
    {
        [TestMethod]
        public void Run_Parameterless_Presenter_run_called()
        {
            var presenterMock = new Mock<IPresenter>();
            presenterMock.Setup(m => m.Run()).Verifiable();
            Type presenterType = presenterMock.Object.GetType();

            var factoryMock = new Mock<IPresenterFactory>();
            factoryMock.Setup(m => m.Create(presenterType)).Returns(presenterMock.Object);

            var navigator = new Navigator(factoryMock.Object);

            navigator.Run(presenterType);

            presenterMock.Verify();
        }

        [TestMethod]
        public void Run_One_parameter_Presenter_run_called()
        {
            var presenterMock = new Mock<IPresenter<object>>();
            presenterMock.Setup(m => m.Run(null)).Verifiable();
            Type presenterType = presenterMock.Object.GetType();

            var factoryMock = new Mock<IPresenterFactory>();
            factoryMock.Setup(m => m.Create<object>(presenterType)).Returns(presenterMock.Object);

            var navigator = new Navigator(factoryMock.Object);

            navigator.Run<object>(presenterType, null);

            presenterMock.Verify();
        }

        [TestMethod]
        public void Run_Invalid_type_Exception_thrown()
        {
            Type invalidType = typeof(object);

            var presenterMock = new Mock<IPresenter>();
            var factoryMock = new Mock<IPresenterFactory>();
            var navigator = new Navigator(factoryMock.Object);

            Assert.ThrowsException<ArgumentException>(() => navigator.Run(invalidType));
        }
    }
}
