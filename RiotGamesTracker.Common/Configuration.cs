namespace RiotGamesTracker.Common;

public static class Configuration
{
    public const int DefaultStatusCode = 200;

    public static string BackendUrl { get; set; } = "https://localhost:7184";
    public static string FrontendUrl { get; set; } = "https://localhost:7132";
}