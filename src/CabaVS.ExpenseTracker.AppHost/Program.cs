IDistributedApplicationBuilder builder = DistributedApplication.CreateBuilder(args);

builder
    .AddDockerfile(
        name: "cvs-expensetracker-api",
        contextPath: "../..")
    .WithImage("expensetrackerapi")
    .WithImageTag("local")
    .WithHttpEndpoint(port: 4790, targetPort: 4790)
    .WithContainerRuntimeArgs("--env-file", "../../.env")
    .WithEnvironment("ASPNETCORE_ENVIRONMENT", "Development")
    .WithEnvironment("ASPNETCORE_URLS", "http://+:4790")
    .WithEnvironment("CVS_USER_ID", "00000001-0001-0001-0001-000000000001");

await builder.Build().RunAsync();
