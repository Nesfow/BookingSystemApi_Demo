using BookingSystemApi.Application.Abstractions.Repositories;
using BookingSystemApi.Domain.Entities;
using BookingSystemApi.Infrastructure.Persistence;

using Microsoft.EntityFrameworkCore;

namespace BookingSystemApi.Infrastructure.Services;

public class LocationRepository : ILocationRepository
{
    private readonly IDbContextFactory<BookingSystemDbContext> _dbContextFactory;

    public LocationRepository(IDbContextFactory<BookingSystemDbContext> dbContextFactory)
    {
        _dbContextFactory = dbContextFactory;
    }

    public async Task<Location?> GetLocationById(int locationid, CancellationToken cancellationToken)
    {
        using var dbContext = await _dbContextFactory.CreateDbContextAsync(cancellationToken);

        return await dbContext.Set<Location>()
            .Where(x => x.Id == locationid)
            .FirstOrDefaultAsync(cancellationToken);
    }
}