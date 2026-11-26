using System.Net;
using System.Text.Json.Nodes;
using OpenDota.NET.Enums;
using OpenDota.NET.Routes.Constants;
using OpenDota.NET.Routes.Constants.Enums;
using OpenDota.NET.Routes.Heroes;
using OpenDota.NET.Routes.Leagues;
using OpenDota.NET.Routes.ParsedMatches;
using OpenDota.NET.Routes.Players;
using OpenDota.NET.Routes.Players.Models;
using OpenDota.NET.Routes.PublicMatches;
using OpenDota.NET.Routes.Request;
using OpenDota.NET.Routes.Scenarios;
using OpenDota.NET.Routes.Search;
using OpenDota.NET.Utilities;

namespace OpenDota.NET.Tests;

public class RequestContractTests
{
    private static readonly long[] ExpectedLeagueIds = [7406531302, 7406482053];

    [Fact]
    public void EveryEndpointExposesItsBasePathAndUrl()
    {
        using var api = new OpenDotaApi();

        var expected = new Dictionary<string, string>
        {
            ["Benchmarks"] = "benchmarks",
            ["Constants"] = "constants",
            ["Distributions"] = "distributions",
            ["Explorer"] = "explorer",
            ["FindMatches"] = "findMatches",
            ["Health"] = "health",
            ["Heroes"] = "heroes",
            ["HeroStats"] = "heroStats",
            ["League"] = "leagues",
            ["Live"] = "live",
            ["Matches"] = "matches",
            ["Metadata"] = "metadata",
            ["ParsedMatches"] = "parsedMatches",
            ["Players"] = "players",
            ["ProMatches"] = "proMatches",
            ["ProPlayers"] = "proPlayers",
            ["PublicMatches"] = "publicMatches",
            ["Rankings"] = "rankings",
            ["Records"] = "records",
            ["Request"] = "request",
            ["Scenarios"] = "scenarios",
            ["Schema"] = "schema",
            ["Search"] = "search",
            ["Teams"] = "teams"
        };

        var endpoints = typeof(IOpenDotaApi).GetProperties().Select(property =>
        {
            var instance = property.GetValue(api)!;
            var path = (string)property.PropertyType.GetProperty("Endpoint")!.GetValue(instance)!;
            var url = (string)property.PropertyType.GetProperty("Url")!.GetValue(instance)!;
            return (property.Name, Path: path, Url: url);
        }).ToList();

        Assert.Equal(expected.Count, endpoints.Count);
        foreach (var endpoint in endpoints)
        {
            Assert.Equal(expected[endpoint.Name], endpoint.Path);
            Assert.Equal($"https://api.opendota.com/api/{endpoint.Path}", endpoint.Url);
        }
    }

    [Theory]
    [InlineData(false, "")]
    [InlineData(true, "/42/matches")]
    public async Task HeroMethodsUseEndpointForBaseAndNestedRoutes(bool matches, string suffix)
    {
        var handler = new RecordingHandler("[]");
        using var requester = new Requester(new OpenDotaSettings(), handler);
        var endpoint = new HeroesEndpoint(requester);

        if (matches)
        {
            await endpoint.GetHeroMatchesAsync(42);
        }
        else
        {
            await endpoint.GetHeroesAsync();
        }

        Assert.Equal($"{endpoint.Url}{suffix}", handler.Uri!.AbsoluteUri);
    }

    [Theory]
    [InlineData("itemTimings")]
    [InlineData("laneRoles")]
    [InlineData("misc")]
    public async Task ScenarioMethodsUseEndpointForNestedRoutes(string route)
    {
        var handler = new RecordingHandler("[]");
        using var requester = new Requester(new OpenDotaSettings(), handler);
        var endpoint = new ScenariosEndpoint(requester);

        switch (route)
        {
            case "itemTimings":
                await endpoint.GetItemNamingAsync();
                break;
            case "laneRoles":
                await endpoint.GetLaneRolesAsync();
                break;
            case "misc":
                await endpoint.GetMiscTeamScenariosAsync();
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(route));
        }

        Assert.Equal($"{endpoint.Url}/{route}", handler.Uri!.AbsoluteUri);
    }

    [Fact]
    public async Task LaneRolesUsesNumericFiltersAndReadsResponse()
    {
        var handler = new RecordingHandler("""[{"hero_id":40,"lane_role":3,"time":900,"games":"8","wins":"1"}]""");
        using var requester = new Requester(new OpenDotaSettings(), handler);
        var endpoint = new ScenariosEndpoint(requester);

        var result = await endpoint.GetLaneRolesAsync(LaneRole.Offlane, 40);

        Assert.Equal("?hero_id=40&lane_role=3", handler.Uri!.Query);
        var role = Assert.Single(result!);
        Assert.Equal(40, role.HeroId);
        Assert.Equal(LaneRole.Offlane, role.LaneRole);
        Assert.Equal(8, role.Games);
        Assert.Equal(1, role.Wins);
    }

    [Fact]
    public async Task SearchEncodesQueryAndApiKey()
    {
        var handler = new RecordingHandler("[]");
        using var requester = new Requester(new OpenDotaSettings { ApiKey = "key&?" }, handler);
        var endpoint = new SearchEndpoint(requester);

        await endpoint.GetPlayersByNameAsync("a&b #тест");

        Assert.Equal("?q=a%26b%20%23%D1%82%D0%B5%D1%81%D1%82&api_key=key%26%3F", handler.Uri!.Query);
    }

    [Fact]
    public async Task PostEncodesApiKey()
    {
        var handler = new RecordingHandler("[]");
        using var requester = new Requester(new OpenDotaSettings { ApiKey = "key&?" }, handler);

        using var response = await requester.PostRequestAsync("players/1/refresh");

        Assert.Equal(HttpMethod.Post, handler.Method);
        Assert.Equal("?api_key=key%26%3F", handler.Uri!.Query);
    }

    [Theory]
    [InlineData(false, "")]
    [InlineData(true, "?significant=0&having=0")]
    public async Task PlayerFiltersAreOmittedUnlessProvided(bool includeFilters, string expectedQuery)
    {
        var handler = new RecordingHandler("[]");
        using var requester = new Requester(new OpenDotaSettings(), handler);
        var endpoint = new PlayersEndpoint(requester);
        var filters = includeFilters
            ? new PlayerEndpointParameters { Significant = 0, Having = 0 }
            : new PlayerEndpointParameters();

        await endpoint.GetPlayerMatchesAsync(42, filters);

        Assert.Equal(expectedQuery, handler.Uri!.Query);
    }

    [Fact]
    public async Task PlayerEnumFiltersUseNumericValues()
    {
        var handler = new RecordingHandler("[]");
        using var requester = new Requester(new OpenDotaSettings(), handler);
        var filters = new PlayerEndpointParameters
        {
            GameMode = GameMode.Turbo,
            LobbyType = LobbyType.Ranked,
            LaneRole = LaneRole.Offlane
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

        var result = await new ConstantsEndpoint(requester).GetConstantsAsync(Constant.Heroes);

        Assert.Equal(array, result is JsonArray);
        Assert.NotNull(result);
    }

    [Fact]
    public async Task LeagueReadsObservedResponseShape()
    {
        using var requester = new Requester(new OpenDotaSettings(), new RecordingHandler("""{"leagueid":15728,"name":"The International"}"""));
        var endpoint = new LeagueEndpoint(requester);

        var league = await endpoint.GetLeagueAsync(15728);

        Assert.NotNull(league);
        Assert.Equal(15728, league.LeagueId);
    }

    [Fact]
    public async Task LeagueMatchesReadObservedResponseShape()
    {
        using var requester = new Requester(new OpenDotaSettings(), new RecordingHandler("""[{"match_id":7406531302,"radiant_team_name":"Team"}]"""));
        var endpoint = new LeagueEndpoint(requester);

        var matches = await endpoint.GetLeagueMatchesAsync(15728);

        Assert.NotNull(matches);
        Assert.Equal("Team", Assert.Single(matches).RadiantTeamName);
    }


    [Fact]
    public async Task LeagueMatchIdsReadNumbersAndStrings()
    {
        using var requester = new Requester(new OpenDotaSettings(), new RecordingHandler("""[7406531302,"7406482053"]"""));
        var endpoint = new LeagueEndpoint(requester);

        var ids = await endpoint.GetLeagueMatchIdsAsync(15728);

        Assert.Equal(ExpectedLeagueIds, ids);
    }

    [Fact]
    public async Task LeagueTeamsReadObservedResponseShape()
    {
        using var requester = new Requester(new OpenDotaSettings(), new RecordingHandler("""[{"team_id":42}]"""));
        var endpoint = new LeagueEndpoint(requester);

        var teams = await endpoint.GetLeagueTeamsAsync(15728);

        Assert.NotNull(teams);
        Assert.Equal(42, Assert.Single(teams).TeamId);
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

    [Fact]
    public async Task ClientConfigurationSuppliesApiKeyToRequests()
    {
        var handler = new RecordingHandler("[]");
        using var api = new OpenDotaApi(settings => settings.ApiKey = "key&?", handler);

        await api.Search.GetPlayersByNameAsync("player");

        Assert.Equal("?q=player&api_key=key%26%3F", handler.Uri!.Query);
    }

    [Theory]
    [InlineData(null, "")]
    [InlineData(123L, "?less_than_match_id=123")]
    public async Task ParsedMatchesReadArrayAndOptionalCursor(long? cursor, string expectedQuery)
    {
        var handler = new RecordingHandler("""[{"match_id":123},{"match_id":456}]""");
        using var requester = new Requester(new OpenDotaSettings(), handler);
        var endpoint = new ParsedMatchesEndpoint(requester);

        var matches = await endpoint.GetParsedMatchesAsync(cursor);

        Assert.Equal("/api/parsedMatches", handler.Uri!.AbsolutePath);
        Assert.Equal(expectedQuery, handler.Uri.Query);
        Assert.NotNull(matches);
        Assert.Equal([123, 456], matches.Select(match => match.MatchId));
    }

    [Fact]
    public async Task ParseRequestUsesConfiguredJsonOptions()
    {
        var handler = new RecordingHandler("""{"JOB":{"JOBID":123}}""");
        var settings = new OpenDotaSettings
        {
            ApiKey = "key&?",
            JsonSerializerOptions = new System.Text.Json.JsonSerializerOptions { PropertyNameCaseInsensitive = true }
        };
        using var requester = new Requester(settings, handler);
        var endpoint = new RequestEndpoint(requester);

        var request = await endpoint.SubmitNewParseRequestAsync(42);

        Assert.Equal(HttpMethod.Post, handler.Method);
        Assert.Equal("/api/request/42", handler.Uri!.AbsolutePath);
        Assert.Equal("?api_key=key%26%3F", handler.Uri.Query);
        Assert.NotNull(request);
        Assert.Equal(123, request.Job.JobId);
    }

    [Fact]
    public async Task ParseRequestReturnsNullForEmptyResponse()
    {
        var handler = new RecordingHandler(string.Empty);
        using var requester = new Requester(new OpenDotaSettings(), handler);
        var endpoint = new RequestEndpoint(requester);

        var request = await endpoint.SubmitNewParseRequestAsync(42);

        Assert.Null(request);
    }

    [Fact]
    public async Task ParseRequestThrowsForUnsuccessfulResponse()
    {
        var handler = new RecordingHandler("{}", HttpStatusCode.BadRequest);
        using var requester = new Requester(new OpenDotaSettings(), handler);
        var endpoint = new RequestEndpoint(requester);

        var exception = await Assert.ThrowsAsync<HttpRequestException>(() => endpoint.SubmitNewParseRequestAsync(42));

        Assert.Equal(HttpStatusCode.BadRequest, exception.StatusCode);
    }

    private sealed class RecordingHandler(string json, HttpStatusCode statusCode = HttpStatusCode.OK) : HttpMessageHandler
    {
        public Uri? Uri { get; private set; }
        public HttpMethod? Method { get; private set; }

        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            Uri = request.RequestUri;
            Method = request.Method;
            return Task.FromResult(new HttpResponseMessage(statusCode) { Content = new StringContent(json) });
        }
    }
}
