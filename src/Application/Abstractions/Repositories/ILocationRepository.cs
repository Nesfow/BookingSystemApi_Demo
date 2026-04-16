using BookingSystemApi.Domain.Entities;

namespace BookingSystemApi.Application.Abstractions.Repositories;

public interface ILocationRepository
{
    Task<Location?> GetLocationById(int locationid, CancellationToken cancellationToken);
}