namespace OpenDota.NET.Routes.HeroStats.Enums;

/// <summary>
/// The attack type of the hero.
/// </summary>
public enum HeroAttackType
{
	/// <summary>
	/// None attack type only for internal usage.
	/// </summary>
	[JsonIgnore] None = 0,

	/// <summary>
	/// The melee attack type.
	/// </summary>
	[JsonStringEnumMemberName("Melee")] Melee = 1,

	/// <summary>
	/// The ranged attack type.
	/// </summary>
	[JsonStringEnumMemberName("Ranged")] Ranged = 2,
}