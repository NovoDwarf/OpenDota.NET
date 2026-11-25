namespace OpenDotaDotNet.Routes.Metadata;

/// <summary>
/// Metadata endpoint.
/// </summary>
[PublicAPI]
public interface IMetadataEndpoint
{
	/// <summary>The base path of this endpoint, relative to the API address.</summary>
	public string Endpoint { get; }

	/// <summary>The absolute URL of the endpoint, without query parameters.</summary>
	public string Url { get; }

	/// <summary>
	/// Gets site metadata.
	/// </summary>
	/// <returns>Site metadata.</returns>
	public Task<Models.Metadata?> GetMetadataAsync();
}