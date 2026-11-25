using OpenDota.NET.Routes.ProMatches.Models;
using OpenDota.NET.Utilities;

namespace OpenDota.NET.Routes.ProMatches;

/// <inheritdoc />
[UsedImplicitly]
public class ProMatchesEndpoint : IProMatchEndpoint
{
	private readonly Requester _requester;

	/// <inheritdoc />
	public ProMatchesEndpoint(Requester requester)
	{
		_requester = requester;
	}

	/// <inheritdoc />
	public string Endpoint => "proMatches";

	/// <inheritdoc />
	public string Url => new Uri(baseUri: _requester.BaseAddress, relativeUri: Endpoint).AbsoluteUri;


	/// <inheritdoc />
	public Task<List<ProMatch>?> GetProMatchesAsync(long? lessThanMatchId = null)
	{
		return _requester.GetResponseAsync<List<ProMatch>>(
			url: Endpoint,
			queryParameters: GetArguments(lessThanMatchId: lessThanMatchId));
	}

	private static List<string> GetArguments(long? lessThanMatchId = null)
	{
		var addedArguments = new List<string>();

		if (lessThanMatchId != null)
			addedArguments.Add(item: $"less_than_match_id={lessThanMatchId}");

		return addedArguments;
	}
}