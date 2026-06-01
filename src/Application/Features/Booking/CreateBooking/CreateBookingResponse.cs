using BookingSystemApi.Domain.Enums;

namespace BookingSystemApi.Application.Features.Booking.CreateBooking;

public sealed class CreateBookingResponse
{
    public int BookingId { get; init; }
    public decimal AmountToPay { get; init; }
    public BookingStatus BookingStatus { get; set; }
    public DateTimeOffset PaymentExpirationDate { get; set; }
}