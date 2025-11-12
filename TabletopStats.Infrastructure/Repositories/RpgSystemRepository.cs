using Microsoft.EntityFrameworkCore;
using TabletopStats.Application.Interface.Persistence;
using TabletopStats.Domain.Entities;

namespace TabletopStats.Infrastructure.Repositories;

public class RpgSystemRepository(RpgContext context): IRpgSystemRepository
{
    public Task InsertAsync(RpgSystem entity)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(RpgSystem entity)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<RpgSystem?> GetAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<RpgSystem>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public async Task<RpgSystem?> GetByCode(string code)
    {
        return await context.RpgSystems.FirstOrDefaultAsync(x => x.Code == code);
    }
}