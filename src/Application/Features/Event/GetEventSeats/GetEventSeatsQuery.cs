using BookingSystemApi.Application.Abstractions.Messaging;

namespace BookingSystemApi.Application.Features.Event.GetEventSeats;

public sealed record GetEventSeatsQuery(int EventId) : IQuery<IReadOnlyCollection<GetEventSeatDto>>;