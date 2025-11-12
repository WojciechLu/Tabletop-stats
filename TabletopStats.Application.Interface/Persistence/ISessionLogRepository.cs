using TabletopStats.Domain.Entities;

namespace TabletopStats.Application.Interface.Persistence;

public interface ISessionLogRepository: IGenericRepository<SessionLog>
{
    public Task<IEnumerable<SessionLog>> GetPlayerLogsAsync(Guid requestPlayerId, int pageNumber, int pageSize);
    public Task<IEnumerable<SessionLog>> GetGameMasterLogsAsync(Guid requestPlayerId, int pageNumber, int pageSize);
}