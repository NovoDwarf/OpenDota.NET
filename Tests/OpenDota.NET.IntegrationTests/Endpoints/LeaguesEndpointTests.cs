using OpenDota.NET.Routes.Leagues.Enums;

namespace OpenDota.NET.IntegrationTests.Endpoints;

public class LeaguesEndpointTests
{
	private readonly OpenDotaApi _openDotaApi = new();
	private readonly ITestOutputHelper _testOutputHelper;

	public LeaguesEndpointTests(ITestOutputHelper testOutputHelper)
	{
		_testOutputHelper = testOutputHelper;
	}

	[Fact]
	public async Task TestGetLeagues()
	{
		var result = await _openDotaApi.League.GetLeaguesAsync();
		_testOutputHelper.WriteLine(result.ToJsonString());

		Assert.NotNull(result);
		Assert.True(result.Count >= 3322);
		Assert.Contains(result, x => x.Tier == Tier.Amateur);
		Assert.Contains(result, x => x.Tier == Tier.Excluded);
		Assert.Contains(result, x => x.Tier == Tier.Premium);
		Assert.Contains(result, x => x.Tier == Tier.Professional);
		Assert.Contains(result, x => x.LeagueId > 0);
		Assert.True(result.TrueForAll(x => !string.IsNullOrWhiteSpace(x.Name)));
		Assert.Contains(result, x => !string.IsNullOrWhiteSpace(x.Banner));
		Assert.Contains(result, x => !string.IsNullOrWhiteSpace(x.Ticket));
	}
}