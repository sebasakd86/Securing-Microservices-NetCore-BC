using System.Collections.Generic;
using System.Threading.Tasks;
using Job_Client.Models;

namespace Job_Client.Services
{
    public interface IJobService
    {
        Task<Job> GetJob(int jobId);
        Task<IEnumerable<Job>> GetJobs();
    }
}