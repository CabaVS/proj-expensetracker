using CabaVS.ExpenseTracker.Domain.Common;
using CabaVS.ExpenseTracker.Domain.Primitives;
using CabaVS.ExpenseTracker.Domain.ValueObjects;

namespace CabaVS.ExpenseTracker.Domain.Entities;

public sealed class Workspace : Entity
{
    public WorkspaceName Name { get; }
    
    private Workspace(Guid id, WorkspaceName name) : base(id) => Name = name;
    
    public static Result<Workspace> CreateNew(string name) => 
        CreateExisting(Guid.NewGuid(), name);

    public static Result<Workspace> CreateExisting(Guid id, string name) =>
        WorkspaceName.Create(name)
            .Map(x => new Workspace(id, x));
}
