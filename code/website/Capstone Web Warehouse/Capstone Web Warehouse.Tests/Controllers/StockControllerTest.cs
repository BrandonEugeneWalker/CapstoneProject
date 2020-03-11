using System;
using System.Text;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Capstone_Database.Model;
using Capstone_Web_Warehouse.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Capstone_Web_Warehouse.Tests.Controllers
{
    /// <summary>
    /// Summary description for StockControllerTest
    /// </summary>
    [TestClass]
    public class StockControllerTest
    {
        [TestMethod()]
        public void TestController()
        {
            var controller = new StocksController();
            controller.Dispose();
            Assert.IsNotNull(controller);
        }

        [TestMethod()]
        public void TestIndexLogin()
        {
            var controller = setupControllerWithSession();
            var index = controller.Index() as ViewResult;
 
            Assert.IsNotNull(index);
        }
        [TestMethod()]
        public void TestIndexNoLogin()
        {
            var controller = setupControllerWithoutSession();
            var index = controller.Index() as RedirectResult;

            Assert.IsNotNull(index);
        }

        [TestMethod()]
        public void TestDetailsNull()
        {
            var controller = setupControllerWithoutSession();
            var index = controller.Details(null) as HttpStatusCodeResult;

            Assert.IsNotNull(index);
        }
        [TestMethod()]
        public void TestDetailsGood()
        {
            var controller = setupControllerWithSession();
            var index = controller.Details(1) as ViewResult;

            Assert.IsNotNull(index);
        }

        [TestMethod()]
        public void TestDetailsNotFound()
        {
            var controller = setupControllerWithoutSession();
            var index = controller.Details(6) as HttpNotFoundResult;

            Assert.IsNotNull(index);
        }
        private static StocksController setupControllerWithoutSession()
        {
            var emp1 = new Employee() { employeeId = 1000, name = "Bob", password = "whm3GC0X8np.c", isManager = true };
            var stock1 = new Stock() {stockId = 1, productId = 1, itemCondition = "Good"};
            var stock2 = new Stock() { stockId = 2, productId = 2, itemCondition = "Good" };
            IList<Stock> stocks = new List<Stock>()
            {
                stock1,stock2
            };
            var context = new Mock<OnlineEntities>();
            var mock = CreateDbSetMock(stocks);
            context.Setup(x => x.Stocks).Returns(mock.Object);
            context.Setup(x => x.Stocks.Find(1)).Returns(stock1);

            var eController = new StocksController(context.Object);

            var httpContext = new Mock<HttpContextBase>();
            var session = new Mock<HttpSessionStateBase>();
            session.Setup(s => s["Employee"]).Returns(null);
            httpContext.Setup(x => x.Session).Returns(session.Object);
            var requestContext = new RequestContext(httpContext.Object, new RouteData());
            eController.ControllerContext = new ControllerContext(requestContext, eController);

            return eController;
        }

        private static StocksController setupControllerWithSession()
        {
            var emp1 = new Employee() { employeeId = 1000, name = "Bob", password = "whm3GC0X8np.c", isManager = true };
            var stock1 = new Stock() { stockId = 1, productId = 1, itemCondition = "Good" };
            var stock2 = new Stock() { stockId = 2, productId = 2, itemCondition = "Good" };
            IList<Stock> stocks = new List<Stock>()
            {
                stock1,stock2
            };
            var context = new Mock<OnlineEntities>();
            var mock = CreateDbSetMock(stocks);
            context.Setup(x => x.Stocks).Returns(mock.Object);
            context.Setup(x => x.Stocks.Find(1)).Returns(stock1);

            var eController = new StocksController(context.Object);

            var httpContext = new Mock<HttpContextBase>();
            var session = new Mock<HttpSessionStateBase>();
            session.Setup(s => s["Employee"]).Returns(emp1);
            httpContext.Setup(x => x.Session).Returns(session.Object);
            var requestContext = new RequestContext(httpContext.Object, new RouteData());
            eController.ControllerContext = new ControllerContext(requestContext, eController);

            return eController;
        }

        private static Mock<DbSet<T>> CreateDbSetMock<T>(IEnumerable<T> elements) where T : class
        {
            var elementsAsQueryable = elements.AsQueryable();
            var dbSetMock = new Mock<DbSet<T>>();

            dbSetMock.As<IQueryable<T>>().Setup(m => m.Provider).Returns(elementsAsQueryable.Provider);
            dbSetMock.As<IQueryable<T>>().Setup(m => m.Expression).Returns(elementsAsQueryable.Expression);
            dbSetMock.As<IQueryable<T>>().Setup(m => m.ElementType).Returns(elementsAsQueryable.ElementType);
            dbSetMock.As<IQueryable<T>>().Setup(m => m.GetEnumerator()).Returns(elementsAsQueryable.GetEnumerator());

            return dbSetMock;
        }
    }
}
