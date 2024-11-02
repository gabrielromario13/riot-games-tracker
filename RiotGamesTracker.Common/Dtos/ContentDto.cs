using System.Text.Json.Serialization;

namespace RiotGamesTracker.Common.Dtos;

public class ContentDto
{
    [JsonPropertyName("acts")]
    public IEnumerable<ActDto> Acts { get; set; } = [];
}