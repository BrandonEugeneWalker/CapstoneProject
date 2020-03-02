using System.Collections.Generic;
using Capstone_Database.Model;

namespace Capstone_Web_Members.ViewModels
{
    /// <summary>
    ///     ViewModel for storing the current Member, their ItemRental history, and Addresses via multiple models to display on
    ///     the Member Profile View
    /// </summary>
    public class MemberProfileViewModel
    {
        #region Properties

        /// <summary>
        ///     Gets or sets the member model.
        /// </summary>
        /// <value>
        ///     The member model, storing a Member object from the MembersController for the Member Profile View to display.
        /// </value>
        public Member MemberModel { get; set; }

        /// <summary>
        ///     Gets or sets the item rentals model.
        /// </summary>
        /// <value>
        ///     The item rentals model, storing a List of ItemRental objects from the MembersController for the Member Profile View
        ///     to display.
        /// </value>
        public List<ItemRental> ItemRentalsModel { get; set; }

        /// <summary>
        ///     Gets or sets the addresses model.
        /// </summary>
        /// <value>
        ///     The addresses model, storing a List of Address objects from the MembersController for the Member Profile View to
        ///     display.
        /// </value>
        public List<Address> AddressesModel { get; set; }

        #endregion
    }
}