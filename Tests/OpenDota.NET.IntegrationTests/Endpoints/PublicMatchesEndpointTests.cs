namespace OpenDota.NET.IntegrationTests.Endpoints;

public class PublicMatchesEndpointTests
{
	private readonly OpenDotaApi _openDotaApi = new();
	private readonly ITestOutputHelper _testOutputHelper;

	public PublicMatchesEndpointTests(ITestOutputHelper testOutputHelper)
	{
		_testOutputHelper = testOutputHelper;
	}

	[Fact]
	public async Task TestGetPublicMatches()
	{
		var result = await _openDotaApi.PublicMatches.GetPublicMatchesAsync();
		_testOutputHelper.WriteLine(result.ToJsonString());

		Assert.NotNull(result);
		Assert.True(result.TrueForAll(x => x.MatchId > 0));
		Assert.True(result.TrueForAll(x => x.AvgRankTier > 0));
		Assert.True(result.TrueForAll(x => x.Cluster > 0));
		Assert.True(result.TrueForAll(x => x.Duration >= 0));
		Assert.True(result.TrueForAll(x => (long)x.GameMode > 0));
		Assert.True(result.TrueForAll(x => (long)x.LobbyType >= 0));
		Assert.True(result.TrueForAll(x => x.MatchSeqNum > 0));
		Assert.True(result.TrueForAll(x => x.NumRankTier > 0));
		Assert.True(result.TrueForAll(x => x.StartTime > 0));
		Assert.True(result.TrueForAll(x => x.RadiantTeam.Length == 5));
		Assert.True(result.TrueForAll(x => x.DireTeam.Length == 5));
	}
}