namespace OpenDota.NET.Routes.Players.Models;

/// <summary>
/// Represents player histogram.
/// </summary>
[UsedImplicitly]
public class PlayerHistogram
{
	/// <summary>
	/// Gets the X factor of the histogram.
	/// </summary>
	[JsonPropertyName("x")]
	public long? X { get; init; }

	/// <summary>
	/// Gets the factor of the histogram.
	/// </summary>
	[JsonPropertyName("games")]
	public int Games { get; init; }
	
	/// <summary>
	/// Gets the factor of the histogram.
	/// </summary>
	[JsonPropertyName("win")]
	public int Win { get; init; }
}