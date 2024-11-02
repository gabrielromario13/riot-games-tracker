using RiotGamesTracker.Common.Dtos;

namespace RiotGamesTracker.API.Services.Leaderboard;

public interface ILeaderboardService
{
    Task<LeaderboardDto?> GetByAct(LeaderboardRequestDto request);
}