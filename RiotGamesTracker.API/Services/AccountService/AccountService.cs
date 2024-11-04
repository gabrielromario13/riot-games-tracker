using RiotGamesTracker.API.Utils;
using RiotGamesTracker.Common.Dtos;
using RiotGamesTracker.Common.Dtos.Requests;

namespace RiotGamesTracker.API.Services.AccountService;

public class AccountService : IAccountService
{
    private readonly string API_KEY = RiotGamesApiSettings.API_KEY;
    private const string ENDPOINT_ACCOUNT = "/riot/account/v1/accounts/by-riot-id";

    public async Task<ResponseDto<Account?>> GetAccount(IHttpClientFactory factory, MatchRequestDto request)
    {
        var httpClient = HttpClientManager.GetHttpClientByRegion(factory, request.Region);

        var accountResponse = await httpClient.GetAsync($"{ENDPOINT_ACCOUNT}/{request.PlayerName}/{request.PlayerTagline}?api_key={API_KEY}");

        var account = await accountResponse.Content.ReadFromJsonAsync<Account>();

        return new(account);
    }
}