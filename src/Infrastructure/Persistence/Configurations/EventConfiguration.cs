using BookingSystemApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookingSystemApi.Infrastructure.Persistence.Configurations;

public class EventConfiguration : IEntityTypeConfiguration<Event>
{
    public void Configure(EntityTypeBuilder<Event> builder)
    {
        builder.ToTable(nameof(Event));

        builder.HasKey(k => k.Id);

        builder.Property(p => p.Name)
            .IsRequired();
        builder.Property(p => p.Description);
        builder.Property(p => p.EventDate)
            .HasPrecision(3);

        builder.HasOne(p => p.Location)
            .WithMany()
            .HasForeignKey(fk => fk.LocationId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(p => p.Seats)
            .WithOne()
            .HasForeignKey(fk => fk.EventId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}