using BookingSystemApi.Application.Features.Event.AddSeats;
using BookingSystemApi.Domain.Entities;

namespace BookingSystemApi.Application.Extensions;

public static class SeatExtensions
{
    public static Seat ToSeat(this AddSeatDto seat)
    {
        return new Seat(seat.Price)
        {
            Label = seat.Label,
            SeatType = seat.SeatType,
            IsAvailable = seat.IsAvailable,
        };
    }
}