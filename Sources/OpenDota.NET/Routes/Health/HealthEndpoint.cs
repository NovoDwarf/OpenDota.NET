namespace OpenDotaDotNet.Routes.Health;

/// <inheritdoc />
public class HealthEndpoint : IHealthEndpoint
{
	private readonly Requester _requester;

	/// <inheritdoc />
	public HealthEndpoint(Requester requester)
	{
		_requester = requester;
	}

	/// <inheritdoc />
	public string Endpoint => "health";

	/// <inheritdoc />
	public string Url => new Uri(baseUri: _requester.BaseAddress, relativeUri: Endpoint).AbsoluteUri;


	/// <inheritdoc />
	public Task<ServiceHealth?> GetServiceHealthDataAsync()
	{
		return _requester.GetResponseAsync<ServiceHealth>(Endpoint);
	}
}