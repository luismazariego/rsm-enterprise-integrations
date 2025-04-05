using DIYBeers.Domain.Interfaces;
using DIYBeers.Domain.Interfaces.ExternalServices;
using DIYBeers.Infrastructure.ExternalServices;
using DIYBeers.Infrastructure.Persistence;
using DIYBeers.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace DIYBeers.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services,
                                                               IConfiguration configuration)
    {
        services.AddDbContext<AppDbContext>(options =>
        {
            options.UseSqlServer(configuration.GetConnectionString("BeerDbConnection"),
                opt => opt.MigrationsAssembly(typeof(AppDbContext).Assembly.FullName));
        });
        
        services.AddTransient<IRepository, Repository>();
        
        return services;
    }
}
