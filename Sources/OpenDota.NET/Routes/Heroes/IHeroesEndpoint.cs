namespace OpenDota.NET.Routes.Heroes;

/// <summary>
/// Represents a heroes endpoint. 
/// </summary>
[PublicAPI]
public interface IHeroesEndpoint
{
	/// <summary>The base path of this endpoint, relative to the API address.</summary>
	public string Endpoint { get; }

	/// <summary>The absolute URL of the endpoint, without query parameters.</summary>
	public string Url { get; }

	/// <summary>
	/// Get hero data. GET /heroes.
	/// </summary>
	/// <returns>Hero data.</returns>
	public Task<List<Hero>?> GetHeroesAsync();

	/// <summary>
	/// Get recent matches with a hero. GET /heroes/{hero_id}/matches.
	/// </summary>
	/// <param name="heroId"></param>
	/// <returns>Recent matches with a hero.</returns>
	public Task<List<HeroMatch>?> GetHeroMatchesAsync(int heroId);

	/// <summary>
	/// Get results against other heroes for a hero. GET /heroes/{hero_id}/matchups.
	/// </summary>
	/// <param name="heroId"></param>
	/// <returns>Results against other heroes for a hero.</returns>
	public Task<List<HeroMatchup>?> GetHeroMatchupsAsync(int heroId);

	/// <summary>
	/// Get hero performance over a range of match durations. GET /heroes/{hero_id}/durations.
	/// </summary>
	/// <param name="heroId"></param>
	/// <returns>Hero performance over a range of match durations.</returns>
	public Task<List<HeroDuration>?> GetHeroDurationsAsync(int heroId);

	/// <summary>
	/// Get players who have played this hero. GET /heroes/{hero_id}/players.
	/// </summary>
	/// <param name="heroId"></param>
	/// <returns>Players who have played this hero.</returns>
	public Task<List<HeroPlayer>?> GetHeroPlayersAsync(int heroId);

	/// <summary>
	/// Get item popularity of hero categoried by start, early, mid and late game, analyzed from professional games. GET /heroes/{hero_id}/itemPopularity.
	/// </summary>
	/// <param name="heroId">The hero identifier.</param>
	/// <returns></returns>
	public Task<HeroItemPopularity?> GetHeroItemPopularityAsync(int heroId);
}