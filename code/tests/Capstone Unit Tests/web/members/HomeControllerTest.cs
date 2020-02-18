using System.Collections.Generic;
using System.Web.Mvc;
using Capstone_Database.Model;
using Capstone_Web_Members.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

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
                description = "The fate of Middle-earth hangs in the balance as Frodo and " +
                              "eight companions who form the Fellowship of the Ring begin their " +
                              "journey to Mount Doom - Movie Adaptation",
                type = "Movie",
                category = "Fantasy"
            };

            var testProducts = new List<Product>() { productA, productB };

            return testProducts;
        }

        /// <summary>
        /// Tests the controller behavior for the member web Index
        /// </summary>
        [TestMethod]
        public void Index()
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
        public void About()
        {
            // Arrange
            var controller = new HomeController();

            // Act
            var result = controller.About() as ViewResult;

            // Assert
            Assert.AreEqual("About Us", result.ViewBag.Message);
            Assert.IsNotNull(result);
        }

        /// <summary>
        /// Tests the controller behavior for the member web Contact info page
        /// </summary>
        [TestMethod]
        public void Contact()
        {
            // Arrange
            var controller = new HomeController();

            // Act
            var result = controller.Contact() as ViewResult;

            // Assert
            Assert.AreEqual("Contact Information:", result.ViewBag.Message);
            Assert.IsNotNull(result);
        }

        /// <summary>
        /// Tests the controller behavior for the Media Library
        /// </summary>
        [TestMethod]
        public void MediaLibrary()
        {
            // Arrange
            var controller = new HomeController();

            // Act
            var result = controller.MediaLibrary() as ViewResult;
            var model = result.Model;
            var testProducts = GetTestProducts();

            // Assert
            Assert.IsNotNull(result);
        }

        /// <summary>
        /// Tests the controller behavior for the Media Library when ordering a product
        /// </summary>
        /// <param name="id">The identifier.</param>
        [TestMethod]
        public void OrderProduct(int id)
        {
            // Arrange
            var controller = new HomeController();

            // Act
            var result = controller.MediaLibrary() as ViewResult;
            var model = result.Model;

            // Assert
            Assert.IsNotNull(result);
        }
    }
}
