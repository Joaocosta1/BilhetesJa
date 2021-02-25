using Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Configuration
{
    public class TransferItemConfiguration : IEntityTypeConfiguration<TransferItem>
    {
        public void Configure(EntityTypeBuilder<TransferItem> builder)
        {
            builder.HasKey(o => new {o.ProductId, o.TransferId});
        }
    }
}