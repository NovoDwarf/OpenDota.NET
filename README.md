# OpenDota.NET

A .NET wrapper for the [OpenDota API](https://docs.opendota.com/). Game data is available from [dotaconstants](https://github.com/odota/dotaconstants).

[![NuGet version](https://badge.fury.io/nu/OpenDota.NET.Remade.svg)](https://www.nuget.org/packages/OpenDota.NET.Remade)

Targets .NET 9, .NET 10 and .NET 11.

## Usage

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

## Dependency injection

Install `OpenDota.NET.Remade.Microsoft.DependencyInjection` to register a singleton client:

```csharp
using OpenDota.NET.Microsoft.DependencyInjection;

services.AddOpenDotaApi(settings =>
{
    settings.ApiKey = Environment.GetEnvironmentVariable("OPENDOTA_API_KEY");
});
```

Resolve `IOpenDotaApi` from the service provider. The provider disposes the client.

## Tests

The `Tests` directory contains contract, integration and dependency-injection test projects. For example:

```sh
dotnet run --project Tests/OpenDota.NET.Tests -f net9.0
dotnet run --project Tests/OpenDota.NET.Microsoft.DependencyInjection.Tests -f net9.0
dotnet run --project Tests/OpenDota.NET.IntegrationTests -f net9.0 -- -maxThreads 2
```

Integration tests call the live OpenDota API and depend on its availability and rate limits. See [CHANGELOG.md](CHANGELOG.md) for breaking changes.
