using BookingSystemApi.Api.Helpers;
using BookingSystemApi.Application.Abstractions.Messaging;
using BookingSystemApi.Application.Features.User.CreateUser;

namespace BookingSystemApi.Api.Endpoints;

public static class UserEndpoints
{
    public static IEndpointRouteBuilder MapUserEndpoints(this IEndpointRouteBuilder routeBuilder)
    {
        routeBuilder.MapPost("/users/add", async (
            CreateUserDto createUserDto,
            ICommandHandler<CreateUserCommand, int> commandHandler,
            CancellationToken cancellationToken) =>
            {
                var result = await commandHandler.Handle(new CreateUserCommand(createUserDto), cancellationToken);

                return result.IsSuccess
                    ? Results.Ok(result.Value)
                    : result.Error!.ToHttpResult();
            });

        return routeBuilder;
    }
}