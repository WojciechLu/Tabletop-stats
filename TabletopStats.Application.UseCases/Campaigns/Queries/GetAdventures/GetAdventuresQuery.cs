using MediatR;
using TabletopStats.Application.Dto;
using TabletopStats.Application.UseCases.Commons.Bases;

namespace TabletopStats.Application.UseCases.Campaigns.Queries.GetAdventuresQuery;

public class GetAdventuresQuery: IRequest<BaseResponse<IEnumerable<AdventureDto>>>
{
    
}