using System.Collections.Generic;
using System.Data.Entity;
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

        /// Setup for Test Products
        private static DbSet<Product> getTestProducts()
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
                productId = 1,
                name = "Fellowship of the Ring",
                description = "The first movie",
                type = "Movie",
                category = "Fantasy"
            };

            var testProducts = new List<Product> { productA, productB }.AsQueryable();

            var productsMock = new Mock<DbSet<Product>>();

            productsMock.As<IQueryable<Product>>().Setup(m => m.Provider).Returns(testProducts.Provider);
            productsMock.As<IQueryable<Product>>().Setup(m => m.Expression).Returns(testProducts.Expression);
            productsMock.As<IQueryable<Product>>().Setup(m => m.ElementType).Returns(testProducts.ElementType);
            productsMock.As<IQueryable<Product>>().Setup(m => m.GetEnumerator()).Returns(testProducts.GetEnumerator());

            return productsMock.Object;
        }

        private static IEnumerable<Stock> getTestStocks()
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

            var testStock = new List<Stock> { stockA, stockB };

            return testStock;
        }

        private static Mock<OnlineEntities> getMockDatabase()
        {
            var databaseMock = new Mock<OnlineEntities>();
            //TODO Properly set up the Mock to potentially have data
            databaseMock.Object.Products = getTestProducts();

            return databaseMock;
        }

        /// <summary>
        /// Tests that the Index Page is not null.
        /// </summary>
        [TestMethod]
        public void Index_IsNotNull()
        {
            // Arrange
            var databaseMock = getMockDatabase();
            var controller = new HomeController(databaseMock.Object);

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
            var databaseMock = getMockDatabase();
            var controller = new HomeController(databaseMock.Object);

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
            var databaseMock = getMockDatabase();
            var controller = new HomeController(databaseMock.Object);

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
            var databaseMock = new Mock<OnlineEntities>();
            var controller = new HomeController(databaseMock.Object);

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
            var databaseMock = getMockDatabase();
            var controller = new HomeController(databaseMock.Object);

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
            var databaseMock = getMockDatabase();
            var controller = new HomeController(databaseMock.Object);

            // Act
            var result = controller.OrderProduct(1) as ViewResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Model);
        }
    }
}