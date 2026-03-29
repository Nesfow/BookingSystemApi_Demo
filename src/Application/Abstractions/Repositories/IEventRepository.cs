using BookingSystemApi.Domain.Entities;

namespace BookingSystemApi.Application.Abstractions.Repositories;

public interface IEventRepository
{
    Task<bool> CreateEvent(Event eventToCreate);
}