using RiotGamesTracker.Common.Dtos;

namespace RiotGamesTracker.API.Services.Act;

public interface IActService
{
    Task<string?> GetActId(LeaderboardRequestDto request);
}