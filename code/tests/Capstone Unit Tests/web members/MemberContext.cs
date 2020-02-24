using System.Data.Entity;
using Capstone_Database.Model;

namespace Capstone_Unit_Tests.web_members
{
    /// <summary>
    /// Representation of the DB Context (OnlineEntities) for testing
    /// May need to be moved from the testing project
    /// </summary>
    public class MemberContext : OnlineEntities
    {
        /// <summary>
        /// Gets or sets the products.
        /// </summary>
        /// <value>
        /// The products.
        /// </value>
        public override DbSet<Product> Products { get; set; }

        /// <summary>
        /// Gets or sets the stocks.
        /// </summary>
        /// <value>
        /// The stocks.
        /// </value>
        public override DbSet<Stock> Stocks { get; set; }

        /// <summary>
        /// Gets or sets the members.
        /// </summary>
        /// <value>
        /// The members.
        /// </value>
        public override DbSet<Member> Members { get; set; }

        /// <summary>
        /// Gets or sets the item rentals.
        /// </summary>
        /// <value>
        /// The item rentals.
        /// </value>
        public override DbSet<ItemRental> ItemRentals { get; set; }
    }
}
