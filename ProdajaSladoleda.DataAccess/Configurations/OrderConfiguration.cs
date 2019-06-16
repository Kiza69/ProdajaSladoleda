using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProdajaSladoleda.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProdajaSladoleda.DataAccess.Configurations
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.Property(o => o.CustomerId).IsRequired();

            builder.Property(o => o.OrderDate).IsRequired().HasDefaultValueSql("GETDATE()");

            builder.Property(o => o.Total).IsRequired();

            builder.Property(o => o.ShipDate).HasDefaultValueSql("GETDATE()");

            builder.Property(o => o.EmployeeId);

            builder.Property(o => o.ShipName).IsRequired().HasMaxLength(50);

            builder.Property(o => o.ShipAddress).IsRequired().HasMaxLength(150);

            builder.Property(o => o.Active).IsRequired().HasDefaultValue(true);

            builder.HasOne(o => o.Customer)
                    .WithMany(c => c.Orders)
                    .HasForeignKey(od => od.CustomerId);

            builder.HasOne(o => o.Employee)
                    .WithMany(e => e.Orders)
                    .HasForeignKey(od => od.EmployeeId);

            builder.HasMany(o => o.OrderDetails)
                    .WithOne(od => od.Order)
                    .HasForeignKey(od => od.OrderId)
                    .OnDelete(DeleteBehavior.Cascade);
        }
    }
}

