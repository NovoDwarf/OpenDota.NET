namespace OpenDota.NET.Routes.Schema;

/// <summary>Provides access to the schema endpoint.</summary>
[UsedImplicitly]
public class SchemaEndpoint : ISchemaEndpoint
{
	private readonly Requester _requester;

	/// <summary>Creates the endpoint.</summary>
	/// <param name="requester">The HTTP requester used by the endpoint.</param>
	public SchemaEndpoint(Requester requester)
	{
		_requester = requester;
	}

	/// <inheritdoc />
	public string Endpoint => "schema";

	/// <inheritdoc />
	public string Url => new Uri(baseUri: _requester.BaseAddress, relativeUri: Endpoint).AbsoluteUri;


	/// <summary>
	/// Get database schema.
	/// </summary>
	/// <returns>Database schema.</returns>
	public Task<List<DatabaseSchema>?> GetDatabaseSchemaAsync()
	{
		return _requester.GetResponseAsync<List<DatabaseSchema>>(Endpoint);
	}
}