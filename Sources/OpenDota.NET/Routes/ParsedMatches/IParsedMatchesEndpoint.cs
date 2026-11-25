namespace OpenDota.NET.Routes.ParsedMatches;

/// <summary>
/// Represents a parsed matches endpoint.
/// </summary>
[PublicAPI]
public interface IParsedMatchesEndpoint
{
	/// <summary>The base path of this endpoint, relative to the API address.</summary>
	public string Endpoint { get; }

	/// <summary>The absolute URL of the endpoint, without query parameters.</summary>
	public string Url { get; }

	/// <summary>Gets parsed matches before the specified match ID.</summary>
	/// <param name="lessThenMatchId">Exclusive upper bound for the match ID.</param>
	/// <returns>The parsed matches response.</returns>
	public Task<ParsedMatch?> GetParsedMatchesAsync(long lessThenMatchId);
}