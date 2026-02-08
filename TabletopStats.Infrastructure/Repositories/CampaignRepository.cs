using Microsoft.EntityFrameworkCore;
using TabletopStats.Application.Interface.Persistence;
using TabletopStats.Domain.Entities;

namespace TabletopStats.Infrastructure.Repositories;

public class CampaignRepository(RpgContext context): ICampaignRepository
{
    public async Task InsertAsync(Campaign entity)
    {
        await context.Campaigns.AddAsync(entity);
        await context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Campaign entity)
    {
        context.Entry(entity).State = EntityState.Modified;
        await context.SaveChangesAsync();
    }

    public Task<bool> DeleteAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public async Task<Campaign?> GetAsync(Guid id)
    {
        var campaign = await context.Campaigns
            .Include(x => x.Adventures)
            .SingleOrDefaultAsync(x => x.Id == id);
        return campaign;
    }

    public async Task<IEnumerable<Campaign>> GetAllAsync()
    {
        var hardcodedUser = Guid.Parse("D6434E4D-0B8C-4892-9803-4702038BB818");
        return await context.Campaigns.Include(x => x.GameMaster)
            .Where(x => x.GameMaster.Id == hardcodedUser)
            .ToListAsync();
    }
}