using RiotGamesTracker.API;
using RiotGamesTracker.API.Common.Api;

var builder = WebApplication.CreateBuilder(args);

builder.AddConfiguration();
builder.AddHttpClients();
builder.AddCrossOrigin();
builder.AddDocumentation();
builder.AddServices();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();

if (app.Environment.IsDevelopment())
    app.ConfigureDevEnvironment();

app.UseHttpsRedirection();

app.UseCors(ApiConfiguration.CorsPolicyName);

app.MapControllers();

app.Run();