using System;
using System.Collections.Generic;
using Capstone_Database.Model;
using Capstone_Desktop.Controller;
using Capstone_Desktop.Model;
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
        public void TestOverloadedConstructorNull()
        {
            Assert.ThrowsException<ArgumentNullException>(() => new EmployeeHistoryController(null));
        }

        [TestMethod]
        public void TestOverloadedConstructorSunnyDay()
        {
            var contextHandlerMock = new Mock<IDbContextHandler>();
            var employeeHistoryController = new EmployeeHistoryController(contextHandlerMock.Object);
            Assert.IsNotNull(employeeHistoryController);
        }

        [TestMethod]
        public void TestDefaultConstructorSunnyDay()
        {
            var employeeHistoryController = new EmployeeHistoryController();
            Assert.IsNotNull(employeeHistoryController);
        }

        [TestMethod]
        public void TestGetEmployeeHistoryEmployeeNull()
        {
            var employeeHistoryController = new EmployeeHistoryController();

            Assert.ThrowsException<ArgumentNullException>(() =>
                employeeHistoryController.GetEmployeeHistory(null));
        }

        [TestMethod]
        public void TestGetEmployeeHistorySunnyDay()
        {
            var testEmployee = new Employee();
            var contextHandlerMock = new Mock<IDbContextHandler>();
            contextHandlerMock.Setup(x => x.GetDetailedEmployeeHistory(testEmployee))
                              .Returns(new List<DetailedRentalView>());
            var employeeHistoryController = new EmployeeHistoryController(contextHandlerMock.Object);
            var results = employeeHistoryController.GetEmployeeHistory(testEmployee);
            Assert.IsNotNull(results);
            Assert.IsTrue(results is List<DetailedRentalView>);
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
            var testEmployee = new Employee {
                name = "Brandon Walker",
                employeeId = 1234
            };
            var employeeHistoryController = new EmployeeHistoryController();
            var results = employeeHistoryController.BuildEmployeeDescription(testEmployee);
            var expected = @" Name: Brandon Walker ID: 1234";

            Assert.IsTrue(results.Equals(expected));
        }

        #endregion
    }
}