using MapsterMapper;
using MediatR;
using TabletopStats.Application.Dto;
using TabletopStats.Application.Interface.Persistence;
using TabletopStats.Application.UseCases.Commons.Bases;
using TabletopStats.Application.UseCases.SessionLog.Queries.GetGameMasterLogs;

namespace TabletopStats.Application.UseCases.Dictionary.Queries;


public class GetRpgSystemsHandler(IUnitOfWork unitOfWork)
    : IRequestHandler<GetRpgSystemsQuery, BaseResponse<IEnumerable<RpgSystemDto>>>
{
    public async Task<BaseResponse<IEnumerable<RpgSystemDto>>> Handle(GetRpgSystemsQuery request, CancellationToken cancellationToken)
    {
        var rpgSystem = await unitOfWork.RpgSystems.GetAllLikeAsync(request.Name);
        return new BaseResponse<IEnumerable<RpgSystemDto>>
        {
            succcess = true,
            Data = rpgSystem.Select(x => new RpgSystemDto
            {
                Code = x.Code,
                Name = x.Name,
            }),
            Message = null,
            Errors = null
        };
    }
}