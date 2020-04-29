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
    public class ManageProductsControllerTests
    {
        [TestMethod]
        public void TestDefaultConstructorSunnyDay()
        {
            var testController = new ManageProductsController();
            Assert.IsNotNull(testController);
        }

        [TestMethod]
        public void TestOverloadedConstructorNull()
        {
            Assert.ThrowsException<ArgumentNullException>(() => new ManageProductsController(null));
        }

        [TestMethod]
        public void TestOverloadedConstructorSunnyDay()
        {
            var testController = new ManageProductsController(new CapstoneDbContextHandler());
            Assert.IsNotNull(testController);
        }

        [TestMethod]
        public void TestGetAllProductsSunnyDay()
        {
            var capstoneHandlerMock = new Mock<IDbContextHandler>();
            capstoneHandlerMock.Setup(x => x.GetAllProducts()).Returns(new BindingList<Product>());
            var testController = new ManageProductsController(capstoneHandlerMock.Object);
            var results = testController.GetAllProducts();
            Assert.IsNotNull(results);
            Assert.IsTrue(results is BindingList<Product>);
        }

        [TestMethod]
        public void TestAddProductNull()
        {
            var testController = new ManageProductsController();
            Assert.ThrowsException<ArgumentNullException>(() => testController.AddProduct(null));
        }

        [TestMethod]
        public void TestAddProductSunnyDay()
        {
            var capstoneHandlerMock = new Mock<IDbContextHandler>();
            var testController = new ManageProductsController(capstoneHandlerMock.Object);
            testController.AddProduct(new Product());
        }
    }
}