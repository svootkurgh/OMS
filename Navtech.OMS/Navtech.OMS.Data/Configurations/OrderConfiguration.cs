using Navtech.OMS.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;

namespace Navtech.OMS.Data.Configurations
{
    public class OrderConfiguration : EntityTypeConfiguration<Order>
    {
        public OrderConfiguration()
        {
            HasKey(buyer => buyer.Id);

            Property(buyer => buyer.Status)
                 .IsRequired();

            HasRequired(buyer => buyer.Buyer)
            .WithMany(order => order.Orders)
            .HasForeignKey(address => address.BuyerId);
        }
    }
}