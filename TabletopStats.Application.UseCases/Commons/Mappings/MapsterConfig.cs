using Mapster;

namespace TabletopStats.Application.UseCases.Commons.Mappings;

public static class MapsterConfig
{
    public static void Configure(TypeAdapterConfig config)
    {
        config.ConfigurePerson();
        config.ConfigureRpgSystem();
        config.ConfigureSession();
    }
}