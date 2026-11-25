namespace OpenDotaDotNet.Routes.Constants;

/// <summary>
/// Constants endpoint.
/// </summary>
[PublicAPI]
public interface IConstantsEndpoint
{
	/// <summary>The base path of this endpoint, relative to the API address.</summary>
	public string Endpoint { get; }

	/// <summary>The absolute URL of the endpoint, without query parameters.</summary>
	public string Url { get; }

	/// <summary>
	/// Get static game data mirrored from the dotaconstants repository. Get /constants/{resource}
	/// </summary>
	/// <param name="resource">The resource.</param>
	/// <returns></returns>
	public Task<JsonNode?> GetConstantsAsync(Constant resource);

	/// <summary>
	/// Gets a list of available resources. GET /constants
	/// </summary>
	/// <returns></returns>
	public Task<List<string>?> GetConstantsAsync();

}