using MediatR;
using TabletopStats.Application.UseCases.Commons.Bases;

namespace TabletopStats.Application.UseCases.SessionLog.Commands.CreateAdventure;

public class CreateAdventureCommand : IRequest<BaseResponse<bool>>
{
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
    public Guid CampaignId { get; set; }
}