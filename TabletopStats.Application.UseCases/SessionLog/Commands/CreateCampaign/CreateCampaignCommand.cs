using MediatR;
using TabletopStats.Application.UseCases.Commons.Bases;

namespace TabletopStats.Application.UseCases.SessionLog.Commands.CreateCampaign;

public class CreateCampaignCommand : IRequest<BaseResponse<bool>>
{
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
}