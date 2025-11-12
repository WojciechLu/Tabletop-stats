using TabletopStats.Application.Interface.Persistence;
using TabletopStats.Domain.Entities;

namespace TabletopStats.Infrastructure.Repositories;

public class PersonRepository(RpgContext context): IPersonRepository
{
    public Task InsertAsync(Person entity)
    {
        try
        {
            context.Persons.Add(entity);
            context.SaveChanges();
            return Task.FromResult(true);
        }
        catch (Exception)
        {
            return Task.FromResult(false);
        }
    }

    public Task UpdateAsync(Person entity)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<Person?> GetAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Person>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Person> GetList(IEnumerable<Guid> select)
    {
        return context.Persons.Where(x => select.Contains(x.Id));
    }
}