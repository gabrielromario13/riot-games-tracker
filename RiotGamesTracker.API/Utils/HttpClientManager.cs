namespace RiotGamesTracker.API.Utils;

public static class HttpClientManager
{
    public static HttpClient GetHttpClientByRegion(IHttpClientFactory factory, string region) =>
        factory.CreateClient($"riotgames-api-{region}");
}