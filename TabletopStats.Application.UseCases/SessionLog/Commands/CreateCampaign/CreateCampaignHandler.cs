using MediatR;
using TabletopStats.Application.Interface.Persistence;
using TabletopStats.Application.UseCases.Commons.Bases;
using TabletopStats.Domain.Entities;

namespace TabletopStats.Application.UseCases.SessionLog.Commands.CreateCampaign;

public class CreateCampaignHandler(IUnitOfWork unitOfWork) 
    : IRequestHandler<CreateCampaignCommand, BaseResponse<bool>>
{
    public async Task<BaseResponse<bool>> Handle(CreateCampaignCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var campaign = new Campaign
            {
                Id = Guid.NewGuid(),
                Name = request.Name,
                Description = request.Description ?? string.Empty,
                Adventures = new List<Adventure>()
            };

            await unitOfWork.Campaigns.InsertAsync(campaign);

            return new BaseResponse<bool>
            {
                succcess = true,
                Data = true
            };
        }
        catch (Exception ex)
        {
            return new BaseResponse<bool>
            {
                succcess = false,
                Data = false,
                Message = ex.Message
            };
        }
    }
}