using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Capstone_Database.Model;
using Capstone_Desktop.Model;

namespace Capstone_Desktop.Controller
{
    /// <summary>
    ///     <para>This class handles interactions between the database and the ItemHistoryForm.</para>
    ///     <para>Methods will require a valid stock item.</para>
    /// </summary>
    public class ItemHistoryController
    {
        #region Data members

        private const string StockNullError = @"The Stock to view the history for cannot be null!";

        public IDbContextHandler CapstoneDatabaseHandler;

        #endregion

        #region Constructors

        /// <summary>
        ///     <para>
        ///         Initializes a new instance of the <see cref="ItemHistoryController" /> class.
        ///     </para>
        ///     <para>Separates the view and database logic.</para>
        /// </summary>
        /// <Precondition> None </Precondition>
        /// <Postcondition> A new instance is created. </Postcondition>
        public ItemHistoryController()
        {
            this.CapstoneDatabaseHandler = new CapstoneDbContextHandler();
        }

        /// <summary>
        ///     <para>
        ///         Initializes a new instance of the <see cref="ItemHistoryController" /> class.
        ///     </para>
        ///     <para>Separates the view and database logic.</para>
        /// </summary>
        /// <param name="capstoneDatabaseHandler">The capstone database handler.</param>
        /// <exception cref="ArgumentNullException">capstoneDatabaseHandler - The database handler cannot be null!</exception>
        /// <Precondition> None </Precondition>
        /// <Postcondition> A new instance is created. </Postcondition>
        public ItemHistoryController(IDbContextHandler capstoneDatabaseHandler)
        {
            this.CapstoneDatabaseHandler = capstoneDatabaseHandler ??
                                           throw new ArgumentNullException(nameof(capstoneDatabaseHandler),
                                               @"The database handler cannot be null!");
        }

        #endregion

        #region Methods

        /// <summary>
        ///     <para>
        ///         Gets and returns the rental history of a stock item.
        ///     </para>
        ///     <para>The given stock and database cannot be null.</para>
        /// </summary>
        /// <param name="stock">The stock to get the history of.</param>
        /// <returns>A list of rentals that stock is involved in.</returns>
        /// <exception cref="ArgumentNullException">
        ///     stock
        ///     or
        ///     capstoneDbContext - The given database context cannot be null!
        /// </exception>
        public List<DetailedRentalView> GetStockHistory(Stock stock)
        {
            if (stock == null)
            {
                throw new ArgumentNullException(nameof(stock), StockNullError);
            }

            return this.CapstoneDatabaseHandler.GetDetailedStockHistory(stock).OrderByDescending(x => x.rentalDateTime).ToList();
        }

        /// <summary>
        ///     <para>
        ///         Builds the string representation of a stock object needed for the UI.
        ///     </para>
        ///     <para>If the stock is null an error is thrown.</para>
        /// </summary>
        /// <param name="stock">The stock to describe.</param>
        /// <returns>A string representation of the stock.</returns>
        public string BuildStockDescription(Stock stock)
        {
            if (stock == null)
            {
                throw new ArgumentNullException(nameof(stock), StockNullError);
            }

            var stringBuilder = new StringBuilder();
            stringBuilder.Append(" Item Name: " + stock.Product.name);
            stringBuilder.Append(" Stock ID: " + stock.stockId);
            stringBuilder.Append(" Condition: " + stock.itemCondition);
            return stringBuilder.ToString();
        }

        #endregion
    }
}