namespace CabaVS.ExpenseTracker.Application.Abstractions.UserContext;

public interface ICurrentUserAccessor
{
    UserModel GetCurrentUser();
    
    bool TryGetCurrentUser(out UserModel userModel);
}
