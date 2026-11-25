namespace OpenDota.NET.IntegrationTests.Endpoints;

public class MetadataEndpointTests
{
	private readonly OpenDotaApi _openDotaApi = new();
	private readonly ITestOutputHelper _testOutputHelper;

	public MetadataEndpointTests(ITestOutputHelper testOutputHelper)
	{
		_testOutputHelper = testOutputHelper;
	}

	[Fact]
	public async Task TestGetMetadata()
	{
		var result = await _openDotaApi.Metadata.GetMetadataAsync();
		_testOutputHelper.WriteLine(result.ToJsonString());

		Assert.NotNull(result);
		Assert.True(result.Scenarios.ItemCost > 0);
		Assert.True(result.Scenarios.GameDurationBucket.Count > 0);
		Assert.True(result.Scenarios.TeamScenariosQueryParams.Count > 0);
		Assert.True(result.Scenarios.Timings.Count > 0);
	}
}