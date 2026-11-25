using OpenDota.NET.Routes.Live.Models;

namespace OpenDota.NET.Routes.Live;

/// <summary>
/// Live endpoint.
/// </summary>
[PublicAPI]
public interface ILiveEndpoint
{
	/// <summary>The base path of this endpoint, relative to the API address.</summary>
	public string Endpoint { get; }

	/// <summary>The absolute URL of the endpoint, without query parameters.</summary>
	public string Url { get; }

	/// <summary>
	/// Get top currently ongoing live games.
	/// </summary>
	/// <returns>Top currently ongoing live games.</returns>
	public Task<List<LiveGame>?> GetTopLiveGamesAsync();
}