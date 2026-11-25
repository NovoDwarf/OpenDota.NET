#nullable enable
using System.Net;
using System.Net.Http;
using System.Text.Json.Nodes;
using System.Threading;
using OpenDota.NET.Routes.Constants;
using OpenDota.NET.Routes.Heroes;
using OpenDota.NET.Routes.Players;
using OpenDota.NET.Routes.PublicMatches;
using OpenDota.NET.Routes.Search;
using OpenDota.NET.Utilities;

namespace OpenDota.NET.Tests;

public class RequestContractTests
{
    [Fact]
    public void EveryEndpointExposesItsBasePathAndUrl()
    {
        using var api = new OpenDotaApi();
        var expected = new Dictionary<string, string>
        {
            ["Benchmarks"] = "benchmarks", ["Constants"] = "constants", ["Distributions"] = "distributions",
            ["Explorer"] = "explorer", ["FindMatches"] = "findMatches", ["Health"] = "health",
            ["Heroes"] = "heroes", ["HeroStats"] = "heroStats", ["League"] = "leagues", ["Live"] = "live",
            ["Matches"] = "matches", ["Metadata"] = "metadata", ["ParsedMatches"] = "parsedMatches",
            ["Players"] = "players", ["ProMatches"] = "proMatches", ["ProPlayers"] = "proPlayers",
            ["PublicMatches"] = "publicMatches", ["Rankings"] = "rankings", ["Records"] = "records",
            ["Request"] = "request", ["Scenarios"] = "scenarios", ["Schema"] = "schema",
            ["Search"] = "search", ["Teams"] = "teams"
        };

        var properties = typeof(IOpenDotaApi).GetProperties();
        Assert.Equal(expected.Count, properties.Length);
        foreach (var property in properties)
        {
            var instance = property.GetValue(api)!;
            var path = (string)property.PropertyType.GetProperty("Endpoint")!.GetValue(instance)!;
            var url = (string)property.PropertyType.GetProperty("Url")!.GetValue(instance)!;
            Assert.Equal(expected[property.Name], path);
            Assert.Equal($"https://api.opendota.com/api/{path}", url);
        }
    }

    [Fact]
    public async Task HeroMethodsUseEndpointForBaseAndNestedRoutes()
    {
        var handler = new RecordingHandler("[]");
        using var requester = new Requester(new OpenDotaSettings(), handler);
        var endpoint = new HeroesEndpoint(requester);

        await endpoint.GetHeroesAsync();
        Assert.Equal(new Uri(endpoint.Url), handler.Uri);
        await endpoint.GetHeroMatchesAsync(42);
        Assert.Equal($"{endpoint.Url}/42/matches", handler.Uri!.AbsoluteUri);
    }

    [Fact]
    public async Task ScenarioMethodsUseEndpointForNestedRoutes()
    {
        var handler = new RecordingHandler("[]");
        using var requester = new Requester(new OpenDotaSettings(), handler);
        var endpoint = new OpenDota.NET.Routes.Scenarios.ScenariosEndpoint(requester);

        await endpoint.GetItemNamingAsync();
        Assert.Equal($"{endpoint.Url}/itemTimings", handler.Uri!.AbsoluteUri);
        await endpoint.GetLaneRolesAsync();
        Assert.Equal($"{endpoint.Url}/laneRoles", handler.Uri!.AbsoluteUri);
        await endpoint.GetMiscTeamScenariosAsync();
        Assert.Equal($"{endpoint.Url}/misc", handler.Uri!.AbsoluteUri);
    }

    [Fact]
    public async Task EncodesSearchAndApiKeyForGetAndPost()
    {
        var handler = new RecordingHandler("[]");
        using var requester = new Requester(new OpenDotaSettings { ApiKey = "key&?" }, handler);
        await new SearchEndpoint(requester).GetPlayersByNameAsync("a&b #тест");
        Assert.Equal("?q=a%26b%20%23%D1%82%D0%B5%D1%81%D1%82&api_key=key%26%3F", handler.Uri!.Query);
        using var response = await requester.PostRequestAsync("players/1/refresh");
        Assert.Equal(HttpMethod.Post, handler.Method);
        Assert.Equal("?api_key=key%26%3F", handler.Uri!.Query);
    }

    [Fact]
    public async Task PlayerFiltersAreOmittedUnlessProvided()
    {
        var handler = new RecordingHandler("[]");
        using var requester = new Requester(new OpenDotaSettings(), handler);
        var endpoint = new PlayersEndpoint(requester);
        await endpoint.GetPlayerMatchesAsync(42, new PlayerEndpointParameters());
        Assert.Equal(string.Empty, handler.Uri!.Query);
        await endpoint.GetPlayerMatchesAsync(42, new PlayerEndpointParameters { Significant = 0, Having = 0 });
        Assert.Equal("?significant=0&having=0", handler.Uri!.Query);
    }

    [Fact]
    public async Task PlayerEnumFiltersUseNumericValues()
    {
        var handler = new RecordingHandler("[]");
        using var requester = new Requester(new OpenDotaSettings(), handler);
        var filters = new PlayerEndpointParameters
        {
            GameMode = OpenDota.NET.Enums.GameMode.Turbo,
            LobbyType = OpenDota.NET.Enums.LobbyType.Ranked,
            LaneRole = OpenDota.NET.Enums.LaneRole.Offlane
        };

        await new PlayersEndpoint(requester).GetPlayerMatchesAsync(42, filters);

        Assert.Equal("?game_mode=23&lobby_type=7&lane_role=3", handler.Uri!.Query);
    }

    [Fact]
    public async Task PublicMatchesUsesRankFilters()
    {
        var handler = new RecordingHandler("[]");
        using var requester = new Requester(new OpenDotaSettings(), handler);
        await new PublicMatchesEndpoint(requester).GetPublicMatchesAsync(20, 80, 123);
        Assert.Equal("?min_rank=20&max_rank=80&less_than_match_id=123", handler.Uri!.Query);
    }

    [Fact]
    public async Task HeroPopularityReadsObject()
    {
        var handler = new RecordingHandler("""{"start_game_items":{"1":3}}""");
        using var requester = new Requester(new OpenDotaSettings(), handler);
        var result = await new HeroesEndpoint(requester).GetHeroItemPopularityAsync(1);
        Assert.NotNull(result);
        Assert.Equal(3, result.StartGameItems["1"]);
    }

    [Theory]
    [InlineData("{}", false)]
    [InlineData("[1,2]", true)]
    public async Task ConstantsAcceptsObjectAndArray(string json, bool array)
    {
        var handler = new RecordingHandler(json);
        using var requester = new Requester(new OpenDotaSettings(), handler);
        var result = await new ConstantsEndpoint(requester).GetConstantsAsync(OpenDota.NET.Routes.Constants.Enums.Constant.Heroes);
        Assert.Equal(array, result is JsonArray);
        Assert.NotNull(result);
    }

    [Fact]
    public async Task LeagueOperationsUseObservedResponseShapes()
    {
        var options = new OpenDotaSettings();
        using var leagueRequester = new Requester(options, new RecordingHandler("""{"leagueid":15728,"name":"The International"}"""));
        var league = await new OpenDota.NET.Routes.Leagues.LeagueEndpoint(leagueRequester).GetLeagueAsync(15728);
        Assert.Equal(15728, league!.LeagueId);

        using var matchesRequester = new Requester(options, new RecordingHandler("""[{"match_id":7406531302,"radiant_team_name":"Team"}]"""));
        var matches = await new OpenDota.NET.Routes.Leagues.LeagueEndpoint(matchesRequester).GetLeagueMatchesAsync(15728);
        Assert.Equal("Team", Assert.Single(matches!).RadiantTeamName);

        using var idsRequester = new Requester(options, new RecordingHandler("""[7406531302,"7406482053"]"""));
        var ids = await new OpenDota.NET.Routes.Leagues.LeagueEndpoint(idsRequester).GetLeagueMatchIdsAsync(15728);
        Assert.Equal(new long[] { 7406531302, 7406482053 }, ids);

        using var teamsRequester = new Requester(options, new RecordingHandler("""[{"team_id":42}]"""));
        var teams = await new OpenDota.NET.Routes.Leagues.LeagueEndpoint(teamsRequester).GetLeagueTeamsAsync(15728);
        Assert.Equal(42, Assert.Single(teams!).TeamId);
    }

    [Fact]
    public async Task TopPlayersSupportsTurbo()
    {
        var handler = new RecordingHandler("""[{"account_id":42,"computed_mmr":4655.32}]""");
        using var requester = new Requester(new OpenDotaSettings(), handler);
        var players = await new PlayersEndpoint(requester).GetTopPlayersAsync(true);
        Assert.Equal("/api/topPlayers", handler.Uri!.AbsolutePath);
        Assert.Equal("?turbo=1", handler.Uri.Query);
        Assert.Equal(42, Assert.Single(players!)["account_id"]!.GetValue<int>());
    }

    [Fact]
    public async Task PublicMatchesAcceptNullWinner()
    {
        var handler = new RecordingHandler("""[{"radiant_win":null}]""");
        using var requester = new Requester(new OpenDotaSettings(), handler);
        var matches = await new PublicMatchesEndpoint(requester).GetPublicMatchesAsync();
        Assert.Null(Assert.Single(matches!).RadiantWin);
    }

    private sealed class RecordingHandler(string json) : HttpMessageHandler
    {
        public Uri? Uri { get; private set; }
        public HttpMethod? Method { get; private set; }

        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            Uri = request.RequestUri;
            Method = request.Method;
            return Task.FromResult(new HttpResponseMessage(HttpStatusCode.OK) { Content = new StringContent(json) });
        }
    }
}
