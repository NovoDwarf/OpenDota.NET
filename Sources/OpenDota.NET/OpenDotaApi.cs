using OpenDota.NET.Routes.Benchmarks;
using OpenDota.NET.Routes.Constants;
using OpenDota.NET.Routes.Distributions;
using OpenDota.NET.Routes.Explorer;
using OpenDota.NET.Routes.FindMatches;
using OpenDota.NET.Routes.Health;
using OpenDota.NET.Routes.Heroes;
using OpenDota.NET.Routes.HeroStats;
using OpenDota.NET.Routes.Leagues;
using OpenDota.NET.Routes.Live;
using OpenDota.NET.Routes.Matches;
using OpenDota.NET.Routes.Metadata;
using OpenDota.NET.Routes.ParsedMatches;
using OpenDota.NET.Routes.Players;
using OpenDota.NET.Routes.ProMatches;
using OpenDota.NET.Routes.ProPlayers;
using OpenDota.NET.Routes.PublicMatches;
using OpenDota.NET.Routes.Rankings;
using OpenDota.NET.Routes.Records;
using OpenDota.NET.Routes.Request;
using OpenDota.NET.Routes.Scenarios;
using OpenDota.NET.Routes.Schema;
using OpenDota.NET.Routes.Search;
using OpenDota.NET.Routes.Teams;
using OpenDota.NET.Utilities;

namespace OpenDota.NET;

/// <inheritdoc cref="IOpenDotaApi" />
public sealed class OpenDotaApi : IOpenDotaApi, IDisposable
{
	private readonly Requester _requester;

	/// <summary>
	/// Creates new instance of <see cref="OpenDotaApi"/>
	/// </summary>
	/// <param name="configure">Action to configure <see cref="OpenDotaSettings"/></param>
	public OpenDotaApi(Action<OpenDotaSettings>? configure = null)
		: this(configure: configure, handler: null)
	{
	}

	internal OpenDotaApi(Action<OpenDotaSettings>? configure, HttpMessageHandler? handler)
	{
		var settings = new OpenDotaSettings();

		configure?.Invoke(settings);

		var request = new Requester(settings: settings, handler: handler);

		_requester = request;

		Matches = new MatchesEndpoint(request);
		Players = new PlayersEndpoint(request);
		ProPlayers = new ProPlayersEndpoint(request);
		ProMatches = new ProMatchesEndpoint(request);
		PublicMatches = new PublicMatchesEndpoint(request);
		ParsedMatches = new ParsedMatchesEndpoint(request);
		Explorer = new ExplorerEndpoint(request);
		Metadata = new MetadataEndpoint(request);
		Distributions = new DistributionsEndpoint(request);
		Search = new SearchEndpoint(request);
		Rankings = new RankingsEndpoint(request);
		Benchmarks = new BenchmarksEndpoint(request);
		Health = new HealthEndpoint(request);
		Request = new RequestEndpoint(request);
		FindMatches = new FindMatchesEndpoint(request);
		Heroes = new HeroesEndpoint(request);
		HeroStats = new HeroStatsEndpoint(request);
		League = new LeagueEndpoint(request);
		Teams = new TeamsEndpoint(request);
		Records = new RecordsEndpoint(request);
		Live = new LiveEndpoint(request);
		Scenarios = new ScenariosEndpoint(request);
		Schema = new SchemaEndpoint(request);
		Constants = new ConstantsEndpoint(request);
	}

	/// <summary>Releases the HTTP resources owned by this client.</summary>
	public void Dispose()
	{
		_requester.Dispose();
	}

	/// <inheritdoc />
	public IBenchmarkEndpoint Benchmarks { get; }

	/// <inheritdoc />
	public IConstantsEndpoint Constants { get; }

	/// <inheritdoc />
	public IDistributionsEndpoint Distributions { get; }

	/// <inheritdoc />
	public IExplorerEndpoint Explorer { get; }

	/// <inheritdoc />
	public IFindMatchesEndpoint FindMatches { get; }

	/// <inheritdoc />
	public IHealthEndpoint Health { get; }

	/// <inheritdoc />
	public IHeroesEndpoint Heroes { get; }

	/// <inheritdoc />
	public IHeroStatsEndpoint HeroStats { get; }

	/// <inheritdoc />
	public ILeagueEndpoint League { get; }

	/// <inheritdoc />
	public ILiveEndpoint Live { get; }

	/// <inheritdoc />
	public IMatchesEndpoint Matches { get; }

	/// <inheritdoc />
	public IMetadataEndpoint Metadata { get; }

	/// <inheritdoc />
	public IParsedMatchesEndpoint ParsedMatches { get; }

	/// <inheritdoc />
	public IPlayersEndpoint Players { get; }

	/// <inheritdoc />
	public IProMatchEndpoint ProMatches { get; }

	/// <inheritdoc />
	public IProPlayersEndpoint ProPlayers { get; }
	/// <inheritdoc />
	public IPublicMatchesEndpoint PublicMatches { get; }
	/// <inheritdoc />
	public IRankingsEndpoint Rankings { get; }

	/// <inheritdoc />
	public IRecordsEndpoint Records { get; }

	/// <inheritdoc />
	public IRequestEndpoint Request { get; }

	/// <inheritdoc />
	public IScenariosEndpoint Scenarios { get; }

	/// <inheritdoc />
	public ISchemaEndpoint Schema { get; }

	/// <inheritdoc />
	public ISearchEndpoint Search { get; }

	/// <inheritdoc />
	public ITeamsEndpoint Teams { get; }
}