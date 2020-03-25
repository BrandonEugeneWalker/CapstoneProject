using System.Collections.Generic;
using Capstone_Database.Model;

namespace Capstone_Web_Members.ViewModels
{
    /// <summary>
    ///     ViewModel for storing the available Products to rent and the count of active rentals a Member has via multiple
    ///     models to display on the MediaLibrary View
    /// </summary>
    public class MediaLibraryViewModel
    {
        #region Properties

        /// <summary>
        ///     Gets or sets the products model.
        /// </summary>
        /// <value>
        ///     The products model, storing a List of Products available to rent
        /// </value>
        public List<Product> ProductsModel { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [at maximum rentals].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [at maximum rentals]; otherwise, <c>false</c>.
        /// </value>
        public bool AtMaxRentals { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is librarian.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is librarian; otherwise, <c>false</c>.
        /// </value>
        public bool IsLibrarian { get; set; }

        #endregion
    }
}