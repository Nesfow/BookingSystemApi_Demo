using BookingSystemApi.Api.Helpers;
using BookingSystemApi.Application.Abstractions.Messaging;
using BookingSystemApi.Application.Features.Event.CreateEvent;

using Shared;

namespace BookingSystemApi.Api.Endpoints;

public static class EventEndpoints
{
    public static IEndpointRouteBuilder MapEventEndpoints(this IEndpointRouteBuilder routeBuilder)
    {
        routeBuilder.MapPost("/events/add", async (
            CreateEventDto request,
            ICommandHandler<CreateEventCommand, int> commandHandler,
            CancellationToken cancellationToken) =>
            {
                var result = await commandHandler.Handle(new CreateEventCommand(request), cancellationToken);

                return result.IsSuccess
                    ? Results.Ok(result.Value)
                    : result.Error!.ToHttpResult();
            });

        return routeBuilder;
    }
}