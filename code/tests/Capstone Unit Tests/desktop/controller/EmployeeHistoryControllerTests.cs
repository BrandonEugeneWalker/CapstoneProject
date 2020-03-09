using System;
using System.ComponentModel;
using System.Data.Entity;
using Capstone_Database.Model;
using Capstone_Desktop.Controller;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Capstone_Unit_Tests.desktop.controller
{
    [TestClass]
    public class EmployeeHistoryControllerTests
    {
        [TestMethod]
        public void TestGetEmployeeHistoryEmployeeNull()
        {
            var capstoneDbContextMock = new Mock<OnlineEntities>();
            EmployeeHistoryController employeeHistoryController = new EmployeeHistoryController();

            Assert.ThrowsException<ArgumentException>(() =>
                employeeHistoryController.GetEmployeeHistory(null, capstoneDbContextMock.Object));
        }

        [TestMethod]
        public void TestGetEmployeeHistoryDbContextNull()
        {
            var employeeMock = new Mock<Employee>();
            EmployeeHistoryController employeeHistoryController = new EmployeeHistoryController();

            Assert.ThrowsException<ArgumentNullException>(() =>
                employeeHistoryController.GetEmployeeHistory(employeeMock.Object, null));
        }

        [TestMethod]
        public void TestGetEmployeeHistorySunnyDayEmpty()
        {
            var capstoneDbContextMock = new Mock<OnlineEntities>();
            capstoneDbContextMock.Setup(x => x.DetailedRentalViews.Local.ToBindingList()).Returns(new BindingList<DetailedRentalView>());
            Employee testEmployee = new Employee
            {
                employeeId = 1,
                isManager = false,
                ItemRentals = null,
                ItemRentals1 = null,
                name = "name",
                password = "password"
            };
            EmployeeHistoryController employeeHistoryController = new EmployeeHistoryController();
            var results = employeeHistoryController.GetEmployeeHistory(testEmployee, capstoneDbContextMock.Object);

            Assert.IsTrue(results.Count == 0);

        }

        [TestMethod]
        public void TestGetEmployeeHistorySunnyDayNotEmpty()
        {
            BindingList<DetailedRentalView> testList = new BindingList<DetailedRentalView>();
            DetailedRentalView testRentalView = new DetailedRentalView {
                address1 = "",
                address2 = "",
                city = "",
                itemName = "",
                itemRentalId = 1,
                memberId = 1,
                memberName = "",
                rentalDateTime = null,
                returnCondition = "",
                returnDateTime = null,
                shipDateTime = null,
                shipEmployeeId = 1,
                returnEmployeeId = 2,
                state = "",
                zip = 2,
                status = ""
            };
            testList.Add(testRentalView);

            var capstoneDbContextMock = new Mock<OnlineEntities>();
            capstoneDbContextMock.Setup(x => x.DetailedRentalViews.Local.ToBindingList()).Returns(testList);
            Employee testEmployee = new Employee
            {
                employeeId = 1,
                isManager = false,
                ItemRentals = null,
                ItemRentals1 = null,
                name = "name",
                password = "password"
            };
            EmployeeHistoryController employeeHistoryController = new EmployeeHistoryController();
            var results = employeeHistoryController.GetEmployeeHistory(testEmployee, capstoneDbContextMock.Object);

            Assert.IsTrue(results.Count == 1);
        }

        [TestMethod]
        public void TestBuildEmployeeDescriptionNull()
        {
            EmployeeHistoryController employeeHistoryController = new EmployeeHistoryController();
            Assert.ThrowsException<ArgumentNullException>(
                () => employeeHistoryController.BuildEmployeeDescription(null));
        }

        [TestMethod]
        public void TestBuildEmployeeDescriptionSunnyDay()
        {
            EmployeeHistoryController employeeHistoryController = new EmployeeHistoryController();
            Employee testEmployee = new Employee
            {
                employeeId = 1234,
                isManager = false,
                ItemRentals = null,
                ItemRentals1 = null,
                name = "Brandon Walker",
                password = "password"
            };
            string expectedString = @" Name: Brandon Walker ID: 1234";
            string givenString = employeeHistoryController.BuildEmployeeDescription(testEmployee);

            Assert.Equals(expectedString, givenString);
        }
    }
}