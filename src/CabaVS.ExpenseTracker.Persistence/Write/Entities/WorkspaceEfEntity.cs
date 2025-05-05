namespace CabaVS.ExpenseTracker.Persistence.Write.Entities;

internal sealed class WorkspaceEfEntity
{
    public Guid Id { get; set; }
    public string Name { get; set; } = null!;

    public ICollection<WorkspaceMemberEfEntity>? Members { get; set; }
}
