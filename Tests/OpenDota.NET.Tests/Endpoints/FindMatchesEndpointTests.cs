namespace OpenDota.NET.Tests.Endpoints;

public class FindMatchesEndpointTests
{
	private readonly OpenDotaApi _openDotaApi = new();
	private readonly ITestOutputHelper _testOutputHelper;

	public FindMatchesEndpointTests(ITestOutputHelper testOutputHelper)
	{
		_testOutputHelper = testOutputHelper;
	}

	[Fact]
	public async Task TestFindMatchesByHeroesPlayed()
	{
		var result = await _openDotaApi.FindMatches.FindMatchesByHeroesPlayedAsync([27], [2]);
		_testOutputHelper.WriteLine(result.ToJsonString());

		if (result != null)
		{
			Assert.Equal(10, result.Count);
			Assert.True(result.TrueForAll(x => x.TeamA.Contains(27) || x.TeamB.Contains(27)));
			Assert.True(result.TrueForAll(x => x.TeamA.Contains(2) || x.TeamB.Contains(2)));
			Assert.True(result.TrueForAll(x => x.StartTime > 0));
			Assert.True(result.TrueForAll(x => x.MatchId > 0));
		}
	}
}