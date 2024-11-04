using RiotGamesTracker.Common.Dtos;
using RiotGamesTracker.Common.Dtos.Requests;

namespace RiotGamesTracker.API.Services.LeaderboardService;

public interface ILeaderboardService
{
    Task<LeaderboardDto?> GetByAct(LeaderboardRequestDto request);
}