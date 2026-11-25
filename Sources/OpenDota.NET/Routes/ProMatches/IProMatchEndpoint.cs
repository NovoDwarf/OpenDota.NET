namespace OpenDotaDotNet.Routes.ProMatches;

/// <summary>
/// Represents pro matches endpoint.
/// </summary>
[PublicAPI]
public interface IProMatchEndpoint
{
	/// <summary>The base path of this endpoint, relative to the API address.</summary>
	public string Endpoint { get; }

	/// <summary>The absolute URL of the endpoint, without query parameters.</summary>
	public string Url { get; }

	/// <summary>
	/// Get list of pro matches.
	/// </summary>
	/// <param name="lessThanMatchId">Get matches with a match ID lower than this value.</param>
	/// <returns>List of pro matches.</returns>
	public Task<List<ProMatch>?> GetProMatchesAsync(long? lessThanMatchId = null);
}