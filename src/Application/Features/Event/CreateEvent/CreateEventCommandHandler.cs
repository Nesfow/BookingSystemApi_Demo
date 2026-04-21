using BookingSystemApi.Application.Abstractions.Data;
using BookingSystemApi.Application.Abstractions.Messaging;

using Microsoft.EntityFrameworkCore;

using Shared;

namespace BookingSystemApi.Application.Features.Event.CreateEvent;

internal sealed class CreateEventCommandHandler : ICommandHandler<CreateEventCommand, int>
{
    private readonly IApplicationDbContext _applicationDbContext;

    public CreateEventCommandHandler(IApplicationDbContext applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
    }

    public async Task<Result<int>> Handle(CreateEventCommand command, CancellationToken cancellationToken)
    {
        var location = await _applicationDbContext.Locations
            .Where(x => x.Id == command.CreateEventDto.LocationId)
            .FirstOrDefaultAsync(cancellationToken);

        if (location is null)
        {
            return new Error("Location not found.", ErrorType.NotFound);
        }

        var timeSlotUnavailable = await _applicationDbContext.Events
           .AnyAsync(x => x.LocationId == command.CreateEventDto.LocationId && x.EventDate.Date == command.CreateEventDto.EventDate.Date,
            cancellationToken);

        if (timeSlotUnavailable)
        {
            return new Error("An event already exists at this location for the selected date.", ErrorType.Conflict);
        }

        var newEvent = new Domain.Entities.Event(
            command.CreateEventDto.Name,
            command.CreateEventDto.Description,
            command.CreateEventDto.EventDate,
            command.CreateEventDto.LocationId
        );

        _applicationDbContext.Events.Add(newEvent);
        await _applicationDbContext.SaveChangesAsync(cancellationToken);

        return newEvent.Id;
    }
}