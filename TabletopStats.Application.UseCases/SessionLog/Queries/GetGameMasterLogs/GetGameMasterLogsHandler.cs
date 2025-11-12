using MapsterMapper;
using MediatR;
using TabletopStats.Application.Dto;
using TabletopStats.Application.Interface.Persistence;
using TabletopStats.Application.UseCases.Commons.Bases;

namespace TabletopStats.Application.UseCases.SessionLog.Queries.GetGameMasterLogs;

public class GetGameMasterLogsHandler(IUnitOfWork unitOfWork, IMapper mapper) : IRequestHandler<GetGameMasterLogsQuery, BaseResponse<IEnumerable<SessionLogDto>>>
{
    public async Task<BaseResponse<IEnumerable<SessionLogDto>>> Handle(GetGameMasterLogsQuery request, CancellationToken cancellationToken)
    {
        var sessions = await unitOfWork.SessionLogs.GetGameMasterLogsAsync(request.GameMasterId, request.PageNumber, request.PageSize);
        var sessionDtos = mapper.Map<IEnumerable<SessionLogDto>>(sessions);
        return new BaseResponse<IEnumerable<SessionLogDto>>
        {
            succcess = true,
            Data = sessionDtos
        };
    }
}