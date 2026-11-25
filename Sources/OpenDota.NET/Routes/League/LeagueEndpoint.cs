namespace OpenDotaDotNet.Routes.League;

/// <inheritdoc />
public class LeagueEndpoint : ILeagueEndpoint
{
	private readonly Requester _requester;

	/// <inheritdoc />
	public LeagueEndpoint(Requester requester)
	{
		_requester = requester;
	}

	/// <inheritdoc />
	public string Endpoint => "leagues";

	/// <inheritdoc />
	public string Url => new Uri(baseUri: _requester.BaseAddress, relativeUri: Endpoint).AbsoluteUri;

	/// <inheritdoc />
	public Task<List<Models.League>?> GetLeaguesAsync()
	{
		return _requester.GetResponseAsync<List<Models.League>>(Endpoint);
	}

	/// <inheritdoc />
    public Task<Models.League?> GetLeagueAsync(long leagueId)
	{
		return _requester.GetResponseAsync<Models.League>($"{Endpoint}/{leagueId}");
	}

	/// <inheritdoc />
    public Task<List<Models.LeagueMatch>?> GetLeagueMatchesAsync(long leagueId)
	{
		return _requester.GetResponseAsync<List<Models.LeagueMatch>>($"{Endpoint}/{leagueId}/matches");
	}

	/// <inheritdoc />
    public Task<List<long>?> GetLeagueMatchIdsAsync(long leagueId)
	{
		return _requester.GetResponseAsync<List<long>>($"{Endpoint}/{leagueId}/matchIds");
	}

	/// <inheritdoc />
    public Task<List<Team>?> GetLeagueTeamsAsync(long leagueId)
	{
		return _requester.GetResponseAsync<List<Team>>($"{Endpoint}/{leagueId}/teams");
	}
}