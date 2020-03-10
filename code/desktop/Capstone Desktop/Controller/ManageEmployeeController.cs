using System;
using System.ComponentModel;
using System.Data.Entity;
using Capstone_Database.Model;

namespace Capstone_Desktop.Controller
{
    /// <summary>
    ///     <para>Handles communications between the view and the database.</para>
    ///     <para>Has methods for getting and removing employees.</para>
    /// </summary>
    public class ManageEmployeeController
    {
        #region Methods

        /// <summary>
        ///     <para>
        ///         Removes the employee from database.
        ///     </para>
        ///     <para>The employee and the database cannot be null.</para>
        /// </summary>
        /// <param name="employee">The employee to remove.</param>
        /// <param name="capstoneDbContext">The capstone database context.</param>
        /// <exception cref="ArgumentNullException">
        ///     employee - The employee to remove cannot be null!
        ///     or
        ///     capstoneDbContext - The database to remove the employee from cannot be null!
        /// </exception>
        public void RemoveEmployeeFromDatabase(Employee employee, OnlineEntities capstoneDbContext)
        {
            if (employee == null)
            {
                throw new ArgumentNullException(nameof(employee), @"The employee to remove cannot be null!");
            }

            if (capstoneDbContext == null)
            {
                throw new ArgumentNullException(nameof(capstoneDbContext),
                    @"The database to remove the employee from cannot be null!");
            }

            this.deleteGivenEmployeeFromDatabase(capstoneDbContext, employee);
        }

        private void deleteGivenEmployeeFromDatabase(OnlineEntities capstoneDbContext, Employee employee)
        {
            capstoneDbContext.Employees.Load();
            capstoneDbContext.Employees.Remove(employee);
            capstoneDbContext.SaveChanges();
        }

        /// <summary>
        ///     <para>
        ///         Gets and returns the employees in the database.
        ///     </para>
        ///     <para>Uses the DbContext in order to do this.</para>
        /// </summary>
        /// <param name="capstoneDbContext">The capstone database context.</param>
        /// <returns>A binding list of employees.</returns>
        public BindingList<Employee> GetEmployees(OnlineEntities capstoneDbContext)
        {
            if (capstoneDbContext == null)
            {
                throw new ArgumentNullException(nameof(capstoneDbContext), @"The database to get from cannot be null!");
            }
            capstoneDbContext.Employees.Load();
            return capstoneDbContext.Employees.Local.ToBindingList();
        }

        #endregion
    }
}