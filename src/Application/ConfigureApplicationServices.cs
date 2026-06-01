using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;

using BookingSystemApi.Application.Abstractions.Messaging;
using BookingSystemApi.Application.Features.Event.CreateEvent;
using BookingSystemApi.Application.Features.Event.GetEventDetails;
using BookingSystemApi.Application.Features.Event.AddSeats;
using BookingSystemApi.Application.Features.Location.GetLocation;
using BookingSystemApi.Application.Features.Event.GetEventSeats;
using BookingSystemApi.Application.Features.Location.CreateLocation;
using BookingSystemApi.Application.Features.User.CreateUser;
using BookingSystemApi.Application.Features.User.GetUserById;
using BookingSystemApi.Application.Features.Booking.CreateBooking;

namespace BookingSystemApi.Application;

public static class ConfigureApplicationServices
{

    public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<ICommandHandler<CreateEventCommand, int>, CreateEventCommandHandler>();
        services.AddScoped<ICommandHandler<CreateLocationCommand, int>, CreateLocationCommandHandler>();
        services.AddScoped<ICommandHandler<AddSeatsCommand>, AddSeatsCommandHandler>();
        services.AddScoped<ICommandHandler<CreateUserCommand, int>, CreateUserCommandHandler>();
        services.AddScoped<ICommandHandler<CreateBookingCommand, CreateBookingResponse>, CreateBookingCommandHandler>();

        services.AddScoped<IQueryHandler<GetEventDetailsQuery, GetEventDetailsDto>, GetEventDetailsQueryHandler>();
        services.AddScoped<IQueryHandler<GetLocationQuery, GetLocationDto>, GetLocationQueryHandler>();
        services.AddScoped<IQueryHandler<GetEventSeatsQuery, IReadOnlyCollection<GetEventSeatDto>>, GetEventSeatsQueryHandler>();
        services.AddScoped<IQueryHandler<GetUserByIdQuery, GetUserByIdDto>, GetUserByIdQueryHandler>();

        return services;
    }
}