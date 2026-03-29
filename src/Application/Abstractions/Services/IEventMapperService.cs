using BookingSystemApi.Application.Features.Event.CreateEvent;
using BookingSystemApi.Domain.Entities;

namespace BookingSystemApi.Application.Abstractions.Services;

public interface IEventMapperService
{
    Event ToEvent(CreateEventDto createEventDto);
}