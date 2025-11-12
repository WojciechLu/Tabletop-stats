using TabletopStats.Domain.Entities;

namespace TabletopStats.Application.Interface.Persistence;

public interface IRpgSystemRepository: IGenericRepository<RpgSystem>
{
    public RpgSystem? GetByCode(string code);
}