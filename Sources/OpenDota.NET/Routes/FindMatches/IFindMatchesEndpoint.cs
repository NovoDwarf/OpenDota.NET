using OpenDota.NET.Routes.FindMatches.Models;

namespace OpenDota.NET.Routes.FindMatches;

/// <summary>
/// Find matches endpoint.
/// </summary>
[PublicAPI]
public interface IFindMatchesEndpoint
{
	/// <summary>The base path of this endpoint, relative to the API address.</summary>
	public string Endpoint { get; }

	/// <summary>The absolute URL of the endpoint, without query parameters.</summary>
	public string Url { get; }

	/// <summary>
	/// Finds matches by heroes played (currently includes matches played after April 2019).
	/// </summary>
	/// <param name="teamA"></param>
	/// <param name="teamB"></param>
	/// <returns>Matches by heroes played.</returns>
	public Task<List<FindMatch>?> FindMatchesByHeroesPlayedAsync(
		List<int>? teamA = null,
		List<int>? teamB = null);
}