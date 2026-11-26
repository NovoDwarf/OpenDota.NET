using OpenDota.NET.Routes.FindMatches.Models;
using OpenDota.NET.Utilities;

namespace OpenDota.NET.Routes.FindMatches;

/// <inheritdoc />
public class FindMatchesEndpoint : IFindMatchesEndpoint
{
	private readonly Requester _requester;

	/// <summary>Creates an instance of <see cref="FindMatchesEndpoint" />.</summary>
	/// <param name="requester">The requester used to send API requests.</param>
	public FindMatchesEndpoint(Requester requester)
	{
		_requester = requester;
	}

	/// <inheritdoc />
	public string Endpoint => "findMatches";

	/// <inheritdoc />
	public string Url => new Uri(baseUri: _requester.BaseAddress, relativeUri: Endpoint).AbsoluteUri;


	/// <inheritdoc />
	public Task<List<FindMatch>?> FindMatchesByHeroesPlayedAsync(
		List<int>? teamA = null,
		List<int>? teamB = null)
	{
		return _requester.GetResponseAsync<List<FindMatch>>(
			url: Endpoint,
			queryParameters: GetArguments(teamA: teamA, teamB: teamB));
	}

	private List<string> GetArguments(
		List<int>? teamA = null,
		List<int>? teamB = null)
	{
		var addedArguments = new List<string>();

		if (teamA != null)
			addedArguments.AddRange(teamA.Select(heroId => $"teamA={heroId}"));

		if (teamB != null)
			addedArguments.AddRange(teamB.Select(heroId => $"teamB={heroId}"));

		return addedArguments;
	}
}