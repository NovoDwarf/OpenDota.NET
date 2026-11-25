namespace OpenDotaDotNet.Routes.Metadata;

/// <inheritdoc />
public class MetadataEndpoint : IMetadataEndpoint
{
	private readonly Requester _requester;

	/// <inheritdoc />
	public MetadataEndpoint(Requester requester)
	{
		_requester = requester;
	}

	/// <inheritdoc />
	public string Endpoint => "metadata";

	/// <inheritdoc />
	public string Url => new Uri(baseUri: _requester.BaseAddress, relativeUri: Endpoint).AbsoluteUri;


	/// <inheritdoc />
	public Task<Models.Metadata?> GetMetadataAsync()
	{
		return _requester.GetResponseAsync<Models.Metadata>(Endpoint);
	}
}