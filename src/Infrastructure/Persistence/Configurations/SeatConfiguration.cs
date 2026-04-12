using BookingSystemApi.Domain.Entities;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookingSystemApi.Infrastructure.Persistence.Configurations;

public class SeatConfiguration : IEntityTypeConfiguration<Seat>
{
    public void Configure(EntityTypeBuilder<Seat> builder)
    {
        builder.ToTable(nameof(Seat));

        builder.HasKey(k => k.Id);

        builder.Property(p => p.Label);
        builder.Property(p => p.SeatType);

        builder.Ignore(p => p.SeatOccupancy); // computed property, for Domain object only
    }
}