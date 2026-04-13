
using BookingSystemApi.Application.Abstractions.Messaging;

namespace BookingSystemApi.Application.Features.Event.CreateEvent;

public sealed record CreateEventCommand(CreateEventDto CreateEventDto) : ICommand<int>;