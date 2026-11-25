namespace OpenDotaDotNet.Routes.Matches;

/// <summary>
/// Matches endpoint.
/// </summary>
[PublicAPI]
public interface IMatchesEndpoint
{
	/// <summary>The base path of this endpoint, relative to the API address.</summary>
	public string Endpoint { get; }

	/// <summary>The absolute URL of the endpoint, without query parameters.</summary>
	public string Url { get; }

	/// <summary>
	/// Get match data by ID.
	/// </summary>
	/// <param name="matchId">ID used to identify individual matches, e.g. 3703866531.</param>
	/// <returns>Match data.</returns>
	public Task<Match?> GetMatchByIdAsync(long matchId);
}