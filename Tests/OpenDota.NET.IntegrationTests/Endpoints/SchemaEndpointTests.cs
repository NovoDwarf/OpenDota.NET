namespace OpenDota.NET.IntegrationTests.Endpoints;

public class SchemaEndpointTests
{
	private readonly OpenDotaApi _openDotaApi = new();
	private readonly ITestOutputHelper _testOutputHelper;

	public SchemaEndpointTests(ITestOutputHelper testOutputHelper)
	{
		_testOutputHelper = testOutputHelper;
	}

	[Fact]
	public async Task TestGetDatabaseSchema()
	{
		var result = await _openDotaApi.Schema.GetDatabaseSchemaAsync();
		_testOutputHelper.WriteLine(result.ToJsonString());

		Assert.NotNull(result);
		Assert.Contains(result, x => x.TableName == "api_key_usage");
	}
}