namespace OpenDotaDotNet.Routes.ProPlayers;

/// <summary>
/// Represents pro players endpoint.
/// </summary>
[PublicAPI]
public interface IProPlayersEndpoint
{
	/// <summary>The base path of this endpoint, relative to the API address.</summary>
	public string Endpoint { get; }

	/// <summary>The absolute URL of the endpoint, without query parameters.</summary>
	public string Url { get; }

	/// <summary>
	/// Get list of pro players.
	/// </summary>
	/// <returns>List of pro players.</returns>
	public Task<List<ProPlayer>?> GetProPlayersAsync();
}