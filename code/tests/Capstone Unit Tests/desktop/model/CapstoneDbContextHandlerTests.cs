using System;
using System.Data.Entity;
using Capstone_Database.Model;
using Capstone_Desktop.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Capstone_Unit_Tests.desktop.model
{
    [TestClass]
    public class CapstoneDbContextHandlerTests
    {
        [TestMethod]
        public void TestOverloadedConstructorNull()
        {
            Assert.ThrowsException<ArgumentNullException>(() => new CapstoneDbContextHandler(null));
        }

        [TestMethod]
        public void TestOverloadedConstructorSunnyDay()
        {
            var testHandler = new CapstoneDbContextHandler(new OnlineEntities());
            Assert.IsNotNull(testHandler);
        }

        [TestMethod]
        public void TestGetDetailedEmployeeHistoryNullEmployee()
        {
            var testHandler = new CapstoneDbContextHandler();
            Assert.ThrowsException<ArgumentNullException>(() => testHandler.GetDetailedEmployeeHistory(null));
        }

        [TestMethod]
        public void TestGetDetailedEmployeeHistoryNoHistory()
        {
            var testHandler = new CapstoneDbContextHandler();
            using (var transaction = testHandler.CapstoneDbContext.Database.BeginTransaction())
            {
                Employee testEmployee = new Employee {
                    employeeId = 1,
                    password = "password",
                    isManager = false,
                    name = "TestEmployee"
                };

                testHandler.CapstoneDbContext.Employees.Add(testEmployee);

                var results = testHandler.GetDetailedEmployeeHistory(testEmployee);

                Assert.AreEqual(results.Count, 0);
            }
        }

        [TestMethod]
        public void TestGetDetailedEmployeeHistoryWithHistory()
        {
            var testHandler = new CapstoneDbContextHandler();
            using (var transaction = testHandler.CapstoneDbContext.Database.BeginTransaction())
            {
                testHandler.CapstoneDbContext.Employees.Load();
                var testEmployee = testHandler.CapstoneDbContext.Employees.Find(1234);

                var results = testHandler.GetDetailedEmployeeHistory(testEmployee);

                Assert.IsTrue(results.Count > 0);
            }
        }

        [TestMethod]
        public void TestGetDetailedStockHistoryNullStock()
        {
            var testHandler = new CapstoneDbContextHandler();
            Assert.ThrowsException<ArgumentNullException>(() => testHandler.GetDetailedStockHistory(null));
        }

        [TestMethod]
        public void TestGetDetailedStockHistoryNoHistory()
        {
            var testHandler = new CapstoneDbContextHandler();
            using (var transaction = testHandler.CapstoneDbContext.Database.BeginTransaction())
            {
                Stock testStock = new Stock {
                    stockId = -1,
                    productId = 1,
                    itemCondition = "Good"
                };
                testHandler.CapstoneDbContext.Stocks.Add(testStock);

                var results = testHandler.GetDetailedStockHistory(testStock);

                Assert.AreEqual(results.Count, 0);
            }
        }

        [TestMethod]
        public void TestGetDetailedStockHistoryWithHistory()
        {
            var testHandler = new CapstoneDbContextHandler();
            using (var transaction = testHandler.CapstoneDbContext.Database.BeginTransaction())
            {
                
                testHandler.CapstoneDbContext.Stocks.Load();

                var testStock = testHandler.CapstoneDbContext.Stocks.Find(1);

                var results = testHandler.GetDetailedStockHistory(testStock);

                Assert.IsTrue(results.Count > 0);
            }
        }
    }
}