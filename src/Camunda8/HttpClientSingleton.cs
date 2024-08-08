using System.Net.Http;

public static class HttpClientSingleton
{
    private static readonly HttpClient _httpClient = new HttpClient();

    public static HttpClient Instance => _httpClient;
}
