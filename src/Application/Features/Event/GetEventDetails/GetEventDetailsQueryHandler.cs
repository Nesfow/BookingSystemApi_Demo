using BookingSystemApi.Application.Abstractions.Data;
using BookingSystemApi.Application.Abstractions.Messaging;
using BookingSystemApi.Application.Extensions;

using Microsoft.EntityFrameworkCore;

using Shared;

namespace BookingSystemApi.Application.Features.Event.GetEventDetails;

internal sealed class GetEventDetailsQueryHandler : IQueryHandler<GetEventDetailsQuery, GetEventDetailsDto>
{
    private readonly IApplicationDbContext _applicationDbContext;

    public GetEventDetailsQueryHandler(IApplicationDbContext applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
    }

    public async Task<Result<GetEventDetailsDto>> Handle(GetEventDetailsQuery query, CancellationToken cancellationToken)
    {
        var eventDetails = await _applicationDbContext.Events
            .Where(x => x.Id == query.EventId)
            .Include(x => x.Location)
            .Include(x => x.Seats)
            .FirstOrDefaultAsync(cancellationToken);

        return eventDetails is null ?
            new Error("Event not found", ErrorType.NotFound) :
            eventDetails.ToEventDetailsDto();
    }
}