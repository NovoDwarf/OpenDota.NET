using OpenDota.NET.Utilities;

namespace OpenDota.NET.Routes.HeroStats;

/// <inheritdoc />
public class HeroStatsEndpoint : IHeroStatsEndpoint
{
	private readonly Requester _requester;

	/// <summary>Creates an instance of <see cref="HeroStatsEndpoint" />.</summary>
	/// <param name="requester">The requester used to send API requests.</param>
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