namespace OpenDota.NET.Routes.Benchmarks;

/// <inheritdoc />
public class BenchmarksEndpoint : IBenchmarkEndpoint
{
	private readonly Requester _requester;

	/// <inheritdoc />
	public BenchmarksEndpoint(Requester requester)
	{
		_requester = requester;
	}

	/// <inheritdoc />
	public string Endpoint => "benchmarks";

	/// <inheritdoc />
	public string Url => new Uri(baseUri: _requester.BaseAddress, relativeUri: Endpoint).AbsoluteUri;


	/// <inheritdoc />
	public Task<Benchmark?> GetHeroBenchmarkAsync(int heroId)
	{
		return _requester.GetResponseAsync<Benchmark>(
			url: Endpoint,
			queryParameters: [$"hero_id={heroId}"]);
	}
}