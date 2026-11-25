namespace OpenDota.NET.Routes.ParsedMatches;

/// <inheritdoc />
public class ParsedMatchesEndpoint : IParsedMatchesEndpoint
{
	private readonly Requester _requester;

	/// <inheritdoc />
	public ParsedMatchesEndpoint(Requester requester)
	{
		_requester = requester;
	}

	/// <inheritdoc />
	public string Endpoint => "parsedMatches";

	/// <inheritdoc />
	public string Url => new Uri(baseUri: _requester.BaseAddress, relativeUri: Endpoint).AbsoluteUri;


	/// <inheritdoc />
	public Task<ParsedMatch?> GetParsedMatchesAsync(long lessThenMatchId)
	{
		return _requester.GetResponseAsync<ParsedMatch>(
			url: Endpoint,
			queryParameters: [$"less_then_match_id={lessThenMatchId}"]);
	}
}