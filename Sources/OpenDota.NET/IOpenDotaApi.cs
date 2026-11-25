namespace OpenDotaDotNet;

/// <summary>
/// The OpenDota API provides Dota 2 related data including advanced match data extracted from match replays.
/// </summary>
/// <remarks>
/// Full documentation is available on <see href="https://docs.opendota.com/">OpenDota</see>.
/// You can find data that can be used to convert hero and ability IDs and other information provided by
/// the API from the <see href="https://github.com/odota/dotaconstants">Dota Constants</see> repository.
/// </remarks>
[PublicAPI]
public interface IOpenDotaApi
{
	/// <inheritdoc cref="IBenchmarkEndpoint" />
	public IBenchmarkEndpoint Benchmarks { get; }

	/// <inheritdoc cref="IConstantsEndpoint" />
	public IConstantsEndpoint Constants { get; }

	/// <inheritdoc cref="IDistributionsEndpoint" />
	public IDistributionsEndpoint Distributions { get; }

	/// <inheritdoc cref="IExplorerEndpoint" />
	public IExplorerEndpoint Explorer { get; }

	/// <inheritdoc cref="IFindMatchesEndpoint" />
	public IFindMatchesEndpoint FindMatches { get; }

	/// <inheritdoc cref="IHealthEndpoint" />
	public IHealthEndpoint Health { get; }

	/// <inheritdoc cref="IHeroesEndpoint" />
	public IHeroesEndpoint Heroes { get; }

	/// <inheritdoc cref="IHeroStatsEndpoint" />
	public IHeroStatsEndpoint HeroStats { get; }

	/// <inheritdoc cref="ILeagueEndpoint" />
	public ILeagueEndpoint League { get; }

	/// <inheritdoc cref="ILiveEndpoint" />
	public ILiveEndpoint Live { get; }

	/// <inheritdoc cref="IMatchesEndpoint" />
	public IMatchesEndpoint Matches { get; }

	/// <inheritdoc cref="IMetadataEndpoint" />
	public IMetadataEndpoint Metadata { get; }

	/// <inheritdoc cref="IParsedMatchesEndpoint" />
	public IParsedMatchesEndpoint ParsedMatches { get; }

	/// <inheritdoc cref="IPlayersEndpoint" />
	public IPlayersEndpoint Players { get; }

	/// <inheritdoc cref="IProMatchEndpoint" />
	public IProMatchEndpoint ProMatches { get; }

	/// <inheritdoc cref="IProPlayersEndpoint" />
	public IProPlayersEndpoint ProPlayers { get; }

	/// <inheritdoc cref="IPublicMatchesEndpoint" />
	public IPublicMatchesEndpoint PublicMatches { get; }

	/// <inheritdoc cref="IRankingsEndpoint" />
	public IRankingsEndpoint Rankings { get; }

	/// <inheritdoc cref="IRecordsEndpoint" />
	public IRecordsEndpoint Records { get; }

	/// <inheritdoc cref="IRequestEndpoint" />
	public IRequestEndpoint Request { get; }

	/// <inheritdoc cref="IScenariosEndpoint" />
	public IScenariosEndpoint Scenarios { get; }

	/// <inheritdoc cref="ISchemaEndpoint" />
	public ISchemaEndpoint Schema { get; }

	/// <inheritdoc cref="ISearchEndpoint" />
	public ISearchEndpoint Search { get; }
	
	/// <inheritdoc cref="ITeamsEndpoint" />
	///
	public ITeamsEndpoint Teams { get; }
}