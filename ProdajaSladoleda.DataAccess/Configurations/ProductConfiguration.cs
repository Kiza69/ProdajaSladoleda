using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProdajaSladoleda.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProdajaSladoleda.DataAccess.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(p => p.Name).IsRequired().HasMaxLength(30);
            builder.HasIndex(p => p.Name).IsUnique();

            builder.Property(p => p.CategoryId).IsRequired();

            builder.Property(p => p.Description).IsRequired().HasMaxLength(150);

            builder.Property(p => p.Filename).IsRequired().HasMaxLength(150);

            builder.Property(p => p.Active).IsRequired().HasDefaultValue(true);

            builder.HasOne(p => p.Category)
                    .WithMany(c => c.Products);

            builder.HasMany(p => p.OrderDetails)
                    .WithOne(od => od.Product)
                    .HasForeignKey(od => od.ProductId)
                    .OnDelete(DeleteBehavior.Restrict);
        }
    }
}