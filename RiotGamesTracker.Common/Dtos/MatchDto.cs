using System.Text.Json.Serialization;

namespace RiotGamesTracker.Common.Dtos;

public class MatchDto
{
    [JsonPropertyName("info")]
    public Info Info { get; set; } = null!;
}

public class Info
{
    [JsonPropertyName("participants")]
    public IEnumerable<PlayerDto> Players { get; set; } = [];
}

public class PlayerDto
{
    [JsonPropertyName("puuid")]
    public string Id { get; set; } = string.Empty;

    [JsonPropertyName("summonerId")]
    public string SummonerId { get; set; } = string.Empty;

    [JsonPropertyName("championId")]
    public int ChampionId { get; set; }

    [JsonPropertyName("championName")]
    public string ChampionName { get; set; } = string.Empty;

    [JsonPropertyName("riotIdGameName")]
    public string Name { get; set; } = string.Empty;

    [JsonPropertyName("riotIdTagline")]
    public string Tag { get; set; } = string.Empty;

    [JsonPropertyName("firstBloodKill")]
    public bool FirstBloodKill { get; set; }

    [JsonPropertyName("kills")]
    public int Kills { get; set; }

    [JsonPropertyName("deaths")]
    public int Deaths { get; set; }

    [JsonPropertyName("assists")]
    public int Assists { get; set; }

    [JsonPropertyName("timePlayed")]
    public int TimePlayed { get; set; }

    [JsonPropertyName("totalDamageDealtToChampions")]
    public int TotalDamageDealtToChampions { get; set; }

    [JsonPropertyName("totalMinionsKilled")]
    public int TotalMinionsKilled { get; set; }
}

public class Account
{
    [JsonPropertyName("puuid")]
    public string Id { get; set; } = string.Empty;
}