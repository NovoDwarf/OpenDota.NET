namespace OpenDotaDotNet.Routes.Distributions;

/// <inheritdoc />
public class DistributionsEndpoint : IDistributionsEndpoint
{
	private readonly Requester _requester;

	/// <inheritdoc />
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