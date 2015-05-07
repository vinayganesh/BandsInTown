using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace HttpManager
{
    public static class BitRequestManager
    {
        private static HttpClient _httpClient;

        public static async Task<HttpResponseMessage> SendRequest(Uri uri)
        {
            try
            {
                _httpClient = new HttpClient();

                var request = new HttpRequestMessage(HttpMethod.Get, uri);

                Debug.WriteLine(request.RequestUri);

                var response = await _httpClient.SendAsync(request);

                return response;
            }

            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
            return null;
        }
    }
}
