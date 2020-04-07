using System;
using Capstone_Desktop.Controller;
using Capstone_Desktop.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Capstone_Unit_Tests.desktop.controller
{
    /// <summary>Tests the functionality of the AddEmployeeFormController.</summary>
    [TestClass]
    public class AddEmployeeFormControllerTests
    {
        #region Methods

        [TestMethod]
        public void TestOverloadedConstructorNull()
        {
            Assert.ThrowsException<ArgumentNullException>(() => new AddEmployeeFormController(null));
        }

        [TestMethod]
        public void TestOverloadedConstructorSunnyDay()
        {
            var contextHandlerMock = new Mock<IDbContextHandler>();
            var testController = new AddEmployeeFormController(contextHandlerMock.Object);
            Assert.IsNotNull(testController);
        }

        [TestMethod]
        public void TestDefaultConstructorSunnyDay()
        {
            var testController = new AddEmployeeFormController();
            Assert.IsNotNull(testController);
        }

        [TestMethod]
        public void TestPasswordValiditySunnyDay()
        {
            var testController = new AddEmployeeFormController();
            var password = "P@ssword12@PP";
            var results = testController.IsValidPassword(password);
            Assert.IsTrue(results);
        }

        [TestMethod]
        public void TestPasswordValidityNullPassword()
        {
            var testController = new AddEmployeeFormController();
            var results = testController.IsValidPassword(null);
            Assert.IsFalse(results);
        }

        [TestMethod]
        public void TestPasswordValidityEmptyPassword()
        {
            var testController = new AddEmployeeFormController();
            var results = testController.IsValidPassword("");
            Assert.IsFalse(results);
        }

        [TestMethod]
        public void TestPasswordValidityNoCapitalsPassword()
        {
            var testController = new AddEmployeeFormController();
            var results = testController.IsValidPassword("p@ssword12");
            Assert.IsFalse(results);
        }

        [TestMethod]
        public void TestPasswordValidityNoLowerCasePassword()
        {
            var testController = new AddEmployeeFormController();
            var results = testController.IsValidPassword("P@SSWORD12");
            Assert.IsFalse(results);
        }

        [TestMethod]
        public void TestPasswordValidityNoNumbersPassword()
        {
            var testController = new AddEmployeeFormController();
            var results = testController.IsValidPassword("P@ssword");
            Assert.IsFalse(results);
        }

        [TestMethod]
        public void TestPasswordValidityNoSymbolsPassword()
        {
            var testController = new AddEmployeeFormController();
            var results = testController.IsValidPassword("Password12");
            Assert.IsFalse(results);
        }

        [TestMethod]
        public void TestPasswordValidityTooShortPasswordBoundary()
        {
            var testController = new AddEmployeeFormController();
            var results = testController.IsValidPassword("P@ss1");
            Assert.IsFalse(results);
        }

        [TestMethod]
        public void TestPasswordValidityTooShortPasswordBeyondBoundary()
        {
            var testController = new AddEmployeeFormController();
            var results = testController.IsValidPassword("P@s1");
            Assert.IsFalse(results);
        }

        [TestMethod]
        public void TestPasswordValidityTooLongPasswordBoundary()
        {
            var testController = new AddEmployeeFormController();
            var results = testController.IsValidPassword("P@ssword1Password");
            Assert.IsFalse(results);
        }

        [TestMethod]
        public void TestPasswordValidityTooLongPasswordBeyondBoundary()
        {
            var testController = new AddEmployeeFormController();
            var results = testController.IsValidPassword("P@ssword1PasswordPassword");
            Assert.IsFalse(results);
        }

        [TestMethod]
        public void TestPasswordValidityPasswordLengthUpperBoundary()
        {
            var testController = new AddEmployeeFormController();
            var results = testController.IsValidPassword("P@ssword1Passwor");
            Assert.IsTrue(results);
        }

        [TestMethod]
        public void TestPasswordValidityPasswordLengthLowerBoundary()
        {
            var testController = new AddEmployeeFormController();
            var results = testController.IsValidPassword("P@ssw1");
            Assert.IsTrue(results);
        }

        [TestMethod]
        public void TestPasswordValidityPasswordWithMultipleOfEach()
        {
            var testController = new AddEmployeeFormController();
            var results = testController.IsValidPassword("P@!ssW0rd98");
            Assert.IsTrue(results);
        }

        [TestMethod]
        public void TestPasswordValidityPasswordWithSpace()
        {
            var testController = new AddEmployeeFormController();
            var results = testController.IsValidPassword("P@!ss W0rd98");
            Assert.IsTrue(results);
        }

        [TestMethod]
        public void TestAddEmployeeNullPassword()
        {
            var testController = new AddEmployeeFormController();
            Assert.ThrowsException<ArgumentNullException>(() => testController.AddEmployee(null, true, "name"));
        }

        [TestMethod]
        public void TestAddEmployeeEmptyPassword()
        {
            var testController = new AddEmployeeFormController();
            Assert.ThrowsException<ArgumentNullException>(() => testController.AddEmployee("", true, "name"));
        }

        [TestMethod]
        public void TestAddEmployeeNullName()
        {
            var testController = new AddEmployeeFormController();
            Assert.ThrowsException<ArgumentNullException>(() => testController.AddEmployee("password", true, null));
        }

        [TestMethod]
        public void TestAddEmployeeEmptyName()
        {
            var testController = new AddEmployeeFormController();
            Assert.ThrowsException<ArgumentNullException>(() => testController.AddEmployee("password", true, ""));
        }

        [TestMethod]
        public void TestAddEmployeeSunnyDay()
        {
            var mockedContext = new Mock<IDbContextHandler>();
            var testController = new AddEmployeeFormController(mockedContext.Object);
            testController.AddEmployee("password", true, "Test Employee");
        }

        #endregion
    }
}