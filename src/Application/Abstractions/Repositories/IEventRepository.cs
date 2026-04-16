using BookingSystemApi.Domain.Entities;

namespace BookingSystemApi.Application.Abstractions.Repositories;

public interface IEventRepository
{
    Task<int> CreateEvent(Event eventToCreate, CancellationToken cancellationToken);
}