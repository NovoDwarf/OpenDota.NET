# OpenDota.NET Microsoft Dependency Injection

Microsoft.Extensions.DependencyInjection integration
for [OpenDota.NET Remade](https://www.nuget.org/packages/OpenDota.NET.Remade).

Targets .NET 9, .NET 10 and .NET 11.

```sh
dotnet add package OpenDota.NET.Remade.Microsoft.DependencyInjection
```

```csharp
using OpenDota.NET.Microsoft.DependencyInjection;

services.AddOpenDotaApi(settings =>
{
    settings.ApiKey = Environment.GetEnvironmentVariable("OPENDOTA_API_KEY");
});
```

Resolve `IOpenDotaApi` from the service provider. The client is registered as a singleton and disposed by the provider.
The API key is optional.

See the [repository](https://github.com/NovoDwarf/OpenDota.NET)
and [changelog](https://github.com/NovoDwarf/OpenDota.NET/blob/master/CHANGELOG.md) for details and breaking changes.
