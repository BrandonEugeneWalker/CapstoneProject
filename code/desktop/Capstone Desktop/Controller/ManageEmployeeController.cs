using System;
using System.ComponentModel;
using System.Data.Entity;
using Capstone_Database.Model;
using Capstone_Desktop.Model;

namespace Capstone_Desktop.Controller
{
    /// <summary>
    ///     <para>Handles communications between the view and the database.</para>
    ///     <para>Has methods for getting and removing employees.</para>
    /// </summary>
    public class ManageEmployeeController
    {

        public IDbContextHandler CapstoneDatabaseHandler { get; set; }

        /// <summary>
        ///   <para>
        ///  Initializes a new instance of the <see cref="ManageEmployeeController"/> class.
        /// </para>
        ///   <para>Acts as a intermediary between the view and database handler.</para>
        /// </summary>
        /// <Precondition>None</Precondition>
        /// <Postcondition>A new instance is created.</Postcondition>
        public ManageEmployeeController()
        {
            this.CapstoneDatabaseHandler = new CapstoneDbContextHandler();
        }

        /// <summary>
        ///   <para>
        ///  Initializes a new instance of the <see cref="ManageEmployeeController"/> class.
        /// </para>
        ///   <para>Acts as an intermediary between the view and database handler.</para>
        /// </summary>
        /// <param name="capstoneDatabaseHandler">The capstone database handler.</param>
        /// <exception cref="ArgumentNullException">capstoneDatabaseHandler - The database handler cannot be null!</exception>
        /// <Precondition>The database handler cannot be null!</Precondition>
        /// <Postcondition>A new instance is created.</Postcondition>
        public ManageEmployeeController(IDbContextHandler capstoneDatabaseHandler)
        {
            this.CapstoneDatabaseHandler = capstoneDatabaseHandler ??
                                           throw new ArgumentNullException(nameof(capstoneDatabaseHandler),
                                               @"The database handler cannot be null!");
        }


        #region Methods

        /// <summary>
        ///     <para>
        ///         Removes the employee from database.
        ///     </para>
        /// </summary>
        /// <param name="employee">The employee to remove.</param>
        /// <exception cref="ArgumentNullException">
        ///     employee - The employee to remove cannot be null!
        ///     or
        ///     capstoneDbContext - The database to remove the employee from cannot be null!
        /// </exception>
        /// <Precondition>The employee cannot be null!</Precondition>
        /// <Postcondition>The employee is removed from the database.</Postcondition>
        public void RemoveEmployeeFromDatabase(Employee employee)
        {
            if (employee == null)
            {
                throw new ArgumentNullException(nameof(employee), @"The employee to remove cannot be null!");
            }

            this.CapstoneDatabaseHandler.RemoveEmployee(employee);
        }

        /// <summary>
        ///     <para>
        ///         Gets and returns the employees in the database.
        ///     </para>
        /// </summary>
        /// <returns>A binding list of employees.</returns>
        /// <Precondition>None </Precondition>
        public BindingList<Employee> GetEmployees()
        {
            return this.CapstoneDatabaseHandler.GetAllEmployees();
        }

        #endregion
    }
}