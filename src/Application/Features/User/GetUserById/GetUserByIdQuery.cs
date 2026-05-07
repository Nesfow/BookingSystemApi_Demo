using BookingSystemApi.Application.Abstractions.Messaging;

namespace BookingSystemApi.Application.Features.User.GetUserById;

public sealed record GetUserByIdQuery(int UserId) : IQuery<GetUserByIdDto>;