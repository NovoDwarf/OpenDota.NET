namespace OpenDotaDotNet;

/// <summary>
/// Represents the OpenDota.NET settings.
/// </summary>
public class OpenDotaSettings
{
	/// <summary>
	/// The OpenDota API key. If you have API key, set this property.
	/// </summary>
	public string? ApiKey { get; init; }

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
			new StringToBooleanNull(), new StringToDoubleNull(),
			new StringToIntNull(),
			new StringToLongNull(),
			new StringToDouble(),
			new StringToInt(),
			new StringToLong(),
			new StringToEnumList<HeroRole>(),
			new StringToEnum<HeroPrimaryAttribute>(),
			new StringToEnum<HeroAttackType>(),
			new StringToEnum<Tier>(),
			new StringToEnum<Scenario>()
		},
		IncludeFields = true,
	};
}