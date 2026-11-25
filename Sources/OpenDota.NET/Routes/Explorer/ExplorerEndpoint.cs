namespace OpenDota.NET.Routes.Explorer;

/// <inheritdoc />
public class ExplorerEndpoint : IExplorerEndpoint
{
	private readonly Requester _requester;

	/// <inheritdoc />
	public ExplorerEndpoint(Requester requester)
	{
		_requester = requester;
	}

	/// <inheritdoc />
	public string Endpoint => "explorer";

	/// <inheritdoc />
	public string Url => new Uri(baseUri: _requester.BaseAddress, relativeUri: Endpoint).AbsoluteUri;


	/// <inheritdoc />
	public Task<JsonObject?> GetFromExplorerAsync(string query)
	{
		return _requester.GetResponseAsync<JsonObject>(
			url: Endpoint,
			queryParameters: [$"sql={query}"]);
	}
}