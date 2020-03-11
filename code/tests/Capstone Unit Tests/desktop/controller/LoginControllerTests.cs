using System;
using Capstone_Database.Model;
using Capstone_Desktop.Controller;
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
        public void TestGetEmployeeByUsernameAndPasswordNullPassword()
        {
            var capstoneDbContextMock = new Mock<OnlineEntities>();
            var loginController = new LoginController();

            Assert.ThrowsException<ArgumentNullException>(() =>
                loginController.GetEmployeeByIdAndPassword(1, null, capstoneDbContextMock.Object));
        }

        [TestMethod]
        public void TestGetEmployeeByUsernameAndPasswordEmptyPassword()
        {
            var capstoneDbContextMock = new Mock<OnlineEntities>();
            var loginController = new LoginController();

            Assert.ThrowsException<ArgumentNullException>(() =>
                loginController.GetEmployeeByIdAndPassword(1, "", capstoneDbContextMock.Object));
        }

        [TestMethod]
        public void TestGetEmployeeByUsernameAndPasswordNullDbContext()
        {
            var loginController = new LoginController();

            Assert.ThrowsException<ArgumentNullException>(() =>
                loginController.GetEmployeeByIdAndPassword(1, "hello", null));
        }

        [TestMethod]
        public void TestGetEmployeeByUsernameAndPasswordZeroId()
        {
            var capstoneDbContextMock = new Mock<OnlineEntities>();
            var loginController = new LoginController();

            Assert.ThrowsException<ArgumentOutOfRangeException>(() =>
                loginController.GetEmployeeByIdAndPassword(0, "hello", capstoneDbContextMock.Object));
        }

        [TestMethod]
        public void TestGetEmployeeByUsernameAndPasswordNegativeId()
        {
            var capstoneDbContextMock = new Mock<OnlineEntities>();
            var loginController = new LoginController();

            Assert.ThrowsException<ArgumentOutOfRangeException>(() =>
                loginController.GetEmployeeByIdAndPassword(-1, "hello", capstoneDbContextMock.Object));
        }

        #endregion
    }
}