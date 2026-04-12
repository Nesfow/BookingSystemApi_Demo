using BookingSystemApi.Domain.Entities;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookingSystemApi.Infrastructure.Persistence.Configurations;

public class LocationConfiguration : IEntityTypeConfiguration<Location>
{
    public void Configure(EntityTypeBuilder<Location> builder)
    {
        builder.ToTable(nameof(Location));

        builder.HasKey(k => k.Id);

        builder.Property(x => x.Address);
        builder.Property(x => x.Name);
        builder.Property(x => x.Capacity);
    }
}