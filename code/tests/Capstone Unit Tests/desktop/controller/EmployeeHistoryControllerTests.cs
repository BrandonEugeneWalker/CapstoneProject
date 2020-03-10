using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using Capstone_Database.Model;
using Capstone_Desktop.Controller;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Capstone_Unit_Tests.desktop.controller
{
    /// <summary>Tests the functionality of the EmployeeHistoryController.</summary>
    [TestClass]
    public class EmployeeHistoryControllerTests
    {
        #region Methods

        [TestMethod]
        public void TestGetEmployeeHistoryEmployeeNull()
        {
            var capstoneDbContextMock = new Mock<OnlineEntities>();
            var employeeHistoryController = new EmployeeHistoryController();

            Assert.ThrowsException<ArgumentNullException>(() =>
                employeeHistoryController.GetEmployeeHistory(null, capstoneDbContextMock.Object));
        }

        [TestMethod]
        public void TestGetEmployeeHistoryDbContextNull()
        {
            var employeeMock = new Mock<Employee>();
            var employeeHistoryController = new EmployeeHistoryController();

            Assert.ThrowsException<ArgumentNullException>(() =>
                employeeHistoryController.GetEmployeeHistory(employeeMock.Object, null));
        }

        [TestMethod]
        public void TestBuildEmployeeDescriptionNull()
        {
            var employeeHistoryController = new EmployeeHistoryController();
            Assert.ThrowsException<ArgumentNullException>(
                () => employeeHistoryController.BuildEmployeeDescription(null));
        }

        [TestMethod]
        public void TestBuildEmployeeDescriptionSunnyDay()
        {
            Employee testEmployee = new Employee {
                name = "Brandon Walker",
                employeeId = 1234
            };
            EmployeeHistoryController employeeHistoryController = new EmployeeHistoryController();
            var results = employeeHistoryController.BuildEmployeeDescription(testEmployee);
            var expected = @" Name: Brandon Walker ID: 1234";

            Assert.IsTrue(results.Equals(expected));
        }

        #endregion
    }
}