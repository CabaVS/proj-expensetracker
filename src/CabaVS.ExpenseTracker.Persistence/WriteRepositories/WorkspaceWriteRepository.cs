using CabaVS.ExpenseTracker.Application.Abstractions.Persistence.WriteRepositories;
using CabaVS.ExpenseTracker.Domain.Entities;
using CabaVS.ExpenseTracker.Persistence.Entities;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace CabaVS.ExpenseTracker.Persistence.WriteRepositories;

internal sealed class WorkspaceWriteRepository(ApplicationDbContext dbContext) : IWorkspaceWriteRepository
{
    public Task<Guid> AddAsync(Workspace workspace, CancellationToken cancellationToken = default)
    {
        var entity = WorkspaceEfEntity.ConvertFromDomain(workspace);
        
        EntityEntry<WorkspaceEfEntity> added = dbContext.Workspaces.Add(entity);
        
        return Task.FromResult(added.Entity.Id);
    }
}
