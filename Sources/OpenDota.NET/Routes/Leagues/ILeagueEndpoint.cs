using OpenDota.NET.Routes.Leagues.Models;
using OpenDota.NET.Routes.Teams.Models;

namespace OpenDota.NET.Routes.Leagues;

/// <summary>
/// League endpoint.
/// </summary>
[PublicAPI]
public interface ILeagueEndpoint
{
	/// <summary>The base path of this endpoint, relative to the API address.</summary>
	public string Endpoint { get; }

	/// <summary>The absolute URL of the endpoint, without query parameters.</summary>
	public string Url { get; }

	/// <summary>
	/// Get league data.
	/// </summary>
	/// <returns>League data.</returns>
	public Task<List<League>?> GetLeaguesAsync();

    /// <summary>Gets a league by its ID.</summary>
    public Task<League?> GetLeagueAsync(long leagueId);

    /// <summary>Gets matches in a league.</summary>
    public Task<List<LeagueMatch>?> GetLeagueMatchesAsync(long leagueId);

    /// <summary>Gets match IDs in a league.</summary>
    public Task<List<long>?> GetLeagueMatchIdsAsync(long leagueId);

    /// <summary>Gets teams in a league.</summary>
    public Task<List<Team>?> GetLeagueTeamsAsync(long leagueId);
}