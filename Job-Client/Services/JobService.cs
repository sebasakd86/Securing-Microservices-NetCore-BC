using System.Collections.Generic;
using System.Threading.Tasks;
using Job_Client.Http;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Job_Client.Services;
using Job_Client.Config;
using Job_Client.Models;

namespace Job_Client.Services
{
    public class JobService : IJobService
    {
        private readonly ApiConfig apiConfig;
        private readonly IHttpClient client;

        public JobService(IHttpClient client, IOptionsMonitor<ApiConfig> apiConfig)
        {
            this.client = client;
            this.apiConfig = apiConfig.CurrentValue;
        }
        public async Task<Job> GetJob(int jobId)
        {
            var str = await client.GetStringAsync($"{apiConfig.JobsApiUrl}/jobs/{jobId}");
            return JsonConvert.DeserializeObject<Job>(str);
        }
        public async Task<IEnumerable<Job>> GetJobs()
        {
            var str = await client.GetStringAsync($"{apiConfig.JobsApiUrl}/jobs/");
            return JsonConvert.DeserializeObject<IEnumerable<Job>>(str);

        }
    }
}