using System.Collections.Generic;
using Capstone_Database.Model;

namespace Capstone_Web_Members.ViewModels
{
    /// <summary>
    ///     ViewModel for storing the current Member, their ItemRental history, and Addresses via multiple models on a single
    ///     view
    /// </summary>
    public class MemberProfileViewModel
    {
        #region Properties

        /// <summary>
        ///     Gets or sets the member model.
        /// </summary>
        /// <value>
        ///     The member model.
        /// </value>
        public Member MemberModel { get; set; }

        /// <summary>
        ///     Gets or sets the item rentals model.
        /// </summary>
        /// <value>
        ///     The item rentals model.
        /// </value>
        public List<ItemRental> ItemRentalsModel { get; set; }

        /// <summary>
        ///     Gets or sets the addresses model.
        /// </summary>
        /// <value>
        ///     The addresses model.
        /// </value>
        public List<Address> AddressesModel { get; set; }

        #endregion
    }
}