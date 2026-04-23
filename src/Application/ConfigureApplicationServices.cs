using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;

using BookingSystemApi.Application.Abstractions.Messaging;
using BookingSystemApi.Application.Features.Event.CreateEvent;
using BookingSystemApi.Application.Features.Event.GetEventDetails;
using BookingSystemApi.Application.Features.Event.AddSeats;
using BookingSystemApi.Application.Features.Location.GetLocation;
using BookingSystemApi.Application.Features.Event.GetEventSeats;

namespace BookingSystemApi.Application;

public static class ConfigureApplicationServices
{

    public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddTransient<ICommandHandler<CreateEventCommand, int>, CreateEventCommandHandler>();
        services.AddTransient<ICommandHandler<AddSeatsCommand>, AddSeatsCommandHandler>();
        services.AddTransient<IQueryHandler<GetEventDetailsQuery, GetEventDetailsDto>, GetEventDetailsQueryHandler>();
        services.AddTransient<IQueryHandler<GetLocationQuery, GetLocationDto>, GetLocationQueryHandler>();
        services.AddTransient<IQueryHandler<GetEventSeatsQuery, IReadOnlyCollection<GetEventSeatDto>>, GetEventSeatsQueryHandler>();

        return services;
    }
}