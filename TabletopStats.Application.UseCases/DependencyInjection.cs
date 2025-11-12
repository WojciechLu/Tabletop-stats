using Mapster;
using Microsoft.Extensions.DependencyInjection;
using TabletopStats.Application.UseCases.Commons.Mappings;

namespace TabletopStats.Application.UseCases;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(cf => cf.RegisterServicesFromAssembly(typeof(DependencyInjection).Assembly));
        var config = new TypeAdapterConfig();
        MapsterConfig.Configure(config);
        services.AddMapster();

        return services;

    }
}