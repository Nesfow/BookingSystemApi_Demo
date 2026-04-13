using BookingSystemApi.Domain.Entities;

namespace BookingSystemApi.Application.Features.Event.CreateEvent;

public class CreateEventDto
{
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
    public DateTimeOffset EventDate { get; set; }
    public Location Location { get; set; } = null!;
    public List<EventSeat> Seats { get; set; } = [];
}