using OpenDota.NET.Extensions;
using OpenDota.NET.Routes.Records.Enums;
using OpenDota.NET.Routes.Records.Models;
using OpenDota.NET.Utilities;

namespace OpenDota.NET.Routes.Records;

/// <inheritdoc />
[UsedImplicitly]
public class RecordsEndpoint : IRecordsEndpoint
{
	private readonly Requester _requester;

	/// <inheritdoc />
	public RecordsEndpoint(Requester requester)
	{
		_requester = requester;
	}

	/// <inheritdoc />
	public string Endpoint => "records";

	/// <inheritdoc />
	public string Url => new Uri(baseUri: _requester.BaseAddress, relativeUri: Endpoint).AbsoluteUri;


	/// <inheritdoc />
	public Task<List<Record>?> GetRecordsByFieldAsync(Field field)
	{
		return _requester.GetResponseAsync<List<Record>>($"{Endpoint}/{field.ToSnakeCase()}");
	}
}