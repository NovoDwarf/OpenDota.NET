namespace OpenDota.NET.Routes.Rankings;

/// <summary>
/// Represents rankings endpoint.
/// </summary>
[PublicAPI]
public interface IRankingsEndpoint
{
	/// <summary>The base path of this endpoint, relative to the API address.</summary>
	public string Endpoint { get; }

	/// <summary>The absolute URL of the endpoint, without query parameters.</summary>
	public string Url { get; }

	/// <summary>
	/// Gets top players by hero.
	/// </summary>
	/// <param name="heroId"></param>
	/// <returns>Top players by hero.</returns>
	public Task<HeroRanking?> GetHeroRankingsAsync(int heroId);
}