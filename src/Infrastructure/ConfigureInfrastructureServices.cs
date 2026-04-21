using BookingSystemApi.Infrastructure.Persistence;
using BookingSystemApi.Application.Abstractions.Data;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;

namespace BookingSystemApi.Infrastructure;

public static class ConfigureInfrastructureServices
{
    private const string DbName = "BookingSystemDb";

    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<BookingSystemDbContext>(options =>
        {
            options.UseSqlServer(
                configuration.GetConnectionString(DbName),
                sqlServerOptionsAction =>
                    {
                        sqlServerOptionsAction.EnableRetryOnFailure(3);
                    });
            options.EnableSensitiveDataLogging();
        });

        services.AddScoped<IApplicationDbContext>(sp => sp.GetRequiredService<BookingSystemDbContext>());

        return services;
    }
}