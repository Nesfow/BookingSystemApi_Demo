using BookingSystemApi.Application.Abstractions.Messaging;
using BookingSystemApi.Application.Abstractions.Repositories;
using BookingSystemApi.Application.Extensions;

using Shared;

namespace BookingSystemApi.Application.Features.Event.GetEventDetails;

internal sealed class GetEventDetailsQueryHandler : IQueryHandler<GetEventDetailsQuery, EventDetailsDto>
{
    private readonly IEventRepository _eventRepository;

    public GetEventDetailsQueryHandler(IEventRepository eventRepository)
    {
        _eventRepository = eventRepository;
    }

    public async Task<Result<EventDetailsDto>> Handle(GetEventDetailsQuery query, CancellationToken cancellationToken)
    {
        var eventDetails = await _eventRepository.GetEventAsync(query.EventId, cancellationToken);

        return eventDetails is null ?
            new Error("Event not found", ErrorType.NotFound) :
            eventDetails.ToEventDetailsDto();
    }
}