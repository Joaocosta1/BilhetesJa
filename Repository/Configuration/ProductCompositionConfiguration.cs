using Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Configuration
{
    public class ProductCompositionConfiguration : IEntityTypeConfiguration<ProductComposition>
    {
        public void Configure(EntityTypeBuilder<ProductComposition> builder)
        {
            builder.HasKey(o => new {o.MasterProductId, o.SlaveProductId});
        }
    }
}