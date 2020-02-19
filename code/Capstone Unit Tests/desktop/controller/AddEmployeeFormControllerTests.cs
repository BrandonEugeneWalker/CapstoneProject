using System;
using Capstone_Desktop.Controller;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Capstone_Unit_Tests.desktop.controller
{
    [TestClass]
    public class AddEmployeeFormControllerTests
    {
        [TestMethod]
        public void TestPasswordValiditySunnyDay()
        {
            AddEmployeeFormController testController = new AddEmployeeFormController();
            var password = "P@ssword12@PP";
            var results = testController.IsValidPassword(password);
            Assert.IsTrue(results);
        }

        [TestMethod]
        public void TestPasswordValidityNullPassword()
        {
            AddEmployeeFormController testController = new AddEmployeeFormController();
            var results = testController.IsValidPassword(null);
            Assert.IsFalse(results);
        }

        [TestMethod]
        public void TestPasswordValidityEmptyPassword()
        {
            AddEmployeeFormController testController = new AddEmployeeFormController();
            var results = testController.IsValidPassword("");
            Assert.IsFalse(results);
        }

        [TestMethod]
        public void TestPasswordValidityNoCapitalsPassword()
        {
            AddEmployeeFormController testController = new AddEmployeeFormController();
            var results = testController.IsValidPassword("p@ssword12");
            Assert.IsFalse(results);
        }

        [TestMethod]
        public void TestPasswordValidityNoLowerCasePassword()
        {
            AddEmployeeFormController testController = new AddEmployeeFormController();
            var results = testController.IsValidPassword("P@SSWORD12");
            Assert.IsFalse(results);
        }

        [TestMethod]
        public void TestPasswordValidityNoNumbersPassword()
        {
            AddEmployeeFormController testController = new AddEmployeeFormController();
            var results = testController.IsValidPassword("P@ssword");
            Assert.IsFalse(results);
        }

        [TestMethod]
        public void TestPasswordValidityNoSymbolsPassword()
        {
            AddEmployeeFormController testController = new AddEmployeeFormController();
            var results = testController.IsValidPassword("Password12");
            Assert.IsFalse(results);
        }

        [TestMethod]
        public void TestPasswordValidityTooShortPasswordBoundary()
        {
            AddEmployeeFormController testController = new AddEmployeeFormController();
            var results = testController.IsValidPassword("P@ss1");
            Assert.IsFalse(results);
        }

        [TestMethod]
        public void TestPasswordValidityTooShortPasswordBeyondBoundary()
        {
            AddEmployeeFormController testController = new AddEmployeeFormController();
            var results = testController.IsValidPassword("P@s1");
            Assert.IsFalse(results);
        }

        [TestMethod]
        public void TestPasswordValidityTooLongPasswordBoundary()
        {
            AddEmployeeFormController testController = new AddEmployeeFormController();
            var results = testController.IsValidPassword("P@ssword1Password");
            Assert.IsFalse(results);
        }

        [TestMethod]
        public void TestPasswordValidityTooLongPasswordBeyondBoundary()
        {
            AddEmployeeFormController testController = new AddEmployeeFormController();
            var results = testController.IsValidPassword("P@ssword1PasswordPassword");
            Assert.IsFalse(results);
        }

        [TestMethod]
        public void TestPasswordValidityPasswordLengthUpperBoundary()
        {
            AddEmployeeFormController testController = new AddEmployeeFormController();
            var results = testController.IsValidPassword("P@ssword1Passwor");
            Assert.IsTrue(results);
        }

        [TestMethod]
        public void TestPasswordValidityPasswordLengthLowerBoundary()
        {
            AddEmployeeFormController testController = new AddEmployeeFormController();
            var results = testController.IsValidPassword("P@ssw1");
            Assert.IsTrue(results);
        }

        [TestMethod]
        public void TestPasswordValidityPasswordWithMultipleOfEach()
        {
            AddEmployeeFormController testController = new AddEmployeeFormController();
            var results = testController.IsValidPassword("P@!ssW0rd98");
            Assert.IsTrue(results);
        }

        [TestMethod]
        public void TestPasswordValidityPasswordWithSpace()
        {
            AddEmployeeFormController testController = new AddEmployeeFormController();
            var results = testController.IsValidPassword("P@!ss W0rd98");
            Assert.IsTrue(results);
        }
    }
}
