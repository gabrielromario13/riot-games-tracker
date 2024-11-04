namespace RiotGamesTracker.Common.Dtos.Responses;

public class MatchResponseDto
{
    public string ChampionName { get; set; } = string.Empty;
    public string PlayerKDA { get; set; } = string.Empty;
    public int TotalDamageDealtToChampions { get; set; }
    public int TotalMinionsKilled { get; set; }
    public string Duration { get; set; } = string.Empty;
}