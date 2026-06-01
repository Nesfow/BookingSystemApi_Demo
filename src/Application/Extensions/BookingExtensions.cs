using BookingSystemApi.Application.Features.Booking.GetBooking;
using BookingSystemApi.Domain.Entities;

namespace BookingSystemApi.Application.Extensions;

public static class BookingExtensions
{
    public static GetBookingDto ToGetBookingDto(this Booking booking)
    {
        return new GetBookingDto()
        {
            BookingId = booking.Id,
            BookedSeatIds = [.. booking.BookedSeats.Select(x => x.Id)],
            BookingDate = booking.BookingDate,
            BookingStatus = booking.BookingStatus,
            EventId = booking.EventId,
            PaymentExpirationDate = booking.PaymentExpirationDate,
            Price = booking.Price,
            UserId = booking.UserId,
        };
    }
}