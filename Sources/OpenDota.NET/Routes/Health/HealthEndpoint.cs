using OpenDota.NET.Routes.Health.Models;
using OpenDota.NET.Utilities;

namespace OpenDota.NET.Routes.Health;

/// <inheritdoc />
public class HealthEndpoint : IHealthEndpoint
{
	private readonly Requester _requester;

	/// <summary>Creates an instance of <see cref="HealthEndpoint" />.</summary>
	/// <param name="requester">The requester used to send API requests.</param>
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