using Microsoft.EntityFrameworkCore;
using TabletopStats.Application.Interface.Persistence;
using TabletopStats.Domain.Entities;

namespace TabletopStats.Infrastructure.Repositories;

public class SessionLogRepository(RpgContext context): ISessionLogRepository
{
    public async Task InsertAsync(SessionLog entity)
    {
        await context.AddAsync(entity);
        await context.SaveChangesAsync();
    }

    public Task UpdateAsync(SessionLog entity)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<SessionLog?> GetAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<SessionLog>> GetAllAsync()
    {
        throw new NotImplementedException();
    }
    public async Task<IEnumerable<SessionLog>> GetPlayerLogsAsync(Guid requestPlayerId, int pageNumber, int pageSize)
    {
        var sessionLogs = await context.SessionLogs
            .Include(x => x.Players)
            .Include(x => x.GameMaster)
            .Include(x => x.RpgSystem)
            .Where(x => x.Players.Any(y => y.Id == requestPlayerId))
            .OrderBy(x => x.StartTime)
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();
        return sessionLogs;
    }

    public async Task<IEnumerable<SessionLog>> GetGameMasterLogsAsync(Guid requestPlayerId, int pageNumber, int pageSize)
    {
        var sessionLogs = await context.SessionLogs
            .Include(x => x.Players)
            .Include(x => x.GameMaster)
            .Include(x => x.RpgSystem)
            .Where(x => x.GameMaster != null && x.GameMaster.Id == requestPlayerId)
            .OrderBy(x => x.StartTime)
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();
        return sessionLogs;
    }
}