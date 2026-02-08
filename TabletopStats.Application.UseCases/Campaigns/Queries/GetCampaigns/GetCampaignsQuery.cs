using MediatR;
using TabletopStats.Application.Dto;
using TabletopStats.Application.UseCases.Commons.Bases;

namespace TabletopStats.Application.UseCases.Campaigns.Queries.GetCampaigns;

public class GetCampaignsQuery: IRequest<BaseResponse<IEnumerable<CampaingDto>>>
{
    
}