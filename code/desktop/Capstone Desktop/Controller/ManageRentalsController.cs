using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;
using Capstone_Database.Model;

namespace Capstone_Desktop.Controller
{
    /// <summary>
    ///     <para>This class handles interactions between the ManageRentalsForm and the Database.</para>
    ///     <para>Most methods require a database to be passed as well as the rental.</para>
    /// </summary>
    public class ManageRentalsController
    {
        #region Data members

        private const string DbContextNullError = @"The database to get the data from cannot be null!";
        private const string RentalNullError = @"The rental to edit cannot be null!";
        private const string EmployeeNullError = @"The employee to update a rental with cannot be null!";

        #endregion

        #region Methods

        /// <summary>
        ///     <para>
        ///         Gets the rentals waiting shipment and returns it.
        ///     </para>
        ///     <para>The list should be a binding list so any changes should reflect on the database.</para>
        /// </summary>
        /// <param name="capstoneDbContext">The capstone database context.</param>
        /// <returns>A list of rentals waiting shipment.</returns>
        /// <exception cref="System.ArgumentNullException">capstoneDbContext</exception>
        public List<DetailedRentalView> GetRentalsWaitingShipment(OnlineEntities capstoneDbContext)
        {
            if (capstoneDbContext == null)
            {
                throw new ArgumentNullException(nameof(capstoneDbContext), DbContextNullError);
            }

            return this.selectRentalsByWaitingShipment(capstoneDbContext);
        }

        private List<DetailedRentalView> selectRentalsByWaitingShipment(OnlineEntities capstoneDbContext)
        {
            var rentalsWaitingShipmentQueryable = this.GetAllRentals(capstoneDbContext).Where(rental =>
                                                           rental.status.Equals("WaitingShipment"));

            return rentalsWaitingShipmentQueryable.ToList();
        }

        /// <summary>
        ///     <para>
        ///         Gets the rentals waiting return and returns it.
        ///     </para>
        ///     <para>List should have binding with the database, so changes will reflect in the database.</para>
        /// </summary>
        /// <param name="capstoneDbContext">The capstone database context.</param>
        /// <returns>A list of rentals waiting to be returned.</returns>
        /// <exception cref="System.ArgumentNullException">capstoneDbContext</exception>
        public List<DetailedRentalView> GetRentalsWaitingReturn(OnlineEntities capstoneDbContext)
        {
            if (capstoneDbContext == null)
            {
                throw new ArgumentNullException(nameof(capstoneDbContext), DbContextNullError);
            }

            return this.selectRentalsByWaitingReturn(capstoneDbContext);
        }

        private List<DetailedRentalView> selectRentalsByWaitingReturn(OnlineEntities capstoneDbContext)
        {

            var rentalsWaitingReturnQueryable = this.GetAllRentals(capstoneDbContext).Where(rental =>
                                                    rental.status.Equals("WaitingReturn"));

            return rentalsWaitingReturnQueryable.ToList();
        }

        public BindingList<DetailedRentalView> GetAllRentals(OnlineEntities capstoneDbContext)
        {
            if (capstoneDbContext == null)
            {
                throw new ArgumentNullException(nameof(capstoneDbContext), DbContextNullError);
            }

            capstoneDbContext.DetailedRentalViews.Load();

            return capstoneDbContext.DetailedRentalViews.Local.ToBindingList();
        }

        /// <summary>
        ///   <para>
        ///       Marks the rental as waiting return.
        ///   </para>
        ///   <para>Throws an exception if the database or rental is null.</para>
        /// </summary>
        /// <param name="detailedRentalView">The detailed rental view.</param>
        /// <param name="capstoneDbContext">The capstone database context.</param>
        /// <param name="employee">The employee handing the action.</param>
        /// <returns>True if successful, false if not.</returns>
        /// <exception cref="System.ArgumentNullException">capstoneDbContext
        ///   or
        ///   detailedRentalView</exception>
        public bool MarkRentalAsWaitingReturn(DetailedRentalView detailedRentalView, OnlineEntities capstoneDbContext,
            Employee employee)
        {
            if (capstoneDbContext == null)
            {
                throw new ArgumentNullException(nameof(capstoneDbContext), DbContextNullError);
            }

            if (detailedRentalView == null)
            {
                throw new ArgumentNullException(nameof(detailedRentalView), RentalNullError);
            }

            if (employee == null)
            {
                throw new ArgumentNullException(nameof(employee), EmployeeNullError);
            }

            if (!detailedRentalView.status.Equals("WaitingShipment"))
            {
                return false;
            }

            capstoneDbContext.ItemRentals.Load();
            var currentRental = capstoneDbContext.ItemRentals.Find(detailedRentalView.stockId);

            if (currentRental == null)
            {
                return false;
            }

            currentRental.status = "WaitingReturn";
            currentRental.shipEmployeeId = employee.employeeId;
            currentRental.shipDateTime = DateTime.Now;
            capstoneDbContext.SaveChanges();
            return true;
        }

        /// <summary>
        ///   <para>
        ///       Marks the rental as returned.
        ///   </para>
        ///   <para>Throws an exception if either the database or rental are null.</para>
        /// </summary>
        /// <param name="detailedRentalView">The detailed rental view.</param>
        /// <param name="capstoneDbContext">The capstone database context.</param>
        /// <param name="employee">The employee marking the rental as returned.</param>
        /// <returns>True if successful, false if not.</returns>
        /// <exception cref="System.ArgumentNullException">capstoneDbContext
        ///   or
        ///   detailedRentalView</exception>
        public bool MarkRentalAsReturned(DetailedRentalView detailedRentalView, OnlineEntities capstoneDbContext,
            Employee employee)
        {
            if (capstoneDbContext == null)
            {
                throw new ArgumentNullException(nameof(capstoneDbContext), DbContextNullError);
            }

            if (detailedRentalView == null)
            {
                throw new ArgumentNullException(nameof(detailedRentalView), RentalNullError);
            }

            if (employee == null)
            {
                throw new ArgumentNullException(nameof(employee), EmployeeNullError);
            }

            if (!detailedRentalView.status.Equals("WaitingReturn"))
            {
                return false;
            }

            capstoneDbContext.ItemRentals.Load();
            var currentRental = capstoneDbContext.ItemRentals.Find(detailedRentalView.stockId);

            if (currentRental == null)
            {
                return false;
            }

            currentRental.status = "Returned";
            currentRental.shipEmployeeId = employee.employeeId;
            currentRental.shipDateTime = DateTime.Now;
            capstoneDbContext.SaveChanges();
            return true;
        }

        #endregion
    }
}