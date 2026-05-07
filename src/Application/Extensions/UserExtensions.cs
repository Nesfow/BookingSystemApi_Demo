using BookingSystemApi.Application.Features.User.GetUserById;
using BookingSystemApi.Domain.Entities;

namespace BookingSystemApi.Application.Extensions;

public static class UserExtensions
{
    public static GetUserByIdDto ToUserByIdDto(this User user)
    {
        return new GetUserByIdDto()
        {
            Id = user.Id,
            Name = user.Name,
            Email = user.Email,
        };
    }
}