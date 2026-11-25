namespace OpenDotaDotNet.Routes.HeroStats;

/// <inheritdoc />
public class HeroStatsEndpoint : IHeroStatsEndpoint
{
	private readonly Requester _requester;

	/// <inheritdoc />
	public HeroStatsEndpoint(Requester requester)
	{
		_requester = requester;
	}

	/// <inheritdoc />
	public string Endpoint => "heroStats";

	/// <inheritdoc />
	public string Url => new Uri(baseUri: _requester.BaseAddress, relativeUri: Endpoint).AbsoluteUri;

	/// <inheritdoc />
	public Task<List<Models.HeroStats>?> GetHeroStatsAsync()
	{
		return _requester.GetResponseAsync<List<Models.HeroStats>>(Endpoint);
	}
}