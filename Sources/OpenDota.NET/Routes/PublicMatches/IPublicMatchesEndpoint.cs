namespace OpenDotaDotNet.Routes.PublicMatches;

/// <summary>
/// Public matches endpoint.
/// </summary>
[PublicAPI]
public interface IPublicMatchesEndpoint
{
	/// <summary>The base path of this endpoint, relative to the API address.</summary>
	public string Endpoint { get; }

	/// <summary>The absolute URL of the endpoint, without query parameters.</summary>
	public string Url { get; }

	/// <summary>
	/// Get list of randomly sampled public matches.
	/// </summary>
	/// <param name="minRank">Minimum rank tier.</param>
	/// <param name="maxRank">Maximum rank tier.</param>
	/// <param name="lessThanMatchId">Get matches with a match ID lower than this value.</param>
	/// <returns>List of randomly sampled public matches.</returns>
	public Task<List<PublicMatch>?> GetPublicMatchesAsync(int? minRank = null, int? maxRank = null, long? lessThanMatchId = null);
}