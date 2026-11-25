namespace OpenDotaDotNet.Routes.Request;

/// <inheritdoc />
[UsedImplicitly]
public class RequestEndpoint : IRequestEndpoint
{
	private readonly Requester _requester;

	/// <inheritdoc />
	public RequestEndpoint(Requester requester)
	{
		_requester = requester;
	}

	/// <inheritdoc />
	public string Endpoint => "request";

	/// <inheritdoc />
	public string Url => new Uri(baseUri: _requester.BaseAddress, relativeUri: Endpoint).AbsoluteUri;


	/// <inheritdoc />
	public Task<ParseRequestState?> GetParseRequestStateAsync(long jobId)
	{
		return _requester.GetResponseAsync<ParseRequestState>($"{Endpoint}/{jobId}");
	}

	/// <inheritdoc />
	public async Task<ParseRequest?> SubmitNewParseRequestAsync(long matchId)
	{
		using var response = await _requester.PostRequestAsync($"{Endpoint}/{matchId}");

		response.EnsureSuccessStatusCode();

		var content = await response.Content.ReadAsStringAsync();

		// TODO: json to class

		var parseRequest = JsonSerializer.Deserialize<ParseRequest>(content);

		return parseRequest;
	}
}