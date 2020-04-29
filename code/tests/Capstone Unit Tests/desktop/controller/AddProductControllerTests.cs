using System;
using Capstone_Database.Model;
using Capstone_Desktop.Controller;
using Capstone_Desktop.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Capstone_Unit_Tests.desktop.controller
{
    [TestClass]
    public class AddProductControllerTests
    {
        [TestMethod]
        public void TestDefaultConstructorSunnyDay()
        {
            var testController = new AddProductController();
            Assert.IsNotNull(testController);
        }

        [TestMethod]
        public void TestOverloadedConstructorNull()
        {
            Assert.ThrowsException<ArgumentNullException>(() => new AddProductController(null));
        }

        [TestMethod]
        public void TestOverloadedConstructorSunnyDay()
        {
            var testController = new AddProductController(new CapstoneDbContextHandler());
            Assert.IsNotNull(testController);
        }

        [TestMethod]
        public void TestAddProductNull()
        {
            var testController = new AddProductController();
            Assert.ThrowsException<ArgumentNullException>(() => testController.AddProduct(null));
        }

        [TestMethod]
        public void TestAddProductSunnyDay()
        {
            var capstoneHandlerMock = new Mock<IDbContextHandler>();
            var testController = new AddProductController(capstoneHandlerMock.Object);
            testController.AddProduct(new Product());
        }
    }
}