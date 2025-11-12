using TabletopStats.Domain.Entities;

namespace TabletopStats.Application.Interface.Persistence;

public interface IRpgSystemRepository: IGenericRepository<RpgSystem>
{
    public Task<RpgSystem?> GetByCode(string code);
}