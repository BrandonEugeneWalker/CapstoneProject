using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using Capstone_Database.Model;

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

        #endregion

        #region Methods

        /// <summary>
        ///     <para>
        ///         Gets and returns the rental history of a stock item.
        ///     </para>
        ///     <para>The given stock and database cannot be null.</para>
        /// </summary>
        /// <param name="stock">The stock to get the history of.</param>
        /// <param name="capstoneDbContext">The capstone database context.</param>
        /// <returns>A list of rentals that stock is involved in.</returns>
        /// <exception cref="ArgumentNullException">
        ///     stock
        ///     or
        ///     capstoneDbContext - The given database context cannot be null!
        /// </exception>
        public List<DetailedRentalView> GetStockHistory(Stock stock, OnlineEntities capstoneDbContext)
        {
            if (stock == null)
            {
                throw new ArgumentNullException(nameof(stock), StockNullError);
            }

            if (capstoneDbContext == null)
            {
                throw new ArgumentNullException(nameof(capstoneDbContext),
                    @"The given database context cannot be null!");
            }

            return this.selectDetailedRentalsFromDatabaseByStock(capstoneDbContext, stock);
        }

        private List<DetailedRentalView> selectDetailedRentalsFromDatabaseByStock(OnlineEntities capstoneDbContext,
            Stock stock)
        {
            capstoneDbContext.DetailedRentalViews.Load();

            var stockHistoryQueryable = capstoneDbContext
                                        .DetailedRentalViews.Local.ToBindingList().Where(rental =>
                                            rental.stockId.Equals(stock.stockId));

            return stockHistoryQueryable.ToList();
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