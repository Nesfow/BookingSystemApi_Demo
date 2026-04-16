using BookingSystemApi.Domain.Entities;

namespace BookingSystemApi.Application.Abstractions.Repositories;

public interface IEventRepository
{
    Task<int> CreateEvent(Event eventToCreate, CancellationToken cancellationToken);
    Task<bool> IsTimeSlotAvailable(int locationId, DateTimeOffset requestedEventTime, CancellationToken cancellationToken);
}