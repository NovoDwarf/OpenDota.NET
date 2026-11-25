namespace OpenDota.NET.Utilities;

/// <summary> Sends requests to the OpenDota API. </summary>
public sealed class Requester : IDisposable
{
    private const string OpenDotaApi = "https://api.opendota.com/api/";

    private readonly HttpClient _httpClient;
    private readonly string? _apiKey;
    private readonly JsonSerializerOptions? _options;

    /// <summary> Creates a requester with the specified settings. </summary>
    public Requester(OpenDotaSettings? settings = null) : this(settings: settings ?? new OpenDotaSettings(), handler: null)
    {
    }

    internal Requester(OpenDotaSettings settings, HttpMessageHandler? handler)
    {
        _apiKey = settings.ApiKey;
        _options = settings.JsonSerializerOptions;
        handler ??= new HttpClientHandler { UseProxy = true, Proxy = settings.Proxy };
        _httpClient = new HttpClient(handler) { Timeout = TimeSpan.FromSeconds(60), BaseAddress = new Uri(OpenDotaApi) };
    }

    /// <summary>The base address used for OpenDota API requests.</summary>
    public Uri BaseAddress => _httpClient.BaseAddress!;

    internal async Task<T?> GetResponseAsync<T>(string url, List<string>? queryParameters = null) where T : class
    {
        using var response = await _httpClient.GetAsync(BuildUrl(url: url, queryParameters: queryParameters));

        response.EnsureSuccessStatusCode();

        var textResponse = await response.Content.ReadAsStringAsync();

        return string.IsNullOrEmpty(textResponse)
            ? null
            : JsonSerializer.Deserialize<T>(json: textResponse, options: _options);
    }

    internal Task<HttpResponseMessage> PostRequestAsync(string url, HttpContent? content = null)
    {
        return _httpClient.PostAsync(requestUri: BuildUrl(url), content: content);
    }

    /// <summary> Releases the underlying HTTP client. </summary>
    public void Dispose()
    {
        _httpClient.Dispose();
    }

    private string BuildUrl(string url, List<string>? queryParameters = null)
    {
        var arguments = new List<string>();

        if (queryParameters != null)
        {
            foreach (var parameter in queryParameters)
            {
                var separator = parameter.IndexOf('=');

                if (separator < 0)
                    throw new ArgumentException(message: "Query parameters must contain an equals sign.", paramName: nameof(queryParameters));

                arguments.Add($"{Uri.EscapeDataString(parameter[..separator])}={Uri.EscapeDataString(parameter[(separator + 1)..])}");
            }
        }

        if (_apiKey != null)
            arguments.Add($"api_key={Uri.EscapeDataString(_apiKey)}");

        return arguments.Count == 0
            ? url
            : $"{url}?{string.Join(separator: "&", values: arguments)}";
    }
}
