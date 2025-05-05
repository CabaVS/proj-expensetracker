using Azure.Core;
using Azure.Identity;
using CabaVS.ExpenseTracker.Application.Abstractions.Persistence.ReadRepositories;
using CabaVS.ExpenseTracker.Persistence.Read;
using CabaVS.ExpenseTracker.Persistence.Read.Repositories;
using CabaVS.ExpenseTracker.Persistence.Write;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CabaVS.ExpenseTracker.Persistence;

public static class DependencyInjection
{
    public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("SqlDatabase")
                               ?? throw new InvalidOperationException("Connection string to the database is not configured.");
        
        services.AddTransient(_ =>
        {
            var tokenRequest = new TokenRequestContext(
                ["https://database.windows.net/.default"]);
            var token = new DefaultAzureCredential()
                .GetToken(tokenRequest)
                .Token;

            return new SqlConnection(connectionString) { AccessToken = token };
        });
        
        services.AddDbContext<ApplicationDbContext>(
            (sp, options) =>
            {
                SqlConnection sqlConnection = sp.GetRequiredService<SqlConnection>();
                options.UseSqlServer(sqlConnection, sqlOptions => sqlOptions.EnableRetryOnFailure(5));
            },
            contextLifetime: ServiceLifetime.Transient,
            optionsLifetime: ServiceLifetime.Transient);
        
        services.AddSingleton<ISqlConnectionFactory, SqlConnectionFactory>();

        services.AddSingleton<IWorkspaceReadRepository, WorkspaceReadRepository>();
        
        return services;
    }
}
