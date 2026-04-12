using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using BookingSystemApi.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace BookingSystemApi.Infrastructure;

public static class ConfigureInfrastructureServices
{
    private const string DbName = "BookingSystemDb";

    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContextFactory<BookingSystemDbContext>(options =>
        {
            options.UseSqlServer(
                configuration.GetConnectionString(DbName) ?? throw new InvalidOperationException($"Connection string '{DbName}' not found."),
                sqlServerOptionsAction =>
                    {
                        sqlServerOptionsAction.EnableRetryOnFailure(3);
                    });
        });

        return services;
    }
}