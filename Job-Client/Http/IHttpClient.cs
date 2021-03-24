using System.Net.Http;
using System.Threading.Tasks;

namespace Job_Client.Http
{
    public interface IHttpClient
    {
        Task<string> GetStringAsync(string url);
        Task<HttpResponseMessage> PostAsync<T>(string url, T item);
    }
}