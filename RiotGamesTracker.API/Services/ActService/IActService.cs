using RiotGamesTracker.Common.Dtos.Requests;

namespace RiotGamesTracker.API.Services.ActService;

public interface IActService
{
    Task<string?> GetActId(LeaderboardRequestDto request);
}