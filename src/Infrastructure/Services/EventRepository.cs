using BookingSystemApi.Application.Abstractions.Repositories;
using BookingSystemApi.Domain.Entities;
using BookingSystemApi.Infrastructure.Persistence;

using Microsoft.EntityFrameworkCore;

using Shared;

namespace BookingSystemApi.Infrastructure.Services;

public class EventRepository : IEventRepository
{
    private readonly IDbContextFactory<BookingSystemDbContext> _dbContextFactory;

    public EventRepository(IDbContextFactory<BookingSystemDbContext> dbContextFactory)
    {
        _dbContextFactory = dbContextFactory;
    }

    public async Task<int> CreateEvent(Event eventToCreate, CancellationToken cancellationToken)
    {
        using var dbContext = await _dbContextFactory.CreateDbContextAsync(cancellationToken);

        dbContext.Add(eventToCreate);
        await dbContext.SaveChangesAsync(cancellationToken);

        return eventToCreate.Id;
    }

    public async Task<bool> IsTimeSlotAvailable(int locationId, DateTimeOffset locationEventTime, CancellationToken cancellationToken)
    {
        using var dbContext = await _dbContextFactory.CreateDbContextAsync(cancellationToken);

        return await dbContext.Set<Event>()
           .AnyAsync(x => x.LocationId == locationId && x.EventDate.Date == locationEventTime.Date,
            cancellationToken);
    }
}