using CabaVS.ExpenseTracker.Application;
using CabaVS.ExpenseTracker.Persistence;
using CabaVS.ExpenseTracker.Presentation;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

// Only for Aspire (DEV only)
if (builder.Environment.IsDevelopment())
{
    builder.AddServiceDefaults();
}

builder.Services.AddApplication();
builder.Services.AddPersistence(builder.Configuration, builder.Environment.IsDevelopment());
builder.Services.AddPresentation(builder.Host, builder.Configuration, builder.Environment.IsDevelopment());

WebApplication app = builder.Build();

// Only for Aspire (DEV only)
if (app.Environment.IsDevelopment())
{
    app.MapDefaultEndpoints();
}

app.UsePresentation();

await app.RunAsync();
