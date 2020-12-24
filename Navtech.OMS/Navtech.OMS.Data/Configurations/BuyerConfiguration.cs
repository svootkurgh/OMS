using Navtech.OMS.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;

namespace Navtech.OMS.Data.Configurations
{
    public class BuyerConfiguration : EntityTypeConfiguration<Buyer>
    {
        public BuyerConfiguration()
        {
            HasKey(buyer => buyer.Id);

            Property(buyer => buyer.FirstName)
                 .IsRequired()
                 .HasMaxLength(25);

            Property(buyer => buyer.MiddleName)
                 .IsOptional()
                 .HasMaxLength(25);

            Property(buyer => buyer.LastName)
                .IsRequired()
                .HasMaxLength(25);

            Property(buyer => buyer.MobileNumber)
                .IsRequired()
                .HasMaxLength(15); //To allow different formats like +91 99*** *****,91 99999 99999

            Property(buyer => buyer.AlternateMobileNumber)
                .IsOptional()
                .HasMaxLength(15);

            Property(buyer => buyer.EmailAddress)
               .IsRequired()
               .HasMaxLength(100);
        }
    }
}