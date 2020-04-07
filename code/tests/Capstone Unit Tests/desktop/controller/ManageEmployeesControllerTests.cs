using System;
using System.ComponentModel;
using Capstone_Database.Model;
using Capstone_Desktop.Controller;
using Capstone_Desktop.Model;
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
        public void TestDefaultConstructorSunnyDay()
        {
            var testController = new ManageEmployeeController();
            Assert.IsNotNull(testController);
        }

        [TestMethod]
        public void TestOverloadedConstructorNull()
        {
            Assert.ThrowsException<ArgumentNullException>(() => new ManageEmployeeController(null));
        }

        [TestMethod]
        public void TestOverloadedConstructorSunnyDay()
        {
            var testController = new ManageEmployeeController(new CapstoneDbContextHandler());
            Assert.IsNotNull(testController);
        }

        [TestMethod]
        public void TestRemoveEmployeeFromDatabaseNullEmployee()
        {
            var manageEmployeeController = new ManageEmployeeController();

            Assert.ThrowsException<ArgumentNullException>(() =>
                manageEmployeeController.RemoveEmployeeFromDatabase(null));
        }

        [TestMethod]
        public void TestRemoveEmployeeFromDatabaseSunnyDay()
        {
            var employeeToRemove = new Employee();
            var contextHandlerMock = new Mock<IDbContextHandler>();
            contextHandlerMock.Setup(x => x.RemoveEmployee(employeeToRemove));
            var manageEmployeeController = new ManageEmployeeController(contextHandlerMock.Object);
            manageEmployeeController.RemoveEmployeeFromDatabase(employeeToRemove);
        }

        [TestMethod]
        public void TestGetEmployeesSunnyDay()
        {
            var employeeToRemove = new Employee();
            var contextHandlerMock = new Mock<IDbContextHandler>();
            contextHandlerMock.Setup(x => x.GetAllEmployees()).Returns(new BindingList<Employee>());
            var manageEmployeeController = new ManageEmployeeController(contextHandlerMock.Object);
            var results = manageEmployeeController.GetEmployees();
            Assert.IsNotNull(results);
            Assert.IsTrue(results is BindingList<Employee>);
        }

        #endregion
    }
}