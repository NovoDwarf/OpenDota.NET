namespace OpenDota.NET.Routes.HeroStats.Enums;

/// <summary>
/// The primary attribute of the hero.
/// </summary>
public enum HeroPrimaryAttribute
{
	/// <summary>
	/// None attribute only for internal usage.
	/// </summary>
	[JsonIgnore] None = 0,

	/// <summary>
	/// Agility attribute.
	/// </summary>
	[JsonStringEnumMemberName("agi")] Agility = 1,

	/// <summary>
	/// Intelligence attribute.
	/// </summary>
	[JsonStringEnumMemberName("int")] Intelligence = 2,

	/// <summary>
	/// Strength attribute.
	/// </summary>
	[JsonStringEnumMemberName("str")] Strength = 3,

	/// <summary>
	/// Universal attribute.
	/// </summary>
	[JsonStringEnumMemberName("all")] All = 4,
}