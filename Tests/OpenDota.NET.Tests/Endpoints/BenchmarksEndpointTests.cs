namespace OpenDota.NET.Tests.Endpoints;

public class BenchmarksEndpointTests
{
	private readonly OpenDotaApi _openDotaApi = new();
	private readonly ITestOutputHelper _testOutputHelper;

	public BenchmarksEndpointTests(ITestOutputHelper testOutputHelper)
	{
		_testOutputHelper = testOutputHelper;
	}

	[Fact]
	public async Task TestGetHeroBenchmark()
	{
		const int heroId = 2;

		var result = await _openDotaApi.Benchmarks.GetHeroBenchmarkAsync(heroId);

		_testOutputHelper.WriteLine(result.ToJsonString());

		if (result != null)
		{
			Assert.Equal(heroId, result.HeroId);
			Assert.NotNull(result.Result);
			Assert.Equal(11, result.Result.GoldPerMinutes.Count);
			Assert.Equal(11, result.Result.XpPerMinutes.Count);
			Assert.Equal(11, result.Result.KillsPerMinutes.Count);
			Assert.Equal(11, result.Result.LastHitPerMinutes.Count);
			Assert.Equal(11, result.Result.HeroDamagePerMinutes.Count);
			Assert.Equal(11, result.Result.HeroHealingPerMinutes.Count);
			Assert.Equal(11, result.Result.TowerDamage.Count);
		}
	}
}