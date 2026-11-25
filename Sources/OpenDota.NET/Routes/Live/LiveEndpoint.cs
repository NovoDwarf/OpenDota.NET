using OpenDota.NET.Routes.Live.Models;
using OpenDota.NET.Utilities;

namespace OpenDota.NET.Routes.Live;

/// <inheritdoc />
public class LiveEndpoint : ILiveEndpoint
{
	private readonly Requester _requester;

	/// <inheritdoc />
	public LiveEndpoint(Requester requester)
	{
		_requester = requester;
	}

	/// <inheritdoc />
	public string Endpoint => "live";

	/// <inheritdoc />
	public string Url => new Uri(baseUri: _requester.BaseAddress, relativeUri: Endpoint).AbsoluteUri;

	/// <inheritdoc />
	public Task<List<LiveGame>?> GetTopLiveGamesAsync()
	{
		return _requester.GetResponseAsync<List<LiveGame>>(Endpoint);
	}
}