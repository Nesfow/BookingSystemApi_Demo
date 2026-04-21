using BookingSystemApi.Domain.Enums;

namespace BookingSystemApi.Application.Features.Event.AddSeats;

public class AddSeatDto
{
    public decimal Price { get; set; }
    public bool IsAvailable { get; set; } = true;
    public string? Label { get; set; }
    public SeatType SeatType { get; set; } = SeatType.Standard;
}