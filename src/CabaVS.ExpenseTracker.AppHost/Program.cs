IDistributedApplicationBuilder builder = DistributedApplication.CreateBuilder(args);

builder
    .AddDockerfile("cvs-expensetracker-api", "../..")
    .WithImage("expensetrackerapi")
    .WithImageTag("local")
    .WithContainerRuntimeArgs("--env-file", "../../.env")
    .WithHttpEndpoint(port: 4790, targetPort: 4790);

await builder.Build().RunAsync();
