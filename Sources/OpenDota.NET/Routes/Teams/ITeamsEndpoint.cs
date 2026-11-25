namespace OpenDotaDotNet.Routes.Teams;

/// <summary>
/// Represents a teams endpoint.
/// </summary>
[PublicAPI]
public interface ITeamsEndpoint
{
	/// <summary>The base path of this endpoint, relative to the API address.</summary>
	public string Endpoint { get; }

	/// <summary>The absolute URL of the endpoint, without query parameters.</summary>
	public string Url { get; }

	/// <summary>
	/// Get team data.
	/// </summary>
	/// <returns>Team data.</returns>
	public Task<List<Team>?> GetTeamsAsync();

	/// <summary>
	/// Get data for a team.
	/// </summary>
	/// <param name="teamId"></param>
	/// <returns>Data for a team.</returns>
	public Task<Team?> GetTeamByIdAsync(int teamId);

	/// <summary>
	/// Get matches for a team.
	/// </summary>
	/// <param name="teamId"></param>
	/// <returns>Matches for a team.</returns>
	public Task<List<TeamMatch>?> GetTeamMatchesByIdAsync(int teamId);

	/// <summary>
	/// Get players who have played for a team.
	/// </summary>
	/// <param name="teamId"></param>
	/// <returns>Players who have played for a team.</returns>
	public Task<List<TeamPlayer>?> GetTeamPlayersByIdAsync(int teamId);

	/// <summary>
	/// Get heroes for a team.
	/// </summary>
	/// <param name="teamId"></param>
	/// <returns>Heroes for a team.</returns>
	public Task<List<TeamHero>?> GetTeamHeroesByIdAsync(int teamId);
}