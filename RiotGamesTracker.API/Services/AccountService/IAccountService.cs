using RiotGamesTracker.Common.Dtos;
using RiotGamesTracker.Common.Dtos.Requests;

namespace RiotGamesTracker.API.Services.AccountService;

public interface IAccountService
{
    Task<ResponseDto<Account?>> GetAccount(IHttpClientFactory factory, MatchRequestDto request);
}