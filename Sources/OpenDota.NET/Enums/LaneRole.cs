namespace OpenDota.NET.Enums;

/// <summary>
/// Represents a lane roles from Dota 2.
/// </summary>
[JsonConverter(typeof(NumericEnumConverter<LaneRole>))]
public enum LaneRole
{
	/// <summary>
	/// None only for internal use.
	/// </summary>
	None = 0,

	/// <summary>
	/// Safe lane role.
	/// </summary>
	Safe = 1,

	/// <summary>
	/// Mid lane role.
	/// </summary>
	Mid = 2,

	/// <summary>
	/// Offlane role.
	/// </summary>
	Offlane = 3,

	/// <summary>
	/// Jungle role.
	/// </summary>
	Jungle = 4
}