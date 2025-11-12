using MapsterMapper;
using MediatR;
using TabletopStats.Application.Dto;
using TabletopStats.Application.Interface.Persistence;
using TabletopStats.Application.UseCases.Commons.Bases;

namespace TabletopStats.Application.UseCases.SessionLog.Queries.GetPlayerLogs;

public class GetPlayerLogsHandler(IUnitOfWork unitOfWork, IMapper mapper) : IRequestHandler<GetPlayerLogsQuery, BaseResponse<IEnumerable<SessionLogDto>>>
{
    public async Task<BaseResponse<IEnumerable<SessionLogDto>>> Handle(GetPlayerLogsQuery request, CancellationToken cancellationToken)
    {
        var sessions = await unitOfWork.SessionLogs.GetPlayerLogsAsync(request.PlayerId, request.PageNumber, request.PageSize);
        var sessionDtos = mapper.Map<IEnumerable<SessionLogDto>>(sessions);
        return new BaseResponse<IEnumerable<SessionLogDto>>
        {
            succcess = true,
            Data = sessionDtos
        };
    }
}