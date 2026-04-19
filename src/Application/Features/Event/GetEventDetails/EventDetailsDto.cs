using BookingSystemApi.Application.Features.Location.GetLocation;
using BookingSystemApi.Domain.Enums;

namespace BookingSystemApi.Application.Features.Event.GetEventDetails;

public class EventDetailsDto
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string? Description { get; set; }
    public DateTime Date { get; set; }
    public Dictionary<SeatType, int> AllSeats { get; set; } = [];
    public Dictionary<SeatType, int> AvailableSeats { get; set; } = [];
    public GetLocationDto Location { get; set; } = null!;
}