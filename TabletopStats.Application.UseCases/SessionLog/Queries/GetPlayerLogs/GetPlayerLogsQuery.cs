using MediatR;
using TabletopStats.Application.Dto;
using TabletopStats.Application.UseCases.Commons.Bases;

namespace TabletopStats.Application.UseCases.SessionLog.Queries.GetPlayerLogs;

public class GetPlayerLogsQuery: IRequest<BaseResponse<IEnumerable<SessionLogDto>>>
{
    public Guid PlayerId { get; set; }
    public int PageSize { get; set; }
    public int PageNumber { get; set; }
}