namespace OpenDotaDotNet.Routes.Distributions;

/// <summary>
/// Distributions endpoint.
/// </summary>
[PublicAPI]
public interface IDistributionsEndpoint
{
	/// <summary>The base path of this endpoint, relative to the API address.</summary>
	public string Endpoint { get; }

	/// <summary>The absolute URL of the endpoint, without query parameters.</summary>
	public string Url { get; }

	/// <summary>
	/// Gets distributions of MMR data by bracket and country.
	/// </summary>
	/// <returns>Distributions of MMR data by bracket and country.</returns>
	public Task<Distribution?> GetDistributionsAsync();
}