﻿using System.Collections.Generic;
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

            return testProducts;
        }

        private static List<Stock> getTestStocks()
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

        private static Mock<MemberContext> getMemberContext()
        {
            var memberContextMock = new Mock<MemberContext>();

            var mockProductsResult = new TestableObjectResult<Product>();
            memberContextMock.Setup(x => x.retrieveAvailableProductsWithSearch(string.Empty, string.Empty))
                .Returns(mockProductsResult);
            var mockedProductResult = new Mock<TestableObjectResult<Product>>();
            mockedProductResult.Setup(x => x.GetEnumerator()).Returns(getTestProducts().GetEnumerator());
            memberContextMock.Setup(x => x.retrieveAvailableProductsWithSearch(string.Empty, string.Empty))
                .Returns(mockedProductResult.Object);

            var mockIntResult = new TestableObjectResult<int?>();
            memberContextMock.Setup(x => x.retrieveRentedCount(0))
                             .Returns(mockIntResult);
            var mockedIntResult = new Mock<TestableObjectResult<int?>>();
            mockedIntResult.Setup(x => x.GetEnumerator()).Returns(new List<int?>{1,2,3}.GetEnumerator());
            memberContextMock.Setup(x => x.retrieveRentedCount(0)).Returns(mockIntResult);

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

        //TODO The way that MediaLibrary gets the count of rentals is
        //TODO flawed and prevents testing being finished. REWORK
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
        }

        [TestMethod]
        public void ReturnProduct_Action_IsNotNull()
        {
            // Arrange
            var controller = new HomeController(getMemberContext().Object);

            // Act
            var result = controller.OrderProduct(1) as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }
    }
}