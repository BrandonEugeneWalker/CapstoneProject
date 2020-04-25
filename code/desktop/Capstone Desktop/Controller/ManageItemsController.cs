using System;
using System.ComponentModel;
using Capstone_Database.Model;
using Capstone_Desktop.Model;

namespace Capstone_Desktop.Controller
{
    /// <summary>
    ///     <para>Handles communication between the view and the database.</para>
    ///     <para>Handles operations involving a Stock object in the database.</para>
    /// </summary>
    public class ManageItemsController
    {
        #region Properties

        /// <summary>
        ///     Gets or sets the capstone database handler.
        ///     Which acts as the intermediary between the controller and raw database.
        /// </summary>
        /// <value>The capstone database handler.</value>
        public IDbContextHandler CapstoneDatabaseHandler { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        ///     <para>
        ///         Initializes a new instance of the <see cref="ManageItemsController" /> class.
        ///     </para>
        ///     <para>Acts as an intermediary between the view and database handler.</para>
        /// </summary>
        /// <Precondition>None</Precondition>
        /// <Postcondition>A new instance is created.</Postcondition>
        public ManageItemsController()
        {
            this.CapstoneDatabaseHandler = new CapstoneDbContextHandler();
        }

        /// <summary>
        ///     <para>
        ///         Initializes a new instance of the <see cref="ManageItemsController" /> class.
        ///     </para>
        ///     <para>Acts as an intermediary between the view and database handler.</para>
        /// </summary>
        /// <param name="capstoneDatabaseHandler">The capstone database handler.</param>
        /// <exception cref="ArgumentNullException">capstoneDatabaseHandler - The database handler cannot be null!</exception>
        /// <Precondition>The database handler cannot be null!</Precondition>
        /// <Postcondition>A new instance is created.</Postcondition>
        public ManageItemsController(IDbContextHandler capstoneDatabaseHandler)
        {
            this.CapstoneDatabaseHandler = capstoneDatabaseHandler ??
                                           throw new ArgumentNullException(nameof(capstoneDatabaseHandler),
                                               @"The database handler cannot be null!");
        }

        #endregion

        #region Methods

        /// <summary>
        ///     <para>
        ///         Gets and returns all the Stock objects in the database.
        ///     </para>
        ///     <para>The database to get them from cannot be null.</para>
        /// </summary>
        /// <returns>The list of stock objects in the database.</returns>
        /// <Precondition>None</Precondition>
        public BindingList<StockDetailView> GetAllStock()
        {
            return this.CapstoneDatabaseHandler.GetAllDetailedStock();
        }

        /// <summary>
        ///     Gets the stock by detailed stock and returns it.
        /// </summary>
        /// <param name="stockDetailView">The stock detail view.</param>
        /// <returns>The stock if found, null if not.</returns>
        /// <Precondition> the detailed stock cannot be null!</Precondition>
        public Stock GetStockByDetailedStock(StockDetailView stockDetailView)
        {
            if (stockDetailView == null)
            {
                throw new ArgumentNullException(nameof(stockDetailView), @"The detailed stock cannot be null!");
            }

            return this.CapstoneDatabaseHandler.GetStockById(stockDetailView.stockId);
        }

        /// <summary>Marks the stock as unusable.</summary>
        /// <param name="stock">The stock to mark unusable.</param>
        /// <exception cref="System.ArgumentNullException">stock - The stock to mark unusable cannot be null!</exception>
        /// <Precondition> The stock cannot be null! </Precondition>
        public void MarkStockUnusable(Stock stock)
        {
            if (stock == null)
            {
                throw new ArgumentNullException(nameof(stock), @"The stock to mark unusable cannot be null!");
            }

            this.CapstoneDatabaseHandler.MarkStockUnusable(stock);
        }

        #endregion
    }
}