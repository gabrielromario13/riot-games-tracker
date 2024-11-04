using RiotGamesTracker.Common.Dtos;
using RiotGamesTracker.Common.Dtos.Requests;

namespace RiotGamesTracker.API.Services.ActService;

public class ActService : IActService
{
    private readonly IHttpClientFactory _factory;
    private readonly HttpClient _httpClient;

    private readonly string CONTENT_ENDPOINT_URL = "/val/content/v1/contents";
    private readonly string API_KEY = RiotGamesApiSettings.API_KEY;
    private readonly string LOCALE = "pt-BR";

    public ActService(IHttpClientFactory factory)
    {
        _factory = factory;
        _httpClient = _factory.CreateClient("RiotGamesApi");
    }

    public async Task<string?> GetActId(LeaderboardRequestDto request)
    {
        var response = await _httpClient
            .GetAsync($"{CONTENT_ENDPOINT_URL}?locale={LOCALE}&api_key={API_KEY}");

        if (!response.IsSuccessStatusCode)
            return default;

        var contentDto = (await response.Content.ReadFromJsonAsync<ContentDto>())!;

        var episode = contentDto.Acts
            .FirstOrDefault(a => a.Name == $"EPISÓDIO {request.Episode}");

        if (episode is null)
            return default;

        var act = contentDto.Acts
            .Where(x => x.ParentId == episode.Id)
            .FirstOrDefault(x => x.Name == $"ATO {request.Act}");

        return act is null ? default : act.Id;
    }
}