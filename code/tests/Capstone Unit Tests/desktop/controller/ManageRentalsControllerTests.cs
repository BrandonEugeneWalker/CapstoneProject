using System;
using Capstone_Database.Model;
using Capstone_Desktop.Controller;
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
        public void TestGetRentalsWaitingShipmentNullDatabase()
        {
            var manageRentalsController = new ManageRentalsController();

            Assert.ThrowsException<ArgumentNullException>(() =>
                manageRentalsController.GetRentalsWaitingShipment(null));
        }

        [TestMethod]
        public void TestGetRentalsWaitingReturnNullDatabase()
        {
            var manageRentalsController = new ManageRentalsController();

            Assert.ThrowsException<ArgumentNullException>(() =>
                manageRentalsController.GetRentalsWaitingReturn(null));
        }

        [TestMethod]
        public void TestGetAllRentalsNullDatabase()
        {
            var manageRentalsController = new ManageRentalsController();

            Assert.ThrowsException<ArgumentNullException>(() =>
                manageRentalsController.GetAllRentals(null));
        }

        [TestMethod]
        public void TestMarkRentalAsWaitingReturnNullDatabase()
        {
            var manageRentalsController = new ManageRentalsController();

            Assert.ThrowsException<ArgumentNullException>(() =>
                manageRentalsController.MarkRentalAsWaitingReturn(new DetailedRentalView(), null, new Employee()));
        }

        [TestMethod]
        public void TestMarkRentalAsWaitingReturnNullRental()
        {
            var capstoneDbContextMock = new Mock<OnlineEntities>();
            var manageRentalsController = new ManageRentalsController();

            Assert.ThrowsException<ArgumentNullException>(() =>
                manageRentalsController.MarkRentalAsWaitingReturn(null, capstoneDbContextMock.Object, new Employee()));
        }

        [TestMethod]
        public void TestMarkRentalAsWaitingReturnNullEmployee()
        {
            var capstoneDbContextMock = new Mock<OnlineEntities>();
            var manageRentalsController = new ManageRentalsController();

            Assert.ThrowsException<ArgumentNullException>(() =>
                manageRentalsController.MarkRentalAsWaitingReturn(new DetailedRentalView(),
                    capstoneDbContextMock.Object, null));
        }

        [TestMethod]
        public void TestMarkRentalAsWaitingReturnIncorrectStatus()
        {
            var capstoneDbContextMock = new Mock<OnlineEntities>();
            var manageRentalsController = new ManageRentalsController();

            Assert.ThrowsException<ArgumentNullException>(() =>
                manageRentalsController.MarkRentalAsWaitingReturn(new DetailedRentalView {
                    status = "Returned"
                }, null, new Employee()));
        }

        [TestMethod]
        public void TestMarkRentalAsReturnedNullDatabase()
        {
            var manageRentalsController = new ManageRentalsController();

            Assert.ThrowsException<ArgumentNullException>(() =>
                manageRentalsController.MarkRentalAsReturned(new DetailedRentalView(), null, new Employee()));
        }

        [TestMethod]
        public void TestMarkRentalAsReturnedNullRental()
        {
            var capstoneDbContextMock = new Mock<OnlineEntities>();
            var manageRentalsController = new ManageRentalsController();

            Assert.ThrowsException<ArgumentNullException>(() =>
                manageRentalsController.MarkRentalAsReturned(null, capstoneDbContextMock.Object, new Employee()));
        }

        [TestMethod]
        public void TestMarkRentalAsReturnedNullEmployee()
        {
            var capstoneDbContextMock = new Mock<OnlineEntities>();
            var manageRentalsController = new ManageRentalsController();

            Assert.ThrowsException<ArgumentNullException>(() =>
                manageRentalsController.MarkRentalAsReturned(new DetailedRentalView(), capstoneDbContextMock.Object,
                    null));
        }

        [TestMethod]
        public void TestMarkRentalAsReturnedIncorrectStatus()
        {
            var capstoneDbContextMock = new Mock<OnlineEntities>();
            var manageRentalsController = new ManageRentalsController();

            Assert.ThrowsException<ArgumentNullException>(() =>
                manageRentalsController.MarkRentalAsWaitingReturn(new DetailedRentalView {
                    status = "Returned"
                }, null, new Employee()));
        }

        #endregion
    }
}