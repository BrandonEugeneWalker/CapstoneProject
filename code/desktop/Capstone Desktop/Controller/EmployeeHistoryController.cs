using System;
using System.Collections.Generic;
using System.Text;
using Capstone_Database.Model;
using Capstone_Desktop.Model;

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

        public IDbContextHandler CapstoneDatabaseHandler;

        #endregion

        #region Constructors

        /// <summary>
        ///     <para>
        ///         Initializes a new instance of the <see cref="EmployeeHistoryController" /> class.
        ///     </para>
        ///     <para>Separates database logic from the view with this class acting as an intermediary.</para>
        /// </summary>
        /// <Precondition> None </Precondition>
        /// <Postcondition> The new instance is created. </Postcondition>
        public EmployeeHistoryController()
        {
            this.CapstoneDatabaseHandler = new CapstoneDbContextHandler();
        }

        /// <summary>
        ///     <para>
        ///         Initializes a new instance of the <see cref="EmployeeHistoryController" /> class.
        ///     </para>
        ///     <para>Separates database logic from the view with the controller acting as the intermediary.</para>
        /// </summary>
        /// <param name="capstoneDatabaseHandler">The capstone database handler.</param>
        /// <exception cref="ArgumentNullException">capstoneDatabaseHandler - The database handler cannot be null!</exception>
        /// <Precondition> None </Precondition>
        /// <Postcondition> The new instance is created. </Postcondition>
        public EmployeeHistoryController(IDbContextHandler capstoneDatabaseHandler)
        {
            this.CapstoneDatabaseHandler = capstoneDatabaseHandler ??
                                           throw new ArgumentNullException(nameof(capstoneDatabaseHandler),
                                               @"The database handler cannot be null!");
        }

        #endregion

        #region Methods

        /// <summary>
        ///     <para>Gets the employee history of a given employee and returns it as a list</para>
        ///     <para>The list contains detailed rentals.</para>
        /// </summary>
        /// <param name="employee">The employee to get the history for.</param>
        /// <returns>Returns a list of all rentals a employee has managed.</returns>
        /// <Precondition> The employee cannot be null!  </Precondition>
        public List<DetailedRentalView> GetEmployeeHistory(Employee employee)
        {
            if (employee == null)
            {
                throw new ArgumentNullException(nameof(employee), EmployeeNullMessage);
            }

            return this.CapstoneDatabaseHandler.GetDetailedEmployeeHistory(employee);
        }

        /// <summary>
        ///     <para>
        ///         Builds the employee description. based on the given employee.
        ///     </para>
        ///     <para>If the employee is null an error is thrown.</para>
        /// </summary>
        /// <param name="employee">The employee to describe.</param>
        /// <returns>Returns a string describing a Employee for the UI.</returns>
        /// <Precondition> The employee cannot be null! </Precondition>
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