namespace OpenDota.NET.IntegrationTests.Endpoints;

public class DistributionsEndpointTests
{
	private readonly OpenDotaApi _openDotaApi = new();
	private readonly ITestOutputHelper _testOutputHelper;

	public DistributionsEndpointTests(ITestOutputHelper testOutputHelper)
	{
		_testOutputHelper = testOutputHelper;
	}

	[Fact]
	public async Task TestGetDistributions()
	{
		var result = await _openDotaApi.Distributions.GetDistributionsAsync();
		_testOutputHelper.WriteLine(result.ToJsonString());

		Assert.NotNull(result);
		Assert.NotNull(result);
	}
}