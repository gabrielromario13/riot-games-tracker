using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using RiotGamesTracker.Common;
using RiotGamesTracker.Web;
using RiotGamesTracker.Web.Services.LeaderboardService;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient
{
    BaseAddress = new Uri(Configuration.BackendUrl)
});

builder.Services.AddScoped<ILeaderboardService, LeaderboardService>();

await builder.Build().RunAsync();
