using OpenDota.NET.Routes.Players.Models;
using OpenDota.NET.Utilities;

namespace OpenDota.NET.Routes.Players;

/// <inheritdoc />
[UsedImplicitly]
public class PlayersEndpoint : IPlayersEndpoint
{
	private readonly Requester _requester;

	/// <inheritdoc />
	public PlayersEndpoint(Requester requester)
	{
		_requester = requester;
	}

	/// <inheritdoc />
	public string Endpoint => "players";

	/// <inheritdoc />
	public string Url => new Uri(baseUri: _requester.BaseAddress, relativeUri: Endpoint).AbsoluteUri;


	/// <inheritdoc />
    public Task<List<JsonObject>?> GetTopPlayersAsync(bool turbo = false)
	{
		return _requester.GetResponseAsync<List<JsonObject>>(url: "topPlayers", queryParameters: turbo ? ["turbo=1"] : null);
	}

	/// <inheritdoc />
	public Task<Player?> GetPlayerByIdAsync(long accountId)
	{
		return _requester.GetResponseAsync<Player>(url: $"{Endpoint}/{accountId}");
	}

	/// <inheritdoc />
	public Task<PlayerWinLoss?> GetPlayerWinLossByIdAsync(
		long accountId,
		PlayerEndpointParameters? parameters = null)
	{
		return _requester.GetResponseAsync<PlayerWinLoss>(
			url: $"{Endpoint}/{accountId}/wl",
			queryParameters: GetArguments(parameters: parameters));
	}

	/// <inheritdoc />
	public Task<List<PlayerRecentMatch>?> GetPlayerRecentMatchesAsync(long accountId)
	{
		return _requester.GetResponseAsync<List<PlayerRecentMatch>>(url: $"{Endpoint}/{accountId}/recentMatches");
	}

	/// <inheritdoc />
	public Task<List<PlayerMatch>?> GetPlayerMatchesAsync(long accountId, PlayerEndpointParameters? parameters = null)
	{
		return _requester.GetResponseAsync<List<PlayerMatch>>(
			url: $"{Endpoint}/{accountId}/matches",
			queryParameters: GetArguments(parameters: parameters));
	}

	/// <inheritdoc />
	public Task<List<PlayerHero>?> GetPlayerHeroesAsync(long accountId, PlayerEndpointParameters? parameters = null)
	{
		return _requester.GetResponseAsync<List<PlayerHero>>(
			url: $"{Endpoint}/{accountId}/heroes",
			queryParameters: GetArguments(parameters: parameters));
	}

	/// <inheritdoc />
	public Task<List<PlayerPeer>?> GetPlayerPeersAsync(long accountId, PlayerEndpointParameters? parameters = null)
	{
		return _requester.GetResponseAsync<List<PlayerPeer>>(
			url: $"{Endpoint}/{accountId}/peers",
			queryParameters: GetArguments(parameters: parameters));
	}

	/// <inheritdoc />
	public Task<List<PlayerPro>?> GetPlayerProsAsync(long accountId, PlayerEndpointParameters? parameters = null)
	{
		return _requester.GetResponseAsync<List<PlayerPro>>(
			url: $"{Endpoint}/{accountId}/pros",
			queryParameters: GetArguments(parameters: parameters));
	}

	/// <inheritdoc />
	public Task<List<PlayerTotal>?> GetPlayerTotalsAsync(long accountId, PlayerEndpointParameters? parameters = null)
	{
		return _requester.GetResponseAsync<List<PlayerTotal>>(
			url: $"{Endpoint}/{accountId}/totals",
			queryParameters: GetArguments(parameters: parameters));
	}

	/// <inheritdoc />
	public Task<PlayerCount?> GetPlayerCountsAsync(long accountId, PlayerEndpointParameters? parameters = null)
	{
		return _requester.GetResponseAsync<PlayerCount>(
			url: $"{Endpoint}/{accountId}/counts",
			queryParameters: GetArguments(parameters: parameters));
	}

	/// <inheritdoc />
	public Task<List<PlayerHistogram>?> GetPlayerHistogramsAsync(long accountId, string field, PlayerEndpointParameters? parameters = null)
	{
		return _requester.GetResponseAsync<List<PlayerHistogram>>(
			url: $"{Endpoint}/{accountId}/histograms/{field}",
			queryParameters: GetArguments(parameters: parameters));
	}

	/// <inheritdoc />
	public Task<PlayerWardMap?> GetPlayerWardMapAsync(long accountId, PlayerEndpointParameters? parameters = null)
	{
		return _requester.GetResponseAsync<PlayerWardMap>(
			url: $"{Endpoint}/{accountId}/wardmap",
			queryParameters: GetArguments(parameters: parameters));
	}

	/// <inheritdoc />
	public Task<PlayerWordCloud?> GetPlayerWordCloudAsync(long accountId, PlayerEndpointParameters? parameters = null)
	{
		return _requester.GetResponseAsync<PlayerWordCloud>(
			url: $"{Endpoint}/{accountId}/wordcloud",
			queryParameters: GetArguments(parameters: parameters));
	}

	/// <inheritdoc />
	public Task<List<PlayerRating>?> GetPlayerRatingsAsync(long accountId)
	{
		return _requester.GetResponseAsync<List<PlayerRating>>(url: $"{Endpoint}/{accountId}/ratings");
	}

	/// <inheritdoc />
	public Task<List<PlayerHeroRanking>?> GetPlayerHeroRankingsAsync(long accountId)
	{
		return _requester.GetResponseAsync<List<PlayerHeroRanking>>(url: $"{Endpoint}/{accountId}/rankings");
	}

	/// <inheritdoc />
	public async Task<bool> RefreshPlayerMatchHistoryAsync(long accountId)
	{
		using var response = await _requester.PostRequestAsync(url: $"{Endpoint}/{accountId}/refresh");
		response.EnsureSuccessStatusCode();

		return true;
	}

	private static List<string> GetArguments(PlayerEndpointParameters? parameters)
	{
		var addedArguments = new List<string>();

		if (parameters == null)
			return addedArguments;

		if (parameters.Limit != null)
			addedArguments.Add(item: $"limit={parameters.Limit}");

		if (parameters.Offset != null)
			addedArguments.Add(item: $"offset={parameters.Offset}");

		if (parameters.Win != null)
			addedArguments.Add(item: $"win={parameters.Win}");

		if (parameters.Patch != null)
			addedArguments.Add(item: $"patch={parameters.Patch}");

		if (parameters.GameMode != null)
			addedArguments.Add(item: $"game_mode={(long)parameters.GameMode.Value}");

		if (parameters.LobbyType != null)
			addedArguments.Add(item: $"lobby_type={(long)parameters.LobbyType.Value}");

		if (parameters.Region != null)
			addedArguments.Add(item: $"region={parameters.Region}");

		if (parameters.Date != null)
			addedArguments.Add(item: $"date={parameters.Date}");

		if (parameters.LaneRole != null)
			addedArguments.Add(item: $"lane_role={(long)parameters.LaneRole.Value}");

		if (parameters.HeroId != null)
			addedArguments.Add(item: $"hero_id={parameters.HeroId}");

		if (parameters.IsRadiant != null)
			addedArguments.Add(item: $"is_radiant={parameters.IsRadiant}");

		if (parameters.IncludedAccountIds != null)
			addedArguments.AddRange(parameters.IncludedAccountIds.Select(includedAccountId => $"included_account_id={includedAccountId}"));

		if (parameters.ExcludedAccountIds != null)
			addedArguments.AddRange(parameters.ExcludedAccountIds.Select(excludedAccountId => $"excluded_account_id={excludedAccountId}"));

		if (parameters.WithHeroIds != null)
			addedArguments.AddRange(parameters.WithHeroIds.Select(withHeroId => $"with_hero_id={withHeroId}"));

		if (parameters.AgainstHeroIds != null)
			addedArguments.AddRange(parameters.AgainstHeroIds.Select(againstHeroId => $"against_hero_id={againstHeroId}"));

		if (parameters.Significant != null)
			addedArguments.Add(item: $"significant={parameters.Significant}");

		if (parameters.Having != null)
			addedArguments.Add(item: $"having={parameters.Having}");

		if (parameters.Sort != null)
			addedArguments.Add(item: $"sort={parameters.Sort}");

		if (parameters.Project != null)
			addedArguments.AddRange(parameters.Project.Select(project => $"project={project}"));

		return addedArguments;
	}
}