IDistributedApplicationBuilder builder = DistributedApplication.CreateBuilder(args);

IResourceBuilder<SqlServerServerResource> sql = builder.AddSqlServer("sql-expensetracker", port: 1433)
    .WithDataVolume()
    .WithLifetime(ContainerLifetime.Persistent);

IResourceBuilder<SqlServerDatabaseResource> db = sql.AddDatabase("sqldb-expensetracker");

builder
    .AddDockerfile("aca-expensetrackerapi", "../..")
    .WithImage("expensetrackerapi")
    .WithImageTag("local")
    .WithContainerRuntimeArgs("--env-file", "../../.env")
    .WithHttpEndpoint(port: 4790, targetPort: 4790)
    .WithReference(db, "SqlDatabase")
    .WaitFor(db);

await builder.Build().RunAsync();
