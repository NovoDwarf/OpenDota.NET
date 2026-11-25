using Microsoft.Extensions.DependencyInjection;

namespace OpenDota.NET.Microsoft.DependencyInjection;

/// <summary>Registers the OpenDota client with Microsoft dependency injection.</summary>
public static class ServiceCollectionExtensions
{
    /// <summary>Registers a singleton OpenDota client owned by the service provider.</summary>
    /// <param name="services">The service collection.</param>
    /// <param name="configure">Optional client configuration.</param>
    /// <returns>The service collection.</returns>
    public static IServiceCollection AddOpenDotaApi(this IServiceCollection services, Action<OpenDotaSettings>? configure = null)
    {
        ArgumentNullException.ThrowIfNull(services);
      
        services.AddSingleton<IOpenDotaApi>(_ => new OpenDotaApi(configure));
       
        return services;
    }
}
