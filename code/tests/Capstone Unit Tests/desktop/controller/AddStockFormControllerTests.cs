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
    public class AddStockFormControllerTests
    {
        #region Methods

        [TestMethod]
        public void TestDefaultConstructorSunnyDay()
        {
            var testController = new AddStockFormController();
            Assert.IsNotNull(testController);
        }

        [TestMethod]
        public void TestOverloadedConstructorNull()
        {
            Assert.ThrowsException<ArgumentNullException>(() => new AddStockFormController(null));
        }

        [TestMethod]
        public void TestOverloadedConstructorSunnyDay()
        {
            var testController = new AddStockFormController(new CapstoneDbContextHandler());
            Assert.IsNotNull(testController);
        }

        [TestMethod]
        public void TestAddStockToDatabaseNullItemCondition()
        {
            var testController = new AddStockFormController();
            Assert.ThrowsException<ArgumentNullException>(() => testController.AddStockToDatabase(4, null));
        }

        [TestMethod]
        public void TestAddStockToDatabaseZeroId()
        {
            var testController = new AddStockFormController();
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => testController.AddStockToDatabase(0, "blabla"));
        }

        [TestMethod]
        public void TestAddStockToDatabaseNegativeId()
        {
            var testController = new AddStockFormController();
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => testController.AddStockToDatabase(-1, "blabla"));
        }

        [TestMethod]
        public void TestAddStockToDatabaseSunnyDay()
        {
            var databaseHandlerMock = new Mock<IDbContextHandler>();
            var testController = new AddStockFormController(databaseHandlerMock.Object);
            testController.AddStockToDatabase(10, "blabla");
        }

        [TestMethod]
        public void TestGetAllProductsSunnyDay()
        {
            var databaseHandlerMock = new Mock<IDbContextHandler>();
            databaseHandlerMock.Setup(x => x.GetAllProducts()).Returns(new BindingList<Product>());
            var testController = new AddStockFormController(databaseHandlerMock.Object);
            var results = testController.GetAllProducts();
            Assert.IsNotNull(results);
            Assert.IsTrue(results is BindingList<Product>);
        }

        #endregion
    }
}