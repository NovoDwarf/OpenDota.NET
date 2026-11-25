namespace OpenDota.NET.Routes.Players.Models;

/// <summary>
/// Represents player ward map.
/// </summary>
[PublicAPI]
public class PlayerWardMap
{
	/// <summary>
	/// Get observer wards.
	/// </summary>
	[JsonPropertyName("obs")]
	public Dictionary<string, Dictionary<string, long>> Obs { get; init; } = [];

	/// <summary>
	/// Gets sentry wards.
	/// </summary>
	[JsonPropertyName("sen")]
	public Dictionary<string, Dictionary<string, long>> Sen { get; init; } = [];
}