using BookingSystemApi.Application.Abstractions.Data;
using BookingSystemApi.Application.Abstractions.Messaging;

using Microsoft.EntityFrameworkCore;

using Shared;

namespace BookingSystemApi.Application.Features.Booking.CreateBooking;

internal sealed class CreateBookingCommandHandler : ICommandHandler<CreateBookingCommand, CreateBookingResponse>
{
    private readonly IApplicationDbContext _applicationDbContext;

    public CreateBookingCommandHandler(IApplicationDbContext applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
    }

    public async Task<Result<CreateBookingResponse>> Handle(CreateBookingCommand command, CancellationToken cancellationToken)
    {
        // for simlicity - having 1 booking per user
        var bookingExists = await _applicationDbContext.Bookings
            .AnyAsync(x => x.UserId == command.CreateBookingDto.UserId && x.EventId == command.CreateBookingDto.EventId, cancellationToken);

        if (bookingExists)
        {
            return new Error("User already has booking for this event; booking can be canceled or changed", ErrorType.Conflict);
        }

        var thisEvent = await _applicationDbContext.Events.FirstOrDefaultAsync(x => x.Id == command.CreateBookingDto.EventId,
            cancellationToken);

        if (thisEvent is null)
        {
            return new Error("Event doesn't exist", ErrorType.NotFound);
        }

        if (thisEvent.EventDate < DateTimeOffset.UtcNow)
        {
            return new Error("Event has already finished", ErrorType.Validation);
        }

        var newBooking = new Domain.Entities.Booking(command.CreateBookingDto.UserId, command.CreateBookingDto.EventId);

        newBooking.CalculatePaymentExpirationDate(thisEvent.EventDate);

        var seatsToBook = await _applicationDbContext.Seats
            .Where(x => command.CreateBookingDto.Seats.Contains(x.Id))
            .ToListAsync(cancellationToken);

        if (seatsToBook.Any(x => x.EventId != command.CreateBookingDto.EventId))
        {
            return new Error("One or more seats are not for this event", ErrorType.Conflict);
        }

        if (seatsToBook.Any(x => !x.IsAvailable))
        {
            return new Error("One or more seats are already booked", ErrorType.Conflict);
        }

        foreach (var seat in seatsToBook)
        {
            seat.Book(newBooking);
        }

        newBooking.CalculateBookingPrice();

        _applicationDbContext.Bookings.Add(newBooking);
        await _applicationDbContext.SaveChangesAsync(cancellationToken);

        return new CreateBookingResponse()
        {
            BookingId = newBooking.Id,
            AmountToPay = newBooking.CalculatePaymentOwned(),
            BookingStatus = newBooking.BookingStatus,
            PaymentExpirationDate = newBooking.PaymentExpirationDate,
        };
    }
}