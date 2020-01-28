using System;
using System.Transactions;
using Capstone_Desktop.Database.employee;
using Capstone_Desktop.Model;
using MySql.Data.MySqlClient;
using NUnit.Framework;

namespace Capstone_Desktop_Tests.Model_Tests
{
    internal class SQLCommandTests
    {
        #region Methods

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestSelectingNewEmployee()
        {
            using (var transactionScope = new TransactionScope())
            {
                var returnedEmployee = SelectEmployeeSqlCommands.GetEmployeeByIdPassword(1234, "password");
                Assert.NotNull(returnedEmployee);
                Assert.AreEqual("Brandon Walker", returnedEmployee.EmployeeName);
                Assert.AreEqual(1234, returnedEmployee.EmployeeId);
                Assert.True(returnedEmployee.IsManager);
            }
        }

        [Test]
        public void TestInsertNewEmployeeSunnyDay()
        {
            using (var transactionScope = new TransactionScope())
            {
                var newEmployee = new Employee(101, "Name", false);
                var result = InsertEmployeeSqlCommands.InsertEmployee(newEmployee, "password");
                Assert.True(result);

                var returnedEmployee = SelectEmployeeSqlCommands.GetEmployeeByIdPassword(101, "password");
                Assert.NotNull(returnedEmployee);
                Assert.AreEqual("Name", returnedEmployee.EmployeeName);
                Assert.AreEqual(101, returnedEmployee.EmployeeId);
                Assert.False(returnedEmployee.IsManager);
            }
        }

        [Test]
        public void TestInsertNewEmployeeFailDuplicateEmployeeId()
        {
            using (var transactionScope = new TransactionScope())
            {
                var newEmployee = new Employee(1234, "Name", false);
                Assert.Throws<MySqlException>(() =>
                {
                    var result = InsertEmployeeSqlCommands.InsertEmployee(newEmployee, "password");
                });
            }
        }

        [Test]
        public void TestInsertingEmployeeWithEmptyPassword()
        {
            using (var transactionScope = new TransactionScope())
            {
                var newEmployee = new Employee(1234, "Name", false);
                Assert.Throws<ArgumentNullException>(() =>
                {
                    var result = InsertEmployeeSqlCommands.InsertEmployee(newEmployee, "");
                });
            }
        }

        [Test]
        public void TestInsertingEmployeeWithNullPassword()
        {
            using (var transactionScope = new TransactionScope())
            {
                var newEmployee = new Employee(1234, "Name", false);
                Assert.Throws<ArgumentNullException>(() =>
                {
                    var result = InsertEmployeeSqlCommands.InsertEmployee(newEmployee, null);
                });
            }
        }

        #endregion
    }
}