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
    [TestClass()]
    public class EmployeesControllerTests
    {

        [TestMethod()]
        public void ControllerTest()
        {
            var controller = new EmployeesController();
            Assert.IsNotNull(controller);
        }

        [TestMethod]
        public void ControllerDisposesResourcesValid()
        {
            var controller = setupControllerWithSession();

            var index = controller.Index() as ViewResult;
            controller.Dispose();

            Assert.IsNotNull(index);
        }

        [TestMethod()]
        public void IndexViewManagerTest()
        {
            var controller = setupControllerWithSession();
            var index = controller.Index() as ViewResult;
            Assert.IsNotNull(index);
            Assert.IsNotNull(index.Model);
            Assert.IsInstanceOfType(index.Model, typeof(IEnumerable<Employee>));
            var model = (IEnumerable<Employee>)index.Model;
            Assert.AreEqual(2, model.Count());
        }

        [TestMethod()]
        public void IndexViewEmployeeTest()
        {
            var controller = setupControllerNotManagerSession();
            var index = controller.Index() as RedirectResult;
            Assert.IsNotNull(index);
        }

        [TestMethod()]
        public void IndexViewNoLoginTest()
        {
            var controller = setupControllerWithoutSession();
            var index = controller.Index() as RedirectResult;
            Assert.IsNotNull(index);
        }

        [TestMethod()]
        public void CreateViewNoLoginTest()
        {
            var controller = setupControllerWithoutSession();
            var index = controller.Create() as RedirectToRouteResult;
            Assert.IsNotNull(index);
        }
        [TestMethod()]
        public void CreateManagerLoginTest()
        {
            var controller = setupControllerWithSession();
            var index = controller.Create() as ViewResult;
            Assert.IsNotNull(index);
        }
        [TestMethod()]
        public void CreateEmployeeLoginTest()
        {
            var controller = setupControllerNotManagerSession();
            var create = controller.Create() as RedirectToRouteResult;
            Assert.IsNotNull(create);
        }
        [TestMethod()]
        public void CreateEmployeeClickTest()
        {
            var controller = setupControllerWithSession();
            var create = controller.Create(new Employee()) as RedirectToRouteResult;
            Assert.IsNotNull(create);
        }

        [TestMethod()]
        public void CreateManagerClickTest()
        {
            var controller = setupControllerWithSession();
            var emp1 = new Employee() { employeeId = 3000, name = "Bob", password = "whm3GC0X8np.c", isManager = true };
            var create = controller.Create(emp1) as RedirectToRouteResult;
            Assert.IsNotNull(create);
        }

        [TestMethod()]
        public void DetailsGoodIdTest()
        {
            var emp1 = new Employee() { employeeId = 1000 };
            var emp2 = new Employee() { employeeId = 2000 };
            IList<Employee> employees = new List<Employee>()
            {
                emp1,
                emp2
            };

            var context = new Mock<OnlineEntities>();
            var mock = CreateDbSetMock(employees);
            context.Setup(x => x.Employees).Returns(mock.Object);
            context.Setup(x => x.Employees.Find(1000)).Returns(emp1);
            var ec = new EmployeesController(context.Object);
            var detail = ec.Details(1000) as ViewResult;
            Assert.IsNotNull(detail);
            Assert.IsNotNull(detail.Model);
            Assert.IsInstanceOfType(detail.Model, typeof(Employee));
            var model = (Employee)detail.Model;
            Assert.AreEqual(1000, model.employeeId);
        }

        [TestMethod()]
        public void DetailsIdNullTest()
        {
            var emp1 = new Employee() { employeeId = 1000 };
            var emp2 = new Employee() { employeeId = 2000 };
            IList<Employee> employees = new List<Employee>()
            {
                emp1,
                emp2
            };

            var context = new Mock<OnlineEntities>();
            var mock = CreateDbSetMock(employees);
            context.Setup(x => x.Employees).Returns(mock.Object);
            context.Setup(x => x.Employees.Find(1000)).Returns(emp1);
            var ec = new EmployeesController(context.Object);
            int? bad = null;
            var detail = ec.Details(bad) as HttpStatusCodeResult;
            Assert.IsNotNull(detail);
        }

        [TestMethod()]
        public void DetailsIdNotFoundTest()
        {
            var emp1 = new Employee() { employeeId = 1000 };
            var emp2 = new Employee() { employeeId = 2000 };
            IList<Employee> employees = new List<Employee>()
            {
                emp1,
                emp2
            };

            var context = new Mock<OnlineEntities>();
            var mock = CreateDbSetMock(employees);
            context.Setup(x => x.Employees).Returns(mock.Object);
            context.Setup(x => x.Employees.Find(1000)).Returns(emp1);
            var ec = new EmployeesController(context.Object);
            var detail = ec.Details(3000) as HttpNotFoundResult;
            Assert.IsNotNull(detail);
        }

        [TestMethod()]
        public void DeleteTest()
        {
            var emp1 = new Employee() { employeeId = 1000 };
            var emp2 = new Employee() { employeeId = 2000 };
            IList<Employee> employees = new List<Employee>()
            {
                emp1,
                emp2
            };

            var context = new Mock<OnlineEntities>();
            var mock = CreateDbSetMock(employees);
            context.Setup(x => x.Employees).Returns(mock.Object);
            context.Setup(x => x.Employees.Find(1000)).Returns(emp1);
            var ec = new EmployeesController(context.Object);
            var delete = ec.Delete(1000) as ViewResult;
            Assert.IsNotNull(delete);
            Assert.IsNotNull(delete.Model);
            Assert.IsInstanceOfType(delete.Model, typeof(Employee));
            var model = (Employee)delete.Model;
            Assert.AreEqual(1000, model.employeeId);
        }
        [TestMethod()]
        public void DeleteNotFoundTest()
        {
            var emp1 = new Employee() { employeeId = 1000 };
            var emp2 = new Employee() { employeeId = 2000 };
            IList<Employee> employees = new List<Employee>()
            {
                emp1,
                emp2
            };

            var context = new Mock<OnlineEntities>();
            var mock = CreateDbSetMock(employees);
            context.Setup(x => x.Employees).Returns(mock.Object);
            context.Setup(x => x.Employees.Find(1000)).Returns(emp1);
            var ec = new EmployeesController(context.Object);
            var delete = ec.Delete(3000) as HttpNotFoundResult;
            Assert.IsNotNull(delete);
        }
        [TestMethod()]
        public void DeleteNullIdTest()
        {
            var emp1 = new Employee() { employeeId = 1000 };
            var emp2 = new Employee() { employeeId = 2000 };
            IList<Employee> employees = new List<Employee>()
            {
                emp1,
                emp2
            };

            var context = new Mock<OnlineEntities>();
            var mock = CreateDbSetMock(employees);
            context.Setup(x => x.Employees).Returns(mock.Object);
            context.Setup(x => x.Employees.Find(1000)).Returns(emp1);
            var ec = new EmployeesController(context.Object);
            var delete = ec.Delete(null) as HttpStatusCodeResult;
            Assert.IsNotNull(delete);
        }
        [TestMethod()]
        public void DeleteConfirmedTest()
        {
            var controller = setupControllerWithSession();
            var confirm = controller.DeleteConfirmed(1000) as RedirectToRouteResult;
            Assert.IsNotNull(confirm);

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

        private static EmployeesController setupControllerWithSession()
        {
            var emp1 = new Employee() { employeeId = 1000, name = "Bob", password = "whm3GC0X8np.c", isManager = true};
            var emp2 = new Employee() { employeeId = 2000, name = "Bill", password = "whm3GC0X8np.c", isManager = false };
            IList<Employee> employees = new List<Employee>()
            {
                emp1,
                emp2
            };

            var context = new Mock<OnlineEntities>();
            var mock = CreateDbSetMock(employees);

            context.Setup(x => x.Employees).Returns(mock.Object);
            context.Setup(x => x.Employees.Remove(emp1)).Returns(emp1);

            var eController = new EmployeesController(context.Object);

            var httpContext = new Mock<HttpContextBase>();
            var session = new Mock<HttpSessionStateBase>();
            session.Setup(s => s["Employee"]).Returns(emp1);
            httpContext.Setup(x => x.Session).Returns(session.Object);
            var requestContext = new RequestContext(httpContext.Object, new RouteData());
            eController.ControllerContext = new ControllerContext(requestContext, eController);

            return eController;
        }

        private static EmployeesController setupControllerWithoutSession()
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

            var eController = new EmployeesController(context.Object);

            var httpContext = new Mock<HttpContextBase>();
            var session = new Mock<HttpSessionStateBase>();
            session.Setup(s => s["Employee"]).Returns(null);
            httpContext.Setup(x => x.Session).Returns(session.Object);
            var requestContext = new RequestContext(httpContext.Object, new RouteData());
            eController.ControllerContext = new ControllerContext(requestContext, eController);

            return eController;
        }

        private static EmployeesController setupControllerNotManagerSession()
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

            var eController = new EmployeesController(context.Object);

            var httpContext = new Mock<HttpContextBase>();
            var session = new Mock<HttpSessionStateBase>();
            session.Setup(s => s["Employee"]).Returns(emp2);
            httpContext.Setup(x => x.Session).Returns(session.Object);
            var requestContext = new RequestContext(httpContext.Object, new RouteData());
            eController.ControllerContext = new ControllerContext(requestContext, eController);

            return eController;
        }

    }
}