namespace OpenDota.NET.Routes.Players.Models;

/// <summary>
/// Represents player wordcloud.
/// </summary>
[PublicAPI]
public class PlayerWordCloud
{
	/// <summary>
	/// Gets player's word counts.
	/// </summary>
	[JsonPropertyName("my_word_counts")]
	public Dictionary<string, long> MyWordCounts { get; init; } = [];

	/// <summary>
	/// Gets word counts.
	/// </summary>
	[JsonPropertyName("all_word_counts")]
	public Dictionary<string, long> AllWordCounts { get; init; } = [];
}