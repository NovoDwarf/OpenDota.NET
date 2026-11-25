using JsonSerializer = System.Text.Json.JsonSerializer;
using OpenDotaDotNet.Routes.Health.Models;

namespace OpenDota.NET.Tests;

public class ApiResponseDeserializationTests
{
    [Fact]
    public void MissingFieldsUseExplicitDefaults()
    {
        var options = new OpenDotaSettings().JsonSerializerOptions;
        var purchase = JsonSerializer.Deserialize<OpenDotaDotNet.Routes.Matches.Models.PurchaseLog>("{}", options);
        var profile = JsonSerializer.Deserialize<OpenDotaDotNet.Routes.Players.Models.Profile>("{}", options);
        var state = JsonSerializer.Deserialize<OpenDotaDotNet.Routes.Request.Models.ParseRequestState>("{}", options);
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
        var mode = JsonSerializer.Deserialize<OpenDotaDotNet.Enums.GameMode>(json, options);
        var lobby = JsonSerializer.Deserialize<OpenDotaDotNet.Enums.LobbyType>(json, options);
        var role = JsonSerializer.Deserialize<OpenDotaDotNet.Enums.LaneRole>(json, options);

        Assert.Equal(expected, (long)mode);
        Assert.Equal(expected, (long)lobby);
        Assert.Equal(expected, (long)role);
        Assert.Equal(expected.ToString(System.Globalization.CultureInfo.InvariantCulture), JsonSerializer.Serialize(mode, options));
    }

    [Fact]
    public void RecentMatchAcceptsNullLaneRole()
    {
        var match = JsonSerializer.Deserialize<PlayerRecentMatch>("""{"lane_role":null}""", new OpenDotaSettings().JsonSerializerOptions);

        Assert.NotNull(match);
        Assert.Null(match.LaneRole);
    }

    [Fact]
    public void LongConvertersAcceptLargeStringIds()
    {
        var options = new OpenDotaSettings().JsonSerializerOptions;
        
        Assert.Equal(7406482053, JsonSerializer.Deserialize<long>("\"7406482053\"", options));
        Assert.Equal(7406482053, JsonSerializer.Deserialize<long?>("\"7406482053\"", options));
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
