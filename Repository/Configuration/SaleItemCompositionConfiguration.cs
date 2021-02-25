using Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Configuration
{
    public class SaleItemCompositionConfiguration : IEntityTypeConfiguration<SaleItemComposition>
    {
        public void Configure(EntityTypeBuilder<SaleItemComposition> builder)
        {
            builder.HasKey(o => new {o.ProductId, o.SaleItemId});
        }
    }
}