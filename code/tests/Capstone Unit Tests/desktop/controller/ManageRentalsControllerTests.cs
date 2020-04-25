using System;
using System.Collections.Generic;
using System.ComponentModel;
using Capstone_Database.Model;
using Capstone_Desktop.Controller;
using Capstone_Desktop.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Capstone_Unit_Tests.desktop.controller
{
    /// <summary>Tests the functionality of the ManageRentalsController.</summary>
    [TestClass]
    public class ManageRentalsControllerTests
    {
        #region Methods

        [TestMethod]
        public void TestDefaultConstructorSunnyDay()
        {
            var testConstructor = new ManageRentalsController();
            Assert.IsNotNull(testConstructor);
        }

        [TestMethod]
        public void TestOverloadedConstructorNull()
        {
            Assert.ThrowsException<ArgumentNullException>(() => new ManageRentalsController(null));
        }

        [TestMethod]
        public void TestOverloadedConstructorSunnyDay()
        {
            var testConstructor = new ManageRentalsController(new CapstoneDbContextHandler());
            Assert.IsNotNull(testConstructor);
        }

        [TestMethod]
        public void TestGetRentalsWaitingShipmentSunnyDay()
        {
            var contextMock = new Mock<IDbContextHandler>();
            contextMock.Setup(x => x.GetDetailedRentalsWaitingShipment()).Returns(new List<DetailedRentalView>());
            var testController = new ManageRentalsController(contextMock.Object);
            var results = testController.GetRentalsWaitingShipment();
            Assert.IsNotNull(results);
            Assert.IsTrue(results is List<DetailedRentalView>);
        }

        [TestMethod]
        public void TestGetRentalsWaitingReturnSunnyDay()
        {
            var contextMock = new Mock<IDbContextHandler>();
            contextMock.Setup(x => x.GetDetailedRentalsWaitingReturn()).Returns(new List<DetailedRentalView>());
            var testController = new ManageRentalsController(contextMock.Object);
            var results = testController.GetRentalsWaitingReturn();
            Assert.IsNotNull(results);
            Assert.IsTrue(results is List<DetailedRentalView>);
        }

        [TestMethod]
        public void TestGettingAllRentalsSunnyDay()
        {
            var contextMock = new Mock<IDbContextHandler>();
            contextMock.Setup(x => x.GetAllDetailedRentals()).Returns(new BindingList<DetailedRentalView>());
            var testController = new ManageRentalsController(contextMock.Object);
            var results = testController.GetAllRentals();
            Assert.IsNotNull(results);
            Assert.IsTrue(results is BindingList<DetailedRentalView>);
        }

        [TestMethod]
        public void TestMarkRentalAsWaitingReturnNullRental()
        {
            var manageRentalsController = new ManageRentalsController();

            Assert.ThrowsException<ArgumentNullException>(() =>
                manageRentalsController.MarkRentalAsWaitingReturn(null, new Employee()));
        }

        [TestMethod]
        public void TestMarkRentalAsWaitingReturnNullEmployee()
        {
            var manageRentalsController = new ManageRentalsController();

            Assert.ThrowsException<ArgumentNullException>(() =>
                manageRentalsController.MarkRentalAsWaitingReturn(new DetailedRentalView(), null));
        }

        [TestMethod]
        public void TestMarkRentalAsWaitingReturnSunnyDay()
        {
            var employee = new Employee();
            var detailedRental = new DetailedRentalView();
            var contextMock = new Mock<IDbContextHandler>();
            contextMock.Setup(x => x.MarkRentalAsWaitingReturn(detailedRental, employee)).Returns(true);
            var testController = new ManageRentalsController(contextMock.Object);
            var results = testController.MarkRentalAsWaitingReturn(detailedRental, employee);
            Assert.IsTrue(results);
        }

        [TestMethod]
        public void TestMarkRentalAsReturnedNullRental()
        {
            var manageRentalsController = new ManageRentalsController();

            Assert.ThrowsException<ArgumentNullException>(() =>
                manageRentalsController.MarkRentalAsReturned(null, new Employee(), "Good"));
        }

        [TestMethod]
        public void TestMarkRentalAsReturnedNullEmployee()
        {
            var manageRentalsController = new ManageRentalsController();

            Assert.ThrowsException<ArgumentNullException>(() =>
                manageRentalsController.MarkRentalAsReturned(new DetailedRentalView(),
                    null, "Good"));
        }

        [TestMethod]
        public void TestMarkRentalAsReturnedNullCondition()
        {
            var manageRentalsController = new ManageRentalsController();

            Assert.ThrowsException<ArgumentNullException>(() =>
                manageRentalsController.MarkRentalAsReturned(new DetailedRentalView(),
                    new Employee(), null));
        }

        [TestMethod]
        public void TestMarkRentalsAsReturnedSunnyDay()
        {
            var employee = new Employee();
            var detailedRental = new DetailedRentalView();
            var contextMock = new Mock<IDbContextHandler>();
            contextMock.Setup(x => x.MarkRentalAsReturned(detailedRental, employee, "Good")).Returns(true);
            var testController = new ManageRentalsController(contextMock.Object);
            var results = testController.MarkRentalAsReturned(detailedRental, employee, "Good");
            Assert.IsTrue(results);
        }

        #endregion
    }
}