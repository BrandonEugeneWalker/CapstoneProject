using System.Net.Http.Headers;
using System.Web.Mvc;
using Capstone_Web_Members.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Capstone_Web_Members.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
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

        [TestMethod]
        public void MediaLibrary()
        {
            // Arrange
            var controller = new HomeController();

            // Act
            var result = controller.MediaLibrary() as ViewResult;
            var model = result.Model;
            

            // Assert
            Assert.IsNotNull(result);
        }

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