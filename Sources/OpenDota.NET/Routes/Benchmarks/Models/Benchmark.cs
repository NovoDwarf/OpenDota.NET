namespace OpenDota.NET.Routes.Benchmarks.Models;

/// <summary>
/// Represents a benchmark.
/// </summary>
[PublicAPI]
public class Benchmark
{
	/// <summary>
	/// Gets the ID value of the hero played.
	/// </summary>
	[JsonPropertyName("hero_id")]
	public long HeroId { get; init; }

	/// <summary>
	/// Gets the result of the benchmark. See <see cref="BenchmarkResult"/>.
	/// </summary>
	[JsonPropertyName("result")]
	public BenchmarkResult Result { get; init; } = new();
}