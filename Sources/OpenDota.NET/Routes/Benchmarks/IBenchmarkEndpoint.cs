namespace OpenDotaDotNet.Routes.Benchmarks;

/// <summary>
/// Benchmark endpoint.
/// </summary>
[PublicAPI]
public interface IBenchmarkEndpoint
{
	/// <summary>The base path of this endpoint, relative to the API address.</summary>
	public string Endpoint { get; }

	/// <summary>The absolute URL of the endpoint, without query parameters.</summary>
	public string Url { get; }

	/// <summary>
	/// Gets benchmarks of average stat values for a hero.
	/// </summary>
	/// <param name="heroId">Hero ID.</param>
	/// <returns>Benchmarks of average stat values for a hero.</returns>
	public Task<Benchmark?> GetHeroBenchmarkAsync(int heroId);
}