using BookingSystemApi.Application.Abstractions.Data;
using BookingSystemApi.Application.Abstractions.Messaging;
using BookingSystemApi.Application.Extensions;

using Microsoft.EntityFrameworkCore;

using Shared;

namespace BookingSystemApi.Application.Features.Event.GetEventSeats;

internal sealed class GetEventSeatsQueryHandler : IQueryHandler<GetEventSeatsQuery, IReadOnlyCollection<GetEventSeatDto>>
{
    private readonly IApplicationDbContext _applicationDbContext;

    public GetEventSeatsQueryHandler(IApplicationDbContext applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
    }

    public async Task<Result<IReadOnlyCollection<GetEventSeatDto>>> Handle(GetEventSeatsQuery query, CancellationToken cancellationToken)
    {
        var eventDetails = await _applicationDbContext.Events
            .Where(x => x.Id == query.EventId)
            .Include(x => x.Seats)
            .FirstOrDefaultAsync(cancellationToken);

        return eventDetails is null ?
            new Error("Event not found", ErrorType.NotFound) :
            eventDetails.Seats.Select(x => x.ToGetEventSeatDto()).ToList().AsReadOnly();
    }
}