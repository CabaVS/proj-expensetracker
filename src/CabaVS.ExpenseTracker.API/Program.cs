using CabaVS.ExpenseTracker.Application;
using CabaVS.ExpenseTracker.Persistence;
using CabaVS.ExpenseTracker.Presentation;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

var isDevelopment = builder.Environment.IsDevelopment();

// Only for Aspire (DEV only)
if (isDevelopment)
{
    builder.AddServiceDefaults();
}

builder.Services.AddApplication();
builder.Services.AddPersistence(builder.Configuration);
builder.Services.AddPresentation(builder.Host, builder.Configuration, isDevelopment);

WebApplication app = builder.Build();

// Only for Aspire (DEV only)
if (isDevelopment)
{
    app.MapDefaultEndpoints();
}

app.UsePresentation();

await app.RunAsync();
