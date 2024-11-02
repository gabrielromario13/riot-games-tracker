using System.Text.Json.Serialization;

namespace RiotGamesTracker.Common.Dtos;

public class LeaderboardDto
{
    [JsonPropertyName("actId")]
    public string ActId { get; set; } = string.Empty;

    [JsonPropertyName("players")]
    public IEnumerable<PlayerDto> Players { get; set; } = [];

    [JsonPropertyName("totalPlayers")]
    public int TotalPlayers { get; set; }

    [JsonPropertyName("immortalStartingPage")]
    public int ImmortalStartingPage { get; set; }

    [JsonPropertyName("immortalStartingIndex")]
    public int ImmortalStartingIndex { get; set; }

    [JsonPropertyName("topTierRRThreshold")]
    public int TopTierRRThreshold { get; set; }

    [JsonPropertyName("startIndex")]
    public int StartIndex { get; set; }

    [JsonPropertyName("query")]
    public string Query { get; set; } = string.Empty;

    [JsonPropertyName("shard")]
    public string Shard { get; set; } = string.Empty;
}