using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;
using Capstone_Database.Model;

namespace Capstone_Desktop.Model
{
    /// <summary>
    ///     <para>
    ///         Implements the IDbContextHandler interface in order to provide a inbetween from controller classes and the
    ///         database.
    ///     </para>
    ///     <para>
    ///         By default this class will create a new instance of the default database used with the system. There is an
    ///         overloaded constructor that allows for a database to be passed in, making mocking database interaction more
    ///         manageable.
    ///     </para>
    /// </summary>
    /// <seealso cref="Capstone_Desktop.Model.IDbContextHandler" />
    public class CapstoneDbContextHandler : IDbContextHandler
    {
        #region Data members

        private const string EmployeeNullMessage = @"The given employee cannot be null!";
        private const string StockNullError = @"The Stock to view the history for cannot be null!";
        private const string RentalNullError = @"The rental to edit cannot be null!";

        #endregion

        #region Properties

        /// <summary>
        ///     <para>
        ///         The database DbContext used for database operations.
        ///     </para>
        ///     <para>Allows for getting and setting.</para>
        /// </summary>
        /// <value>The capstone database context.</value>
        public OnlineEntities CapstoneDbContext { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        ///     <para>
        ///         Initializes a new instance of the <see cref="CapstoneDbContextHandler" /> class.
        ///     </para>
        ///     <para>Creates the new instance with a new database object.</para>
        /// </summary>
        /// <Precondition>None</Precondition>
        /// <Postcondition>The object is created.</Postcondition>
        public CapstoneDbContextHandler()
        {
            this.CapstoneDbContext = new OnlineEntities();
        }

        /// <summary>
        ///     <para>
        ///         Initializes a new instance of the <see cref="CapstoneDbContextHandler" /> class.
        ///     </para>
        ///     <para>Creates the new instance with the given database object. This is intended for ease of mocking.</para>
        /// </summary>
        /// <param name="capstoneDbContext">The capstone database context.</param>
        /// <exception cref="ArgumentNullException">capstoneDbContext - The given database cannot be null!</exception>
        /// <Precondition>None</Precondition>
        /// <Postcondition>The object is created.</Postcondition>
        public CapstoneDbContextHandler(OnlineEntities capstoneDbContext)
        {
            this.CapstoneDbContext = capstoneDbContext ??
                                     throw new ArgumentNullException(nameof(capstoneDbContext),
                                         @"The given database cannot be null!");
        }

        #endregion

        #region Methods

        /// <summary>
        ///     <para>
        ///         Gets the detailed rental history of the given employee from the database.
        ///     </para>
        /// </summary>
        /// <param name="employee">The employee to get the history of.</param>
        /// <returns>Returns the detailed rentals that employee has worked with.</returns>
        /// <exception cref="ArgumentNullException">employee - The employee cannot be null!</exception>
        /// <Precondition>The employee cannot be null!</Precondition>
        public List<DetailedRentalView> GetDetailedEmployeeHistory(Employee employee)
        {
            if (employee == null)
            {
                throw new ArgumentNullException(nameof(employee), EmployeeNullMessage);
            }

            this.CapstoneDbContext.DetailedRentalViews.Load();

            var employeeHistoryQueryable = this.CapstoneDbContext.DetailedRentalViews.Local.ToBindingList().Where(
                                                   rental =>
                                                       rental.shipEmployeeId.Equals(employee.employeeId) ||
                                                       rental.returnEmployeeId.Equals(employee.employeeId))
                                               .Distinct();

            return employeeHistoryQueryable.ToList();
        }

        /// <summary>Gets the detailed rental history of the given stock item from the database.</summary>
        /// <param name="stock">The stock to get the history of.</param>
        /// <returns>The detailed rentals that stock item was a part of.</returns>
        /// <exception cref="ArgumentNullException">
        ///     stock
        ///     - The stock item cannot be null!
        /// </exception>
        /// <Precondition>The stock item cannot be null!</Precondition>
        public List<DetailedRentalView> GetDetailedStockHistory(Stock stock)
        {
            if (stock == null)
            {
                throw new ArgumentNullException(nameof(stock), StockNullError);
            }

            this.CapstoneDbContext.DetailedRentalViews.Load();

            var stockHistoryQueryable = this.CapstoneDbContext
                                            .DetailedRentalViews.Local.ToBindingList().Where(rental =>
                                                rental.stockId.Equals(stock.stockId));

            return stockHistoryQueryable.ToList();
        }

        /// <summary>Gets the employee by identifier and password from the database and returns it.</summary>
        /// <param name="id">The identifier used to get the employee.</param>
        /// <param name="password">The password used to get the employee.</param>
        /// <returns>The employee found using the id and password.</returns>
        /// <exception cref="ArgumentOutOfRangeException">id - The id must be a positive integer.</exception>
        /// <exception cref="ArgumentNullException">password - The password cannot be null or empty.</exception>
        /// <Precondition>The id must be a positive integer, the password cannot be null or empty!</Precondition>
        public Employee GetEmployeeByIdAndPassword(int id, string password)
        {
            if (id <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(id), @"The id must be a positive integer.");
            }

            if (string.IsNullOrEmpty(password))
            {
                throw new ArgumentNullException(nameof(password), @"The password cannot be null or empty.");
            }

            this.CapstoneDbContext.Employees.Load();

            try
            {
                return this.CapstoneDbContext.selectEmployeeByIdAndPassword(id, password).First();
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>Gets all employees from the database and returns it as a bound list.</summary>
        /// <returns>A bound list containing all the employees in the database.</returns>
        /// <Precondition>None</Precondition>
        public BindingList<Employee> GetAllEmployees()
        {
            this.CapstoneDbContext.Employees.Load();
            return this.CapstoneDbContext.Employees.Local.ToBindingList();
        }

        /// <summary>Gets all detailed stock items from the database and returns it as a bound list.</summary>
        /// <returns>A bound list containing all the detailed stock items in the database.</returns>
        /// <Precondition>None</Precondition>
        public BindingList<StockDetailView> GetAllDetailedStock()
        {
            this.CapstoneDbContext.StockDetailViews.Load();
            return this.CapstoneDbContext.StockDetailViews.Local.ToBindingList();
        }

        /// <summary>Gets the detailed rentals waiting shipment from the database.</summary>
        /// <returns>A list containing all the detailed rentals waiting to be shipped.</returns>
        /// <Precondition>None</Precondition>
        public List<DetailedRentalView> GetDetailedRentalsWaitingShipment()
        {
            var rentalsWaitingShipmentQueryable = this.GetAllDetailedRentals().Where(rental =>
                rental.status.Equals("WaitingShipment"));

            return rentalsWaitingShipmentQueryable.ToList();
        }

        /// <summary>Gets the detailed rentals waiting return from the database.</summary>
        /// <returns>A list containing all the detailed rentals waiting to be returned.</returns>
        /// <Precondition>None</Precondition>
        public List<DetailedRentalView> GetDetailedRentalsWaitingReturn()
        {
            var rentalsWaitingReturnQueryable = this.GetAllDetailedRentals().Where(rental =>
                rental.status.Equals("WaitingReturn"));

            return rentalsWaitingReturnQueryable.ToList();
        }

        /// <summary>Gets all detailed rentals from the database and returns it as a bound list.</summary>
        /// <returns>A bound list containing all of the detailed rentals in the database.</returns>
        /// <Precondition>None</Precondition>
        public BindingList<DetailedRentalView> GetAllDetailedRentals()
        {
            this.CapstoneDbContext.DetailedRentalViews.Load();

            return this.CapstoneDbContext.DetailedRentalViews.Local.ToBindingList();
        }

        /// <summary>Gets the item rental from the database by its identifier and returns it.</summary>
        /// <param name="id">The identifier used to get the rental.</param>
        /// <returns>The rental if the id exists on the database. Null if not.</returns>
        /// <Precondition>None</Precondition>
        public ItemRental GetItemRentalById(int id)
        {
            this.CapstoneDbContext.ItemRentals.Load();

            return this.CapstoneDbContext.ItemRentals.Find(id);
        }

        /// <summary>Gets the stock from the database by its identifier and returns it.</summary>
        /// <param name="id">The identifier used to get the stock.</param>
        /// <returns>The stock if the id exists on the database. Null if not.</returns>
        /// <Precondition>None</Precondition>
        public Stock GetStockById(int id)
        {
            this.CapstoneDbContext.Stocks.Load();

            return this.CapstoneDbContext.Stocks.Find(id);
        }

        /// <summary>Gets the detailed rental history of a given stock and returns it as a list.</summary>
        /// <param name="stock">The stock to get the history of.</param>
        /// <returns>A list containing all of the detailed rentals that the stock was a part of.</returns>
        /// <exception cref="ArgumentNullException">stock</exception>
        /// <Precondition>The given stock cannot be null.</Precondition>
        public List<DetailedRentalView> GetStockHistoryByStock(Stock stock)
        {
            if (stock == null)
            {
                throw new ArgumentNullException(nameof(stock), StockNullError);
            }

            this.CapstoneDbContext.DetailedRentalViews.Load();

            var stockHistoryQueryable = this.CapstoneDbContext
                                            .DetailedRentalViews.Local.ToBindingList().Where(rental =>
                                                rental.stockId.Equals(stock.stockId));

            return stockHistoryQueryable.ToList();
        }

        /// <summary>Gets all products prom the database.</summary>
        /// <returns>A binding list containing all of the products.</returns>
        /// <Precondition> None </Precondition>
        public BindingList<Product> GetAllProducts()
        {
            this.CapstoneDbContext.Products.Load();
            return this.CapstoneDbContext.Products.Local.ToBindingList();
        }

        /// <summary>  Removes the given employee from the database if it exists.</summary>
        /// <param name="employee">The employee to remove from the database.</param>
        /// <exception cref="ArgumentNullException">
        ///     employee
        ///     - The employee cannot be null!
        /// </exception>
        /// <Precondition>The employee cannot be null.</Precondition>
        public void RemoveEmployee(Employee employee)
        {
            if (employee == null)
            {
                throw new ArgumentNullException(nameof(employee), EmployeeNullMessage);
            }

            this.CapstoneDbContext.Employees.Load();
            this.CapstoneDbContext.Employees.Remove(employee);
            this.CapstoneDbContext.SaveChanges();
        }

        /// <summary>Marks the given stock as unusable.</summary>
        /// <param name="stock">The stock to mark unusable.</param>
        /// <exception cref="ArgumentNullException">
        ///     stock
        ///     - The stock cannot be null!
        /// </exception>
        /// <Precondition>The stock cannot be null.</Precondition>
        /// <Postcondition>The stock is marked unusable.</Postcondition>
        public void MarkStockUnusable(Stock stock)
        {
            if (stock == null)
            {
                throw new ArgumentNullException(nameof(stock), StockNullError);
            }

            this.CapstoneDbContext.Stocks.Load();
            stock.itemCondition = "Unusable";
            this.CapstoneDbContext.SaveChanges();
        }

        /// <summary>Adds the given stock to the database if it does not already exist.</summary>
        /// <param name="stock">The stock to add to the database.</param>
        /// <exception cref="ArgumentNullException">
        ///     stock
        ///     - The stock cannot be null!
        /// </exception>
        /// <Precondition>The stock cannot be null.</Precondition>
        /// <Postcondition> The stock is added to the database. </Postcondition>
        public void AddStock(Stock stock)
        {
            if (stock == null)
            {
                throw new ArgumentNullException(nameof(stock), StockNullError);
            }

            this.CapstoneDbContext.Stocks.Load();
            this.CapstoneDbContext.Stocks.Add(stock);
            this.CapstoneDbContext.SaveChanges();
        }

        /// <summary>Adds the given employee to the database if it does not already exist.</summary>
        /// <param name="employee">The employee to add to the database.</param>
        /// <exception cref="ArgumentNullException">
        ///     employee
        ///     - The employee cannot be null!
        /// </exception>
        /// <Precondition>The employee cannot be null.</Precondition>
        /// <Postcondition> The employee is added. </Postcondition>
        public void AddEmployee(Employee employee)
        {
            if (employee == null)
            {
                throw new ArgumentNullException(nameof(employee), EmployeeNullMessage);
            }

            var isManager = Convert.ToSByte(employee.isManager);
            this.CapstoneDbContext.insertEmployee(null, employee.password, isManager,
                employee.name);
            this.CapstoneDbContext.SaveChanges();
        }

        /// <summary>
        ///   <para>
        ///  Adds the given product to the database. If the product already exists then an exception will be thrown by the database.</para>
        /// </summary>
        /// <param name="product">The product to add to the database.</param>
        /// <exception cref="ArgumentNullException">product - The product to add cannot be null!</exception>
        /// <Precondition> The product to add cannot be null!</Precondition>
        /// <Postcondition> The product is added. </Postcondition>
        public void AddProduct(Product product)
        {
            if (product == null)
            {
                throw new ArgumentNullException(nameof(product), @"The product to add cannot be null!");
            }
            this.CapstoneDbContext.Products.Load();
            this.CapstoneDbContext.Products.Add(product);
            this.CapstoneDbContext.SaveChanges();
        }

        /// <summary>
        ///     <para>Updates the given rental, marking that the status of the return is WaitingReturn.</para>
        ///     <para>This also adds the employee making the action and the current timestamp to the object.</para>
        /// </summary>
        /// <param name="detailedRentalView">The detailed rental view to update.</param>
        /// <param name="employee">The employee doing the updating.</param>
        /// <returns>True if the value could be updated and was, false if not.</returns>
        /// <exception cref="ArgumentNullException">
        ///     detailedRentalView
        ///     or
        ///     employee
        ///     cannot be null!
        /// </exception>
        /// <Precondition>The employee cannot be null, the detailed rental cannot be null!</Precondition>
        public bool MarkRentalAsWaitingReturn(DetailedRentalView detailedRentalView, Employee employee, string itemCondition)
        {
            if (detailedRentalView == null)
            {
                throw new ArgumentNullException(nameof(detailedRentalView), RentalNullError);
            }

            if (employee == null)
            {
                throw new ArgumentNullException(nameof(employee), EmployeeNullMessage);
            }

            if (string.IsNullOrEmpty(itemCondition))
            {
                throw new ArgumentNullException(nameof(itemCondition), @"The item condition cannot be null or empty!");
            }

            this.CapstoneDbContext.ItemRentals.Load();
            var currentRental = this.GetItemRentalById(detailedRentalView.itemRentalId);

            if (currentRental == null)
            {
                return false;
            }

            if (!currentRental.status.Equals("WaitingShipment"))
            {
                return false;
            }

            currentRental.status = "WaitingReturn";
            currentRental.shippedCondition = itemCondition;
            currentRental.Stock.itemCondition = itemCondition;
            currentRental.returnCondition = "Unmarked";
            currentRental.shipEmployeeId = employee.employeeId;
            currentRental.shipDateTime = DateTime.Now;
            this.CapstoneDbContext.SaveChanges();
            return true;
        }

        /// <summary>
        ///     <para>Updates the given rental, marking that the status of the return is Returned.</para>
        ///     <para>This also adds the employee making the action and the current timestamp to the object.</para>
        /// </summary>
        /// <param name="detailedRentalView">The detailed rental view to update.</param>
        /// <param name="employee">The employee doing the updating.</param>
        /// <param name="itemCondition">The condition of the item being returned.</param>
        /// <returns>True if the value could be updated and was, false if not.</returns>
        /// <exception cref="ArgumentNullException">
        ///     detailedRentalView
        ///     or
        ///     employee
        ///     cannot be null!
        /// </exception>
        /// <Precondition>The employee cannot be null, the detailed rental cannot be null!</Precondition>
        public bool MarkRentalAsReturned(DetailedRentalView detailedRentalView, Employee employee, string itemCondition)
        {
            if (detailedRentalView == null)
            {
                throw new ArgumentNullException(nameof(detailedRentalView), RentalNullError);
            }

            if (employee == null)
            {
                throw new ArgumentNullException(nameof(employee), EmployeeNullMessage);
            }

            if (string.IsNullOrEmpty(itemCondition))
            {
                throw new ArgumentNullException(nameof(itemCondition), @"The item condition cannot be null or empty!");
            }

            this.CapstoneDbContext.ItemRentals.Load();
            var currentRental = this.GetItemRentalById(detailedRentalView.itemRentalId);

            if (currentRental == null)
            {
                return false;
            }

            if (!currentRental.status.Equals("WaitingReturn"))
            {
                return false;
            }

            currentRental.status = "Returned";
            currentRental.shipEmployeeId = employee.employeeId;
            currentRental.shipDateTime = DateTime.Now;
            currentRental.Stock.itemCondition = itemCondition;
            currentRental.returnCondition = itemCondition;
            this.CapstoneDbContext.SaveChanges();
            return true;
        }

        #endregion
    }
}