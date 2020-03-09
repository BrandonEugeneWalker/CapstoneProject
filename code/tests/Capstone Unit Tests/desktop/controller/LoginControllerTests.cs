using System;
using System.Linq;
using Capstone_Database.Model;
using Capstone_Desktop.Controller;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Capstone_Unit_Tests.desktop.controller
{
    [TestClass]
    public class LoginControllerTests
    {
        [TestMethod]
        public void TestGetEmployeeByUsernameAndPasswordNullPassword()
        {
            var capstoneDbContextMock = new Mock<OnlineEntities>();
            LoginController loginController = new LoginController();

            Assert.ThrowsException<ArgumentNullException>(() =>
                loginController.GetEmployeeByIdAndPassword(1, null, capstoneDbContextMock.Object));
        }

        [TestMethod]
        public void TestGetEmployeeByUsernameAndPasswordEmptyPassword()
        {
            var capstoneDbContextMock = new Mock<OnlineEntities>();
            LoginController loginController = new LoginController();

            Assert.ThrowsException<ArgumentNullException>(() =>
                loginController.GetEmployeeByIdAndPassword(1, "", capstoneDbContextMock.Object));
        }

        [TestMethod]
        public void TestGetEmployeeByUsernameAndPasswordNullDbContext()
        {
            LoginController loginController = new LoginController();

            Assert.ThrowsException<ArgumentNullException>(() =>
                loginController.GetEmployeeByIdAndPassword(1, "hello", null));
        }

        [TestMethod]
        public void TestGetEmployeeByUsernameAndPasswordZeroId()
        {
            var capstoneDbContextMock = new Mock<OnlineEntities>();
            LoginController loginController = new LoginController();

            Assert.ThrowsException<ArgumentOutOfRangeException>(() =>
                loginController.GetEmployeeByIdAndPassword(0, "hello", capstoneDbContextMock.Object));
        }

        [TestMethod]
        public void TestGetEmployeeByUsernameAndPasswordNegativeId()
        {
            var capstoneDbContextMock = new Mock<OnlineEntities>();
            LoginController loginController = new LoginController();

            Assert.ThrowsException<ArgumentOutOfRangeException>(() =>
                loginController.GetEmployeeByIdAndPassword(-1, "hello", capstoneDbContextMock.Object));
        }

        [TestMethod]
        public void TestGetEmployeeByUsernameAndPasswordSunnyDay()
        {
            var capstoneDbContextMock = new Mock<OnlineEntities>();

            Employee testEmployee = new Employee {
                employeeId = 1234,
                isManager = false,
                ItemRentals = null,
                ItemRentals1 = null,
                name = "Brandon Walker",
                password = "password"
            };

            capstoneDbContextMock.Setup(x => x.selectEmployeeByIdAndPassword(1, "password").First()).Returns(testEmployee);
            LoginController loginController = new LoginController();

            var loginResults = loginController.GetEmployeeByIdAndPassword(1, "password", capstoneDbContextMock.Object);

            Assert.IsTrue(loginResults.employeeId == 1);
            Assert.IsTrue(loginResults.name.Equals("Brandon Walker"));
            Assert.IsTrue(loginResults.password.Equals("password"));
            Assert.IsTrue(loginResults.isManager == true);
        }
    }
}