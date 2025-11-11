using Microsoft.Extensions.DependencyInjection;
using TabletopStats.Application.Interface.Persistence;
using TabletopStats.Infrastructure.Repositories;

namespace TabletopStats.Infrastructure;

public static class ConfigureServices
{
    public static IServiceCollection AddInjectionInfrastructure(this IServiceCollection services)
    {
        services.AddScoped<ISessionLogRepository, SessionLogRepository>();
        services.AddScoped<IPersonRepository, PersonRepository>();
        services.AddScoped<IUnitOfWork, UnitOfWork>();

        return services;
    } 
}