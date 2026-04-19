using BookingSystemApi.Application.Abstractions.Messaging;
using BookingSystemApi.Application.Abstractions.Repositories;

using Shared;

namespace BookingSystemApi.Application.Features.Event.CreateEvent;

internal sealed class CreateEventCommandHandler : ICommandHandler<CreateEventCommand, int>
{
    private readonly IEventRepository _eventRepository;
    private readonly ILocationRepository _locationRepository;

    public CreateEventCommandHandler(IEventRepository eventRepository, ILocationRepository locationRepository)
    {
        _eventRepository = eventRepository;
        _locationRepository = locationRepository;
    }

    public async Task<Result<int>> Handle(CreateEventCommand command, CancellationToken cancellationToken)
    {
        var location = await _locationRepository.GetLocationById(
            command.CreateEventDto.LocationId,
            cancellationToken);

        if (location is null)
        {
            return new Error("Location not found.", ErrorType.NotFound);
        }

        var timeSlotAvailable = await _eventRepository.IsTimeSlotAvailable(
            command.CreateEventDto.LocationId,
            command.CreateEventDto.EventDate,
            cancellationToken);

        if (!timeSlotAvailable)
        {
            return new Error("An event already exists at this location for the selected date.", ErrorType.Conflict);
        }

        var newEvent = new Domain.Entities.Event(
            command.CreateEventDto.Name,
            command.CreateEventDto.Description,
            command.CreateEventDto.EventDate,
            command.CreateEventDto.LocationId
        );

        return await _eventRepository.CreateEventAsync(newEvent, cancellationToken);
    }
}