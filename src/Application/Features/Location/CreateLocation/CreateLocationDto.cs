namespace BookingSystemApi.Application.Features.Location.CreateLocation;

public class CreateLocationDto
{
    public string Name { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
    public int Capacity { get; set; }
}