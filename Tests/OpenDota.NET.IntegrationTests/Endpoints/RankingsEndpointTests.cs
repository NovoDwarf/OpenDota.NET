namespace OpenDota.NET.IntegrationTests.Endpoints;

public class RankingsEndpointTests
{
	private readonly OpenDotaApi _openDotaApi = new();
	private readonly ITestOutputHelper _testOutputHelper;

	public RankingsEndpointTests(ITestOutputHelper testOutputHelper)
	{
		_testOutputHelper = testOutputHelper;
	}

	[Fact]
	public async Task TestGetHeroRankings()
	{
		const int heroId = 40;
		var result = await _openDotaApi.Rankings.GetHeroRankingsAsync(heroId);
		_testOutputHelper.WriteLine(result.ToJsonString());

		Assert.NotNull(result);
		Assert.Equal(heroId, result.HeroId);

		Assert.Equal(100, result.Rankings.Count);
		Assert.True(result.Rankings.All(x => x.AccountId > 0));
		Assert.Contains(result.Rankings, x => x.RankTier > 0);
		Assert.True(result.Rankings.All(x => x.RankTier > 0));
		Assert.True(result.Rankings.All(x => x.Score > 0));
		Assert.Contains(result.Rankings, x => x.LastLogin > new DateTimeOffset(2000, 1, 1, 0, 0, 0, TimeSpan.Zero));
		Assert.True(result.Rankings.All(x => !x.LastLogin.HasValue || x.LastLogin > new DateTimeOffset(2000, 1, 1, 0, 0, 0, TimeSpan.Zero)));
		Assert.Contains(result.Rankings, x => !string.IsNullOrWhiteSpace(x.Name));
		Assert.True(result.Rankings.All(x => !string.IsNullOrWhiteSpace(x.Avatar?.ToString())));
		Assert.True(result.Rankings.All(x => !string.IsNullOrWhiteSpace(x.PersonaName)));
	}
}