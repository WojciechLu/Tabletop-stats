namespace TabletopStats.Application.Interface.Persistence;

public interface IUnitOfWork: IDisposable
{
    IPersonRepository Persons { get; }
    ISessionLogRepository SessionLogs { get; }
}