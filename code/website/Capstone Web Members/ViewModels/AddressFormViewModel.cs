using Capstone_Database.Model;

namespace Capstone_Web_Members.ViewModels
{
    /// <summary>
    ///     ViewModel for storing the created or edited Address and the nullable ProductId if created or edited from
    ///     OrderProduct
    /// </summary>
    public class AddressFormViewModel
    {
        #region Properties

        /// <summary>
        ///     Gets or sets the address model.
        /// </summary>
        /// <value>
        ///     The address model, storing an Address object from the AddressesController for Creating and Editing Addresses
        /// </value>
        public Address AddressModel { get; set; }

        /// <summary>
        ///     Gets or sets the product identifier model.
        /// </summary>
        /// <value>
        ///     The product identifier model, storing a nullable product Id to be passed in the AddressesController
        /// </value>
        public int? ProductIdModel { get; set; }

        #endregion
    }
}