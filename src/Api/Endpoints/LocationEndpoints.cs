using BookingSystemApi.Api.Helpers;
using BookingSystemApi.Application.Abstractions.Messaging;
using BookingSystemApi.Application.Features.Location.CreateLocation;
using BookingSystemApi.Application.Features.Location.GetLocation;

namespace BookingSystemApi.Api.Endpoints;

public static class LocationEndpoints
{
    public static IEndpointRouteBuilder MapLocationEndpoints(this IEndpointRouteBuilder routeBuilder)
    {
        routeBuilder.MapGet("/locations/{locationId}", async (
            int locationId,
            IQueryHandler<GetLocationQuery, GetLocationDto> queryHandler,
            CancellationToken cancellationToken) =>
            {
                var result = await queryHandler.Handle(new GetLocationQuery(locationId), cancellationToken);

                return result.IsSuccess
                    ? Results.Ok(result.Value)
                    : result.Error!.ToHttpResult();
            });

        routeBuilder.MapPost("/locations/add", async (
            CreateLocationDto createLocationDto,
            ICommandHandler<CreateLocationCommand, int> commandHandler,
            CancellationToken cancellationToken) =>
            {
                var result = await commandHandler.Handle(new CreateLocationCommand(createLocationDto), cancellationToken);

                return result.IsSuccess
                    ? Results.Ok(result.Value)
                    : result.Error!.ToHttpResult();
            });

        return routeBuilder;
    }
}