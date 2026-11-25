using OpenDota.NET.Routes.ParsedMatches.Models;
using OpenDota.NET.Utilities;

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
	public Task<List<ParsedMatch>?> GetParsedMatchesAsync(long? lessThanMatchId = null)
	{
		return _requester.GetResponseAsync<List<ParsedMatch>>(
			url: Endpoint,
			queryParameters: lessThanMatchId.HasValue ? [$"less_than_match_id={lessThanMatchId.Value}"] : null);
	}
}