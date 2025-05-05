namespace CabaVS.ExpenseTracker.Domain.Common;

public static class CommonErrors
{
    public static Error NotFoundById(string entity, Guid id) =>
        new(
            $"{entity}.{nameof(NotFoundById)}", 
            $"Entity '{entity}' not found by Id '{id}'.");
}
