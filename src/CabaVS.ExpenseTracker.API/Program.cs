using CabaVS.ExpenseTracker.Application;
using CabaVS.ExpenseTracker.Persistence;
using CabaVS.ExpenseTracker.Presentation;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Services.AddApplication();
builder.Services.AddPersistence(builder.Configuration);
builder.Services.AddPresentation(builder.Host, builder.Configuration, builder.Environment.IsDevelopment());

WebApplication app = builder.Build();

app.UsePresentation();

await app.RunAsync();
