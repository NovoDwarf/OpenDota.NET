# OpenDota.NET Remade

A .NET client for the [OpenDota API](https://docs.opendota.com/). It provides access to Dota 2 match, player, hero and
other game data.

Targets .NET 9, .NET 10 and .NET 11.

```sh
dotnet add package OpenDota.NET.Remade
```

```csharp
using OpenDota.NET;

using var api = new OpenDotaApi(settings =>
{
    settings.ApiKey = Environment.GetEnvironmentVariable("OPENDOTA_API_KEY");
});

var match = await api.Matches.GetMatchByIdAsync(4986133311);
if (match is not null)
{
    Console.WriteLine($"{match.RadiantTeam.Name} vs {match.DireTeam.Name}: {match.RadiantScore}:{match.DireScore}");
}
```

The API key is optional. Dispose the client when it is no longer needed.

For dependency injection,
install [OpenDota.NET.Remade.Microsoft.DependencyInjection](https://www.nuget.org/packages/OpenDota.NET.Remade.Microsoft.DependencyInjection).
See the [repository](https://github.com/NovoDwarf/OpenDota.NET)
and [changelog](https://github.com/NovoDwarf/OpenDota.NET/blob/master/CHANGELOG.md) for details and breaking changes.
