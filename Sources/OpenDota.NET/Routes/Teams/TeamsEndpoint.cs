namespace OpenDota.NET.Routes.Teams;

/// <inheritdoc />
[UsedImplicitly]
public class TeamsEndpoint : ITeamsEndpoint
{
	private readonly Requester _requester;

	/// <inheritdoc />
	public TeamsEndpoint(Requester requester)
	{
		_requester = requester;
	}

	/// <inheritdoc />
	public string Endpoint => "teams";

	/// <inheritdoc />
	public string Url => new Uri(baseUri: _requester.BaseAddress, relativeUri: Endpoint).AbsoluteUri;


	/// <inheritdoc />
	public Task<List<Team>?> GetTeamsAsync()
	{
		return _requester.GetResponseAsync<List<Team>>(Endpoint);
	}

	/// <inheritdoc />
	public Task<Team?> GetTeamByIdAsync(int teamId)
	{
		return _requester.GetResponseAsync<Team>($"{Endpoint}/{teamId}");
	}

	/// <inheritdoc />
	public Task<List<TeamMatch>?> GetTeamMatchesByIdAsync(int teamId)
	{
		return _requester.GetResponseAsync<List<TeamMatch>>($"{Endpoint}/{teamId}/matches");
	}

	/// <inheritdoc />
	public Task<List<TeamPlayer>?> GetTeamPlayersByIdAsync(int teamId)
	{
		return _requester.GetResponseAsync<List<TeamPlayer>>($"{Endpoint}/{teamId}/players");
	}

	/// <inheritdoc />
	public Task<List<TeamHero>?> GetTeamHeroesByIdAsync(int teamId)
	{
		return _requester.GetResponseAsync<List<TeamHero>>($"{Endpoint}/{teamId}/heroes");
	}
}