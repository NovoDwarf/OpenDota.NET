namespace OpenDotaDotNet.Routes.Players.Models;

/// <summary>
/// Represents player count.
/// </summary>
[UsedImplicitly]
public class PlayerCount
{
	/// <summary>
	/// Gets integer describing whether or not the player left the game. 0: didn't leave. 1: left safely. 2+: Abandoned.
	/// </summary>
	[JsonPropertyName("leaver_status")]
	[UsedImplicitly]
	public Dictionary<string, PlayerCountStats> LeaverStatus { get; init; } = [];

	/// <summary>
	/// Gets integer corresponding to game mode played.
	/// List of constants can be found here: https://github.com/odota/dotaconstants/blob/master/json/game_mode.json.
	/// </summary>
	[JsonPropertyName("game_mode")]
	[UsedImplicitly]
	public Dictionary<string, PlayerCountStats> GameMode { get; init; } = [];

	/// <summary>
	/// Gets integer corresponding to lobby type of match.
	/// List of constants can be found here: https://github.com/odota/dotaconstants/blob/master/json/lobby_type.json.
	/// </summary>
	[JsonPropertyName("lobby_type")]
	[UsedImplicitly]
	public Dictionary<string, PlayerCountStats> LobbyType { get; init; } = [];

	/// <summary>
	/// Gets lane_role.
	/// </summary>
	[JsonPropertyName("lane_role")]
	[UsedImplicitly]
	public Dictionary<string, PlayerCountStats> LaneRole { get; init; } = [];

	/// <summary>
	/// Gets integer corresponding to the region the game was played on.
	/// </summary>
	[JsonPropertyName("region")]
	[UsedImplicitly]
	public Dictionary<string, PlayerCountStats> Region { get; init; } = [];

	/// <summary>
	/// Gets patch.
	/// </summary>
	[JsonPropertyName("patch")]
	[UsedImplicitly]
	public Dictionary<string, PlayerCountStats> Patch { get; init; } = [];

	/// <summary>
	/// Gets radiant/dire stats.
	/// </summary>
	[JsonPropertyName("is_radiant")]
	[UsedImplicitly]
	public Dictionary<string, PlayerCountStats> IsRadiant { get; init; } = [];
}