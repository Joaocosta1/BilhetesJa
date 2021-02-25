using Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Configuration
{
    public class ReceiptItemConfiguration : IEntityTypeConfiguration<ReceiptItem>
    {
        public void Configure(EntityTypeBuilder<ReceiptItem> builder)
        {
            builder.HasKey(o => new {o.ProductId, o.ReceiptId});
        }
    }
}