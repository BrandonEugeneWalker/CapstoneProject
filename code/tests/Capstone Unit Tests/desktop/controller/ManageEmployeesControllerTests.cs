using System;
using Capstone_Database.Model;
using Capstone_Desktop.Controller;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Capstone_Unit_Tests.desktop.controller
{
    /// <summary>Tests the functionality of the ManageEmployeesController.</summary>
    [TestClass]
    public class ManageEmployeesControllerTests
    {
        #region Methods

        [TestMethod]
        public void TestRemoveEmployeeFromDatabaseNullEmployee()
        {
            var capstoneDbContextMock = new Mock<OnlineEntities>();
            var manageEmployeeController = new ManageEmployeeController();

            Assert.ThrowsException<ArgumentNullException>(() =>
                manageEmployeeController.RemoveEmployeeFromDatabase(null, capstoneDbContextMock.Object));
        }

        [TestMethod]
        public void TestRemoveEmployeeFromDatabaseNullDatabase()
        {
            var manageEmployeeController = new ManageEmployeeController();

            Assert.ThrowsException<ArgumentNullException>(() =>
                manageEmployeeController.RemoveEmployeeFromDatabase(new Employee(), null));
        }

        [TestMethod]
        public void TestGetEmployeesNullDatabase()
        {
            var manageEmployeeController = new ManageEmployeeController();

            Assert.ThrowsException<ArgumentNullException>(() =>
                manageEmployeeController.GetEmployees(null));
        }

        #endregion
    }
}