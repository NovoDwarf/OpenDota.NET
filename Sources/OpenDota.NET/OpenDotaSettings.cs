using OpenDota.NET.Converters;
using OpenDota.NET.Routes.HeroStats.Enums;
using OpenDota.NET.Routes.Leagues.Enums;
using OpenDota.NET.Routes.Scenarios.Enums;

namespace OpenDota.NET;

/// <summary>
/// Represents the OpenDota.NET settings.
/// </summary>
public class OpenDotaSettings
{
	/// <summary>
	/// The OpenDota API key. If you have API key, set this property.
	/// </summary>
	public string? ApiKey { get; set; }

	/// <summary>
	/// The proxy. If you want to use own proxy, set this property.
	/// </summary>
	public IWebProxy? Proxy { get; set; }

	/// <summary>
	/// The JSON serializer options. If you want to use own options, set this property.
	/// </summary>
	public JsonSerializerOptions? JsonSerializerOptions { get; set; } = new(JsonSerializerOptions.Web)
	{
		Converters =
		{
			new StringToBooleanNull(),
			new JsonStringEnumConverter<HeroRole>(),
			new JsonStringEnumConverter<HeroPrimaryAttribute>(),
			new JsonStringEnumConverter<HeroAttackType>(),
			new JsonStringEnumConverter<Tier>(),
			new JsonStringEnumConverter<Scenario>()
		},
		IncludeFields = true,
	};
}