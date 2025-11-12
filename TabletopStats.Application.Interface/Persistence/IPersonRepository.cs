using TabletopStats.Domain.Entities;

namespace TabletopStats.Application.Interface.Persistence;

public interface IPersonRepository: IGenericRepository<Person>
{
    Task<List<Person>> GetList(IEnumerable<Guid> select);
}