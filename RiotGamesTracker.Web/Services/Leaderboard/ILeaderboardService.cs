using RiotGamesTracker.Common.Dtos;

namespace RiotGamesTracker.Web.Services.Leaderboard;

public interface ILeaderboardService
{
    Task<LeaderboardDto?> GetLeaderboardByAct(LeaderboardRequestDto request);
}