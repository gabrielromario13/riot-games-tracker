using RiotGamesTracker.API.Services.AccountService;
using RiotGamesTracker.API.Services.ActService;
using RiotGamesTracker.API.Services.LeaderboardService;
using RiotGamesTracker.API.Services.MatchService;
using RiotGamesTracker.Common;

namespace RiotGamesTracker.API.Common.Api;

public static class BuildExtension
{
    public static void AddConfiguration(this WebApplicationBuilder builder)
    {
        //ApiConfiguration.ConnectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? string.Empty;
        Configuration.BackendUrl = builder.Configuration.GetValue<string>("BackendUrl") ?? string.Empty;
        Configuration.FrontendUrl = builder.Configuration.GetValue<string>("FrontendUrl") ?? string.Empty;
    }

    public static void AddHttpClients(this WebApplicationBuilder builder)
    {
        builder.Services.AddHttpClient("riotgames-api", (serviceProvider, httpClient) =>
        {
            //var riotGamesApiSettings = serviceProvider.GetRequiredService<IOptions<RiotGamesApiSettings>>().Value;
            httpClient.BaseAddress = new Uri("https://br.api.riotgames.com");
        });

        builder.Services.AddHttpClient("riotgames-api-americas", (httpClient) =>
        {
            httpClient.BaseAddress = new Uri("https://americas.api.riotgames.com");
        });

        builder.Services.AddHttpClient("riotgames-api-europe", (httpClient) =>
        {
            httpClient.BaseAddress = new Uri("https://europe.api.riotgames.com");
        });

        builder.Services.AddHttpClient("riotgames-api-asia", (httpClient) =>
        {
            httpClient.BaseAddress = new Uri("https://asia.api.riotgames.com");
        });

        builder.Services.AddHttpClient("riotgames-api-sea", (httpClient) =>
        {
            httpClient.BaseAddress = new Uri("https://sea.api.riotgames.com");
        });
    }

    public static void AddDocumentation(this WebApplicationBuilder builder)
    {
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen(x =>
        {
            x.CustomSchemaIds(n => n.FullName);
        });
    }

    public static void AddCrossOrigin(this WebApplicationBuilder builder)
    {
        builder.Services.AddCors(
            options => options.AddPolicy(
                ApiConfiguration.CorsPolicyName,
                policy => policy
                    .WithOrigins([
                        Configuration.BackendUrl,
                        Configuration.FrontendUrl
                    ])
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials()
            ));
    }

    public static void AddServices(this WebApplicationBuilder builder)
    {
        builder.Services.AddScoped<IAccountService, AccountService>();
        builder.Services.AddScoped<IActService, ActService>();
        builder.Services.AddScoped<ILeaderboardService, LeaderboardService>();
        builder.Services.AddScoped<IMatchService, MatchService>();
    }
}