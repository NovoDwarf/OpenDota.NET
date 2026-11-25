namespace OpenDota.NET.Routes.Health.Models;

/// <summary>
/// Represents service usage.
/// </summary>
[PublicAPI]
public class ServiceUsage
{
	/// <summary>
	/// Gets the metric.
	/// </summary>
	[JsonPropertyName("metric")]

	public double Metric { get; init; }

	/// <summary>
	/// Gets the threshold.
	/// </summary>
	[JsonPropertyName("threshold")]

	public long? Threshold { get; init; }

	/// <summary>
	/// Gets the current limit.
	/// </summary>
	[JsonPropertyName("limit")]
	public long? Limit { get; init; }

	/// <summary>
	/// Gets the timestamp.
	/// </summary>
	[JsonPropertyName("timestamp")]

	public long? Timestamp { get; init; }
}