using TabletopStats.Application.Interface.Persistence;

namespace TabletopStats.Infrastructure.Repositories;

internal class UnitOfWork(
    IPersonRepository personRepository, 
    ISessionLogRepository sessionLogRepository,
    IRpgSystemRepository rpgSystemRepository,
    IAdventureRepository adventureRepository,
    ICampaignRepository campaignRepository)
    : IUnitOfWork
{
    public void Dispose()
    {
        System.GC.SuppressFinalize(this);
    }

    public IPersonRepository Persons { get; } = personRepository ?? throw new ArgumentNullException(nameof(Persons));
    public ISessionLogRepository SessionLogs { get; } = sessionLogRepository ?? throw new ArgumentNullException(nameof(SessionLogs));
    public IRpgSystemRepository RpgSystems { get; } = rpgSystemRepository ?? throw new ArgumentNullException(nameof(RpgSystems));
    public IAdventureRepository Adventures { get; } = adventureRepository ?? throw new ArgumentNullException(nameof(Adventures));
    public ICampaignRepository Campaigns { get; } = campaignRepository ?? throw new ArgumentNullException(nameof(Campaigns));
}