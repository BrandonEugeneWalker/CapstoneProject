using System;
using Capstone_Database.Model;
using Capstone_Desktop.Controller;
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
        public void TestGetStockHistoryNullStock()
        {
            var capstoneDbContextMock = new Mock<OnlineEntities>();
            var itemHistoryController = new ItemHistoryController();

            Assert.ThrowsException<ArgumentNullException>(() =>
                itemHistoryController.GetStockHistory(null, capstoneDbContextMock.Object));
        }

        [TestMethod]
        public void TestGetStockHistoryNullDbContext()
        {
            var itemHistoryController = new ItemHistoryController();
            var stockMock = new Mock<Stock>();

            Assert.ThrowsException<ArgumentNullException>(() =>
                itemHistoryController.GetStockHistory(stockMock.Object, null));
        }

        #endregion
    }
}