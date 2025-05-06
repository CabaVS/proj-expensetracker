using CabaVS.ExpenseTracker.Application.Abstractions.Persistence.WriteRepositories;
using CabaVS.ExpenseTracker.Domain.Entities;
using CabaVS.ExpenseTracker.Persistence.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace CabaVS.ExpenseTracker.Persistence.WriteRepositories;

internal sealed class WorkspaceWriteRepository(ApplicationDbContext dbContext) : IWorkspaceWriteRepository
{
    public async Task<Workspace?> GetByIdAsync(Guid workspaceId, CancellationToken cancellationToken = default)
    {
        Workspace? workspace = await dbContext.Workspaces
            .Where(w => w.Id == workspaceId)
            .Select(WorkspaceEfEntity.ProjectToDomain())
            .FirstOrDefaultAsync(cancellationToken);
        return workspace;
    }

    public Task<Guid> AddAsync(Workspace workspace, CancellationToken cancellationToken = default)
    {
        var entity = WorkspaceEfEntity.ConvertFromDomain(workspace);
        
        EntityEntry<WorkspaceEfEntity> added = dbContext.Workspaces.Add(entity);
        
        return Task.FromResult(added.Entity.Id);
    }

    public Task UpdateAsync(Workspace workspace, CancellationToken cancellationToken = default)
    {
        var entity = WorkspaceEfEntity.ConvertFromDomain(workspace);
        
        _ = dbContext.Workspaces.Update(entity);
        
        return Task.CompletedTask;
    }

    public Task DeleteAsync(Workspace workspace, CancellationToken cancellationToken = default)
    {
        var entity = WorkspaceEfEntity.ConvertFromDomain(workspace);
        
        _ = dbContext.Workspaces.Remove(entity);
        
        return Task.CompletedTask;
    }
}
