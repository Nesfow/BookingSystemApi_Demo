using BookingSystemApi.Application.Abstractions.Messaging;

namespace BookingSystemApi.Application.Features.Event.GetEventDetails;

public sealed record GetEventDetailsQuery(int EventId) : IQuery<GetEventDetailsDto>;