# OpenDota.NET

## .NET wrapper for the OpenDota API

The OpenDota API provides Dota 2 related data including advanced match data extracted from match replays.

Full documentation is available on [OpenDota](https://docs.opendota.com/).

Some of the data types can be found in the [dotaconstants](https://github.com/odota/dotaconstants) repository.

[![NuGet version](https://badge.fury.io/nu/OpenDota.NET.Remade.svg)](https://badge.fury.io/nu/OpenDota.NET.Remade/)

## Example

```csharp
using var openDota = new OpenDotaApi();
var matchDetails = await openDota.Matches.GetMatchByIdAsync(4986133311);

Console.WriteLine($"{matchDetails.RadiantTeam.Name} vs {matchDetails.DireTeam.Name} - {matchDetails.RadiantScore}:{matchDetails.DireScore}.");
Console.WriteLine($"Duration of game: {TimeSpan.FromSeconds(matchDetails.Duration):mm\\:ss}.");
```
## Configuration

```csharp
using var openDota = new OpenDotaApi(settings =>
{
    settings.ApiKey = Environment.GetEnvironmentVariable("OPENDOTA_API_KEY");
    // settings.Proxy = new WebProxy("http://localhost:8080");
});

var players = await openDota.Search.GetPlayersByNameAsync("player name");
```

The API key is optional and is sent with both GET and POST requests. Do not put keys in source control. Dispose `OpenDotaApi` when finished. Query values are encoded by the client; pass raw strings, including SQL queries to the Explorer endpoint.

Public match rank filters use `minRank` and `maxRank`. `Players.GetTopPlayersAsync(turbo: true)` requests turbo rankings. League endpoints include league details, matches, match IDs, and teams. Top-player entries are returned as JSON objects so all fields from the API are available. League response shapes and numeric match IDs follow observed API responses; the OpenAPI specification describes some of these differently.

## Tests

`dotnet run --project Tests/OpenDota.NET.Tests --framework net9.0 -- -maxThreads 2` runs the xUnit suite. Endpoint tests call the live API and can fail due to rate limiting, unavailable services, or changing data. Contract tests do not call the network:

```sh
dotnet run --project Tests/OpenDota.NET.Tests --framework net9.0 -- -class OpenDota.NET.Tests.RequestContractTests -class OpenDota.NET.Tests.ApiResponseDeserializationTests
```

With SDK 10 or later, the current test project cannot run through `dotnet test` without changing its test-platform configuration. The built-in xUnit runner above is supported. The projects target .NET 9, .NET 10, and .NET 11. Building requires a .NET 11 SDK; running each target requires the corresponding runtime.

Game mode, lobby type, and lane role fields use the `GameMode`, `LobbyType`, and `LaneRole` enums. Values are serialized as numbers; unrecognized numeric values are preserved for forward compatibility. The enum members reflect the current [dotaconstants game modes](https://github.com/odota/dotaconstants/blob/master/json/game_mode.json) and [lobby types](https://github.com/odota/dotaconstants/blob/master/json/lobby_type.json).

Models initialize non-nullable strings, collections, nested objects, and non-nullable timestamps to empty values, new instances, or `DateTimeOffset.MinValue` when a field is absent. Nullable properties remain `null` when absent; a JSON `null` is not converted to an empty value by these initializers.

Each endpoint exposes its relative `Endpoint` path and its absolute `Url` without query parameters or API credentials:

```csharp
Console.WriteLine(openDota.Heroes.Endpoint); // heroes
Console.WriteLine(openDota.Heroes.Url);      // https://api.opendota.com/api/heroes
```

The URL is the endpoint group's base address. Individual methods may use additional path segments or a separate route (for example, `Players.GetTopPlayersAsync` uses `/topPlayers`).

## CI and releases

CI builds all target frameworks and runs the complete suite on .NET 9. To avoid exhausting OpenDota rate limits, .NET 10 and .NET 11 run the offline contract tests. Test reports are uploaded as workflow artifacts. Endpoint tests require a reachable OpenDota API and are subject to its rate limits.

A push of a release tag such as `v5.0.0` or `v5.0.0-rc.1` runs CI and packs the tagged version before publishing the same artifact to nuget.org and GitHub Packages. NuGet publishing uses trusted publishing via `NuGet/login`; configure a nuget.org trusted publisher for this repository, the `release.yml` workflow and the `release` environment, and set the GitHub `NUGET_USER` secret to the NuGet account name. GitHub Packages requires the repository's workflow token to have package write access. Environment protection rules, if configured, apply to the publish job.
