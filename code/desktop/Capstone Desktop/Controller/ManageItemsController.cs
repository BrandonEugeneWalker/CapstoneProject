using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Capstone_Database.Model;

namespace Capstone_Desktop.Controller
{
    /// <summary>
    ///     <para>Handles communication between the view and the database.</para>
    ///     <para>Handles operations involving a Stock object in the database.</para>
    /// </summary>
    public class ManageItemsController
    {
        #region Methods

        /// <summary>
        ///     <para>
        ///         Gets and returns all the Stock objects in the database.
        ///     </para>
        ///     <para>The database to get them from cannot be null.</para>
        /// </summary>
        /// <param name="capstoneDbContext">The capstone database context.</param>
        /// <returns>The list of stock objects in the database.</returns>
        /// <exception cref="ArgumentNullException">capstoneDbContext - The database to get stock from cannot be null!</exception>
        public List<StockDetailView> GetAllStock(OnlineEntities capstoneDbContext)
        {
            if (capstoneDbContext == null)
            {
                throw new ArgumentNullException(nameof(capstoneDbContext),
                    @"The database to get stock from cannot be null!");
            }

            return this.selectAllStockFromDatabase(capstoneDbContext);
        }

        private List<StockDetailView> selectAllStockFromDatabase(OnlineEntities capstoneDbContext)
        {
            capstoneDbContext.StockDetailViews.Load();
            return capstoneDbContext.StockDetailViews.Local.ToBindingList().ToList();
        }

        #endregion
    }
}