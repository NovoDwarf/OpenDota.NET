namespace OpenDota.NET.Tests.Endpoints;

public class RecordsEndpointTests
{
	private readonly OpenDotaApi _openDotaApi = new();
	private readonly ITestOutputHelper _testOutputHelper;

	public RecordsEndpointTests(ITestOutputHelper testOutputHelper)
	{
		_testOutputHelper = testOutputHelper;
	}

	[Fact]
	public async Task TestGetRecordsByField()
	{
		var result = await _openDotaApi.Records.GetRecordsByFieldAsync(Field.Duration);
		_testOutputHelper.WriteLine(result.ToJsonString());

		if (result != null)
		{
			Assert.Equal(100, result.Count);
			Assert.True(result.TrueForAll(x => x.MatchId > 0));
			Assert.True(result.TrueForAll(x => x.Score > 0));
			Assert.True(result.TrueForAll(x => x.StartTime > 0));
		}
	}
}