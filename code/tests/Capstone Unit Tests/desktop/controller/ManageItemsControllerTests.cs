using System;
using System.ComponentModel;
using Capstone_Database.Model;
using Capstone_Desktop.Controller;
using Capstone_Desktop.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Capstone_Unit_Tests.desktop.controller
{
    [TestClass]
    public class ManageItemsControllerTests
    {
        #region Methods

        [TestMethod]
        public void TestDefaultConstructorSunnyDay()
        {
            var testController = new ManageItemsController();
            Assert.IsNotNull(testController);
        }

        [TestMethod]
        public void TestOverloadedConstructorNull()
        {
            Assert.ThrowsException<ArgumentNullException>(() => new ManageItemsController(null));
        }

        [TestMethod]
        public void TestOverloadedConstructorSunnyDay()
        {
            var testController = new ManageItemsController(new CapstoneDbContextHandler());
            Assert.IsNotNull(testController);
        }

        [TestMethod]
        public void TestGetAllStockSunnyDay()
        {
            var contextHandlerMock = new Mock<IDbContextHandler>();
            contextHandlerMock.Setup(x => x.GetAllDetailedStock()).Returns(new BindingList<StockDetailView>());
            var testController = new ManageItemsController(contextHandlerMock.Object);
            var results = testController.GetAllStock();
            Assert.IsNotNull(results);
            Assert.IsTrue(results is BindingList<StockDetailView>);
        }

        [TestMethod]
        public void TestGetStockByDetailedStockNull()
        {
            var testController = new ManageItemsController();
            Assert.ThrowsException<ArgumentNullException>(() => testController.GetStockByDetailedStock(null));
        }

        [TestMethod]
        public void TestGetStockByDetailedStockSunnyDay()
        {
            var contextHandlerMock = new Mock<IDbContextHandler>();
            contextHandlerMock.Setup(x => x.GetStockById(1234)).Returns(new Stock());
            var testController = new ManageItemsController(contextHandlerMock.Object);
            var results = testController.GetStockByDetailedStock(new StockDetailView {
                stockId = 1234
            });
            Assert.IsNotNull(results);
            Assert.IsTrue(results is Stock);
        }

        #endregion
    }
}