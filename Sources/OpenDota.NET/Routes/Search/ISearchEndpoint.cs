namespace OpenDotaDotNet.Routes.Search;

/// <summary>
/// Represents search endpoint.
/// </summary>
[PublicAPI]
public interface ISearchEndpoint
{
	/// <summary>The base path of this endpoint, relative to the API address.</summary>
	public string Endpoint { get; }

	/// <summary>The absolute URL of the endpoint, without query parameters.</summary>
	public string Url { get; }

	/// <summary>
	/// Search players by PersonaName.
	/// </summary>
	/// <param name="personaName">Search string.</param>
	/// <returns>Players by PersonaName.</returns>
	public Task<List<PlayerResponse>?> GetPlayersByNameAsync(string personaName);
}