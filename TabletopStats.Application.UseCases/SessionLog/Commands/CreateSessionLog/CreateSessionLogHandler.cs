using MediatR;
using TabletopStats.Application.Interface.Persistence;
using TabletopStats.Application.UseCases.Commons.Bases;

namespace TabletopStats.Application.UseCases.SessionLog.Commands.CreateSessionLog;

public class CreateSessionLogHandler(IUnitOfWork unitOfWork) : IRequestHandler<CreateSessionLogCommand, BaseResponse<bool>>
{
    public async Task<BaseResponse<bool>> Handle(CreateSessionLogCommand request, CancellationToken cancellationToken)
    {
        var adventure = request.AdventureId.HasValue
            ? await unitOfWork.Adventures.GetAsync(request.AdventureId.Value)
            : null;
        var rpgSystem = await unitOfWork.RpgSystems.GetByCode(request.RpgSystemCode);
        var players = await unitOfWork.Persons.GetList(request.Players.Select(x => x.Id));
        var gameMaster = request.GameMaster?.Id != null
            ? await unitOfWork.Persons.GetAsync(request.GameMaster.Id)
            : null;

        var session = new Domain.Entities.SessionLog
        {
            SessionId = Guid.NewGuid(),
            SessionName = request.SessionName,
            Description = request.Description,
            StartTime = request.StartTime,
            EndTime = request.EndTime,
            RpgSystem = rpgSystem,
            GameMaster = gameMaster,
            Players = players,
            Adventure = adventure
        };
        try
        {
            await unitOfWork.SessionLogs.InsertAsync(session);
            return new BaseResponse<bool>
            {
                succcess = true,
                Data = false
            };
        }
        catch (Exception ex)
        {
            return new BaseResponse<bool>
            {
                succcess = false,
                Data = false,
                Message = ex.Message,
            };
        }
    }
}