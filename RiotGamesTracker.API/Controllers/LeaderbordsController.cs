using Microsoft.AspNetCore.Mvc;
using RiotGamesTracker.API.Services.Leaderboard;
using RiotGamesTracker.Common.Dtos;

namespace RiotGamesTracker.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class LeaderbordsController(ILeaderboardService leaderboardService) : ControllerBase
{
    private readonly ILeaderboardService _leaderboardService = leaderboardService;

    [HttpGet("by-act")]
    public async Task<ActionResult> GetByAct([FromQuery] LeaderboardRequestDto request)
    {
        var result = await _leaderboardService.GetByAct(request);

        return result == default ? BadRequest() : Ok(result);
    }
}