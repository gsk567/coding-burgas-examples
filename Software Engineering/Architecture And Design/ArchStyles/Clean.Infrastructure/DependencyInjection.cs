using Clean.Application.Contracts;
using Clean.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Clean.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddDbContext<CleanEntityContext>(options =>
        {
            options.UseSqlite(configuration.GetConnectionString("CleanDb"));
        });

        services.AddScoped<IDogRepository, DogRepository>();
        
        return services;
    }
}