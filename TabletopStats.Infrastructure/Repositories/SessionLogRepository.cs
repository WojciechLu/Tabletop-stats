using TabletopStats.Application.Interface.Persistence;
using TabletopStats.Domain.Entities;

namespace TabletopStats.Infrastructure.Repositories;

public class SessionLogRepository: ISessionLogRepository
{
    public Task<bool> InsertAsync(SessionLog entity)
    {
        throw new NotImplementedException();
    }

    public Task<bool> UpdateAsync(SessionLog entity)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteAsync(string id)
    {
        throw new NotImplementedException();
    }

    public Task<SessionLog> GetAsync(string id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<SessionLog>> GetAllAsync()
    {
        throw new NotImplementedException();
    }
}