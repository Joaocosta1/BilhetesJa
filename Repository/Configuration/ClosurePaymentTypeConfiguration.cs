using Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Configuration
{
    public class ClosurePaymentTypeConfiguration : IEntityTypeConfiguration<ClosurePaymentType>
    {
        public void Configure(EntityTypeBuilder<ClosurePaymentType> builder)
        {
            builder.HasKey(o => new {o.ClosureId, o.PaymentTypeId});
        }
    }
}