using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Capstone_Web_Warehouse.Controllers;

namespace Capstone_Web_Warehouse.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void Index()
        {
            var controller = new HomeController();

            // Act
            var result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

    }
}
