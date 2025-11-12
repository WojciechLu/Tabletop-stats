using Mapster;
using TabletopStats.Application.Dto;
using TabletopStats.Domain.Entities;

namespace TabletopStats.Application.UseCases.Commons.Mappings;

public static class PlayerMapper
{
    public static void ConfigurePerson(this TypeAdapterConfig config)
    {
        config.NewConfig<Person, PersonDto>()
            .Map(dest => dest.Name, src => src.Name)
            .Map(dest => dest.Id, src => src.Id);
    }
}