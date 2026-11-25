namespace OpenDota.NET.Routes.Leagues.Models;

/// <summary>A match in a league.</summary>
[PublicAPI]
public sealed class LeagueMatch
{
    /// <summary>Match ID.</summary>
    [JsonPropertyName("match_id")]
    public long MatchId { get; init; }
    /// <summary>Whether Radiant won.</summary>
    [JsonPropertyName("radiant_win")]
    public bool? RadiantWin { get; init; }
    /// <summary>Match start time as a Unix timestamp.</summary>
    [JsonPropertyName("start_time")]
    public long StartTime { get; init; }
    /// <summary>Match duration in seconds.</summary>
    [JsonPropertyName("duration")]
    public int Duration { get; init; }
    /// <summary>League ID.</summary>
    [JsonPropertyName("leagueid")]
    public long LeagueId { get; init; }
    /// <summary>Radiant score.</summary>
    [JsonPropertyName("radiant_score")]
    public int? RadiantScore { get; init; }
    /// <summary>Dire score.</summary>
    [JsonPropertyName("dire_score")]
    public int? DireScore { get; init; }
    /// <summary>Radiant team ID.</summary>
    [JsonPropertyName("radiant_team_id")]
    public long? RadiantTeamId { get; init; }
    /// <summary>Radiant team name.</summary>
    [JsonPropertyName("radiant_team_name")]
    public string? RadiantTeamName { get; init; }
    /// <summary>Dire team ID.</summary>
    [JsonPropertyName("dire_team_id")]
    public long? DireTeamId { get; init; }
    /// <summary>Dire team name.</summary>
    [JsonPropertyName("dire_team_name")]
    public string? DireTeamName { get; init; }
    /// <summary>Series ID.</summary>
    [JsonPropertyName("series_id")]
    public long? SeriesId { get; init; }
    /// <summary>Series type.</summary>
    [JsonPropertyName("series_type")]
    public int? SeriesType { get; init; }
}
