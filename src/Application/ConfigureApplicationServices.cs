using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;

using BookingSystemApi.Application.Abstractions.Messaging;
using BookingSystemApi.Application.Features.Event.CreateEvent;

namespace BookingSystemApi.Application;

public static class ConfigureApplicationServices
{

    public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddTransient<ICommandHandler<CreateEventCommand, int>, CreateEventCommandHandler>();

        return services;
    }
}