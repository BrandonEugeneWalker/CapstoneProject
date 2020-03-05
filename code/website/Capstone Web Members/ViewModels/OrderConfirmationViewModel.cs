using Capstone_Database.Model;

namespace Capstone_Web_Members.ViewModels
{
    /// <summary>
    /// ViewModel for storing the product being ordered and the selected address via multiple models to display on the Order Confirmation page
    /// </summary>
    public class OrderConfirmationViewModel
    {
        /// <summary>
        /// Gets or sets the product identifier.
        /// </summary>
        /// <value>
        /// The product model, storing the product that was ordered for the Order Confirmation View
        /// </value>
        public Product ProductModel { get; set; }

        /// <summary>
        /// Gets or sets the address identifier.
        /// </summary>
        /// <value>
        /// The address model, storing the address that was ordered with for the Order Confirmation View
        /// </value>
        public Address AddressModel { get; set; }
    }
}