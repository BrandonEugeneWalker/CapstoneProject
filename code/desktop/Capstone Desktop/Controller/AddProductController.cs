using System;
using Capstone_Database.Model;
using Capstone_Desktop.Model;

namespace Capstone_Desktop.Controller
{
    /// <summary>Handles interaction between the UI and the database handler. Specifically in the area of adding new products.</summary>
    public class AddProductController
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
        ///         Initializes a new instance of the <see cref="AddProductController" /> class.
        ///     </para>
        ///     <para>
        ///         This overloaded constructor uses the IDbContextHandler implementing class given to it. Allowing for easy
        ///         testing.
        ///     </para>
        ///     <para>This default constructor uses the default CapstoneDbContextHandler for the database handler.</para>
        /// </summary>
        /// <Precondition>None</Precondition>
        /// <Postcondition>The class is instantiated.</Postcondition>
        public AddProductController()
        {
            this.CapstoneDatabaseHandler = new CapstoneDbContextHandler();
        }

        /// <summary>Initializes a new instance of the <see cref="AddProductController" /> class.</summary>
        /// <param name="capstoneDatabaseHandler">The capstone database handler to use.</param>
        /// <exception cref="ArgumentNullException">capstoneDatabaseHandler - The database handler cannot be null!</exception>
        /// <Precondition>The given database handler cannot be null!</Precondition>
        /// <Postcondition>The class is instantiated.</Postcondition>
        public AddProductController(IDbContextHandler capstoneDatabaseHandler)
        {
            this.CapstoneDatabaseHandler = capstoneDatabaseHandler ??
                                           throw new ArgumentNullException(nameof(capstoneDatabaseHandler),
                                               @"The database handler cannot be null!");
        }

        #endregion

        #region Methods

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