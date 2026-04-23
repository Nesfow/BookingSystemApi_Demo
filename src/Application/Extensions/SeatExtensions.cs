using BookingSystemApi.Application.Features.Event.GetEventSeats;
using BookingSystemApi.Domain.Entities;

namespace BookingSystemApi.Application.Extensions;

public static class SeatExtensions
{
    public static GetEventSeatDto ToGetEventSeatDto(this Seat seat)
    {
        return new GetEventSeatDto()
        {
            Id = seat.Id,
            BookingId = seat.BookingId,
            IsAvailable = seat.IsAvailable,
            Label = seat.Label,
            Price = seat.Price,
            SeatType = seat.SeatType,
        };
    }
}