using OpenDota.NET.Utilities;

namespace OpenDota.NET.Routes.Metadata;

/// <inheritdoc />
public class MetadataEndpoint : IMetadataEndpoint
{
	private readonly Requester _requester;

	/// <summary>Creates an instance of <see cref="MetadataEndpoint" />.</summary>
	/// <param name="requester">The requester used to send API requests.</param>
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