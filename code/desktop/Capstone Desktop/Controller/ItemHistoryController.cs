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

            capstoneDbContext.ItemRentals.Load();

            var stockHistoryQueryable = capstoneDbContext
                                        .DetailedRentalViews.Local.ToBindingList().Where(rental =>
                                            rental.stockId.Equals(stock.stockId));

            return stockHistoryQueryable.ToList();
        }

        /// <summary>
        ///     <para>
        ///         Builds the string representation of a stock object needed for the UI.
        ///     </para>
        ///     <para>If the stock is null an error is thown.</para>
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