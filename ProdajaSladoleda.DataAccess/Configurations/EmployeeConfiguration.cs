using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProdajaSladoleda.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProdajaSladoleda.DataAccess.Configurations
{
    public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.Property(c => c.FirstName).IsRequired().HasMaxLength(25);

            builder.Property(c => c.LastName).IsRequired().HasMaxLength(25);

            builder.Property(c => c.Address).IsRequired().HasMaxLength(150);

            builder.Property(c => c.Phone).IsRequired().HasMaxLength(13);

            builder.Property(c => c.Email).IsRequired().HasMaxLength(50);
            builder.HasIndex(c => c.Email).IsUnique();

            builder.Property(e => e.HireDate).HasDefaultValueSql("GETDATE()");

            builder.Property(c => c.UserId).IsRequired();

            builder.Property(c => c.Active).IsRequired().HasDefaultValue(true);

            builder.HasOne(e => e.User)
                    .WithMany(u => u.Employee)
                    .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(c => c.Orders)
                    .WithOne(o => o.Employee)
                    .HasForeignKey(o => o.EmployeeId)
                    .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
