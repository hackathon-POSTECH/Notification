using System.Text.Json;
using NOTIFICATION.APPLICATION.Abstractions.Http;

namespace NOTIFICATION.INFRA.Adapters.Http;

public class HttpClientService : IHttpClientService
{
    private readonly HttpClient _httpClient;

    public HttpClientService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<T> RequestAsync<T>(
        string url,
        HttpMethod method,
        Dictionary<string, string>? body = null,
        Dictionary<string, string>? headers = null
    )
    {
        var request = new HttpRequestMessage(method, url);

        if (body is not null)
            request.Content = new FormUrlEncodedContent(body);

        if (headers is not null)
            foreach (var header in headers)
                request.Headers.Add(header.Key, header.Value);

        var response = await _httpClient.SendAsync(request);
        response.EnsureSuccessStatusCode();

        var responseContent = await response.Content.ReadAsStringAsync();

        var result = JsonSerializer.Deserialize<T>(responseContent, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        });

        if (result == null)
        {
            throw new InvalidOperationException("Failed to deserialize response.");
        }

        return result;
    }
}
