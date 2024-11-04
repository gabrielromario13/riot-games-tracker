using RiotGamesTracker.Common.Dtos;
using RiotGamesTracker.Common.Dtos.Requests;
using RiotGamesTracker.Common.Dtos.Responses;

namespace RiotGamesTracker.API.Services.MatchService;

public interface IMatchService
{
    Task<ResponseDto<IEnumerable<MatchResponseDto>>> Get(MatchRequestDto request);
}