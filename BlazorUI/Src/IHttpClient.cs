using System.Net.Http.Headers;
using System.Text.Json;

namespace BlazorUI.Src
{
    public interface IHttpClient : IDisposable
    {
        Uri? BaseAddress { get; set; }
        HttpRequestHeaders DefaultRequestHeaders { get; }
        Version DefaultRequestVersion { get; set; }
        HttpVersionPolicy DefaultVersionPolicy { get; set; }
        long MaxResponseContentBufferSize { get; set; }
        TimeSpan Timeout { get; set; }

        Task<HttpResponseMessage> DeleteAsync(string? requestUri);
        Task<HttpResponseMessage> DeleteAsync(string? requestUri, CancellationToken cancellationToken);
        Task<HttpResponseMessage> DeleteAsync(Uri? requestUri);
        Task<HttpResponseMessage> DeleteAsync(Uri? requestUri, CancellationToken cancellationToken);
        void Dispose();
        Task<HttpResponseMessage> GetAsync(string? requestUri);
        Task<HttpResponseMessage> GetAsync(string? requestUri, CancellationToken cancellationToken);
        Task<HttpResponseMessage> GetAsync(string? requestUri, HttpCompletionOption completionOption);
        Task<HttpResponseMessage> GetAsync(string? requestUri, HttpCompletionOption completionOption, CancellationToken cancellationToken);
        Task<HttpResponseMessage> GetAsync(Uri? requestUri);
        Task<HttpResponseMessage> GetAsync(Uri? requestUri, CancellationToken cancellationToken);
        Task<HttpResponseMessage> GetAsync(Uri? requestUri, HttpCompletionOption completionOption);
        Task<object?> GetFromJsonAsync(Uri? requestUri, CancellationToken cancellationToken = default);
        Task<TValue?> GetFromJsonAsync<TValue>(Uri? requestUri, CancellationToken cancellationToken = default);
        Task<HttpResponseMessage> PatchAsync(string? requestUri, HttpContent? content);
        Task<HttpResponseMessage> PatchAsync(string? requestUri, HttpContent? content, CancellationToken cancellationToken);
        Task<HttpResponseMessage> PatchAsync(Uri? requestUri, HttpContent? content);
        Task<HttpResponseMessage> PatchAsync(Uri? requestUri, HttpContent? content, CancellationToken cancellationToken);
        Task<HttpResponseMessage> PostAsJsonAsync<TValue>(string? requestUri, TValue value, JsonSerializerOptions? options = null, CancellationToken cancellationToken = default);
        Task<HttpResponseMessage> PostAsJsonAsync<TValue>(string? requestUri, TValue value, CancellationToken cancellationToken);
        Task<HttpResponseMessage> PostAsJsonAsync<TValue>(Uri? requestUri, TValue value, JsonSerializerOptions? options = null, CancellationToken cancellationToken = default);
        Task<HttpResponseMessage> PostAsJsonAsync<TValue>(Uri? requestUri, TValue value, CancellationToken cancellationToken);
        Task<HttpResponseMessage> PostAsync(string? requestUri, HttpContent? content);
        Task<HttpResponseMessage> PostAsync(string? requestUri, HttpContent? content, CancellationToken cancellationToken);
        Task<HttpResponseMessage> PostAsync(Uri? requestUri, HttpContent? content);
        Task<HttpResponseMessage> PostAsync(Uri? requestUri, HttpContent? content, CancellationToken cancellationToken);
        Task<HttpResponseMessage> PutAsync(string? requestUri, HttpContent? content);
        Task<HttpResponseMessage> PutAsync(string? requestUri, HttpContent? content, CancellationToken cancellationToken);
        Task<HttpResponseMessage> PutAsync(Uri? requestUri, HttpContent? content);
        Task<HttpResponseMessage> PutAsync(Uri? requestUri, HttpContent? content, CancellationToken cancellationToken);
    }
}
