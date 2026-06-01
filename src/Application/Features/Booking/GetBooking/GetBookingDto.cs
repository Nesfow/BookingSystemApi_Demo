using BookingSystemApi.Domain.Enums;

namespace BookingSystemApi.Application.Features.Booking.GetBooking;

public class GetBookingDto
{
    public int BookingId { get; set; }
    public int UserId { get; set; }
    public int EventId { get; set; }
    public DateTimeOffset BookingDate { get; set; }
    public BookingStatus BookingStatus { get; set; }
    public DateTimeOffset PaymentExpirationDate { get; set; }
    public decimal Price { get; set; }

    public List<int> BookedSeatIds { get; set; } = [];
}