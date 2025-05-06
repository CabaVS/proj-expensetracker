using CabaVS.ExpenseTracker.Domain.Entities;

namespace CabaVS.ExpenseTracker.Application.Abstractions.Persistence.WriteRepositories;

public interface IWorkspaceMemberWriteRepository
{
    Task AddUserToTheWorkspaceAsync(Workspace workspace, Guid userId, bool isAdmin, CancellationToken cancellationToken = default);
}
