using System;
using Capstone_Desktop.Model;
using NUnit.Framework;

namespace Capstone_Desktop_Tests.Model_Tests
{
    /// <summary>Handles testing of the Employee class.</summary>
    public class EmployeeTests
    {
        #region Methods

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void SunnyDayConstruction()
        {
            var testEmployee = new Employee(1234, "Name", false);
            Assert.AreEqual(testEmployee.EmployeeName, "Name");
            Assert.AreEqual(testEmployee.EmployeeId, 1234);
            Assert.False(testEmployee.IsManager);
        }

        [Test]
        public void LowerBoundConstructionPass()
        {
            var testEmployee = new Employee(1, "Name", false);
            Assert.AreEqual(testEmployee.EmployeeName, "Name");
            Assert.AreEqual(testEmployee.EmployeeId, 1);
            Assert.False(testEmployee.IsManager);
        }

        [Test]
        public void UpperBoundIdConstructionFail()
        {
            var exception = Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                var testEmployee = new Employee(0, "Name", false);
            });
            Assert.AreEqual("The employee id must be greater than zero. (Parameter 'id')", exception.Message);
        }

        [Test]
        public void PastBoundaryIdConstructionFail()
        {
            var exception = Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                var testEmployee = new Employee(-1, "Name", false);
            });
            Assert.AreEqual("The employee id must be greater than zero. (Parameter 'id')", exception.Message);
        }

        [Test]
        public void EmptyNameConstructionFail()
        {
            var exception = Assert.Throws<ArgumentNullException>(() =>
            {
                var testEmployee = new Employee(1234, "", false);
            });
            Assert.AreEqual("The employee's name cannot be null or empty. (Parameter 'name')", exception.Message);
        }

        [Test]
        public void NullNameConstructionFail()
        {
            var exception = Assert.Throws<ArgumentNullException>(() =>
            {
                var testEmployee = new Employee(1234, null, false);
            });
            Assert.AreEqual("The employee's name cannot be null or empty. (Parameter 'name')", exception.Message);
        }

        #endregion
    }
}