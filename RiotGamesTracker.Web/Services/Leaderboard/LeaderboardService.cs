using RiotGamesTracker.Common.Dtos;
using System.Net.Http.Json;

namespace RiotGamesTracker.Web.Services.Leaderboard;

public class LeaderboardService(HttpClient client) : ILeaderboardService
{
    private readonly HttpClient _client = client;

    public async Task<LeaderboardDto?> GetLeaderboardByAct(LeaderboardRequestDto request)
    {
        var response = await _client.GetAsync(
            $"api/leaderbords/by-act?" +
            $"Episode={request.Episode}&" +
            $"Act={request.Act}&" +
            $"Size={request.Size}&" +
            $"StartIndex={request.StartIndex}"
        );

        return await response.Content.ReadFromJsonAsync<LeaderboardDto?>();
    }
}