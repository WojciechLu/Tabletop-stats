using TabletopStats.Application.Interface.Persistence;

namespace TabletopStats.Infrastructure.Repositories;

internal class UnitOfWork(IPersonRepository personRepository, ISessionLogRepository sessionLogRepository)
    : IUnitOfWork
{
    public void Dispose()
    {
        System.GC.SuppressFinalize(this);
    }

    public IPersonRepository Persons { get; } = personRepository ?? throw new ArgumentNullException(nameof(Persons));
    public ISessionLogRepository SessionLogs { get; } = sessionLogRepository ?? throw new ArgumentNullException(nameof(SessionLogs));
}