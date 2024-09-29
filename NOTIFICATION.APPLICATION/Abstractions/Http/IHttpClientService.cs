namespace NOTIFICATION.APPLICATION.Abstractions.Http;

public interface IHttpClientService
{
    Task<T> RequestAsync<T>(
        string url,
        HttpMethod method,
        Dictionary<string, string>? body = null,
        Dictionary<string, string>? headers = null
    );
}
