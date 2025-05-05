using CabaVS.ExpenseTracker.Application.Abstractions.Persistence.ReadRepositories;
using CabaVS.ExpenseTracker.Application.Models;
using Dapper;
using Microsoft.Data.SqlClient;

namespace CabaVS.ExpenseTracker.Persistence.Read.Repositories;

internal sealed class WorkspaceReadRepository(ISqlConnectionFactory sqlConnectionFactory) : IWorkspaceReadRepository
{
    public async Task<WorkspaceModel?> GetWorkspaceByIdAsync(Guid workspaceId, 
        CancellationToken cancellationToken = default)
    {
        await using SqlConnection connection = sqlConnectionFactory.CreateConnection();
        await connection.OpenAsync(cancellationToken);
        
        const string sql =
            """
            SELECT [Id], [Name] FROM [dbo].[Workspaces]
            WHERE [Id] = @workspaceId
            """;
        
        WorkspaceModel? workspace = await connection.QueryFirstOrDefaultAsync<WorkspaceModel>(sql, new { workspaceId });
        return workspace;
    }

    public async Task<bool> UserIsAdminOfWorkspaceAsync(Guid workspaceId, Guid userId,
        CancellationToken cancellationToken = default)
    {
        await using SqlConnection connection = sqlConnectionFactory.CreateConnection();
        await connection.OpenAsync(cancellationToken);
        
        const string sql =
            """
            SELECT 1 FROM [dbo].[WorkspaceMembers]
            WHERE [WorkspaceId] = @workspaceId
            AND [UserId] = @userId
            AND [IsAdmin] = 1
            """;
        
        var result = await connection.QueryFirstOrDefaultAsync<int?>(sql, new { workspaceId, userId });
        return result.HasValue;
    }

    public async Task<bool> UserIsMemberOfWorkspaceAsync(Guid workspaceId, Guid userId,
        CancellationToken cancellationToken = default)
    {
        await using SqlConnection connection = sqlConnectionFactory.CreateConnection();
        await connection.OpenAsync(cancellationToken);
        
        const string sql =
            """
            SELECT 1 FROM [dbo].[WorkspaceMembers]
            WHERE [WorkspaceId] = @workspaceId
            AND [UserId] = @userId
            """;
        
        var result = await connection.QueryFirstOrDefaultAsync<int?>(sql, new { workspaceId, userId });
        return result.HasValue;
    }
}
