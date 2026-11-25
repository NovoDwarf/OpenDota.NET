namespace OpenDotaDotNet.Routes.Scenarios.Models;

/// <summary>
/// Represents a team scenario.
/// </summary>
[UsedImplicitly]
public class TeamScenario
{
	/// <summary>
	/// Gets the scenario's name or description.
	/// </summary>
	[JsonPropertyName("scenario")]
	public Scenario Scenario { get; [UsedImplicitly] init; }

	/// <summary>
	/// Gets a value indicating whether Radiant executed this scenario.
	/// </summary>
	[JsonPropertyName("is_radiant")]
	public bool IsRadiant { get; [UsedImplicitly] init; }

	/// <summary>
	/// Gets region the game was played in.
	/// </summary>
	[JsonPropertyName("region")]
	public int Region { get; [UsedImplicitly] init; }

	/// <summary>
	/// Gets the number of games where this scenario occurred.
	/// </summary>
	[JsonPropertyName("games")]
	public int Games { get; [UsedImplicitly] init; }

	/// <summary>
	/// Gets the number of games won where this scenario occured.
	/// </summary>
	[JsonPropertyName("wins")]
	public int Wins { get; [UsedImplicitly] init; }
}