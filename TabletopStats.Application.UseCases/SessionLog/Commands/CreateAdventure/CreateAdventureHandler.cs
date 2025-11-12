using MediatR;
using TabletopStats.Application.Interface.Persistence;
using TabletopStats.Application.UseCases.Commons.Bases;
using TabletopStats.Domain.Entities;

namespace TabletopStats.Application.UseCases.SessionLog.Commands.CreateAdventure;

public class CreateAdventureHandler(IUnitOfWork unitOfWork)
    : IRequestHandler<CreateAdventureCommand, BaseResponse<bool>>
{
    public async Task<BaseResponse<bool>> Handle(CreateAdventureCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var campaign = await unitOfWork.Campaigns.GetAsync(request.CampaignId);

            var adventure = new Adventure
            {
                Id = Guid.NewGuid(),
                Name = request.Name,
                Description = request.Description ?? string.Empty,
                Sessions = [],
            };

            await unitOfWork.Adventures.InsertAsync(adventure);

            if (campaign != null)
            {
                campaign.Adventures ??= new List<Adventure>();
                campaign.Adventures.Add(adventure);
                await unitOfWork.Campaigns.UpdateAsync(campaign);
            }

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