namespace OpenDota.NET.Routes.Benchmarks.Models;

/// <summary>
/// Represents a benchmark value.
/// </summary>
[PublicAPI]
public class BenchmarkValue
{
	/// <summary>
	/// Gets the percentile.
	/// </summary>
	[JsonPropertyName("percentile")]
	public double Percentile { get; init; }

	/// <summary>
	/// Gets the value.
	/// </summary>
	[JsonPropertyName("value")]
	public double Value { get; init; }
}