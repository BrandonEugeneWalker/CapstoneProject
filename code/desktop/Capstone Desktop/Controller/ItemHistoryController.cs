using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Capstone_Database.Model;

namespace Capstone_Desktop.Controller
{
    /// <summary>
    ///   <para>This class handles interactions between the database and the ItemHistoryForm.</para>
    ///   <para>Methods will require a valid stock item.</para>
    /// </summary>
    public class ItemHistoryController
    {
        private const string StockNullError = @"The Stock to view the history for cannot be null!";

        public List<ItemRental> GetStockHistory(Stock stock)
        {
            if (stock == null)
            {
                throw new ArgumentNullException(nameof(stock), StockNullError);
            }

            return stock.ItemRentals.ToList();
        }

        public string BuildStockDescription(Stock stock)
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append(" Item Name: " + stock.Product.name);
            stringBuilder.Append(" Stock ID: " + stock.stockId);
            stringBuilder.Append(" Condition: " + stock.itemCondition);
            return stringBuilder.ToString();
        }
    }
}