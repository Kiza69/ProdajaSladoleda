using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProdajaSladoleda.Domain;

namespace ProdajaSladoleda.DataAccess.Configurations
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.Property(c => c.Name).IsRequired().HasMaxLength(25);
            builder.HasIndex(c => c.Name).IsUnique();

            builder.Property(c => c.Price).IsRequired();

            builder.Property(c => c.Active).IsRequired().HasDefaultValue(true);

            builder.HasMany(c => c.Products)
                    .WithOne(p => p.Category)
                    .HasForeignKey(p => p.CategoryId)
                    .OnDelete(DeleteBehavior.Restrict);
        }
    }
}