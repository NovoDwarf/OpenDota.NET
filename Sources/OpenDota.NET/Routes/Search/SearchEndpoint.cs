using OpenDota.NET.Routes.Search.Models;
using OpenDota.NET.Utilities;

namespace OpenDota.NET.Routes.Search;

/// <inheritdoc />
[UsedImplicitly]
public class SearchEndpoint : ISearchEndpoint
{
	private readonly Requester _requester;

	/// <summary>Creates an instance of <see cref="SearchEndpoint" />.</summary>
	/// <param name="requester">The requester used to send API requests.</param>
	public SearchEndpoint(Requester requester)
	{
		_requester = requester;
	}

	/// <inheritdoc />
	public string Endpoint => "search";

	/// <inheritdoc />
	public string Url => new Uri(baseUri: _requester.BaseAddress, relativeUri: Endpoint).AbsoluteUri;


	/// <inheritdoc />
	public Task<List<PlayerResponse>?> GetPlayersByNameAsync(string personaName)
	{
		return _requester.GetResponseAsync<List<PlayerResponse>>(
			url: Endpoint,
			queryParameters: [$"q={personaName}"]);
	}
}