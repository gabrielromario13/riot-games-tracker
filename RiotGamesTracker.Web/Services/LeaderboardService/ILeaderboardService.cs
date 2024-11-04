using RiotGamesTracker.Common.Dtos;
using RiotGamesTracker.Common.Dtos.Requests;

namespace RiotGamesTracker.Web.Services.LeaderboardService;

public interface ILeaderboardService
{
    Task<LeaderboardDto?> GetLeaderboardByAct(LeaderboardRequestDto request);
}