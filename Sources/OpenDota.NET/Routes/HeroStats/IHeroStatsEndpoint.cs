namespace OpenDotaDotNet.Routes.HeroStats;

/// <summary>
/// Hero stats endpoint.
/// </summary>
[PublicAPI]
public interface IHeroStatsEndpoint
{
	/// <summary>The base path of this endpoint, relative to the API address.</summary>
	public string Endpoint { get; }

	/// <summary>The absolute URL of the endpoint, without query parameters.</summary>
	public string Url { get; }

	/// <summary>
	/// Get stats about hero performance in recent matches.
	/// </summary>
	/// <returns>Stats about hero performance in recent matches.</returns>
	public Task<List<Models.HeroStats>?> GetHeroStatsAsync();
}