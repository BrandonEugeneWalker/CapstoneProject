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
            Assert.AreEqual("Your application description page.", result.ViewBag.Message);
        }

        [TestMethod]
        public void Contact()
        {
            // Arrange
            var controller = new HomeController();

            // Act
            var result = controller.Contact() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void MediaLibrary()
        {
            // Arrange
            var controller = new HomeController();

            // Act
            var result = controller.MediaLibrary() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }
    }
}