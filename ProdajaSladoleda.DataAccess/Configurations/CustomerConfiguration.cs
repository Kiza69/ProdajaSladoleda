using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProdajaSladoleda.Domain;

namespace ProdajaSladoleda.DataAccess.Configurations
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.Property(c => c.FirstName).IsRequired().HasMaxLength(25);

            builder.Property(c => c.LastName).IsRequired().HasMaxLength(25);

            builder.Property(c => c.Address).IsRequired().HasMaxLength(150);

            builder.Property(c => c.Phone).IsRequired().HasMaxLength(13);

            builder.Property(c => c.Email).IsRequired().HasMaxLength(50);
            builder.HasIndex(c => c.Email).IsUnique();

            builder.Property(c => c.UserId).IsRequired();

            builder.Property(c => c.Active).IsRequired().HasDefaultValue(true);

            builder.HasOne(c => c.User)
                    .WithMany(u => u.Customer)
                    .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(c => c.Orders)
                    .WithOne(o => o.Customer)
                    .HasForeignKey(o => o.CustomerId)
                    .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
