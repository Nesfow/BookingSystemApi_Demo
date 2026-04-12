using BookingSystemApi.Domain.Entities;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookingSystemApi.Infrastructure.Persistence.Configurations;

public class EventSeatConfiguration : IEntityTypeConfiguration<EventSeat>
{
    public void Configure(EntityTypeBuilder<EventSeat> builder)
    {
        builder.ToTable(nameof(EventSeat));

        builder.HasKey(k => k.Id);
        builder.HasIndex(i => new { i.EventId, i.SeatId })
            .IsUnique(); // to avoid seat duplication for event

        builder.Property(p => p.IsAvailable);
        builder.Property(p => p.Price)
            .HasPrecision(18, 4);

        builder.HasOne(p => p.Event)
            .WithMany(p => p.Seats)
            .HasForeignKey(fk => fk.EventId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(p => p.Seat)
            .WithMany()
            .HasForeignKey(fk => fk.SeatId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}