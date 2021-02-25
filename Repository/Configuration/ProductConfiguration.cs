using Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Configuration
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Ignore(p => p.HaveComposition);
            builder.HasMany(p => p.Composition).WithOne(p => p.MasterProduct).HasForeignKey(p => p.MasterProductId);
            builder.HasMany(p => p.Compositor).WithOne(p => p.SlaveProduct).HasForeignKey(p => p.SlaveProductId);
        }
    }
}