using System;
using System.ComponentModel;
using Capstone_Database.Model;
using Capstone_Desktop.Model;

namespace Capstone_Desktop.Controller
{
    /// <summary>
    ///     The ManageProductsController acts as an intermediary between the ManageProductsForm and the Database Handler.
    ///     This go between focuses on functionality around managing products.
    /// </summary>
    public class ManageProductsController
    {
        #region Properties

        /// <summary>
        ///     Gets or sets the capstone database handler.
        ///     Acts as a go between for the raw database and the classes that use it.
        /// </summary>
        /// <value>The capstone database handler.</value>
        public IDbContextHandler CapstoneDatabaseHandler { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        ///     <para>
        ///         Initializes a new instance of the <see cref="ManageProductsController" /> class.
        ///     </para>
        ///     <para>This default constructor uses the default CapstoneDbContextHandler as the database handler.</para>
        /// </summary>
        /// <Precondition>None</Precondition>
        /// <Postcondition>The class is instantiated.</Postcondition>
        public ManageProductsController()
        {
            this.CapstoneDatabaseHandler = new CapstoneDbContextHandler();
        }

        /// <summary>
        ///     <para>
        ///         Initializes a new instance of the <see cref="ManageProductsController" /> class.
        ///     </para>
        ///     <para>
        ///         This overloaded constructor uses the IDbContextHandler implementing class given to it. Allowing for easy
        ///         testing.
        ///     </para>
        /// </summary>
        /// <param name="capstoneDatabaseHandler">The capstone database handler.</param>
        /// <exception cref="ArgumentNullException">capstoneDatabaseHandler - The database handler cannot be null!</exception>
        /// <Precondition>The given database handler cannot be null!</Precondition>
        /// <Postcondition>The class is instantiated.</Postcondition>
        public ManageProductsController(IDbContextHandler capstoneDatabaseHandler)
        {
            this.CapstoneDatabaseHandler = capstoneDatabaseHandler ??
                                           throw new ArgumentNullException(nameof(capstoneDatabaseHandler),
                                               @"The database handler cannot be null!");
        }

        #endregion

        #region Methods

        /// <summary>Gets all products from the database handler.</summary>
        /// <returns>A binding list containing all the products in the database.</returns>
        /// <Precondition>None</Precondition>
        public BindingList<Product> GetAllProducts()
        {
            return this.CapstoneDatabaseHandler.GetAllProducts();
        }

        /// <summary>Adds the given product to the database using the database handler.</summary>
        /// <param name="product">The product to add to the database.</param>
        /// <exception cref="ArgumentNullException">product - The product to add cannot be null!</exception>
        /// <Precondition>The product to add cannot be null! </Precondition>
        /// <Postcondition>The product is added.</Postcondition>
        public void AddProduct(Product product)
        {
            if (product == null)
            {
                throw new ArgumentNullException(nameof(product), @"The product to add cannot be null!");
            }

            this.CapstoneDatabaseHandler.AddProduct(product);
        }

        #endregion
    }
}