
using System.Net.Http;

namespace SingletonHttpClientNS
{
    public static class HttpHelper
    {
        private static HttpClient _client;
        public static HttpClient SharedHttpClient
        {
            get
            {
                if (_client == null)
                {
                    _client = new HttpClient();
                    //_client.DefaultRequestHeaders.Connection.Add("keep-alive");
                }
                return _client;
            }
        }
    }
}
