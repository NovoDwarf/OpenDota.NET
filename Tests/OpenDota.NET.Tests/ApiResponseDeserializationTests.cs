using OpenDota.NET.Enums;
using OpenDota.NET.Routes.Health.Models;
using OpenDota.NET.Routes.Leagues.Models;
using OpenDota.NET.Routes.Matches.Models;
using OpenDota.NET.Routes.Players.Models;
using OpenDota.NET.Routes.PublicMatches.Models;
using OpenDota.NET.Routes.Request.Models;
using OpenDota.NET.Routes.Search.Models;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace OpenDota.NET.Tests;

public class ApiResponseDeserializationTests
{
    [Fact]
    public void MissingFieldsUseExplicitDefaults()
    {
        var options = new OpenDotaSettings().JsonSerializerOptions;

        var purchase = JsonSerializer.Deserialize<PurchaseLog>("{}", options);
        var profile = JsonSerializer.Deserialize<Profile>("{}", options);
        var state = JsonSerializer.Deserialize<ParseRequestState>("{}", options);
        var match = JsonSerializer.Deserialize<PublicMatch>("{}", options);

        Assert.Equal(string.Empty, purchase!.Key);
        Assert.Equal(string.Empty, profile!.LocCountryCode);
        Assert.Null(profile.LastLogin);
        Assert.Equal(DateTimeOffset.MinValue, state!.Timestamp);
        Assert.NotNull(state.Data);
        Assert.Empty(match!.RadiantTeam);
        Assert.Empty(match.DireTeam);
    }

    [Fact]
    public void MatchAndLeagueResponsesUseSameLeagueContract()
    {
        const string json = """{"leagueid":15728,"ticket":null,"banner":"banner","tier":"premium","name":"The International"}""";
        var options = new OpenDotaSettings().JsonSerializerOptions;

        var league = JsonSerializer.Deserialize<League>(json, options);
        var match = JsonSerializer.Deserialize<Match>($$"""{"league":{{json}}}""", options);

        Assert.NotNull(league);
        Assert.NotNull(match);
        Assert.Equal(league.LeagueId, match.League.LeagueId);
        Assert.Null(match.League.Ticket);
        Assert.Equal(league.Banner, match.League.Banner);
        Assert.Equal(league.Tier, match.League.Tier);
        Assert.Equal(league.Name, match.League.Name);
    }

    [Fact]
    public void PlayerProAcceptsNullableFields()
    {
        const string json = """{"is_locked":null,"is_pro":null,"team_id":null,"fantasy_role":null}""";

        var player = JsonSerializer.Deserialize<PlayerPro>(json, new OpenDotaSettings().JsonSerializerOptions);

        Assert.NotNull(player);
        Assert.Null(player.IsLocked);
        Assert.Null(player.IsPro);
        Assert.Null(player.TeamId);
        Assert.Null(player.FantasyRole);
    }

    [Theory]
    [InlineData("sml")]
    [InlineData("similarity")]
    public void SearchResponseReadsSimilarity(string field)
    {
        var player = JsonSerializer.Deserialize<PlayerResponse>($$"""{"{{field}}":0.75}""", new OpenDotaSettings().JsonSerializerOptions);

        Assert.NotNull(player);
        Assert.Equal(0.75, player.Similarity);
    }

    [Theory]
    [InlineData("23", 23)]
    [InlineData("\"23\"", 23)]
    [InlineData("999", 999)]
    [InlineData("-1", -1)]
    public void NumericEnumsPreserveApiValues(string json, long expected)
    {
        var options = new OpenDotaSettings().JsonSerializerOptions;

        var mode = JsonSerializer.Deserialize<GameMode>(json, options);
        var lobby = JsonSerializer.Deserialize<LobbyType>(json, options);
        var role = JsonSerializer.Deserialize<LaneRole>(json, options);
        var serializedMode = JsonSerializer.Serialize(mode, options);

        Assert.Equal(expected, (long)mode);
        Assert.Equal(expected, (long)lobby);
        Assert.Equal(expected, (long)role);
        Assert.Equal(expected.ToString(System.Globalization.CultureInfo.InvariantCulture), serializedMode);
    }

    [Fact]
    public void RecentMatchAcceptsNullLaneRole()
    {
        var match = JsonSerializer.Deserialize<PlayerRecentMatch>("""{"lane_role":null}""", new OpenDotaSettings().JsonSerializerOptions);

        Assert.NotNull(match);
        Assert.Null(match.LaneRole);
    }

    [Fact]
    public void NumericStringsAcceptLargeIds()
    {
        var options = new OpenDotaSettings().JsonSerializerOptions;

        var value = JsonSerializer.Deserialize<long>("\"7406482053\"", options);
        var nullableValue = JsonSerializer.Deserialize<long?>("\"7406482053\"", options);

        Assert.Equal(7406482053, value);
        Assert.Equal(7406482053, nullableValue);
    }

    [Fact]
    public void NumericStringsAndNullValuesAreSupported()
    {
        var options = new OpenDotaSettings().JsonSerializerOptions;

        var integer = JsonSerializer.Deserialize<int>("\"42\"", options);
        var number = JsonSerializer.Deserialize<double?>("\"12.5\"", options);
        var missing = JsonSerializer.Deserialize<long?>("null", options);

        Assert.Equal(42, integer);
        Assert.Equal(12.5, number);
        Assert.Null(missing);
    }

    [Fact]
    public void InvalidNumberIsNotSilentlyConverted()
    {
        var options = new OpenDotaSettings().JsonSerializerOptions;

        var exception = Record.Exception(() => JsonSerializer.Deserialize<int>("\"invalid\"", options));

        Assert.IsType<System.Text.Json.JsonException>(exception);
    }

    [Fact]
    public void StringEnumsUseApiNamesForReadingAndWriting()
    {
        var options = new OpenDotaSettings().JsonSerializerOptions;

        var attribute = JsonSerializer.Deserialize<OpenDota.NET.Routes.HeroStats.Enums.HeroPrimaryAttribute>("\"agi\"", options);
        var scenario = JsonSerializer.Deserialize<OpenDota.NET.Routes.Scenarios.Enums.Scenario>("\"courier_kill\"", options);
        var roles = JsonSerializer.Deserialize<List<OpenDota.NET.Routes.HeroStats.Enums.HeroRole>>("""["Carry","Support"]""", options);
        var json = JsonSerializer.Serialize(scenario, options);

        Assert.Equal(OpenDota.NET.Routes.HeroStats.Enums.HeroPrimaryAttribute.Agility, attribute);
        Assert.Equal(OpenDota.NET.Routes.Scenarios.Enums.Scenario.CourierKill, scenario);
        Assert.Equal(new[] { OpenDota.NET.Routes.HeroStats.Enums.HeroRole.Carry, OpenDota.NET.Routes.HeroStats.Enums.HeroRole.Support }, roles);
        Assert.Equal("\"courier_kill\"", json);
    }

    [Fact]
    public void ApiResponsesPreserveNullableNumbersAndScenarioNames()
    {
        var options = new OpenDotaSettings().JsonSerializerOptions;

        var live = JsonSerializer.Deserialize<OpenDota.NET.Routes.Live.Models.LiveGamePlayer>("""{"fantasy_role":null,"team_id":null}""", options);
        var pro = JsonSerializer.Deserialize<OpenDota.NET.Routes.ProPlayers.Models.ProPlayer>("""{"cheese":null,"fantasy_role":null,"team_id":null}""", options);
        var match = JsonSerializer.Deserialize<PlayerMatch>("""{"version":null,"party_size":null,"average_rank":null,"hero_variant":null}""", options);
        var recent = JsonSerializer.Deserialize<PlayerRecentMatch>("""{"lane":null,"party_size":null}""", options);
        var record = JsonSerializer.Deserialize<OpenDota.NET.Routes.Records.Models.Record>("""{"hero_id":null}""", options);
        var scenarios = JsonSerializer.Deserialize<OpenDota.NET.Routes.Metadata.Models.Scenarios>("""{"teamScenariosQueryParams":["courier_kill","first_blood"]}""", options);

        Assert.NotNull(live);
        Assert.Null(live.FantasyRole);
        Assert.Null(live.TeamId);
        Assert.NotNull(pro);
        Assert.Null(pro.Cheese);
        Assert.Null(pro.FantasyRole);
        Assert.Null(pro.TeamId);
        Assert.NotNull(match);
        Assert.Null(match.Version);
        Assert.Null(match.PartySize);
        Assert.Null(match.AverageRank);
        Assert.Null(match.HeroVariant);
        Assert.NotNull(recent);
        Assert.Null(recent.Lane);
        Assert.Null(recent.PartySize);
        Assert.NotNull(record);
        Assert.Null(record.HeroId);
        Assert.NotNull(scenarios);
        Assert.Equal(new[] { "courier_kill", "first_blood" }, scenarios.TeamScenariosQueryParams);
    }

    [Fact]
    public void HealthResponseReadsLimit()
    {
        var usage = JsonSerializer.Deserialize<ServiceUsage>("""{"metric":42,"limit":100,"timestamp":123}""");

        Assert.NotNull(usage);
        Assert.Equal(100, usage.Limit);
        Assert.Equal(42, usage.Metric);
        Assert.Equal(123, usage.Timestamp);
    }
}
