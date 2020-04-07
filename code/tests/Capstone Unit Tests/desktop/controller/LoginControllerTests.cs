using System;
using Capstone_Database.Model;
using Capstone_Desktop.Controller;
using Capstone_Desktop.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Capstone_Unit_Tests.desktop.controller
{
    /// <summary>Tests the functionality of the LoginController.</summary>
    [TestClass]
    public class LoginControllerTests
    {
        #region Methods

        [TestMethod]
        public void TestDefaultConstructorSunnyDay()
        {
            var testController = new LoginController();
            Assert.IsNotNull(testController);
        }

        [TestMethod]
        public void TestOverloadedConstructorNull()
        {
            Assert.ThrowsException<ArgumentNullException>(() => new LoginController(null));
        }

        [TestMethod]
        public void TestOverloadedConstructorSunnyDay()
        {
            var testController = new LoginController(new CapstoneDbContextHandler());
            Assert.IsNotNull(testController);
        }

        [TestMethod]
        public void TestGetEmployeeByUsernameAndPasswordNullPassword()
        {
            var loginController = new LoginController();

            Assert.ThrowsException<ArgumentNullException>(() =>
                loginController.GetEmployeeByIdAndPassword(1, null));
        }

        [TestMethod]
        public void TestGetEmployeeByUsernameAndPasswordEmptyPassword()
        {
            var loginController = new LoginController();

            Assert.ThrowsException<ArgumentNullException>(() =>
                loginController.GetEmployeeByIdAndPassword(1, ""));
        }

        [TestMethod]
        public void TestGetEmployeeByUsernameAndPasswordZeroId()
        {
            var loginController = new LoginController();

            Assert.ThrowsException<ArgumentOutOfRangeException>(() =>
                loginController.GetEmployeeByIdAndPassword(0, "hello"));
        }

        [TestMethod]
        public void TestGetEmployeeByUsernameAndPasswordNegativeId()
        {
            var loginController = new LoginController();

            Assert.ThrowsException<ArgumentOutOfRangeException>(() =>
                loginController.GetEmployeeByIdAndPassword(-1, "hello"));
        }

        [TestMethod]
        public void TestGetEmployeeByUsernameAndPasswordSunnyDay()
        {
            var contextHandlerMock = new Mock<IDbContextHandler>();
            contextHandlerMock.Setup(x => x.GetEmployeeByIdAndPassword(1234, "password")).Returns(new Employee());
            var testController = new LoginController(contextHandlerMock.Object);
            var results = testController.GetEmployeeByIdAndPassword(1234, "password");
            Assert.IsNotNull(results);
            Assert.IsTrue(results is Employee);
        }

        #endregion
    }
}