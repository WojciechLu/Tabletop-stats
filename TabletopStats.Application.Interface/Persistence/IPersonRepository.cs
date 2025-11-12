using TabletopStats.Domain.Entities;

namespace TabletopStats.Application.Interface.Persistence;

public interface IPersonRepository: IGenericRepository<Person>
{
    IEnumerable<Person> GetList(IEnumerable<Guid> select);
}