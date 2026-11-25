namespace OpenDota.NET.Tests.Endpoints;

public class MatchesEndpointTests
{
	private readonly OpenDotaApi _openDotaApi = new();
	private readonly ITestOutputHelper _testOutputHelper;

	public MatchesEndpointTests(ITestOutputHelper testOutputHelper)
	{
		_testOutputHelper = testOutputHelper;
	}

	[Fact]
	public async Task TestGetMatchById()
	{
		var result = await _openDotaApi.Matches.GetMatchByIdAsync(4986133311);
		_testOutputHelper.WriteLine(result.ToJsonString());

		Assert.NotNull(result);
	}
}