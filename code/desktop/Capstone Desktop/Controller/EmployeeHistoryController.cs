using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using Capstone_Database.Model;

namespace Capstone_Desktop.Controller
{
    /// <summary>
    ///     <para>This class handles functionality for the EmployeeHistoryForm.</para>
    ///     <para>Most methods will require a valid Employee to be passed as a parameter.</para>
    /// </summary>
    public class EmployeeHistoryController
    {
        #region Data members

        private const string EmployeeNullMessage = @"The given employee cannot be null!";

        #endregion

        #region Methods

        /// <summary>Gets the employee history of a given employee.</summary>
        /// <param name="employee">The employee.</param>
        /// <param name="capstoneDbContext">The capstone database context.</param>
        /// <returns>Returns a list of all rentals a employee has managed.</returns>
        public List<DetailedRentalView> GetEmployeeHistory(Employee employee, OnlineEntities capstoneDbContext)
        {
            if (employee == null)
            {
                throw new ArgumentNullException(nameof(employee), EmployeeNullMessage);
            }

            if (capstoneDbContext == null)
            {
                throw new ArgumentNullException(nameof(capstoneDbContext),
                    @"The given database context cannot be null!");
            }

            return this.SelectDetailedRentalsByEmployee(capstoneDbContext, employee);
        }

        public List<DetailedRentalView> SelectDetailedRentalsByEmployee(OnlineEntities capstoneDbContext, Employee employee)
        {
            capstoneDbContext.DetailedRentalViews.Load();

            var employeeHistoryQueryable = capstoneDbContext.DetailedRentalViews.Local.ToBindingList().Where(rental =>
                                                                rental.shipEmployeeId.Equals(employee.employeeId) ||
                                                                rental.returnEmployeeId.Equals(employee.employeeId))
                                                            .Distinct();

            return employeeHistoryQueryable.ToList();
        }

        /// <summary>
        ///     <para>
        ///         Builds the employee description. based on the given employee.
        ///     </para>
        ///     <para>If the employee is null an error is thrown.</para>
        /// </summary>
        /// <param name="employee">The employee to describe.</param>
        /// <returns>Returns a string describing a Employee for the UI.</returns>
        public string BuildEmployeeDescription(Employee employee)
        {
            if (employee == null)
            {
                throw new ArgumentNullException(nameof(employee), EmployeeNullMessage);
            }

            var stringBuilder = new StringBuilder();
            stringBuilder.Append(" Name: " + employee.name);
            stringBuilder.Append(" ID: " + employee.employeeId);
            return stringBuilder.ToString();
        }

        #endregion
    }
}