using BookingSystemApi.Application.Abstractions.Messaging;

namespace BookingSystemApi.Application.Features.Booking.CreateBooking;

public sealed record CreateBookingCommand(CreateBookingDto CreateBookingDto) : ICommand<CreateBookingResponse>;