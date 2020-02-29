using System.Collections.Generic;
using Capstone_Database.Model;

namespace Capstone_Web_Members.ViewModels
{
    /// <summary>
    ///     ViewModel for storing the current Member and their ItemRental history via multiple models on a single view
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

        #endregion
    }
}