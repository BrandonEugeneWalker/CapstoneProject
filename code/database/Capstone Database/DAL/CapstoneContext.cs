using System;
using Capstone_Database.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.Entity.Infrastructure;
using MySql.Data.MySqlClient;

namespace Capstone_Database.DAL
{
    public  class CapstoneContext : DbContext
    {
        //private MySqlConnection data = new MySqlConnection("server=160.10.25.16;user id=cs4982s20d;persistsecurityinfo=True;port=3306;database=cs4982s20d");
        //private static string blah = Capstone_Database.Properties.Settings.Default.CapstoneConnection;
        //private static string con = Capstone_Database.Properties.Settings.Default.cs4982s20dConnectionString.ToString();
        //private static string connection = Capstone_Database.Properties.Settings.Default.cs4982s20dConnectionString;
        //private static MySqlConnection con = new MySqlConnection("server=160.10.25.16;uid=cs4982s20d;pwd=PAoWBgKC42A3m45V;database=cs4982s20d");
        //private static string goodString = "User ID=cs4982s20d;password=PAoWBgKC42A3m45V;Data Source=160.10.25.16,3306;Initial Catalog=cs4982s20d;persistsecurityinfo=False;connection timeout=30"
        public CapstoneContext() : base(Class1.GetRemoteConnectionString())
        {
        }

        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Member> Members { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<ItemRental> ItemRentals { get; set; }
        public virtual DbSet<ItemReturn> ItemReturns { get; set; }
        public virtual DbSet<Stock> Stocks { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
