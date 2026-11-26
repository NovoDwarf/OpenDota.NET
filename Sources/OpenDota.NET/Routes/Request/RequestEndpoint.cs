using OpenDota.NET.Routes.Request.Models;
using OpenDota.NET.Utilities;

namespace OpenDota.NET.Routes.Request;

/// <inheritdoc />
[UsedImplicitly]
public class RequestEndpoint : IRequestEndpoint
{
	private readonly Requester _requester;

	/// <summary>Creates an instance of <see cref="RequestEndpoint" />.</summary>
	/// <param name="requester">The requester used to send API requests.</param>
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
	public Task<ParseRequest?> SubmitNewParseRequestAsync(long matchId)
	{
		return _requester.PostResponseAsync<ParseRequest>($"{Endpoint}/{matchId}");
	}
}