using System.Text.Json.Serialization;

namespace RiotGamesTracker.Common.Dtos;

public class ValorantPlayerDto
{
    [JsonPropertyName("puuid")]
    public string Id { get; set; } = string.Empty;

    [JsonPropertyName("gameName")]
    public string Name { get; set; } = string.Empty;

    [JsonPropertyName("tagLine")]
    public string Tag { get; set; } = string.Empty;

    [JsonPropertyName("leaderboardRank")]
    public int LeaderboardRank { get; set; }

    [JsonPropertyName("rankedRating")]
    public int RankedRating { get; set; }

    [JsonPropertyName("numberOfWins")]
    public int WinsCount { get; set; }

    [JsonPropertyName("competitiveTier")]
    public int CompetitiveTier { get; set; }
}