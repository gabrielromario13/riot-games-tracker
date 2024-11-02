using RiotGamesTracker.API.Services.Act;
using RiotGamesTracker.Common.Dtos;

namespace RiotGamesTracker.API.Services.Leaderboard;

public class LeaderboardService : ILeaderboardService
{
    private readonly IActService _actService;
    private readonly IHttpClientFactory _factory;
    private readonly HttpClient _httpClient;

    private readonly string LEADERBOARD_ENDPOINT = "/val/ranked/v1/leaderboards/by-act";
    private readonly string API_KEY = RiotGamesApiSettings.API_KEY;

    public LeaderboardService(IActService actService, IHttpClientFactory factory)
    {
        _actService = actService;
        _factory = factory;
        _httpClient = _factory.CreateClient("RiotGamesApi");
    }

    public async Task<LeaderboardDto?> GetByAct(LeaderboardRequestDto request)
    {
        var actId = await _actService.GetActId(request);

        var response = await _httpClient
            .GetAsync($"{LEADERBOARD_ENDPOINT}/{actId}?size={request.Size}&startIndex={request.StartIndex}&api_key={API_KEY}");

        return await response.Content.ReadFromJsonAsync<LeaderboardDto?>();
    }
}