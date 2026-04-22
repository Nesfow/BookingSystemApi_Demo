using BookingSystemApi.Api.Helpers;
using BookingSystemApi.Application.Abstractions.Messaging;
using BookingSystemApi.Application.Features.Event.AddSeats;
using BookingSystemApi.Application.Features.Event.CreateEvent;
using BookingSystemApi.Application.Features.Event.GetEventDetails;

namespace BookingSystemApi.Api.Endpoints;

public static class EventEndpoints
{
    public static IEndpointRouteBuilder MapEventEndpoints(this IEndpointRouteBuilder routeBuilder)
    {
        routeBuilder.MapGet("/events/{eventId}", async (
            int eventId,
            IQueryHandler<GetEventDetailsQuery, EventDetailsDto> queryHandler,
            CancellationToken cancellationToken) =>
            {
                var result = await queryHandler.Handle(new GetEventDetailsQuery(eventId), cancellationToken);

                return result.IsSuccess
                    ? Results.Ok(result.Value)
                    : result.Error!.ToHttpResult();
            });

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

        routeBuilder.MapPost("/events/{eventId}/seats", async (
            int eventId,
            List<AddSeatDto> request,
            ICommandHandler<AddSeatsCommand> commandHandler,
            CancellationToken cancellationToken) =>
            {
                var result = await commandHandler.Handle(new AddSeatsCommand(eventId, request), cancellationToken);

                return result.IsSuccess
                    ? Results.Ok()
                    : result.Error!.ToHttpResult();
            });

        return routeBuilder;
    }
}