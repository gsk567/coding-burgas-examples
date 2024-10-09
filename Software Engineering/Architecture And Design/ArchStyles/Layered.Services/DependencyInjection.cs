using Layered.Services.Contracts;
using Layered.Services.Implementations;
using Microsoft.Extensions.DependencyInjection;

namespace Layered.Services;

public static class DependencyInjection
{
    public static IServiceCollection AddLayeredServices(
        this IServiceCollection services)
    {
        services.AddScoped<IDogService, DogService>();

        return services;
    }
}