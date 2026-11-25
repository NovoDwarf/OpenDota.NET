namespace OpenDotaDotNet.Routes.Health;

/// <summary>
/// Health endpoint.
/// </summary>
[PublicAPI]
public interface IHealthEndpoint
{
	/// <summary>The base path of this endpoint, relative to the API address.</summary>
	public string Endpoint { get; }

	/// <summary>The absolute URL of the endpoint, without query parameters.</summary>
	public string Url { get; }

	/// <summary>
	/// Get service health data.
	/// </summary>
	/// <returns>Service health data.</returns>
	public Task<ServiceHealth?> GetServiceHealthDataAsync();
}