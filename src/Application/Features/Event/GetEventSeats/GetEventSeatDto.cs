using BookingSystemApi.Domain.Enums;

namespace BookingSystemApi.Application.Features.Event.GetEventSeats;

public class GetEventSeatDto
{
    public int Id { get; set; }
    public int? BookingId { get; set; }
    public decimal Price { get; set; }
    public bool IsAvailable { get; set; } = true;
    public string? Label { get; set; }
    public SeatType SeatType { get; set; }
    public int SeatOccupancy => SeatType == SeatType.GeneralAdmission ? 1 : 2;
}