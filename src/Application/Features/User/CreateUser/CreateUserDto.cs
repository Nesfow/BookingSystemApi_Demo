namespace BookingSystemApi.Application.Features.User.CreateUser;

public class CreateUserDto
{
    public required string Name { get; set; }
    public required string Email { get; set; }
}