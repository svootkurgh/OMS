using Navtech.OMS.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;

namespace Navtech.OMS.Data.Configurations
{
    public class ProductConfiguration : EntityTypeConfiguration<Product>
    {
        public ProductConfiguration()
        {
            HasKey(product => product.Id);

            Property(product => product.Name)
                 .IsRequired()
                 .HasMaxLength(50);

            Property(product => product.Price)
                .IsRequired();

            Property(product => product.Weight)
                 .IsRequired();

            Property(product => product.Height)
                 .IsRequired();

            Property(product => product.Image)
                .IsRequired()
                .HasMaxLength(150);

            Property(product => product.SKU)
                .IsRequired()
                .HasMaxLength(20);

            Property(product => product.Barcode)
                .IsRequired()
                .HasMaxLength(25);

            Property(product => product.AvailableQuantity)
                .IsRequired();

            Property(product => product.OrderedQuantity)
              .IsRequired();

            HasRequired(order => order.Order)
                .WithMany(product => product.Products)
                .HasForeignKey(product => product.OrderId);
        }
    }
}
