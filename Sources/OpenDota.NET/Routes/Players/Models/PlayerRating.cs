namespace OpenDota.NET.Routes.Players.Models;

/// <summary>
/// Represents player rating.
/// </summary>
[UsedImplicitly]
public class PlayerRating
{
	/// <summary>
	/// Gets account ID of the player.
	/// </summary>
	[JsonPropertyName("account_id")]
	[UsedImplicitly]
	public long AccountId { get; init; }

	/// <summary>
	/// Gets ID used to identify individual matches, e.g. 3703866531.
	/// </summary>
	[JsonPropertyName("match_id")]
	[UsedImplicitly]
	public long MatchId { get; init; }

	/// <summary>
	/// Gets solo competitive rank.
	/// </summary>
	[JsonPropertyName("solo_competitive_rank")]
	[UsedImplicitly]
	public int SoloCompetitiveRank { get; init; }

	/// <summary>
	/// Gets competitive rank.
	/// </summary>
	[JsonPropertyName("competitive_rank")]
	[UsedImplicitly]
	public int CompetitiveRank { get; init; }

	/// <summary>
	/// Gets time of the rating.
	/// </summary>
	[JsonPropertyName("time")]
	[UsedImplicitly]
	public DateTimeOffset Time { get; init; } = DateTimeOffset.MinValue;
}