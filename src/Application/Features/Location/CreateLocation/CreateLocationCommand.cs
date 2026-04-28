using BookingSystemApi.Application.Abstractions.Messaging;

namespace BookingSystemApi.Application.Features.Location.CreateLocation;

public sealed record CreateLocationCommand(CreateLocationDto CreateLocationDto) : ICommand<int>;