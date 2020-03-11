using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Capstone_Web_Warehouse.Controllers;
using Moq;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using Capstone_Database.Model;
using System.Linq;
using System.Web;
using System.Web.Routing;

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
        [TestMethod]
        public void LogoffTest()
        {
            var controller = setupControllerWithSession();
            var log = controller.LogOff() as RedirectToRouteResult;
            Assert.IsNotNull(log);
        }

        [TestMethod]
        public void LoginTestError()
        {
            var controller = setupControllerWithSession();
            controller.ModelState.AddModelError("", "");
            var log = controller.Login(null) as ViewResult;
            Assert.IsNotNull(log);
        }

        [TestMethod]
        public void ManageStockNullTest()
        {
            var controller = setupControllerWithoutSession();
            var stock = controller.ManageStock() as RedirectToRouteResult;
            Assert.IsNotNull(stock);
        }

        [TestMethod]
        public void ManageStockGoodTest()
        {
            var controller = setupControllerWithSession();
            var stock = controller.ManageStock() as RedirectResult;
            Assert.IsNotNull(stock);
        }

        [TestMethod]
        public void ManageEmployeesNullTest()
        {
            var controller = setupControllerWithoutSession();
            var emp = controller.ManageEmployees() as RedirectToRouteResult;
            Assert.IsNotNull(emp);
        }

        [TestMethod]
        public void ManageEmployeesGoodTest()
        {
            var controller = setupControllerWithSession();
            var emp = controller.ManageEmployees() as RedirectResult;
            Assert.IsNotNull(emp);
        }


        [TestMethod]
        public void ManageRentalNullTest()
        {
            var controller = setupControllerWithoutSession();
            var rent = controller.ManageItems() as RedirectToRouteResult;
            Assert.IsNotNull(rent);
        }

        [TestMethod]
        public void ManageRentalGoodTest()
        {
            var controller = setupControllerWithSession();
            var rent = controller.ManageItems() as RedirectResult;
            Assert.IsNotNull(rent);
        }

        private static HomeController setupControllerWithoutSession()
        {
            var emp1 = new Employee() { employeeId = 1000, name = "Bob", password = "whm3GC0X8np.c", isManager = true };
            var emp2 = new Employee() { employeeId = 2000, name = "Bill", password = "whm3GC0X8np.c", isManager = false };
            IList<Employee> employees = new List<Employee>()
            {
                emp1,
                emp2
            };

            var context = new Mock<OnlineEntities>();
            var mock = CreateDbSetMock(employees);

            context.Setup(x => x.Employees).Returns(mock.Object);
            context.Setup(x => x.Employees.Find(1000)).Returns(emp1);

            var eController = new HomeController(context.Object);

            var httpContext = new Mock<HttpContextBase>();
            var session = new Mock<HttpSessionStateBase>();
            session.Setup(s => s["Employee"]).Returns(null);
            httpContext.Setup(x => x.Session).Returns(session.Object);
            var requestContext = new RequestContext(httpContext.Object, new RouteData());
            eController.ControllerContext = new ControllerContext(requestContext, eController);

            return eController;
        }

        private static HomeController setupControllerWithSession()
        {
            var emp1 = new Employee() { employeeId = 1000, name = "Bob", password = "whm3GC0X8np.c", isManager = true };
            var emp2 = new Employee() { employeeId = 2000, name = "Bill", password = "whm3GC0X8np.c", isManager = false };
            IList<Employee> employees = new List<Employee>()
            {
                emp1,
                emp2
            };

            var context = new Mock<OnlineEntities>();
            var mock = CreateDbSetMock(employees);
            context.Setup(x => x.Employees).Returns(mock.Object);
            context.Setup(x => x.Employees.Find(1000)).Returns(emp1);

            var eController = new HomeController(context.Object);

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
