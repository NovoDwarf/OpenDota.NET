namespace OpenDota.NET.Routes.Heroes;

/// <inheritdoc />
public class HeroesEndpoint : IHeroesEndpoint
{
	private readonly Requester _requester;

	/// <inheritdoc />
	public HeroesEndpoint(Requester requester)
	{
		_requester = requester;
	}

	/// <inheritdoc />
	public string Endpoint => "heroes";

	/// <inheritdoc />
	public string Url => new Uri(baseUri: _requester.BaseAddress, relativeUri: Endpoint).AbsoluteUri;

	/// <inheritdoc />
	public Task<List<Hero>?> GetHeroesAsync()
	{
		return _requester.GetResponseAsync<List<Hero>>(Endpoint);
	}

	/// <inheritdoc />
	public Task<List<HeroMatch>?> GetHeroMatchesAsync(int heroId)
	{
		return _requester.GetResponseAsync<List<HeroMatch>>($"{Endpoint}/{heroId}/matches");
	}

	/// <inheritdoc />
	public Task<List<HeroMatchup>?> GetHeroMatchupsAsync(int heroId)
	{
		return _requester.GetResponseAsync<List<HeroMatchup>>($"{Endpoint}/{heroId}/matchups");
	}

	/// <inheritdoc />
	public Task<List<HeroDuration>?> GetHeroDurationsAsync(int heroId)
	{
		return _requester.GetResponseAsync<List<HeroDuration>>($"{Endpoint}/{heroId}/durations");
	}

	/// <inheritdoc />
	public Task<List<HeroPlayer>?> GetHeroPlayersAsync(int heroId)
	{
		return _requester.GetResponseAsync<List<HeroPlayer>>($"{Endpoint}/{heroId}/players");
	}

	/// <inheritdoc />
	public Task<HeroItemPopularity?> GetHeroItemPopularityAsync(int heroId)
	{
		return _requester.GetResponseAsync<HeroItemPopularity>($"{Endpoint}/{heroId}/itemPopularity");
	}
}