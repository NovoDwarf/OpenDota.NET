namespace OpenDota.NET.Routes.Rankings;

/// <summary>Provides access to the rankings endpoint.</summary>
[UsedImplicitly]
public class RankingsEndpoint : IRankingsEndpoint
{
	private readonly Requester _requester;

	/// <summary>Creates the endpoint.</summary>
	/// <param name="requester">The HTTP requester used by the endpoint.</param>
	public RankingsEndpoint(Requester requester)
	{
		_requester = requester;
	}

	/// <inheritdoc />
	public string Endpoint => "rankings";

	/// <inheritdoc />
	public string Url => new Uri(baseUri: _requester.BaseAddress, relativeUri: Endpoint).AbsoluteUri;


	/// <inheritdoc />
	public Task<HeroRanking?> GetHeroRankingsAsync(int heroId)
	{
		return _requester.GetResponseAsync<HeroRanking>(
			url: Endpoint,
			queryParameters: [$"hero_id={heroId}"]);
	}
}