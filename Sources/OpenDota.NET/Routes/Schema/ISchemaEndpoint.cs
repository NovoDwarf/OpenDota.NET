namespace OpenDotaDotNet.Routes.Schema;

/// <summary>
/// Schema endpoint.
/// </summary>
[PublicAPI]
public interface ISchemaEndpoint
{
	/// <summary>The base path of this endpoint, relative to the API address.</summary>
	public string Endpoint { get; }

	/// <summary>The absolute URL of the endpoint, without query parameters.</summary>
	public string Url { get; }

	/// <summary>
	/// Get database schema.
	/// </summary>
	/// <returns>Database schema.</returns>
	public Task<List<DatabaseSchema>?> GetDatabaseSchemaAsync();
}