namespace OpenDota.NET.Routes.ProPlayers;

/// <inheritdoc />
[UsedImplicitly]
public class ProPlayersEndpoint : IProPlayersEndpoint
{
	private readonly Requester _requester;

	/// <summary>Creates the endpoint.</summary>
	/// <param name="requester">The HTTP requester used by the endpoint.</param>
	public ProPlayersEndpoint(Requester requester)
	{
		_requester = requester;
	}

	/// <inheritdoc />
	public string Endpoint => "proPlayers";

	/// <inheritdoc />
	public string Url => new Uri(baseUri: _requester.BaseAddress, relativeUri: Endpoint).AbsoluteUri;


	/// <inheritdoc />
	public Task<List<ProPlayer>?> GetProPlayersAsync()
	{
		return _requester.GetResponseAsync<List<ProPlayer>>(Endpoint);
	}
}