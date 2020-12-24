using Navtech.OMS.Data.Configurations;
using Navtech.OMS.Entities;
using System;
using System.Data.Entity;

namespace Navtech.OMS.Data
{
    public class OMSContext : DbContext
    {
        public OMSContext() : base("OMSDbConnection")
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new AddressConfiguration());
            modelBuilder.Configurations.Add(new BuyerConfiguration());
            modelBuilder.Configurations.Add(new ProductConfiguration());
            modelBuilder.Configurations.Add(new OrderConfiguration());
        }

        public DbSet<Address> Addresses { get; set; }
        public DbSet<Buyer> Buyers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
    }
}