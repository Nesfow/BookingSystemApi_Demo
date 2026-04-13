using BookingSystemApi.Application.Abstractions.Messaging;
using Shared;

namespace BookingSystemApi.Application.Features.Event.GetEventDetails;

internal sealed class GetEventDetailsQueryHandler() : IQueryHandler<GetEventDetailsQuery, EventDetailsDto>
{
    public Task<Result<EventDetailsDto>> Handle(GetEventDetailsQuery query, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }


}