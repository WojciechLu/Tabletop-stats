using Mapster;
using TabletopStats.Application.Dto;

namespace TabletopStats.Application.UseCases.Commons.Mappings;

public static class SessionMapper
{
    public static void ConfigureSession(this TypeAdapterConfig config)
    {
        config.NewConfig<Domain.Entities.SessionLog, SessionLogDto>()
            .Map(dest => dest.SessionId, src => src.SessionId)
            .Map(dest => dest.SessionName, src => src.SessionName)
            .Map(dest => dest.Description, src => src.Description)
            .Map(dest => dest.StartTime, src => src.StartTime)
            .Map(dest => dest.EndTime, src => src.EndTime)
            .Map(dest => dest.Duration, src => src.EndTime - src.StartTime)
            .Map(dest => dest.RpgSystem, src => src.RpgSystem)
            .Map(dest => dest.GameMaster, src => src.GameMaster)
            .Map(dest => dest.Players, src => src.Players)
            .Map(
                dest => dest.AdventureId, 
                src => src.Adventure != null ? (Guid?)src.Adventure.Id : null)
            .Map(
                dest => dest.CampaignId, 
                src => src.Adventure != null ? (Guid?)src.Adventure.Campaign.Id : null);
    }
}