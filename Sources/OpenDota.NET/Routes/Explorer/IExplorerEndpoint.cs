namespace OpenDota.NET.Routes.Explorer;

/// <summary>
/// Represents an explorer endpoint.
/// </summary>
[PublicAPI]
public interface IExplorerEndpoint
{
	/// <summary>The base path of this endpoint, relative to the API address.</summary>
	public string Endpoint { get; }

	/// <summary>The absolute URL of the endpoint, without query parameters.</summary>
	public string Url { get; }

	/// <summary>
	/// Submit arbitrary SQL queries to the database.
	/// </summary>
	/// <param name="query">The PostgreSQL query. It is encoded by the client.</param>
	/// <returns>Explorer response in JObject format.</returns>
	public Task<JsonObject?> GetFromExplorerAsync(string query);
}