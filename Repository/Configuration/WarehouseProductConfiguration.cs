using Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Configuration
{
    public class WarehouseProductConfiguration : IEntityTypeConfiguration<WarehouseProduct>
    {
        public void Configure(EntityTypeBuilder<WarehouseProduct> builder)
        {
            builder.HasKey(o => new {o.ProductId, o.WarehouseId});
        }
    }
}