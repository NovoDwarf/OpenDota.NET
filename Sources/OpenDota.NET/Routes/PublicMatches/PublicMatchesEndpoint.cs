namespace OpenDotaDotNet.Routes.PublicMatches;

/// <inheritdoc />
[UsedImplicitly]
public class PublicMatchesEndpoint : IPublicMatchesEndpoint
{
	private readonly Requester _requester;

	/// <inheritdoc />
	public PublicMatchesEndpoint(Requester requester)
	{
		_requester = requester;
	}

	/// <inheritdoc />
	public string Endpoint => "publicMatches";

	/// <inheritdoc />
	public string Url => new Uri(baseUri: _requester.BaseAddress, relativeUri: Endpoint).AbsoluteUri;


	/// <inheritdoc />
	public Task<List<PublicMatch>?> GetPublicMatchesAsync(int? minRank = null, int? maxRank = null, long? lessThanMatchId = null)
	{
		return _requester.GetResponseAsync<List<PublicMatch>>(
			url: Endpoint,
			queryParameters: GetArguments(minRank: minRank, maxRank: maxRank, lessThanMatchId: lessThanMatchId));
	}

	private static List<string> GetArguments(int? minRank = null, int? maxRank = null, long? lessThanMatchId = null)
	{
		var addedArguments = new List<string>();

		if (minRank != null)
			addedArguments.Add($"min_rank={minRank}");

		if (maxRank != null)
			addedArguments.Add($"max_rank={maxRank}");

		if (lessThanMatchId != null)
			addedArguments.Add($"less_than_match_id={lessThanMatchId}");

		return addedArguments;
	}
}