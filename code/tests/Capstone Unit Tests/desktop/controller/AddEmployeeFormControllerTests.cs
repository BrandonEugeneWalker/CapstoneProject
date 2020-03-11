using Capstone_Desktop.Controller;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Capstone_Unit_Tests.desktop.controller
{
    /// <summary>Tests the functionality of the AddEmployeeFormController.</summary>
    [TestClass]
    public class AddEmployeeFormControllerTests
    {
        #region Methods

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

        #endregion
    }
}