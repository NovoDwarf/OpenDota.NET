using Microsoft.Extensions.DependencyInjection;
using OpenDota.NET.Microsoft.DependencyInjection;

namespace OpenDota.NET.Microsoft.DependencyInjection.Tests;

public class DependencyInjectionTests
{
    [Fact]
    public void RegisterClientAsSingletonWithConfiguration()
    {
        var services = new ServiceCollection();
        string? configuredKey = null;

        services.AddOpenDotaApi(settings =>
        {
            settings.ApiKey = "test-key";
            configuredKey = settings.ApiKey;
        });

        using var provider = services.BuildServiceProvider();

        var client = provider.GetRequiredService<IOpenDotaApi>();
        var sameClient = provider.GetRequiredService<IOpenDotaApi>();

        Assert.Same(client, sameClient);
        Assert.Equal("test-key", configuredKey);
    }
    [Fact]
    public async Task ProviderDisposesClient()
    {
        var services = new ServiceCollection();

        services.AddOpenDotaApi();

        var provider = services.BuildServiceProvider();
        var client = provider.GetRequiredService<IOpenDotaApi>();

        await provider.DisposeAsync();

        await Assert.ThrowsAsync<ObjectDisposedException>(() => client.Search.GetPlayersByNameAsync("player"));
    }
}
