namespace TabletopStats.Application.Interface.Persistence;

public interface IUnitOfWork: IDisposable
{
    IRpgSystemRepository RpgSystems { get; }
    IPersonRepository Persons { get; }
    ISessionLogRepository SessionLogs { get; }
    ICampaignRepository Campaigns { get; }
    IAdventureRepository Adventures { get; }
}