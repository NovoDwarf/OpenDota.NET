namespace OpenDota.NET.Routes.Scenarios.Enums;

/// <summary>
/// Represents a scenario
/// </summary>
public enum Scenario
{
	/// <summary>
	/// No scenario only for internal usage
	/// </summary>
	[JsonIgnore]
	[UsedImplicitly]
	None = 0,

	/// <summary>
	/// Courier kill
	/// </summary>
	[JsonStringEnumMemberName("courier_kill")]
	[UsedImplicitly]
	CourierKill = 1,

	/// <summary>
	/// First blood
	/// </summary>
	[JsonStringEnumMemberName("first_blood")]
	[UsedImplicitly]
	FirstBlood = 2,

	/// <summary>
	/// Neg chat 1 min
	/// </summary>
	[JsonStringEnumMemberName("neg_chat_1min")]
	[UsedImplicitly]
	NegChat1Min = 3,

	/// <summary>
	/// Pos chat 1 min
	/// </summary>
	[JsonStringEnumMemberName("pos_chat_1min")]
	[UsedImplicitly]
	PosChat1Min = 4
}