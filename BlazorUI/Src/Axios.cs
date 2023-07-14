using BlazorDAL.Models;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Net.Http;
using System.Net;
using System.Text.Json;

namespace BlazorUI.Src
{
    public class Axios : IHttpClient
    {

        public Uri? BaseAddress { get; set; }

        internal const string SerializationUnreferencedCodeMessage = "JSON serialization and deserialization might require types that cannot be statically analyzed. Use the overload that takes a JsonTypeInfo or JsonSerializerContext, or make sure all of the required types are preserved.";

        private Version _defaultRequestVersion => HttpVersion.Version11;
        private HttpVersionPolicy _defaultVersionPolicy => HttpVersionPolicy.RequestVersionOrLower;
        private const HttpCompletionOption DefaultCompletionOption = HttpCompletionOption.ResponseContentRead;
        private HttpClient _httpClient;

        public event Action<object,HttpMethod> OnResponse;
        public event Action OnRequestd;

        public Axios()
        {
            _httpClient = new HttpClient();
        }



        public HttpRequestHeaders DefaultRequestHeaders
        {
            get { return _httpClient.DefaultRequestHeaders; }
        }

        public TimeSpan Timeout
        {
            get { return _httpClient.Timeout; }
            set { _httpClient.Timeout = value; }
        }

        public long MaxResponseContentBufferSize
        {
            get { return _httpClient.MaxResponseContentBufferSize; }
            set { _httpClient.MaxResponseContentBufferSize = value; }
        }

        public Version DefaultRequestVersion
        {
            get { return _httpClient.DefaultRequestVersion; }
            set { _httpClient.DefaultRequestVersion = value; }
        }

        public HttpVersionPolicy DefaultVersionPolicy
        {
            get { return _httpClient.DefaultVersionPolicy; }
            set { _httpClient.DefaultVersionPolicy = value; }
        }


        public Task<HttpResponseMessage> GetAsync(string? requestUri) =>
                   _httpClient.GetAsync(requestUri);

        public Task<HttpResponseMessage> GetAsync(Uri? requestUri) =>
            _httpClient.GetAsync(requestUri);

        public Task<HttpResponseMessage> GetAsync(string? requestUri, HttpCompletionOption completionOption) =>
            _httpClient.GetAsync(requestUri, completionOption);

        public Task<HttpResponseMessage> GetAsync(Uri? requestUri, HttpCompletionOption completionOption) =>
            _httpClient.GetAsync(requestUri, completionOption, CancellationToken.None);

        public Task<HttpResponseMessage> GetAsync(string? requestUri, CancellationToken cancellationToken) =>
            _httpClient.GetAsync(requestUri, cancellationToken);

        public Task<HttpResponseMessage> GetAsync(Uri? requestUri, CancellationToken cancellationToken) =>
            _httpClient.GetAsync(requestUri, DefaultCompletionOption, cancellationToken);

        public Task<HttpResponseMessage> GetAsync(string? requestUri, HttpCompletionOption completionOption, CancellationToken cancellationToken) =>
            _httpClient.GetAsync(requestUri, completionOption, cancellationToken);

        public Task<HttpResponseMessage> PostAsync(string? requestUri, HttpContent? content) =>
            _httpClient.PostAsync(requestUri, content);

        public Task<HttpResponseMessage> PostAsync(Uri? requestUri, HttpContent? content) =>
            _httpClient.PostAsync(requestUri, content, CancellationToken.None);

        public Task<HttpResponseMessage> PostAsync(string? requestUri, HttpContent? content, CancellationToken cancellationToken) =>
            _httpClient.PostAsync(requestUri, content, cancellationToken);

        public Task<HttpResponseMessage> PostAsync(Uri? requestUri, HttpContent? content, CancellationToken cancellationToken)
        {
            HttpRequestMessage request = CreateRequestMessage(HttpMethod.Post, requestUri);
            request.Content = content;
            return _httpClient.SendAsync(request, cancellationToken);
        }

        public Task<HttpResponseMessage> PutAsync(string? requestUri, HttpContent? content) =>
            _httpClient.PutAsync(requestUri, content);

        public Task<HttpResponseMessage> PutAsync(Uri? requestUri, HttpContent? content) =>
            _httpClient.PutAsync(requestUri, content, CancellationToken.None);

        public Task<HttpResponseMessage> PutAsync(string? requestUri, HttpContent? content, CancellationToken cancellationToken) =>
            _httpClient.PutAsync(requestUri, content, cancellationToken);

        public Task<HttpResponseMessage> PutAsync(Uri? requestUri, HttpContent? content, CancellationToken cancellationToken)
        {
            HttpRequestMessage request = CreateRequestMessage(HttpMethod.Put, requestUri);
            request.Content = content;
            return _httpClient.SendAsync(request, cancellationToken);
        }

        public Task<HttpResponseMessage> PatchAsync(string? requestUri, HttpContent? content) =>
            _httpClient.PatchAsync(requestUri, content);

        public Task<HttpResponseMessage> PatchAsync(Uri? requestUri, HttpContent? content) =>
            _httpClient.PatchAsync(requestUri, content, CancellationToken.None);

        public Task<HttpResponseMessage> PatchAsync(string? requestUri, HttpContent? content, CancellationToken cancellationToken) =>
            _httpClient.PatchAsync(requestUri, content, cancellationToken);

        public Task<HttpResponseMessage> PatchAsync(Uri? requestUri, HttpContent? content, CancellationToken cancellationToken)
        {
            HttpRequestMessage request = CreateRequestMessage(HttpMethod.Patch, requestUri);
            request.Content = content;
            return _httpClient.SendAsync(request, cancellationToken);
        }

        public Task<HttpResponseMessage> DeleteAsync(string? requestUri) =>
            _httpClient.DeleteAsync(requestUri);

        public Task<HttpResponseMessage> DeleteAsync(Uri? requestUri) =>
            _httpClient.DeleteAsync(requestUri, CancellationToken.None);

        public Task<HttpResponseMessage> DeleteAsync(string? requestUri, CancellationToken cancellationToken) =>
            _httpClient.DeleteAsync(requestUri, cancellationToken);

        public Task<HttpResponseMessage> DeleteAsync(Uri? requestUri, CancellationToken cancellationToken) =>
            _httpClient.SendAsync(CreateRequestMessage(HttpMethod.Delete, requestUri), cancellationToken);

        [RequiresUnreferencedCode(SerializationUnreferencedCodeMessage)]
        public Task<HttpResponseMessage> PostAsJsonAsync<TValue>(string? requestUri, TValue value, JsonSerializerOptions? options = null, CancellationToken cancellationToken = default)
        {
            try
            {
                if (_httpClient == null)
                {
                    throw new ArgumentNullException(nameof(_httpClient));
                }

                JsonContent content = JsonContent.Create(value, mediaType: null, options);
                return _httpClient.PostAsync(requestUri, content, cancellationToken);
            }
            catch(Exception ex)
            {
                throw;
            }
            
        }

        [RequiresUnreferencedCode(SerializationUnreferencedCodeMessage)]
        public async Task<HttpClientResult<TValue>> PostAsJsonAsync<TValue>(Uri? requestUri, TValue value, JsonSerializerOptions? options = null, CancellationToken cancellationToken = default)
        {
            try
            {
                if (_httpClient == null)
                {
                    throw new ArgumentNullException(nameof(_httpClient));
                }

                JsonContent content = JsonContent.Create(value, mediaType: null, options);
                var responseMessage = await _httpClient.PostAsync(requestUri, content, cancellationToken); ;
                var jsonData = await responseMessage.Content.ReadFromJsonAsync<ReturnResult<TValue>>();
                var httpClientRes = new HttpClientResult<TValue>
                {
                    HttpResponseMessage = responseMessage,
                    Data =jsonData.result,
                };
                OnResponse.Invoke(jsonData,responseMessage.RequestMessage.Method);
                return httpClientRes;
            }
            catch(Exception ex)
            {
                throw;
            }
         
        }

        [RequiresUnreferencedCode(SerializationUnreferencedCodeMessage)]
        public Task<HttpResponseMessage> PostAsJsonAsync<TValue>(string? requestUri, TValue value, CancellationToken cancellationToken)
            => _httpClient.PostAsJsonAsync(requestUri, value, options: null, cancellationToken);

        [RequiresUnreferencedCode(SerializationUnreferencedCodeMessage)]
        public Task<HttpResponseMessage> PostAsJsonAsync<TValue>(Uri? requestUri, TValue value, CancellationToken cancellationToken)
            => _httpClient.PostAsJsonAsync(requestUri, value, options: null, cancellationToken);

        [RequiresUnreferencedCode(SerializationUnreferencedCodeMessage)]
        public async Task<TValue?> GetFromJsonAsync<TValue>(string requestUri, CancellationToken cancellationToken = default)
        {
            var responseMessage = await _httpClient.GetAsync(requestUri, cancellationToken);
            var jsonData = await responseMessage.Content.ReadFromJsonAsync<ReturnResult<TValue>>();

            OnResponse.Invoke(jsonData,responseMessage.RequestMessage.Method);
            return jsonData.result;
        }

        [RequiresUnreferencedCode(SerializationUnreferencedCodeMessage)]
        public async Task<TValue?> GetFromJsonAsync<TValue>(Uri? requestUri, CancellationToken cancellationToken = default)
        {
            var responseMessage = await _httpClient.GetAsync(requestUri, cancellationToken);
            var jsonData = await responseMessage.Content.ReadFromJsonAsync<TValue>();
            OnResponse.Invoke(jsonData, responseMessage.RequestMessage.Method);
            return jsonData;
            //return _httpClient.GetFromJsonAsync<TValue>(requestUri,   cancellationToken);

        }

        [RequiresUnreferencedCode(SerializationUnreferencedCodeMessage)]
        public Task<object?> GetFromJsonAsync(Uri? requestUri, CancellationToken cancellationToken = default)
                => _httpClient.GetFromJsonAsync<object>(requestUri, options: null, cancellationToken);

        private HttpRequestMessage CreateRequestMessage(HttpMethod method, Uri? uri) =>
                new HttpRequestMessage(method, uri) { Version = _defaultRequestVersion, VersionPolicy = _defaultVersionPolicy };

        public void Dispose()
        {
            _httpClient.Dispose();
        }
    }

    public class HttpClientResult<T>
    {
        public T Data { get; set; }
        public Type Type { get; set; }
        public HttpResponseMessage HttpResponseMessage { get; set; }
    }
    public class HttpClientResult:HttpClientResult<object>
    {
      
    }

}
