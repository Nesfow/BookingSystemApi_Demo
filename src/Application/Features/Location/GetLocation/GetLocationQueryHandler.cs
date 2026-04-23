using BookingSystemApi.Application.Abstractions.Data;
using BookingSystemApi.Application.Abstractions.Messaging;
using BookingSystemApi.Application.Extensions;

using Microsoft.EntityFrameworkCore;

using Shared;

namespace BookingSystemApi.Application.Features.Location.GetLocation;

internal sealed class GetLocationQueryHandler : IQueryHandler<GetLocationQuery, GetLocationDto>
{
    private readonly IApplicationDbContext _applicationDbContext;

    public GetLocationQueryHandler(IApplicationDbContext applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
    }

    public async Task<Result<GetLocationDto>> Handle(GetLocationQuery query, CancellationToken cancellationToken)
    {
        var locationDetails = await _applicationDbContext.Locations
            .Where(x => x.Id == query.LocationId)
            .FirstOrDefaultAsync(cancellationToken);

        return locationDetails is null ?
            new Error("Location not found", ErrorType.NotFound) :
            locationDetails.ToGetLocationDto();
    }
}