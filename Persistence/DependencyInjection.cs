using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Repository;

namespace Persistence;

public static class DependencyInjection
{
    public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<AppDbContext>(
            optionsBuilder => { optionsBuilder.UseNpgsql(configuration.GetConnectionString("PostgresqlConnection")); },
            ServiceLifetime.Scoped,
            ServiceLifetime.Scoped
        );

        services.AddScoped<Repo>();

        return services;
    }
}