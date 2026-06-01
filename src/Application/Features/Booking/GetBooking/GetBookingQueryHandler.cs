using BookingSystemApi.Application.Abstractions.Data;
using BookingSystemApi.Application.Abstractions.Messaging;
using BookingSystemApi.Application.Extensions;

using Microsoft.EntityFrameworkCore;

using Shared;

namespace BookingSystemApi.Application.Features.Booking.GetBooking;

internal sealed class GetBookingQueryHandler : IQueryHandler<GetBookingQuery, GetBookingDto>
{
    private readonly IApplicationDbContext _applicationDbContext;

    public GetBookingQueryHandler(IApplicationDbContext applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
    }

    public async Task<Result<GetBookingDto>> Handle(GetBookingQuery query, CancellationToken cancellationToken)
    {
        var bookingDetails = await _applicationDbContext.Bookings
            .AsNoTracking()
            .Where(x => x.Id == query.BookingId)
            .FirstOrDefaultAsync(cancellationToken);

        return bookingDetails is null ?
            new Error("Booking not found", ErrorType.NotFound) :
            bookingDetails.ToGetBookingDto();
    }
}