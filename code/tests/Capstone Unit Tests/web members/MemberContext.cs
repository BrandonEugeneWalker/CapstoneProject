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
        public virtual DbSet<Product> Products { get; set; }

        /// <summary>
        /// Gets or sets the stocks.
        /// </summary>
        /// <value>
        /// The stocks.
        /// </value>
        public virtual DbSet<Stock> Stocks { get; set; }

        /// <summary>
        /// Gets or sets the members.
        /// </summary>
        /// <value>
        /// The members.
        /// </value>
        public virtual DbSet<Member> Members { get; set; }

        /// <summary>
        /// Gets or sets the item rentals.
        /// </summary>
        /// <value>
        /// The item rentals.
        /// </value>
        public virtual DbSet<ItemRental> ItemRentals { get; set; }
    }
}
