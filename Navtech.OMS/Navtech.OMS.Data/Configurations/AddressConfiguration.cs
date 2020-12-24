using Navtech.OMS.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;

namespace Navtech.OMS.Data.Configurations
{
    public class AddressConfiguration : EntityTypeConfiguration<Address>
    {
        public AddressConfiguration()
        {
            HasKey(address => address.Id);

            Property(address => address.Identity)
                 .IsRequired()
                 .HasMaxLength(15);

            Property(address => address.AddressLine1)
                 .IsRequired()
                 .HasMaxLength(75);

            Property(address => address.AddressLine2)
                .IsOptional()
                .HasMaxLength(75);

            Property(address => address.Landmark)
                .IsOptional()
                .HasMaxLength(75);

            Property(address => address.City)
                .IsRequired()
                .HasMaxLength(50);

            Property(address => address.State)
                .IsRequired()
                .HasMaxLength(50);

            Property(address => address.Pincode)
                .IsRequired()
                .HasMaxLength(10);

            HasRequired(buyer => buyer.Buyer)
                .WithMany(address => address.Addresses)
                .HasForeignKey(address => address.BuyerId);
        }
    }
}