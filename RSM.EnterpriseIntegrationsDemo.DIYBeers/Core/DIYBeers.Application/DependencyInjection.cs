using DIYBeers.Application.Interfaces;
using DIYBeers.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace DIYBeers.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddScoped<IBeerService, BeerService>();
        return services;
    }
}
