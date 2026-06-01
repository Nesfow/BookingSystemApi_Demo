using BookingSystemApi.Api.Helpers;
using BookingSystemApi.Application.Abstractions.Messaging;
using BookingSystemApi.Application.Features.Booking.CreateBooking;

namespace BookingSystemApi.Api.Endpoints;

public static class BookingEndpoints
{
    public static IEndpointRouteBuilder MapBookingEndpoints(this IEndpointRouteBuilder routeBuilder)
    {
        routeBuilder.MapPost("/bookings/add", async (
            CreateBookingDto createBookingDto,
            ICommandHandler<CreateBookingCommand, CreateBookingResponse> commandHandler,
            CancellationToken cancellationToken) =>
            {
                var result = await commandHandler.Handle(new CreateBookingCommand(createBookingDto), cancellationToken);

                return result.IsSuccess
                    ? Results.Ok(result.Value)
                    : result.Error!.ToHttpResult();
            });

        // routeBuilder.MapGet("/bookings/{bookingId}", async (
        //     int bookingId,
        //     IQueryHandler<GetUserByIdQuery, GetUserByIdDto> queryHandler,
        //     CancellationToken cancellationToken) =>
        //     {
        //         var result = await queryHandler.Handle(new GetUserByIdQuery(userId), cancellationToken);

        //         return result.IsSuccess
        //             ? Results.Ok(result.Value)
        //             : result.Error!.ToHttpResult();
        //     });

        return routeBuilder;
    }
}