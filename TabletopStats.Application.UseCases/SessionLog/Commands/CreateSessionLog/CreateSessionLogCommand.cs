using MediatR;
using TabletopStats.Application.Dto;
using TabletopStats.Application.UseCases.Commons.Bases;

namespace TabletopStats.Application.UseCases.SessionLog.Commands.CreateSessionLog;

public class CreateSessionLogCommand: IRequest<BaseResponse<bool>>
{
    public Guid? AdventureId { get; set; }
    public string SessionName { get; set; }
    public string Description { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    public RpgSystemDto RpgSystem { get; set; }
    public PersonDto? GameMaster { get; set; }
    public IEnumerable<PersonDto> Players { get; set; }
}