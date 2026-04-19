using BookingSystemApi.Domain.Entities;

namespace BookingSystemApi.Application.Abstractions.Repositories;

public interface IEventRepository
{
    Task<int> CreateEventAsync(Event eventToCreate, CancellationToken cancellationToken);
    Task<Event?> GetEventAsync(int eventId, CancellationToken cancellationToken);
    Task<bool> IsTimeSlotAvailable(int locationId, DateTimeOffset requestedEventTime, CancellationToken cancellationToken);
}