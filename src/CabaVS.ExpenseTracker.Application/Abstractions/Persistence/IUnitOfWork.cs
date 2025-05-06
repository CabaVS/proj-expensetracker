using CabaVS.ExpenseTracker.Application.Abstractions.Persistence.WriteRepositories;

namespace CabaVS.ExpenseTracker.Application.Abstractions.Persistence;

public interface IUnitOfWork
{
    IWorkspaceWriteRepository Workspaces { get; }
    IWorkspaceMemberWriteRepository WorkspaceMembers { get; }
    
    Task SaveChangesAsync(CancellationToken cancellationToken = default);
}
