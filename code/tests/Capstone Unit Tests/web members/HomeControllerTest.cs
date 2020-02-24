using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Web.Mvc;
using Capstone_Database.Model;
using Capstone_Web_Members.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Capstone_Unit_Tests.web_members
{
    /// <summary>
    /// Tests the HomeController behavior
    /// </summary>
    [TestClass]
    public class HomeControllerTest
    {

        private static List<Product> getTestProducts()
        {
            var productA = new Product
            {
                productId = 1,
                name = "The Hobbit",
                description = "One small boi goes on an adventure",
                type = "Book",
                category = "Adventure"
            };
            var productB = new Product
            {
                productId = 2,
                name = "Fellowship of the Ring",
                description = "The first movie",
                type = "Movie",
                category = "Fantasy"
            };

            var testProducts = new List<Product> { productA, productB };

            var productsMock = new Mock<DbSet<Product>>();

            //productsMock.As<IQueryable<Product>>().Setup(m => m.Provider).Returns(testProducts.Provider);
            //productsMock.As<IQueryable<Product>>().Setup(m => m.Expression).Returns(testProducts.Expression);
            //productsMock.As<IQueryable<Product>>().Setup(m => m.ElementType).Returns(testProducts.ElementType);
            //productsMock.As<IQueryable<Product>>().Setup(m => m.GetEnumerator()).Returns(testProducts.GetEnumerator());

            return testProducts;
        }

        private static Mock<DbSet<Stock>> getTestStocks()
        {
            var stockA = new Stock
            {
                stockId = 1,
                productId = 1
            };
            var stockB = new Stock
            {
                stockId = 2,
                productId = 2
            };

            var testStock = new List<Stock> { stockA, stockB }.AsQueryable();

            var stocksMock = new Mock<DbSet<Stock>>();
            stocksMock.As<IQueryable<Stock>>().Setup(m => m.Provider).Returns(testStock.Provider);
            stocksMock.As<IQueryable<Stock>>().Setup(m => m.Expression).Returns(testStock.Expression);
            stocksMock.As<IQueryable<Stock>>().Setup(m => m.ElementType).Returns(testStock.ElementType);
            stocksMock.As<IQueryable<Stock>>().Setup(m => m.GetEnumerator()).Returns(testStock.GetEnumerator());

            return stocksMock;
        }

        private static Mock<MemberContext> getMemberContext()
        {
            var memberContextMock = new Mock<MemberContext>();
            //memberContextMock.Setup(x => x.Products).Returns(getTestProducts().Object);
            memberContextMock.Setup(x => x.Stocks).Returns(getTestStocks().Object);

            var mockObjectResult = new TestableObjectResult<Product>();
            memberContextMock.Setup(x => x.retrieveAvailableProductsWithSearch(string.Empty, string.Empty))
                .Returns(mockObjectResult);

            var mockedProductResult = new Mock<TestableObjectResult<Product>>();
            mockedProductResult.Setup(x => x.GetEnumerator()).Returns(getTestProducts().GetEnumerator());

            memberContextMock.Setup(x => x.retrieveAvailableProductsWithSearch(string.Empty, string.Empty))
                .Returns(mockedProductResult.Object);

            return memberContextMock;
        }

        /// <summary>
        /// Tests that the Index Page is not null.
        /// </summary>
        [TestMethod]
        public void Index_IsNotNull()
        {
            // Arrange
            var controller = new HomeController(getMemberContext().Object);

            // Act
            var result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        /// <summary>
        /// Tests the controller behavior for the member web About page
        /// </summary>
        [TestMethod]
        public void About_IsNotNull()
        {
            // Arrange
            var controller = new HomeController(getMemberContext().Object);

            // Act
            var result = controller.About() as ViewResult;

            // Assert
            Assert.AreEqual("About Us", result?.ViewBag.Message);
            Assert.IsNotNull(result);
        }

        /// <summary>
        /// Tests the controller behavior for the member web Contact info page
        /// </summary>
        [TestMethod]
        public void Contact_IsNotNull()
        {
            // Arrange
            var controller = new HomeController(getMemberContext().Object);

            // Act
            var result = controller.Contact() as ViewResult;

            // Assert
            Assert.AreEqual("Contact Information:", result?.ViewBag.Message);
            Assert.IsNotNull(result);
        }

        /// <summary>
        /// Tests that the Media Library is not null
        /// </summary>
        [TestMethod]
        public void MediaLibrary_IsNotNull()
        {
            // Arrange
            var controller = new HomeController(getMemberContext().Object);

            // Act
            var result = controller.MediaLibrary(null, null) as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        /// <summary>
        /// Tests that the Media Library model is not null
        /// </summary>
        [TestMethod]
        public void MediaLibrary_ModelIsNotNull()
        {
            // Arrange
            var controller = new HomeController(getMemberContext().Object);

            // Act
            var result = controller.MediaLibrary(null, null) as ViewResult;

            // Assert
            Assert.IsNotNull(result?.Model);
        }

        //TODO -Will need further in depth testing, does not reach the ActionResult as
        //TODO -it is triggered by a link, but uses the controllers properties
        /// <summary>
        /// Tests that the ActionResult for OrderProduct is not null within the mock
        /// </summary>
        [TestMethod]
        public void OrderProduct_Action_IsNotNull()
        {
            // Arrange
            var controller = new HomeController(getMemberContext().Object);

            // Act
            var result = controller.OrderProduct(1) as ViewResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Model);
        }
    }
}