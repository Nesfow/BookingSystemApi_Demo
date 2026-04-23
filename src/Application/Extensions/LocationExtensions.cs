using BookingSystemApi.Application.Features.Location.GetLocation;
using BookingSystemApi.Domain.Entities;

namespace BookingSystemApi.Application.Extensions;

public static class LocationExtensions
{
    public static GetLocationDto ToGetLocationDto(this Location location)
    {
        return new GetLocationDto()
        {
            Id = location.Id,
            Name = location.Name,
            Address = location.Address,
            Capacity = location.Capacity,
        };
    }
}