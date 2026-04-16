using BookingSystemApi.Application;
using BookingSystemApi.Application.Abstractions.Messaging;
using BookingSystemApi.Application.Features.Event.CreateEvent;
using BookingSystemApi.Infrastructure;

using Shared;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddInfrastructureServices(builder.Configuration);
builder.Services.AddApplicationServices(builder.Configuration);

var app = builder.Build();


app.MapGet("/", () => "Hello World!");

// This is the first endpoint I have created, so will justify my thoughts here
// I could create a request object for POST, PUT endpoints, however,
// I simplified it and using a DTO object instead, which is also used in the handler
app.MapPost("/events/add", async (
    CreateEventDto request,
    ICommandHandler<CreateEventCommand, int> commandHandler,
    CancellationToken cancellationToken) =>
    {
        var result = await commandHandler.Handle(new CreateEventCommand(request), cancellationToken);

        if (result.IsSuccess)
        {
            return Results.Ok(result.Value);
        }

        return result.Error!.Type switch
        {
            ErrorType.NotFound => Results.NotFound(result.Error.Description),
            ErrorType.Conflict => Results.Conflict(result.Error.Description),
            _ => Results.BadRequest(result.Error.Description)
        };
    });


app.Run();
