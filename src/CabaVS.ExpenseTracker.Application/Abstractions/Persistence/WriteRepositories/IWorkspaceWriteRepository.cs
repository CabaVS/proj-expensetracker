using CabaVS.ExpenseTracker.Domain.Entities;

namespace CabaVS.ExpenseTracker.Application.Abstractions.Persistence.WriteRepositories;

public interface IWorkspaceWriteRepository
{
    Task<Guid> AddAsync(Workspace workspace, CancellationToken cancellationToken = default);
}
