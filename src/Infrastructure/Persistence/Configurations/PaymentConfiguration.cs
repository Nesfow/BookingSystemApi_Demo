using BookingSystemApi.Domain.Entities;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookingSystemApi.Infrastructure.Persistence.Configurations;

public class PaymentConfiguration : IEntityTypeConfiguration<Payment>
{
    public void Configure(EntityTypeBuilder<Payment> builder)
    {
        builder.ToTable(nameof(Payment));

        builder.HasKey(k => k.Id);

        builder.Property(p => p.Amount)
            .HasPrecision(18, 4); // using decimal(18,4) instead of money type, due to possible rounding errors
        builder.Property(p => p.PaymentDate)
            .HasPrecision(3);
        builder.Property(p => p.PaymentType);
    }
}