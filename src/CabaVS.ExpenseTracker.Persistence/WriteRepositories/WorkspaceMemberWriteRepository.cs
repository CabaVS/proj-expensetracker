using CabaVS.ExpenseTracker.Application.Abstractions.Persistence.WriteRepositories;
using CabaVS.ExpenseTracker.Domain.Entities;
using CabaVS.ExpenseTracker.Persistence.Entities;

namespace CabaVS.ExpenseTracker.Persistence.WriteRepositories;

internal sealed class WorkspaceMemberWriteRepository(ApplicationDbContext dbContext) : IWorkspaceMemberWriteRepository
{
    public Task AddUserToTheWorkspaceAsync(Workspace workspace, Guid userId, bool isAdmin,
        CancellationToken cancellationToken = default)
    {
        var entity = new WorkspaceMemberEfEntity { WorkspaceId = workspace.Id, UserId = userId, IsAdmin = isAdmin };
        
        _ = dbContext.WorkspaceMembers.Add(entity);
        
        return Task.CompletedTask;
    }
}
