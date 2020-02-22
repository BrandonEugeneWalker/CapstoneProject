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
        public void EditViewTest()
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
        public void EditClickTest()
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
            var edited = new Employee() { employeeId = 1000, name = "Bobby" };
            var edit = ec.Edit(edited) as ViewResult;
            Assert.IsNotNull(edit);
            Assert.IsNotNull(edit.Model);
            Assert.IsInstanceOfType(edit.Model, typeof(Employee));
            var model = (Employee)edit.Model;
            Assert.AreEqual(1000, model.employeeId);
        }

        [TestMethod()]
        public void IndexTest()
        {
            IList<Employee> employees = new List<Employee>()
            {
                new Employee(){employeeId = 1},
                new Employee()
            };
            var mock = CreateDbSetMock(employees);
            var context = new Mock<OnlineEntities>();
            context.Setup(x => x.Employees).Returns(mock.Object);

            var ec = new EmployeesController(context.Object);

            var index = ec.Index() as ViewResult;
            var edit = ec.Edit(1) as ViewResult;
            //var actual = edit.Model as Employee;
            Assert.IsNotNull(index);
            Assert.IsNotNull(index.Model);
            Assert.IsInstanceOfType(index.Model, typeof(IEnumerable<Employee>));
        }

        [TestMethod()]
        public void DetailsTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void CreateTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void CreateTest1()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void EditTest1()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void EditTest2()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void DeleteTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void DeleteConfirmedTest()
        {
            Assert.Fail();
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