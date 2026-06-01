using BookingSystemApi.Application.Abstractions.Messaging;

namespace BookingSystemApi.Application.Features.Booking.GetBooking;

public sealed record GetBookingQuery(int BookingId) : IQuery<GetBookingDto>;