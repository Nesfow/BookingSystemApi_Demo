using BookingSystemApi.Application.Abstractions.Messaging;

namespace BookingSystemApi.Application.Features.Event.AddSeats;

public sealed record AddSeatsCommand(int EventId, List<AddSeatDto> AddSeatsDtos) : ICommand;