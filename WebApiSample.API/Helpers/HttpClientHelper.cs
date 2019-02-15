using System.Net.Http;
using System.Net.Http.Headers;

namespace WebapiSample.API.Helpers
{
    public class HttpClientHelper
    {
        public static T GetFromEndpoint<T>(string url) where T : class
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/vnd.github.v3+json"));
            var strResponse = client.GetStringAsync(url).Result;
            return JsonHelper.Deserialize<T>(strResponse);
        }
    }
}
