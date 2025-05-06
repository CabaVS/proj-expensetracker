using System.Linq.Expressions;
using CabaVS.ExpenseTracker.Domain.Entities;

namespace CabaVS.ExpenseTracker.Persistence.Entities;

internal sealed class WorkspaceEfEntity
{
    public Guid Id { get; set; }
    public string Name { get; set; } = null!;

    public ICollection<WorkspaceMemberEfEntity>? Members { get; set; }

    public static WorkspaceEfEntity ConvertFromDomain(Workspace workspace) => 
        new()
        {
            Id = workspace.Id,
            Name = workspace.Name.Value
        };

    public static Expression<Func<WorkspaceEfEntity, Workspace>> ProjectToDomain() => entity =>
        Workspace
            .CreateExisting(entity.Id, entity.Name)
            .Value;
}
