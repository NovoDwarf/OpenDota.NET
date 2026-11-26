using OpenDota.NET.Routes.Distributions.Models;
using OpenDota.NET.Utilities;

namespace OpenDota.NET.Routes.Distributions;

/// <inheritdoc />
public class DistributionsEndpoint : IDistributionsEndpoint
{
	private readonly Requester _requester;

	/// <summary>Creates an instance of <see cref="DistributionsEndpoint" />.</summary>
	/// <param name="requester">The requester used to send API requests.</param>
	public DistributionsEndpoint(Requester requester)
	{
		_requester = requester;
	}

	/// <inheritdoc />
	public string Endpoint => "distributions";

	/// <inheritdoc />
	public string Url => new Uri(baseUri: _requester.BaseAddress, relativeUri: Endpoint).AbsoluteUri;


	/// <inheritdoc />
	public Task<Distribution?> GetDistributionsAsync()
	{
		return _requester.GetResponseAsync<Distribution>(Endpoint);
	}
}