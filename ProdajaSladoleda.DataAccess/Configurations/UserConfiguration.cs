using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProdajaSladoleda.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProdajaSladoleda.DataAccess.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(u => u.UserId);
            builder.Property(u => u.Username).IsRequired().HasMaxLength(25);
            builder.HasIndex(u => u.Username).IsUnique();

            builder.Property(u => u.Password).IsRequired().HasMaxLength(15);

            builder.Property(u => u.RoleId).IsRequired();

            builder.Property(u => u.Active).IsRequired().HasDefaultValue(false);

            builder.HasOne(u => u.Role)
                    .WithMany(r => r.Users);

            builder.HasMany(u => u.Customer)
                    .WithOne(c => c.User)
                    .HasForeignKey(c => c.UserId)
                    .OnDelete(DeleteBehavior.Restrict); 

            builder.HasMany(u => u.Employee)
                    .WithOne(e => e.User)
                    .HasForeignKey(e => e.UserId)
                    .OnDelete(DeleteBehavior.Restrict); 
        }
    }
}

