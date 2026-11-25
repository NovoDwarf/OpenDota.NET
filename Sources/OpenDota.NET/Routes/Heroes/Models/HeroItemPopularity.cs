namespace OpenDota.NET.Routes.Heroes.Models;

/// <summary>
/// Represents a hero item popularity.
/// </summary>
[PublicAPI]
public class HeroItemPopularity
{
	/// <summary>
	/// The start game items popularity
	/// </summary>
	[JsonPropertyName("start_game_items")]
	public Dictionary<string, int> StartGameItems { get; init; } = [];

	/// <summary>
	/// The early game items popularity
	/// </summary>
	[JsonPropertyName("early_game_items")]
	public Dictionary<string, int> EarlyGameItems { get; init; } = [];

	/// <summary>
	/// The mid game items popularity
	/// </summary>
	[JsonPropertyName("mid_game_items")]
	public Dictionary<string, int> MidGameItems { get; init; } = [];

	/// <summary>
	/// The late game items popularity
	/// </summary>
	[JsonPropertyName("late_game_items")]
	public Dictionary<string, int> LateGameItems { get; init; } = [];
}