using Microsoft.VisualStudio.TestTools.UnitTesting;
using Capstone_Web_Warehouse.Controllers;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Capstone_Database.Model;
using Moq;

namespace Capstone_Web_Warehouse.Controllers.Tests
{
    [TestClass()]
    public class EmployeesControllerTests
    {
        [TestMethod()]
        public void EditViewGoodIDTest()
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
            var edit = ec.Edit(1000) as ViewResult;
            Assert.IsNotNull(edit);
            Assert.IsNotNull(edit.Model);
            Assert.IsInstanceOfType(edit.Model, typeof(Employee));
            var model = (Employee) edit.Model;
            Assert.AreEqual(1000,model.employeeId);
        }

        [TestMethod()]
        public void EditNullIdTest()
        {
            var emp1 = new Employee() { employeeId = 1000, name = "Bob"};
            var emp2 = new Employee() { employeeId = 2000 };
            IList<Employee> employees = new List<Employee>()
            {
                emp1,
                emp2
            };

            var context = new Mock<OnlineEntities>();
            var mock = CreateDbSetMock(employees);
            context.Setup(x => x.Employees).Returns(mock.Object);
            context.Setup(x => x.Employees.Find(1000)).Returns(emp2);
            var ec = new EmployeesController(context.Object);
            int? bad = null;
            var edit = ec.Edit(bad) as ViewResult;
            Assert.IsNull(edit);
        }

        [TestMethod()]
        public void EditIdNotFoundTest()
        {
            var emp1 = new Employee() { employeeId = 1000, name = "Bob" };
            var emp2 = new Employee() { employeeId = 2000 };
            IList<Employee> employees = new List<Employee>()
            {
                emp1,
                emp2
            };

            var context = new Mock<OnlineEntities>();
            var mock = CreateDbSetMock(employees);
            context.Setup(x => x.Employees).Returns(mock.Object);
            context.Setup(x => x.Employees.Find(1000)).Returns(emp2);
            var ec = new EmployeesController(context.Object);
            var edit = ec.Edit(3) as ViewResult;
            Assert.IsNull(edit);
        }

        [TestMethod()]
        public void EditIdMismatchTest()
        {
            var emp1 = new Employee() { employeeId = 1000, name = "Bob" };
            var emp2 = new Employee() { employeeId = 2000 };
            IList<Employee> employees = new List<Employee>()
            {
                emp1,
                emp2
            };

            var context = new Mock<OnlineEntities>();
            var mock = CreateDbSetMock(employees);
            context.Setup(x => x.Employees).Returns(mock.Object);
            context.Setup(x => x.Employees.Find(1000)).Returns(emp2);
            var ec = new EmployeesController(context.Object);
            var edit = ec.Edit(2000) as ViewResult;
            Assert.IsNull(edit);
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
            var detail = ec.Details(bad) as ViewResult;
            Assert.IsNull(detail);
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
            var detail = ec.Details(3000) as ViewResult;
            Assert.IsNull(detail);
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