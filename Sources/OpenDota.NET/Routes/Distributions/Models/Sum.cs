namespace OpenDotaDotNet.Routes.Distributions.Models;

/// <summary>
/// Represents a sum.
/// </summary>
[PublicAPI]
public class Sum
{
	/// <summary>
	/// Gets the count.
	/// </summary>
	[JsonPropertyName("count")]
	public long Count { get; init; }
}