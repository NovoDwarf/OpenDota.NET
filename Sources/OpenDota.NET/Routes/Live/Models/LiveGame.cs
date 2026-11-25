namespace OpenDota.NET.Routes.Live.Models;

/// <summary>
/// Represents a live game.
/// </summary>
[PublicAPI]
public class LiveGame
{
	/// <summary>The activation time.</summary>
	[JsonPropertyName("activate_time")]
	public long ActivateTime { get; init; }

	/// <summary>The average player MMR.</summary>
	[JsonPropertyName("average_mmr")]
	public int AverageMmr { get; init; }
	/// <summary>The building state bitmask.</summary>
	[JsonPropertyName("building_state")]

	public long BuildingState { get; init; }
	/// <summary>The deactivation time.</summary>
	[JsonPropertyName("deactivate_time")]

	public long DeactivateTime { get; init; }
	/// <summary>The broadcast delay.</summary>
	[JsonPropertyName("delay")]

	public int Delay { get; init; }
	/// <summary>The Dire score.</summary>
	[JsonPropertyName("dire_score")]

	public int DireScore { get; init; }

	/// <summary>
	/// Gets an integer corresponding to game mode played.
	/// List of constants can be found here: https://github.com/odota/dotaconstants/blob/master/json/game_mode.json.
	/// </summary>
	[JsonPropertyName("game_mode")]
	public GameMode GameMode { get; init; }

	/// <summary>The elapsed game time.</summary>
	[JsonPropertyName("game_time")]
	public int GameTime { get; init; }

	/// <summary>The last update time.</summary>
	[JsonPropertyName("last_update_time")]
	public long LastUpdateTime { get; init; }

	/// <summary>The league identifier.</summary>
	[JsonPropertyName("league_id")]
	public long LeagueId { get; init; }

	/// <summary>The lobby identifier.</summary>
	[JsonPropertyName("lobby_id")]
	public string LobbyId { get; init; } = string.Empty;

	/// <summary>
	/// Gets integer corresponding to lobby type of match.
	/// List of constants can be found here: https://github.com/odota/dotaconstants/blob/master/json/lobby_type.json.
	/// </summary>
	[JsonPropertyName("lobby_type")]

	public LobbyType? LobbyType { get; init; }

	/// <summary>
	/// Gets ID used to identify individual matches, e.g. 3703866531.
	/// </summary>
	[JsonPropertyName("match_id")]

	public long? MatchId { get; init; }

	/// <summary>The players in the game.</summary>
	[JsonPropertyName("players")]
	public List<LiveGamePlayer> Players { get; init; } = [];

	/// <summary>The Radiant lead.</summary>
	[JsonPropertyName("radiant_lead")]

	public int RadiantLead { get; init; }

	/// <summary>The Radiant score.</summary>
	[JsonPropertyName("radiant_score")]

	public int RadiantScore { get; init; }

	/// <summary>The series identifier.</summary>
	[JsonPropertyName("series_id")]

	public long? SeriesId { get; init; }

	/// <summary>The server Steam identifier.</summary>
	[JsonPropertyName("server_steam_id")]
	public string ServerSteamId { get; init; } = string.Empty;
	
	/// <summary>The live game sorting score.</summary>
	[JsonPropertyName("sort_score")]

	public long? SortScore { get; init; }

	/// <summary>The spectator count.</summary>
	[JsonPropertyName("spectators")]

	public int Spectators { get; init; }

	/// <summary>The Dire team identifier.</summary>
	[JsonPropertyName("team_id_dire")]

	public long? TeamIdDire { get; init; }

	/// <summary>The Radiant team identifier.</summary>
	[JsonPropertyName("team_id_radiant")]

	public long? TeamIdRadiant { get; init; }

	/// <summary>The Dire team logo URL.</summary>
	[JsonPropertyName("team_logo_dire")]
	public string TeamLogoDire { get; init; } = string.Empty;

	/// <summary>The Radiant team logo URL.</summary>
	[JsonPropertyName("team_logo_radiant")]
	public string TeamLogoRadiant { get; init; } = string.Empty;

	/// <summary>The Dire team name.</summary>
	[JsonPropertyName("team_name_dire")]
	public string TeamNameDire { get; init; } = string.Empty;

	/// <summary>The Radiant team name.</summary>
	[JsonPropertyName("team_name_radiant")]
	public string TeamNameRadiant { get; init; } = string.Empty;
}