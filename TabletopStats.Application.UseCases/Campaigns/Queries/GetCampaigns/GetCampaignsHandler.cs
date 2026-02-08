using MediatR;
using TabletopStats.Application.Dto;
using TabletopStats.Application.Interface.Persistence;
using TabletopStats.Application.UseCases.Commons.Bases;

namespace TabletopStats.Application.UseCases.Campaigns.Queries.GetCampaigns;

public class GetCampaignsHandler(IUnitOfWork unitOfWork)
    : IRequestHandler<GetCampaignsQuery, BaseResponse<IEnumerable<CampaingDto>>>
{
    public async Task<BaseResponse<IEnumerable<CampaingDto>>> Handle(GetCampaignsQuery request, CancellationToken cancellationToken)
    {
        var campaigns = await unitOfWork.Campaigns.GetAllAsync();
        return new BaseResponse<IEnumerable<CampaingDto>>
        {
            succcess = true,
            Data = campaigns.Select(x => new CampaingDto
            {
                Id = x.Id,
                Name = x.Name
            }),
            Message = null,
            Errors = null
        };
    }
}