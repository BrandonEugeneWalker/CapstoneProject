using Capstone_Desktop.Controller;
using NUnit.Framework;

namespace Capstone_Desktop_Tests.Model_Tests
{
    public class LoginControllerTests
    {
        #region Methods

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestTryToLoginSunnyDay()
        {
            var testLoginFormController = new LoginFormController();
            var results = testLoginFormController.TryToLogin(1234, "password");
            Assert.True(results);
            Assert.AreEqual("Brandon Walker", testLoginFormController.CurrentEmployee.name);
            Assert.AreEqual(1234, testLoginFormController.CurrentEmployee.employeeId);
            Assert.True(testLoginFormController.CurrentEmployee.isManager);
        }

        [Test]
        public void TestTryToLoginNotManager()
        {
            var testLoginFormController = new LoginFormController();
            var results = testLoginFormController.TryToLogin(4321, "qwerty");
            Assert.False(results);
        }

        [Test]
        public void TestTryToLoginIdOutOfRangeBoundary()
        {
            var testLoginFormController = new LoginFormController();
            var results = testLoginFormController.TryToLogin(0, "qwerty");
            Assert.False(results);
        }

        [Test]
        public void TestTryToLoginIdOutOfRangePastBoundary()
        {
            var testLoginFormController = new LoginFormController();
            var results = testLoginFormController.TryToLogin(-100, "qwerty");
            Assert.False(results);
        }

        [Test]
        public void TestTryToLoginPasswordNull()
        {
            var testLoginFormController = new LoginFormController();
            var results = testLoginFormController.TryToLogin(4321, null);
            Assert.False(results);
        }

        [Test]
        public void TestTryToLoginPasswordEmpty()
        {
            var testLoginFormController = new LoginFormController();
            var results = testLoginFormController.TryToLogin(4321, "");
            Assert.False(results);
        }

        #endregion
    }
}