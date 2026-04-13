using Microsoft.EntityFrameworkCore;

namespace BookingSystemApi.Infrastructure.Persistence;

public class BookingSystemDbContext : DbContext
{
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
}