using Microsoft.EntityFrameworkCore;
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

    public async Task<Person?> GetAsync(Guid id)
    {
        var person = await context.Persons.FirstOrDefaultAsync(x => x.Id == id);
        return person;
    }

    public Task<IEnumerable<Person>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public async Task<List<Person>> GetList(IEnumerable<Guid> select)
    {
        return await context.Persons.Where(x => select.Contains(x.Id)).ToListAsync();
    }
}