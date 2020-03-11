using System;
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
    /// Summary description for RentalsControllerTest
    /// </summary>
    [TestClass]
    public class RentalsControllerTest
    {
        [TestMethod]
        public void ControllerTest()
        {
            var controller = new RentalsController();
            Assert.IsNotNull(controller);
        }

        [TestMethod()]
        public void IndexNoLoginTest()
        {
            var controller = setupControllerWithoutSession();

            var index = controller.Index() as RedirectResult;
            controller.Dispose();
            Assert.IsNotNull(index);
        }

        [TestMethod()]
        public void IndexLoginTest()
        {
            var controller = setupControllerWithSession();

            var index = controller.Index() as ViewResult;

            Assert.IsNotNull(index);
        }

        [TestMethod]
        public void UpdateStatusNotFoundTest()
        {
            var controller = setupControllerWithSession();

            var update = controller.UpdateStatus(4) as HttpStatusCodeResult;

            Assert.IsNotNull(update);
        }
        [TestMethod]
        public void UpdateStatusReturnedTest()
        {
            var controller = setupControllerWithSession();

            var update = controller.UpdateStatus(1);

            Assert.IsNotNull(update);
        }

        [TestMethod]
        public void UpdateStatusShipTest()
        {
            var controller = setupControllerWithSession();

            var update = controller.UpdateStatus(2);

            Assert.IsNotNull(update);
        }

        [TestMethod]
        public void UpdateStatusWaitReturnTest()
        {
            var controller = setupControllerWithSession();

            var update = controller.UpdateStatus(3);

            Assert.IsNotNull(update);
        }

        [TestMethod]
        public void UpdateStatusNullIDTest()
        {
            var controller = setupControllerWithSession();

            var update = controller.UpdateStatus(null) as HttpStatusCodeResult;

            Assert.IsNotNull(update);
        }

        [TestMethod]
        public void UpdateStatusNoLoginTest()
        {
            var controller = setupControllerWithoutSession();

            var update = controller.UpdateStatus(null) as HttpStatusCodeResult;

            Assert.IsNotNull(update);
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

        private static RentalsController setupControllerWithSession()
        {
            var emp1 = new Employee() { employeeId = 1000, name = "Bob", password = "whm3GC0X8np.c", isManager = true };
            var emp2 = new Employee() { employeeId = 2000, name = "Bill", password = "whm3GC0X8np.c", isManager = false };

            var rent1 = new ItemRental(){itemRentalId = 1, stockId = 1, memberId = 1, status = "Returned", rentalDateTime = DateTime.Now};
            var rent2 = new ItemRental() { itemRentalId = 2, stockId = 1, memberId = 1, status = "WaitingReturn", rentalDateTime = DateTime.Now };
            var rent3 = new ItemRental() { itemRentalId = 3, stockId = 1, memberId = 1, status = "WaitingShipment", rentalDateTime = DateTime.Now };
            IList<ItemRental> rentals = new List<ItemRental>()
            {
                rent1,
                rent2,
                rent3
            };
            var context = new Mock<OnlineEntities>();
            var mock = CreateDbSetMock(rentals);

            context.Setup(x => x.ItemRentals).Returns(mock.Object);
            context.Setup(x => x.ItemRentals.Find(rent1)).Returns(rent1);
            context.Setup(x => x.ItemRentals.Find(rent2)).Returns(rent3);
            context.Setup(x => x.ItemRentals.Find(rent2)).Returns(rent3);

            var eController = new RentalsController(context.Object);

            var httpContext = new Mock<HttpContextBase>();
            var session = new Mock<HttpSessionStateBase>();
            session.Setup(s => s["Employee"]).Returns(emp1);
            httpContext.Setup(x => x.Session).Returns(session.Object);
            var requestContext = new RequestContext(httpContext.Object, new RouteData());
            eController.ControllerContext = new ControllerContext(requestContext, eController);

            return eController;
        }

        private static RentalsController setupControllerWithoutSession()
        {
            var emp1 = new Employee() { employeeId = 1000, name = "Bob", password = "whm3GC0X8np.c", isManager = true };
            var emp2 = new Employee() { employeeId = 2000, name = "Bill", password = "whm3GC0X8np.c", isManager = false };
            IList<Employee> employees = new List<Employee>()
            {
                emp1,
                emp2
            };
            var rent1 = new ItemRental() { itemRentalId = 1, stockId = 1, memberId = 1, status = "WaitingShipment", rentalDateTime = DateTime.Now };
            var rent2 = new ItemRental() { itemRentalId = 2, stockId = 1, memberId = 1, status = "WaitingShipment", rentalDateTime = DateTime.Now };
            var rent3 = new ItemRental() { itemRentalId = 3, stockId = 1, memberId = 1, status = "WaitingShipment", rentalDateTime = DateTime.Now };
            IList<ItemRental> rentals = new List<ItemRental>()
            {
                rent1,
                rent2,
                rent3
            };
            var context = new Mock<OnlineEntities>();
            var mock = CreateDbSetMock(employees);
            var mock2 = CreateDbSetMock(rentals);

            context.Setup(x => x.Employees).Returns(mock.Object);
            context.Setup(x => x.ItemRentals).Returns(mock2.Object);
            context.Setup(x => x.Employees.Find(1000)).Returns(emp1);

            var eController = new RentalsController(context.Object);

            var httpContext = new Mock<HttpContextBase>();
            var session = new Mock<HttpSessionStateBase>();
            session.Setup(s => s["Employee"]).Returns(null);
            httpContext.Setup(x => x.Session).Returns(session.Object);
            var requestContext = new RequestContext(httpContext.Object, new RouteData());
            eController.ControllerContext = new ControllerContext(requestContext, eController);

            return eController;
        }
    }
}
