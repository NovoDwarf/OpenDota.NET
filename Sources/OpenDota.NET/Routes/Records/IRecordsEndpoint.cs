namespace OpenDota.NET.Routes.Records;

/// <summary>
/// Records endpoint.
/// </summary>
[PublicAPI]
public interface IRecordsEndpoint
{
	/// <summary>The base path of this endpoint, relative to the API address.</summary>
	public string Endpoint { get; }

	/// <summary>The absolute URL of the endpoint, without query parameters.</summary>
	public string Url { get; }

	/// <summary>
	/// Get records in ranked matches. Records reset monthly.
	/// </summary>
	/// <param name="field">Field name to query.</param>
	/// <returns>Records in ranked matches.</returns>
	public Task<List<Record>?> GetRecordsByFieldAsync(Field field);
}