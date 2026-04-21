using BookingSystemApi.Domain.Entities;

using Microsoft.EntityFrameworkCore;

namespace BookingSystemApi.Application.Abstractions.Data;

public interface IApplicationDbContext
{
    DbSet<Booking> Bookings { get; }
    DbSet<Event> Events { get; }
    DbSet<Location> Locations { get; }
    DbSet<Payment> Payments { get; }
    DbSet<Seat> Seats { get; }
    DbSet<User> Users { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
