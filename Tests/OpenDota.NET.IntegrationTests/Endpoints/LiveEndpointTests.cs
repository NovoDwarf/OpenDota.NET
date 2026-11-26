namespace OpenDota.NET.IntegrationTests.Endpoints;

public class LiveEndpointTests
{
	private readonly OpenDotaApi _openDotaApi = new();
	private readonly ITestOutputHelper _testOutputHelper;

	public LiveEndpointTests(ITestOutputHelper testOutputHelper)
	{
		_testOutputHelper = testOutputHelper;
	}

	[Fact]
	public async Task TestGetTopLiveGames()
	{
		var result = await _openDotaApi.Live.GetTopLiveGamesAsync();
		_testOutputHelper.WriteLine(result.ToJsonString());

		Assert.NotNull(result);
		Assert.Equal(100, result.Count);
		Assert.True(result.TrueForAll(x => !string.IsNullOrWhiteSpace(x.LobbyId)));
	}
}