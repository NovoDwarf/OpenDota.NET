namespace OpenDota.NET.Routes.Metadata.Models;

/// <summary>
/// Represents the user.
/// </summary>
[PublicAPI]
public class User
{
	/// <summary>
	/// Gets the account identifier.
	/// </summary>
	[JsonPropertyName("account_id")]
	public int AccountId { get; init; }
}