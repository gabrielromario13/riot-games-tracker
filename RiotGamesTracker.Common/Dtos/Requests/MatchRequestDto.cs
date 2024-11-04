namespace RiotGamesTracker.Common.Dtos.Requests;

public class MatchRequestDto
{
    public string PlayerName { get; set; } = string.Empty;
    public string PlayerTagline { get; set; } = string.Empty;
    public string Region { get; set; } = string.Empty;
    public string ChampionName { get; set; } = string.Empty;
}