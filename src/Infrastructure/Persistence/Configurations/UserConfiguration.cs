using BookingSystemApi.Domain.Entities;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookingSystemApi.Infrastructure.Persistence.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable(nameof(User));

        builder.HasKey(k => k.Id);
        builder.HasIndex(u => u.Email)
            .IsUnique();

        // In my opinion, we can trade off this 1 normal form case, as exception, 
        // in favour of simplicity and because many people simply have only first name (e.g. "Akiko")
        builder.Property(p => p.Name)
            .IsRequired();
        builder.Property(p => p.Email)
            .IsRequired();

        builder.HasMany(p => p.Bookings)
            .WithOne(p => p.User)
            .HasForeignKey(fk => fk.UserId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}