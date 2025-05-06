namespace CabaVS.ExpenseTracker.Domain.Common;

public static class AsyncResult
{
    public static async Task Tap<T>(this Result<T> result, Func<T, Task> tapAction)
    {
        if (result.IsSuccess)
        {
            await tapAction(result.Value);
        }
    }
    
    public static async Task<Result<TOut>> Map<TIn, TOut>(this Result<TIn> result, Func<TIn, Task<Result<TOut>>> mapFunc) =>
        result.IsSuccess
            ? await mapFunc(result.Value)
            : Result<TOut>.Fail(result.Error);
}
