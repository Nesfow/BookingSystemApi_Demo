using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using BookingSystemApi.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using BookingSystemApi.Application.Abstractions.Repositories;
using BookingSystemApi.Infrastructure.Services;

namespace BookingSystemApi.Infrastructure;

public static class ConfigureInfrastructureServices
{
    private const string DbName = "BookingSystemDb";

    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContextFactory<BookingSystemDbContext>(options =>
        {
            options.UseSqlServer(
                configuration.GetConnectionString(DbName),
                sqlServerOptionsAction =>
                    {
                        sqlServerOptionsAction.EnableRetryOnFailure(3);
                    });
        });

        services.AddScoped<IEventRepository, EventRepository>();
        services.AddScoped<ILocationRepository, LocationRepository>();

        return services;
    }
}