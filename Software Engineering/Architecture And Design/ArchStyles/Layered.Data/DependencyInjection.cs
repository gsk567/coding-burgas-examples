using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Layered.Data;

public static class DependencyInjection
{
    public static IServiceCollection AddLayeredData(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddDbContext<LayeredEntityContext>(options =>
        {
            options.UseSqlite(configuration.GetConnectionString("LayeredDb"));
        });
        
        return services;
    }
}