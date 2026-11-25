namespace OpenDota.NET.Tests.Endpoints;

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

		if (result != null)
		{
			Assert.NotNull(result);
		}
	}
}