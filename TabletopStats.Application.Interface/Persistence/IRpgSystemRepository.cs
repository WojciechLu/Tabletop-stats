using TabletopStats.Domain.Entities;

namespace TabletopStats.Application.Interface.Persistence;

public interface IRpgSystemRepository: IGenericRepository<RpgSystem>
{
    Task<IEnumerable<RpgSystem>> GetAllLikeAsync(string? name = null);
    public Task<RpgSystem?> GetByCode(string code);
}