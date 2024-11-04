namespace RiotGamesTracker.Common.Dtos.Requests;

public class LeaderboardRequestDto
{
    public int Episode { get; set; }
    public int Act { get; set; }
    public int Size { get; set; } = 200;
    public int StartIndex { get; set; } = 0;
}