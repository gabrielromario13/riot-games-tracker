using Microsoft.AspNetCore.Mvc;
using RiotGamesTracker.API.Services.MatchService;
using RiotGamesTracker.Common.Dtos.Requests;

namespace RiotGamesTracker.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MatchesController(IMatchService matchService) : ControllerBase
{
    private readonly IMatchService _matchService = matchService;

    [HttpGet]
    public async Task<ActionResult> Get([FromQuery] MatchRequestDto request)
    {
        var result = await _matchService.Get(request);

        return result == default ? BadRequest() : Ok(result);
    }
}