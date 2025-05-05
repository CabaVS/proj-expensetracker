﻿using CabaVS.ExpenseTracker.Domain.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;

namespace CabaVS.ExpenseTracker.Presentation.Extensions;

internal static class ResultExtensions
{
    internal static Results<Ok, BadRequest<Error>> ToDefaultApiResponse(this Result result) =>
        result.IsSuccess
            ? TypedResults.Ok()
            : TypedResults.BadRequest(result.Error);
    
    internal static Results<Ok<TResponse>, BadRequest<Error>> ToDefaultApiResponse<TResult, TResponse>(
        this Result<TResult> result,
        Func<TResult, TResponse> mappingFunc) =>
        result.IsSuccess
            ? TypedResults.Ok(mappingFunc(result.Value))
            : TypedResults.BadRequest(result.Error);
    
    internal static Results<CreatedAtRoute, BadRequest<Error>> ToDefaultApiResponse(
        this Result<Guid> result,
        string routeName,
        Func<Guid, object> mappingFunc) =>
        result.IsSuccess
            ? TypedResults.CreatedAtRoute(routeName, mappingFunc(result.Value))
            : TypedResults.BadRequest(result.Error);
}
