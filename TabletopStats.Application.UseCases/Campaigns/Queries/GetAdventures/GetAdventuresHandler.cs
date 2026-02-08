using MediatR;
using TabletopStats.Application.Dto;
using TabletopStats.Application.Interface.Persistence;
using TabletopStats.Application.UseCases.Commons.Bases;

namespace TabletopStats.Application.UseCases.Campaigns.Queries.GetAdventuresQuery;

public class GetAdventuresHandler(IUnitOfWork unitOfWork)
    : IRequestHandler<GetAdventuresQuery, BaseResponse<IEnumerable<AdventureDto>>>
{
    public async Task<BaseResponse<IEnumerable<AdventureDto>>> Handle(GetAdventuresQuery request, CancellationToken cancellationToken)
    {
        var adventutes = await unitOfWork.Adventures.GetAllAsync();
        return new BaseResponse<IEnumerable<AdventureDto>>
        {
            succcess = true,
            Data = adventutes.Select(x => new AdventureDto
            {
                Id = x.Id,
                Name = x.Name
            }),
            Message = null,
            Errors = null
        };
    }
}