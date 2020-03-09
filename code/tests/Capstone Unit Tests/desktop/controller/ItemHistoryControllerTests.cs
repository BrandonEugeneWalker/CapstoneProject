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
    public class ItemHistoryControllerTests
    {
        [TestMethod]
        public void TestGetStockHistoryNullStock()
        {
            var capstoneDbContextMock = new Mock<OnlineEntities>();
            ItemHistoryController itemHistoryController = new ItemHistoryController();

            Assert.ThrowsException<ArgumentNullException>(() =>
                itemHistoryController.GetStockHistory(null, capstoneDbContextMock.Object));
        }

        [TestMethod]
        public void TestGetStockHistoryNullDbContext()
        {
            ItemHistoryController itemHistoryController = new ItemHistoryController();
            var stockMock = new Mock<Stock>();

            Assert.ThrowsException<ArgumentNullException>(() =>
                itemHistoryController.GetStockHistory(stockMock.Object, null));
        }

        [TestMethod]
        public void TestGetStockHistorySunnyDayEmpty()
        {
            var capstoneDbContextMock = new Mock<OnlineEntities>();
            capstoneDbContextMock.Setup(x => x.DetailedRentalViews.Local.ToBindingList()).Returns(new BindingList<DetailedRentalView>());

            Stock testStock = new Stock {
                itemCondition = "Good",
                ItemRentals = null,
                productId = 1,
                Product = null,
                stockId = 1
            };

            ItemHistoryController itemHistoryController = new ItemHistoryController();
            var results = itemHistoryController.GetStockHistory(testStock, capstoneDbContextMock.Object);

            Assert.IsTrue(results.Count == 0);
        }

        [TestMethod]
        public void TestGetStockHistorySunnyDayNotEmpty()
        {
            BindingList<DetailedRentalView> testList = new BindingList<DetailedRentalView>();
            DetailedRentalView testRentalView = new DetailedRentalView
            {
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
                status = "",
                stockId = 1
            };
            testList.Add(testRentalView);

            var capstoneDbContextMock = new Mock<OnlineEntities>();
            capstoneDbContextMock.Setup(x => x.DetailedRentalViews.Local.ToBindingList()).Returns(testList);

            Stock testStock = new Stock
            {
                itemCondition = "Good",
                ItemRentals = null,
                productId = 1,
                Product = null,
                stockId = 1
            };

            ItemHistoryController itemHistoryController = new ItemHistoryController();
            var results = itemHistoryController.GetStockHistory(testStock, capstoneDbContextMock.Object);

            Assert.IsTrue(results.Count == 1);
        }

        [TestMethod]
        public void TestBuildStockDescriptionNull()
        {
            ItemHistoryController itemHistoryController = new ItemHistoryController();

            Assert.ThrowsException<ArgumentNullException>(() => itemHistoryController.BuildStockDescription(null));
        }

        [TestMethod]
        public void TestBuildStockDescriptionSunnyDay()
        {
            Stock testStock = new Stock
            {
                itemCondition = "Good",
                ItemRentals = null,
                productId = 1,
                Product = new Product {
                    category = "",
                    description = "",
                    name = "Clean Code",
                    productId = 1,
                    Stocks = null,
                    type = ""
                },
                stockId = 1
            };

            ItemHistoryController itemHistoryController = new ItemHistoryController();

            string expectedString = @" Item Name: Clean Code Stock ID: 1 Condition: Good";
            string givenString = itemHistoryController.BuildStockDescription(testStock);

            Assert.IsTrue(expectedString.Equals(givenString));

        }
    }
}