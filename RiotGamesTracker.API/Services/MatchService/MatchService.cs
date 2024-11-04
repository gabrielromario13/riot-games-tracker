using RiotGamesTracker.API.Services.AccountService;
using RiotGamesTracker.API.Utils;
using RiotGamesTracker.Common.Dtos;
using RiotGamesTracker.Common.Dtos.Requests;
using RiotGamesTracker.Common.Dtos.Responses;
using System.Data;

namespace RiotGamesTracker.API.Services.MatchService;

public class MatchService(IAccountService accountService, IHttpClientFactory factory) : IMatchService
{
    private readonly IAccountService _accountService = accountService;
    private readonly IHttpClientFactory _factory = factory;

    private readonly string API_KEY = RiotGamesApiSettings.API_KEY;
    private const string ENDPOINT_MATCH_IDS = "/lol/match/v5/matches/by-puuid";
    private const string ENDPOINT_MATCHES = "/lol/match/v5/matches";

    public async Task<ResponseDto<IEnumerable<MatchResponseDto>>> Get(MatchRequestDto request)
    {
        var httpClient = HttpClientManager.GetHttpClientByRegion(_factory, request.Region);

        var responseDto = await _accountService.GetAccount(_factory, request);

        if (responseDto is null)
            return new(null, 404, "Failed to get PlayerId.");

        var matchIds = await GetMatchIds(httpClient, responseDto.Data!.Id);

        if (!matchIds!.Any())
            return new(null, 404, "Failed to get matches info.");

        var champions = await GetPlayerMatchesInfo(httpClient, request, matchIds!);

        return champions;
    }

    private async Task<ResponseDto<IEnumerable<MatchResponseDto>>> GetPlayerMatchesInfo(
        HttpClient httpClient,
        MatchRequestDto request,
        List<string> matchIds)
    {
        var champions = new List<PlayerDto>();

        foreach (var matchId in matchIds)
        {
            var response = await httpClient.GetAsync($"{ENDPOINT_MATCHES}/{matchId}?api_key={API_KEY}");

            var match = (await response.Content.ReadFromJsonAsync<MatchDto>())!;

            if (!response.IsSuccessStatusCode)
                return new(null, 404, "Failed to get match info.");

            var champion = match.Info?.Players.FirstOrDefault(GetFunc(request));

            if (champion is not null)
                champions.Add(champion);
        }

        return new(champions.Select(x => new MatchResponseDto()
        {
            ChampionName = x.ChampionName,
            PlayerKDA = $"{x.Kills}/{x.Deaths}/{x.Assists}",
            TotalDamageDealtToChampions = x.TotalDamageDealtToChampions,
            TotalMinionsKilled = x.TotalMinionsKilled,
            Duration = $"{TimeSpan.FromSeconds(x.TimePlayed).Minutes} minutes",
        }));
    }

    private async Task<List<string>?> GetMatchIds(HttpClient httpClient, string accountId) =>
        await (await httpClient
            .GetAsync($"{ENDPOINT_MATCH_IDS}/{accountId}/ids?count=10&api_key={API_KEY}"))
                .Content.ReadFromJsonAsync<List<string>>();

    private static Func<PlayerDto, bool> GetFunc(MatchRequestDto request)
    {
        return x =>
            string.IsNullOrEmpty(request.PlayerName) || request.PlayerName == x.Name &&
            string.IsNullOrEmpty(request.ChampionName) || request.ChampionName == x.ChampionName;
    }
}