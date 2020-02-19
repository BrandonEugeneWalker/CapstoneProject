using System.Collections.Generic;
using System.Web.Mvc;
using Capstone_Database.Model;
using Capstone_Web_Members.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Capstone_Unit_Tests.web.members
{
    /// <summary>
    /// Tests the HomeController behavior
    /// </summary>
    [TestClass]
    public class HomeControllerTest
    {

        /// Setup for Test Products
        private static IEnumerable<Product> GetTestProducts()
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

            var testProducts = new List<Product> { productA, productB };

            return testProducts;
        }

        /// <summary>
        /// Tests that the Index Page is not null.
        /// </summary>
        [TestMethod]
        public void Index_IsNotNull()
        {
            // Arrange
            var controller = new HomeController();

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
            var controller = new HomeController();

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
            var controller = new HomeController();

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
            var products = GetTestProducts();

            var controller = new HomeController(databaseMock.Object, products);

            // Act
            var result = controller.MediaLibrary() as ViewResult;

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
            var databaseMock = new Mock<OnlineEntities>();
            var products = GetTestProducts();

            var controller = new HomeController(databaseMock.Object, products);

            // Act
            var result = controller.MediaLibrary() as ViewResult;

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
            var controller = new HomeController();

            // Act
            var result = controller.MediaLibrary() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Model);
        }
    }
}