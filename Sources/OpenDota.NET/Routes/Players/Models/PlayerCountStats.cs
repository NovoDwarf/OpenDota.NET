namespace OpenDotaDotNet.Routes.Players.Models;

/// <summary>Aggregated player match counts.</summary>
[UsedImplicitly]
public class PlayerCountStats
{
	/// <summary>
	/// Gets the total number of games
	/// </summary>
	[JsonPropertyName("games")]
	public long Games { get; init; }

	/// <summary>
	/// Gets the total number of wins
	/// </summary>
	[JsonPropertyName("win")]
	public long Win { get; init; }
}