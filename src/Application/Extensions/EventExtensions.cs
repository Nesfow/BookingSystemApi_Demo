using BookingSystemApi.Application.Features.Event.GetEventDetails;
using BookingSystemApi.Domain.Entities;

namespace BookingSystemApi.Application.Extensions;

public static class EventExtensions
{
    public static GetEventDetailsDto ToEventDetailsDto(this Event thisEvent)
    {
        return new GetEventDetailsDto()
        {
            Id = thisEvent.Id,
            Name = thisEvent.Name,
            Description = thisEvent.Description,
            Date = thisEvent.EventDate.DateTime,
            AllSeats = thisEvent.Seats.GroupBy(es => es.SeatType)
                .ToDictionary(x => x.Key, x => x.Count()),
            AvailableSeats = thisEvent.Seats
                .Where(x => x.IsAvailable)
                .GroupBy(es => es.SeatType)
                .ToDictionary(x => x.Key, x => x.Count()),
            Location = new Features.Location.GetLocation.GetLocationDto()
            {
                Id = thisEvent.Location.Id,
                Address = thisEvent.Location.Address,
                Capacity = thisEvent.Location.Capacity,
                Name = thisEvent.Location.Name
            }
        };
    }
}