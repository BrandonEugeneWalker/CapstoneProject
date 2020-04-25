using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Capstone_Database.Model;
using Capstone_Desktop.Model;

namespace Capstone_Desktop.Controller
{
    /// <summary>
    ///     <para>This class handles interactions between the ManageRentalsForm and the Database.</para>
    ///     <para>Most methods require a database to be passed as well as the rental.</para>
    /// </summary>
    public class ManageRentalsController
    {
        #region Data members

        private const string RentalNullError = @"The rental to edit cannot be null!";
        private const string EmployeeNullError = @"The employee to update a rental with cannot be null!";

        #endregion

        public IDbContextHandler CapstoneDatabaseHandler { get; set; }

        /// <summary>
        ///   <para>
        ///  Initializes a new instance of the <see cref="ManageRentalsController"/> class.
        /// </para>
        ///   <para>Acts as a intermediary between the view and database handler.</para>
        /// </summary>
        /// <Precondition> None </Precondition>
        /// <Postcondition> A new instance is created. </Postcondition>
        public ManageRentalsController()
        {
            this.CapstoneDatabaseHandler = new CapstoneDbContextHandler();
        }

        /// <summary>
        ///   <para>
        ///  Initializes a new instance of the <see cref="ManageRentalsController"/> class.
        /// </para>
        ///   <para>Acts as a intermediary between the view and database handler.</para>
        /// </summary>
        /// <param name="capstoneDatabaseHandler">The capstone database handler.</param>
        /// <exception cref="ArgumentNullException">capstoneDatabaseHandler - The database handler cannot be null!</exception>
        /// <Precondition> The database handler cannot be null! </Precondition>
        /// <Postcondition> A new instance is created. </Postcondition>
        public ManageRentalsController(IDbContextHandler capstoneDatabaseHandler)
        {
            this.CapstoneDatabaseHandler = capstoneDatabaseHandler ??
                                           throw new ArgumentNullException(nameof(capstoneDatabaseHandler),
                                               @"The database handler cannot be null!");
        }

        #region Methods

        /// <summary>
        ///     <para>
        ///         Gets the rentals waiting shipment and returns it.
        ///     </para>
        ///     <para>The list should be a binding list so any changes should reflect on the database.</para>
        /// </summary>
        /// <returns>A list of rentals waiting shipment.</returns>
        /// <exception cref="System.ArgumentNullException">capstoneDbContext</exception>
        /// <Precondition> None </Precondition>
        public List<DetailedRentalView> GetRentalsWaitingShipment()
        {
            return this.CapstoneDatabaseHandler.GetDetailedRentalsWaitingShipment().OrderByDescending(x => x.rentalDateTime)
                       .ToList();
        }

        /// <summary>
        ///     <para>
        ///         Gets the rentals waiting return and returns it.
        ///     </para>
        ///     <para>List should have binding with the database, so changes will reflect in the database.</para>
        /// </summary>
        /// <returns>A list of rentals waiting to be returned.</returns>
        /// <exception cref="System.ArgumentNullException">capstoneDbContext</exception>
        /// <Precondition> None </Precondition>
        public List<DetailedRentalView> GetRentalsWaitingReturn()
        {
            return this.CapstoneDatabaseHandler.GetDetailedRentalsWaitingReturn().OrderByDescending(x => x.rentalDateTime).ToList();
        }

        /// <summary>
        ///     <para>
        ///         Gets all the detailed rental information from the database and returns it as a bound list.
        ///     </para>
        /// </summary>
        /// <returns>The list of detailed rentals in the database.</returns>
        /// <exception cref="ArgumentNullException">capstoneDbContext</exception>
        /// <Precondition> None </Precondition>
        public List<DetailedRentalView> GetAllRentals()
        {
            return this.CapstoneDatabaseHandler.GetAllDetailedRentals().OrderByDescending(x => x.rentalDateTime).ToList();
        }

        /// <summary>
        ///     <para>
        ///         Marks the rental as waiting return.
        ///     </para>
        ///     <para>Throws an exception if the database or rental is null.</para>
        /// </summary>
        /// <param name="detailedRentalView">The detailed rental view.</param>
        /// <param name="employee">The employee handing the action.</param>
        /// <returns>True if successful, false if not.</returns>
        /// <exception cref="System.ArgumentNullException">
        ///     employee
        ///     or
        ///     detailedRentalView
        /// </exception>
        /// <Precondition> detailedRentalView and employee cannot be null! </Precondition>
        public bool MarkRentalAsWaitingReturn(DetailedRentalView detailedRentalView,
            Employee employee)
        {
            if (detailedRentalView == null)
            {
                throw new ArgumentNullException(nameof(detailedRentalView), RentalNullError);
            }

            if (employee == null)
            {
                throw new ArgumentNullException(nameof(employee), EmployeeNullError);
            }

            return this.CapstoneDatabaseHandler.MarkRentalAsWaitingReturn(detailedRentalView, employee);
        }

        /// <summary>
        ///     <para>
        ///         Marks the rental as returned.
        ///     </para>
        ///     <para>Throws an exception if either the database or rental are null.</para>
        /// </summary>
        /// <param name="detailedRentalView">The detailed rental view.</param>
        /// <param name="employee">The employee marking the rental as returned.</param>
        /// <returns>True if successful, false if not.</returns>
        /// <exception cref="System.ArgumentNullException">
        ///     employee
        ///     or
        ///     detailedRentalView
        /// </exception>
        /// <Precondition> detailedRentalView and employee cannot be null! </Precondition>
        public bool MarkRentalAsReturned(DetailedRentalView detailedRentalView,
            Employee employee, string itemCondition)
        {
            if (detailedRentalView == null)
            {
                throw new ArgumentNullException(nameof(detailedRentalView), RentalNullError);
            }

            if (employee == null)
            {
                throw new ArgumentNullException(nameof(employee), EmployeeNullError);
            }

            if (string.IsNullOrEmpty(itemCondition))
            {
                throw new ArgumentNullException(nameof(itemCondition), @"The item condition cannot be null or empty!");
            }

            return this.CapstoneDatabaseHandler.MarkRentalAsReturned(detailedRentalView, employee, itemCondition);
        }


        #endregion
    }
}