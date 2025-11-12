using Mapster;
using TabletopStats.Application.Dto;
using TabletopStats.Domain.Entities;

namespace TabletopStats.Application.UseCases.Commons.Mappings;

public static class RpgSystemMapper
{
    public static void ConfigureRpgSystem(this TypeAdapterConfig config)
    {
        config.NewConfig<RpgSystem, RpgSystemDto>()
            .Map(dest => dest.Name, src => src.Name)
            .Map(dest => dest.Code, src => src.Code);
    }
}