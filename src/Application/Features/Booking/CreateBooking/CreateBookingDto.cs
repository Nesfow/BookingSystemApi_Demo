namespace BookingSystemApi.Application.Features.Booking.CreateBooking;

public class CreateBookingDto
{
    public required int UserId { get; set; }
    public required int EventId { get; set; }
    public required List<int> Seats { get; set; } = [];
}