using MediatR;
using TabletopStats.Application.Dto;
using TabletopStats.Application.UseCases.Commons.Bases;

namespace TabletopStats.Application.UseCases.SessionLog.Queries.GetGameMasterLogs;

public class GetGameMasterLogsQuery: IRequest<BaseResponse<IEnumerable<SessionLogDto>>>
{
    public Guid GameMasterId { get; set; }
    public int PageSize { get; set; }
    public int PageNumber { get; set; }
}