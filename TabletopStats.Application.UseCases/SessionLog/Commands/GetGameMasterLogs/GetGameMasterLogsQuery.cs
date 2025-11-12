using MediatR;
using TabletopStats.Application.Dto;

namespace TabletopStats.Application.UseCases.SessionLog.Commands.GetGameMasterLogs;

public class GetGameMasterLogsQuery: IRequest<SessionLogDto>
{
    public int PageSize { get; set; }
    public int PageNumber { get; set; }
}