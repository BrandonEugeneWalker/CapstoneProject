using System.Collections.Generic;
using Capstone_Database.Model;

namespace Capstone_Web_Members.ViewModels
{
    /// <summary>
    /// ViewModel for storing the product being ordered and the member's Addresses via multiple models to display on the Order Product page
    /// </summary>
    public class OrderProductViewModel
    {
        /// <summary>
        /// Gets or sets the product model.
        /// </summary>
        /// <value>
        /// The product model, storing the product to be ordered for the OrderProduct view
        /// </value>
        public Product ProductModel { get; set; }

        /// <summary>
        /// Gets or sets the addresses model.
        /// </summary>
        /// <value>
        /// The addresses model, storing the selected address to be used for the order
        /// </value>
        public List<Address> AddressesModel { get; set; }
    }
}