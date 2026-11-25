using OpenDota.NET.Routes.Request.Models;

namespace OpenDota.NET.Routes.Request;

/// <summary>
/// Request endpoint.
/// </summary>
[PublicAPI]
public interface IRequestEndpoint
{
	/// <summary>The base path of this endpoint, relative to the API address.</summary>
	public string Endpoint { get; }

	/// <summary>The absolute URL of the endpoint, without query parameters.</summary>
	public string Url { get; }

	/// <summary>
	/// Get parse request state.
	/// </summary>
	/// <param name="jobId"></param>
	/// <returns>Parse request state.</returns>
	public Task<ParseRequestState?> GetParseRequestStateAsync(long jobId);

	/// <summary>
	/// Submit a new parse request.
	/// </summary>
	/// <param name="matchId">ID used to identify individual matches, e.g. 3703866531.</param>
	/// <returns>Parse request object.</returns>
	public Task<ParseRequest?> SubmitNewParseRequestAsync(long matchId);
}