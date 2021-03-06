﻿using System;
using System.Collections.Generic;
using Capstone_Database.Model;
using Capstone_Desktop.Controller;
using Capstone_Desktop.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Capstone_Unit_Tests.desktop.controller
{
    /// <summary>Tests the functionality of the ItemHistoryController.</summary>
    [TestClass]
    public class ItemHistoryControllerTests
    {
        #region Methods

        [TestMethod]
        public void TestDefaultConstructorSunnyDay()
        {
            var testController = new ItemHistoryController();
            Assert.IsNotNull(testController);
        }

        [TestMethod]
        public void TestOverloadedConstructorNull()
        {
            Assert.ThrowsException<ArgumentNullException>(() => new ItemHistoryController(null));
        }

        [TestMethod]
        public void TestOverloadedConstructorSunnyDay()
        {
            var contextMock = new Mock<IDbContextHandler>();
            var testController = new ItemHistoryController(contextMock.Object);
            Assert.IsNotNull(testController);
        }

        [TestMethod]
        public void TestGetStockHistoryNullStock()
        {
            var capstoneDbContextMock = new Mock<OnlineEntities>();
            var itemHistoryController = new ItemHistoryController();

            Assert.ThrowsException<ArgumentNullException>(() =>
                itemHistoryController.GetStockHistory(null));
        }

        [TestMethod]
        public void TestGetStockHistorySunnyDay()
        {
            var contextMock = new Mock<IDbContextHandler>();
            var testStock = new Stock();
            contextMock.Setup(x => x.GetDetailedStockHistory(testStock)).Returns(new List<DetailedRentalView>());
            var testController = new ItemHistoryController(contextMock.Object);
            var results = testController.GetStockHistory(testStock);
            Assert.IsNotNull(results);
            Assert.IsTrue(results is List<DetailedRentalView>);
        }

        [TestMethod]
        public void TestGetStockDescriptionNull()
        {
            var testController = new ItemHistoryController();
            Assert.ThrowsException<ArgumentNullException>(() => testController.BuildStockDescription(null));
        }

        [TestMethod]
        public void TestGetStockDescriptionSunnyDay()
        {
            var testProduct = new Product {
                productId = -1,
                name = "Test Product",
                description = "",
                type = "Book",
                category = "Adventure"
            };
            var testStock = new Stock {
                stockId = -1,
                productId = -1,
                itemCondition = "Good",
                Product = testProduct
            };
            var testController = new ItemHistoryController();
            var results = testController.BuildStockDescription(testStock);
            var expected = " Item Name: Test Product Stock ID: -1 Condition: Good";
            Assert.IsNotNull(results);
            Assert.IsTrue(results.Equals(expected));

        }

        #endregion
    }
}