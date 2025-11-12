using TabletopStats.Application.Interface.Persistence;
using TabletopStats.Domain.Entities;

namespace TabletopStats.Infrastructure.Repositories;

public class AdventureRepository(RpgContext context): IAdventureRepository
{
    public async Task InsertAsync(Adventure entity)
    {
        await context.Adventures.AddAsync(entity);
        await context.SaveChangesAsync();
    }

    public Task UpdateAsync(Adventure entity)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<Adventure?> GetAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Adventure>> GetAllAsync()
    {
        throw new NotImplementedException();
    }
}