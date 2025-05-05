namespace CabaVS.ExpenseTracker.Domain.Common;

public sealed record ValidationError(IEnumerable<Error> NestedErrors) 
    : Error("Validation.Summary", "One or more validation errors occurred.");
