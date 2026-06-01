using BookingSystemApi.Application.Abstractions.Data;
using BookingSystemApi.Domain.Entities;

using Microsoft.EntityFrameworkCore;

namespace BookingSystemApi.Infrastructure.Persistence;

public sealed class BookingSystemDbContext : DbContext, IApplicationDbContext
{
    public DbSet<Booking> Bookings { get; set; }

    public DbSet<Event> Events { get; set; }

    public DbSet<Location> Locations { get; set; }

    public DbSet<Seat> Seats { get; set; }

    public DbSet<User> Users { get; set; }

    private BookingSystemDbContext() { }

    public BookingSystemDbContext(DbContextOptions<BookingSystemDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(InfrastructureAssemblyMarker).Assembly);
    }

    protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
    {
        // Converting enums to strings for simplification.
        // Could be a separate table, but assume that enums' names won't be changed
        configurationBuilder.Properties<Enum>()
           .HaveConversion<string>();
    }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return await base.SaveChangesAsync(cancellationToken);
    }
}