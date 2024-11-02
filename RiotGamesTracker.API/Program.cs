using RiotGamesTracker.API.Services.Act;
using RiotGamesTracker.API.Services.Leaderboard;
using RiotGamesTracker.Common;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddCors(
    options => options.AddPolicy(
        "wasm",
        policy => policy
            .WithOrigins([
                Configuration.BackendUrl,
                Configuration.FrontendUrl
            ])
            .AllowAnyMethod()
            .AllowAnyHeader()
            .AllowCredentials()
    ));
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddHttpClient("RiotGamesApi", (serviceProvider, httpClient) =>
{
    //var riotGamesApiSettings = serviceProvider.GetRequiredService<IOptions<RiotGamesApiSettings>>().Value;
    httpClient.BaseAddress = new Uri("https://br.api.riotgames.com");
});

builder.Services.AddScoped<ILeaderboardService, LeaderboardService>();
builder.Services.AddScoped<IActService, ActService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseCors("wasm");

app.MapControllers();

app.Run();
