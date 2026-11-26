using OpenDota.NET.Routes.Leagues.Models;
using OpenDota.NET.Routes.Teams.Models;
using OpenDota.NET.Utilities;

namespace OpenDota.NET.Routes.Leagues;

/// <inheritdoc />
public class LeagueEndpoint : ILeagueEndpoint
{
	private readonly Requester _requester;

	/// <summary>Creates an instance of <see cref="LeagueEndpoint" />.</summary>
	/// <param name="requester">The requester used to send API requests.</param>
	public LeagueEndpoint(Requester requester)
	{
		_requester = requester;
	}

	/// <inheritdoc />
	public string Endpoint => "leagues";

	/// <inheritdoc />
	public string Url => new Uri(baseUri: _requester.BaseAddress, relativeUri: Endpoint).AbsoluteUri;

	/// <inheritdoc />
	public Task<List<League>?> GetLeaguesAsync()
	{
		return _requester.GetResponseAsync<List<League>>(Endpoint);
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