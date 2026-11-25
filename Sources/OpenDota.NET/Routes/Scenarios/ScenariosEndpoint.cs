namespace OpenDotaDotNet.Routes.Scenarios;

/// <inheritdoc />
[UsedImplicitly]
public class ScenariosEndpoint : IScenariosEndpoint
{
	private readonly Requester _requester;

	/// <inheritdoc />
	public ScenariosEndpoint(Requester requester)
	{
		_requester = requester;
	}

	/// <inheritdoc />
	public string Endpoint => "scenarios";

	/// <inheritdoc />
	public string Url => new Uri(baseUri: _requester.BaseAddress, relativeUri: Endpoint).AbsoluteUri;


	/// <inheritdoc />
	public Task<List<ItemTiming>?> GetItemNamingAsync(string? item = null, int? heroId = null)
	{
		return _requester.GetResponseAsync<List<ItemTiming>>(
			url: $"{Endpoint}/itemTimings",
			queryParameters: GetArguments(item: item, heroId: heroId));
	}

	/// <inheritdoc />
	public Task<List<LaneRoles>?> GetLaneRolesAsync(LaneRole? laneRole = null, int? heroId = null)
	{
		return _requester.GetResponseAsync<List<LaneRoles>>(
			url: $"{Endpoint}/laneRoles",
			queryParameters: GetArguments(item: null, heroId: heroId, laneRole: laneRole));
	}

	/// <inheritdoc />
	public Task<List<TeamScenario>?> GetMiscTeamScenariosAsync(Scenario? scenario = null)
	{
		return _requester.GetResponseAsync<List<TeamScenario>>(
			url: $"{Endpoint}/misc",
			queryParameters: GetArguments(item: null, heroId: null, laneRole: null, scenario: scenario));
	}

	private static List<string> GetArguments(string? item = null, int? heroId = null, LaneRole? laneRole = null, Scenario? scenario = null)
	{
		var addedArguments = new List<string>();

		if (item != null)
			addedArguments.Add(item: $"item={item}");

		if (heroId != null)
			addedArguments.Add(item: $"hero_id={heroId}");

		if (laneRole != null)
			addedArguments.Add(item: $"lane_role={(int)laneRole.Value}");

		if (scenario != null)
			addedArguments.Add(item: $"scenario={scenario.ToSnakeCase()}");

		return addedArguments;
	}
}