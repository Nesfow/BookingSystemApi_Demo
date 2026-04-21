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

        builder.Property(p => p.Id)
            .ValueGeneratedOnAdd();
        builder.Property(p => p.Price)
            .HasPrecision(18, 4);
        builder.Property(p => p.IsAvailable);
        builder.Property(p => p.Label);
        builder.Property(p => p.SeatType);

        builder.HasOne(p => p.Event)
            .WithMany(p => p.Seats)
            .HasForeignKey(fk => fk.EventId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(s => s.Booking)
            .WithMany(b => b.BookedSeats)
            .HasForeignKey(s => s.BookingId)
            .IsRequired(false)
            .OnDelete(DeleteBehavior.SetNull);

        builder.Ignore(p => p.SeatOccupancy); // computed property, for Domain object only
    }
}