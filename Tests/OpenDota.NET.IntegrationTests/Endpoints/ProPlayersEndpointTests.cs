namespace OpenDota.NET.IntegrationTests.Endpoints;

public class ProPlayersEndpointTests
{
	private readonly OpenDotaApi _openDotaApi = new();
	private readonly ITestOutputHelper _testOutputHelper;

	public ProPlayersEndpointTests(ITestOutputHelper testOutputHelper)
	{
		_testOutputHelper = testOutputHelper;
	}

	[Fact]
	public async Task TestGetProPlayers()
	{
		var result = await _openDotaApi.ProPlayers.GetProPlayersAsync();
		_testOutputHelper.WriteLine(result.ToJsonString());

		Assert.NotNull(result);
		Assert.True(result.TrueForAll(x => x.AccountId > 0));
		Assert.Contains(result, x => !string.IsNullOrWhiteSpace(x.Name));
		Assert.Contains(result, x => !string.IsNullOrWhiteSpace(x.SteamId));
		Assert.Contains(result, x => !string.IsNullOrWhiteSpace(x.PersonaName));
	}
}