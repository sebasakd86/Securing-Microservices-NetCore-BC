using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Job_Client.Http
{
    public class GeneralHttpClient : IHttpClient
    {
        private static readonly HttpClient client = new HttpClient();
        public async Task<string> GetStringAsync(string url)
        {
            var requestMessage = new HttpRequestMessage(HttpMethod.Get, url);
            var response = await client.SendAsync(requestMessage);
            return await response.Content.ReadAsStringAsync();
        }
        public async Task<HttpResponseMessage> PostAsync<T>(string url, T item)
        {
            var requestMessage = new HttpRequestMessage(HttpMethod.Post, url)
            {
                Content = new StringContent(JsonConvert.SerializeObject(item), System.Text.Encoding.UTF8, "application/json")
            };
            var response = await client.SendAsync(requestMessage);
            if(response.StatusCode == System.Net.HttpStatusCode.InternalServerError)
            {
                throw new HttpRequestException();
            }
            return response;
        }
    }
}