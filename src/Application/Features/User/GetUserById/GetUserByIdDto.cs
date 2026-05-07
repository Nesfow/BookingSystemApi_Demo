namespace BookingSystemApi.Application.Features.User.GetUserById;

public class GetUserByIdDto
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public required string Email { get; set; }
}