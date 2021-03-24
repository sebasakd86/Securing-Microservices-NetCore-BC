using System.Diagnostics;
using System.Threading.Tasks;
using Job_Client.Models;
using Job_Client.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Job_Client.Controllers
{
    public class HomeController : Controller
    {
        private readonly IJobService jobService;
        private readonly ILogger<HomeController> logger;
        public HomeController(ILogger<HomeController> logger, IJobService jobService)
        {
            this.logger = logger;
            this.jobService = jobService;
        }

        public async Task<IActionResult> Index()
        {
            var jobs = await jobService.GetJobs();
            return View(jobs);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
