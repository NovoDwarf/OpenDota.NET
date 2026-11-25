using OpenDota.NET.Extensions;
using OpenDota.NET.Routes.Constants.Enums;
using OpenDota.NET.Utilities;

namespace OpenDota.NET.Routes.Constants;

/// <inheritdoc />
public class ConstantsEndpoint : IConstantsEndpoint
{
	private readonly Requester _requester;

	/// <inheritdoc />
	public ConstantsEndpoint(Requester requester)
	{
		_requester = requester;
	}

	/// <inheritdoc />
	public string Endpoint => "constants";

	/// <inheritdoc />
	public string Url => new Uri(baseUri: _requester.BaseAddress, relativeUri: Endpoint).AbsoluteUri;


	/// <inheritdoc />
	public Task<JsonNode?> GetConstantsAsync(Constant resource)
	{
		return _requester.GetResponseAsync<JsonNode>($"{Endpoint}/{resource.ToSnakeCase()}");
	}

	/// <inheritdoc />
	public Task<List<string>?> GetConstantsAsync()
	{
		return _requester.GetResponseAsync<List<string>>(Endpoint);
	}
}