using MediatR;
using TabletopStats.Application.Dto;
using TabletopStats.Application.UseCases.Commons.Bases;

namespace TabletopStats.Application.UseCases.SessionLog.Commands.GetPlayerLogs;

public class GetPlayerLogsQuery: IRequest<BaseResponse<SessionLogDto>>
{
    public int PageSize { get; set; }
    public int PageNumber { get; set; }
}