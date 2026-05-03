using BookingSystemApi.Application.Abstractions.Messaging;

namespace BookingSystemApi.Application.Features.User;

public sealed record CreateUserCommand(CreateUserDto CreateUserDto) : ICommand<int>;