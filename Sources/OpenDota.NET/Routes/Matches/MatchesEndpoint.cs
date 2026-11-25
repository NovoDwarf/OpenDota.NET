namespace OpenDotaDotNet.Routes.Matches;

/// <inheritdoc />
public class MatchesEndpoint : IMatchesEndpoint
{
	private readonly Requester _requester;

	/// <inheritdoc />
	public MatchesEndpoint(Requester requester)
	{
		_requester = requester;
	}

	/// <inheritdoc />
	public string Endpoint => "matches";

	/// <inheritdoc />
	public string Url => new Uri(baseUri: _requester.BaseAddress, relativeUri: Endpoint).AbsoluteUri;


	/// <inheritdoc />
	public Task<Match?> GetMatchByIdAsync(long matchId)
	{
		return _requester.GetResponseAsync<Match>($"{Endpoint}/{matchId}");
	}
}