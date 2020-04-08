using System;
using System.ComponentModel;
using Capstone_Database.Model;
using Capstone_Desktop.Model;

namespace Capstone_Desktop.Controller
{
    /// <summary>
    ///     <para>
    ///         This class handles interactions between the view and the database handler involving action where we add stock
    ///         to the database.
    ///     </para>
    ///     <para>Contains a IDbContextHandler for easy mocking of database functionality and testing.</para>
    ///     <para>By default this class will use the default database handler unless another is provided.</para>
    /// </summary>
    public class AddStockFormController
    {
        #region Properties

        /// <summary>
        ///     <para>
        ///         Gets or sets the capstone database handler.
        ///     </para>
        ///     <para>Handles interactions with the raw database context.</para>
        /// </summary>
        /// <value>The capstone database handler.</value>
        public IDbContextHandler CapstoneDatabaseHandler { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        ///     <para>
        ///         Initializes a new instance of the <see cref="AddStockFormController" /> class.
        ///     </para>
        ///     <para>Acts as an intermediary between the view and database handler.</para>
        /// </summary>
        /// <Precondition> None </Precondition>
        /// <Postcondition> A new instance is created. </Postcondition>
        public AddStockFormController()
        {
            this.CapstoneDatabaseHandler = new CapstoneDbContextHandler();
        }

        /// <summary>
        ///     <para>
        ///         Initializes a new instance of the <see cref="AddStockFormController" /> class.
        ///     </para>
        ///     <para>Acts as an intermediary between the view and the database handler.</para>
        /// </summary>
        /// <param name="capstoneDatabaseHandler">The capstone database handler.</param>
        /// <exception cref="System.ArgumentNullException">capstoneDatabaseHandler - The database handler cannot be null!</exception>
        /// <Precondition> The database handler cannot be null!  </Precondition>
        /// <Postcondition> A new instance is created. </Postcondition>
        public AddStockFormController(IDbContextHandler capstoneDatabaseHandler)
        {
            this.CapstoneDatabaseHandler = capstoneDatabaseHandler ??
                                           throw new ArgumentNullException(nameof(capstoneDatabaseHandler),
                                               @"The database handler cannot be null!");
        }

        #endregion

        #region Methods

        /// <summary>
        ///     <para>
        ///         Adds the stock to database using the database handler.
        ///     </para>
        ///     <para>Requires a valid product id and item condition, the stock id is auto generated.</para>
        /// </summary>
        /// <param name="productId">The product identifier.</param>
        /// <param name="itemCondition">The item condition.</param>
        /// <exception cref="System.ArgumentOutOfRangeException">
        ///     productId - The product id must be a positive integer greater than
        ///     zero.
        /// </exception>
        /// <exception cref="System.ArgumentNullException">itemCondition - The item condition cannot be null or empty!</exception>
        /// <Precondition> The product id must be a positive integer greater than zero, the item condition cannot be null! </Precondition>
        public void AddStockToDatabase(int productId, string itemCondition)
        {
            if (productId <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(productId),
                    @"The product id must be a positive integer greater than zero.");
            }

            if (string.IsNullOrEmpty(itemCondition))
            {
                throw new ArgumentNullException(nameof(itemCondition), @"The item condition cannot be null or empty!");
            }

            var stockToAdd = new Stock {
                productId = productId,
                itemCondition = itemCondition
            };

            this.CapstoneDatabaseHandler.AddStock(stockToAdd);
        }

        /// <summary>Gets all products in the database and returns them as a list.</summary>
        /// <returns>A binding list of products in the database.</returns>
        /// <Precondition> None </Precondition>
        public BindingList<Product> GetAllProducts()
        {
            return this.CapstoneDatabaseHandler.GetAllProducts();
        }

        #endregion
    }
}