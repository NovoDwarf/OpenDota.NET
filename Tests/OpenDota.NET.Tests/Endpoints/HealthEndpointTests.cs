namespace OpenDota.NET.Tests.Endpoints;

public class HealthEndpointTests
{
	private readonly OpenDotaApi _openDotaApi = new();
	private readonly ITestOutputHelper _testOutputHelper;

	public HealthEndpointTests(ITestOutputHelper testOutputHelper)
	{
		_testOutputHelper = testOutputHelper;
	}

	[Fact]
	public async Task TestGetServiceHealthData()
	{
		var health = await _openDotaApi.Health.GetServiceHealthDataAsync();
		_testOutputHelper.WriteLine(health.ToJsonString());

		if (health != null)
		{
			Assert.True(health.GcDelay is { Timestamp: > 0 });
			Assert.True(health.ParseDelay is { Timestamp: > 0 });
			Assert.True(health.PostgresUsage is { Timestamp: > 0 });
			Assert.True(health.RedisUsage is { Timestamp: > 0 });
			Assert.True(health.SeqNumDelay is { Timestamp: > 0 });
			Assert.True(health.FhDelay is { Timestamp: > 0 });
			Assert.True(health.MmrDelay is { Timestamp: > 0 });
			Assert.True(health.CountsDelay is { Timestamp: > 0 });
			Assert.True(health.ScenariosDelay is { Timestamp: > 0 });

			Assert.True(health.GcDelay.Limit > 0);
			Assert.True(health.ParseDelay.Limit > 0);
			Assert.True(health.PostgresUsage.Limit > 0);
			Assert.True(health.RedisUsage.Limit > 0);
			Assert.True(health.SeqNumDelay.Limit > 0);
			Assert.True(health.FhDelay.Limit > 0);
			Assert.True(health.MmrDelay.Limit > 0);
			Assert.True(health.CountsDelay.Limit > 0);
			Assert.True(health.ScenariosDelay.Limit > 0);

			Assert.True(health.GcDelay.Metric >= 0);
			Assert.True(health.ParseDelay.Metric >= 0);
			Assert.True(health.PostgresUsage.Metric >= 0);
			Assert.True(health.RedisUsage.Metric >= 0);
			Assert.True(health.FhDelay.Metric >= 0);
			Assert.True(health.MmrDelay.Metric >= 0);
			Assert.True(health.CountsDelay.Metric >= 0);
			Assert.True(health.ScenariosDelay.Metric >= 0);
		}
		else
			Assert.Fail();
	}
}