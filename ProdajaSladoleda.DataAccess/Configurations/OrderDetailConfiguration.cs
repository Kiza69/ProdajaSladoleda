using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProdajaSladoleda.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProdajaSladoleda.DataAccess.Configurations
{
    public class OrderDetailConfiguration : IEntityTypeConfiguration<OrderDetail>
    {
        public void Configure(EntityTypeBuilder<OrderDetail> builder)
        {
            builder.HasKey(od => od.OrderDetailId);

            builder.Property(od => od.OrderId).IsRequired();

            builder.Property(od => od.ProductId).IsRequired();

            builder.Property(od => od.UnitPrice).IsRequired();

            builder.Property(od => od.Quantity).IsRequired();

            builder.Property(od => od.Discount);

            builder.Property(o => o.Active).IsRequired().HasDefaultValue(true);

            builder.HasOne(od => od.Order)
                    .WithMany(o => o.OrderDetails)
                    .HasForeignKey(d => d.OrderId);

            builder.HasOne(od => od.Product)
                    .WithMany(p => p.OrderDetails)
                    .HasForeignKey(od => od.ProductId); 
        }
    }
}
