using BookingSystemApi.Domain.Entities;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookingSystemApi.Infrastructure.Persistence.Configurations;

public class BookingConfiguration : IEntityTypeConfiguration<Booking>
{
    public void Configure(EntityTypeBuilder<Booking> builder)
    {
        builder.ToTable(nameof(Booking));

        builder.HasKey(k => k.Id);

        builder.Property(p => p.BookingDate)
            .HasPrecision(3);
        builder.Property(p => p.Price)
            .HasPrecision(18, 4);
        builder.Property(p => p.BookingStatus);

        builder.HasOne(p => p.User)
            .WithMany(p => p.Bookings)
            .HasForeignKey(fk => fk.UserId)
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasOne(p => p.Event)
            .WithMany()
            .HasForeignKey(fk => fk.EventId)
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasMany(p => p.BookedSeats)
            .WithOne()
            .HasForeignKey(fk => fk.BookingId);

        builder.HasMany(p => p.Payments)
            .WithOne(p => p.Booking)
            .HasForeignKey(fk => fk.BookingId)
            .OnDelete(DeleteBehavior.NoAction);
    }
}