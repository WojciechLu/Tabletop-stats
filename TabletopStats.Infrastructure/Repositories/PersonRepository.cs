using TabletopStats.Application.Interface.Persistence;
using TabletopStats.Domain.Entities;

namespace TabletopStats.Infrastructure.Repositories;

public class PersonRepository(RpgContext context): IPersonRepository
{
    public Task<bool> InsertAsync(Person entity)
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

    public Task<bool> UpdateAsync(Person entity)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteAsync(string id)
    {
        throw new NotImplementedException();
    }

    public Task<Person> GetAsync(string id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Person>> GetAllAsync()
    {
        throw new NotImplementedException();
    }
}