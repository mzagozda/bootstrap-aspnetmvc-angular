using System.Net.Http;

namespace Services
{

    /// <summary>
    /// Provides static HttpClient
    /// </summary>
    /// <remarks
    /// HttpClient should have been created as AddressServiceClient so that it is properly managed and properly resolves hosts.
    /// </remarks>

    public static class HttpClientFactory
    {
        private static HttpClient _httpClient;
        public static HttpClient GetHttpClient()
        {
            if (_httpClient == null)
                _httpClient = new HttpClient();

            return _httpClient;
        }


    }
}
