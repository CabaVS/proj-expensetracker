using CabaVS.ExpenseTracker.Domain.Entities;

namespace CabaVS.ExpenseTracker.Persistence.Write.Entities;

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
}
