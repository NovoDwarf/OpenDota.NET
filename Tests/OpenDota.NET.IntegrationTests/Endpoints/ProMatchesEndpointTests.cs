namespace OpenDota.NET.IntegrationTests.Endpoints;

public class ProMatchesEndpointTests
{
	private readonly OpenDotaApi _openDotaApi = new();
	private readonly ITestOutputHelper _testOutputHelper;

	public ProMatchesEndpointTests(ITestOutputHelper testOutputHelper)
	{
		_testOutputHelper = testOutputHelper;
	}

	[Fact]
	public async Task TestGetProMatches()
	{
		var result = await _openDotaApi.ProMatches.GetProMatchesAsync();
		_testOutputHelper.WriteLine(result.ToJsonString());

		Assert.NotNull(result);
		Assert.Equal(100, result.Count);
		Assert.True(result.TrueForAll(x => !string.IsNullOrWhiteSpace(x.LeagueName)));
		Assert.True(result.TrueForAll(x => x.MatchId > 0));
		Assert.True(result.TrueForAll(x => x.StartTime > 0));
	}
}