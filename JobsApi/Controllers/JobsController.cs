namespace JobsApi.Controllers
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using JobsApi.Data;
    using JobsApi.Models;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Logging;

    [Route("[controller]")]
    [ApiController]
    [Authorize]
    public class JobsController : ControllerBase
    {
        private readonly ILogger<JobsController> logger;
        private readonly JobsContext context;
        public JobsController(ILogger<JobsController> logger, JobsContext context)
        {
            this.context = context;
            this.logger = logger;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Job>>> Get()
        {
            var claims = User.Claims;
            return Ok(await context.Jobs.ToListAsync());
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Job>> GetAsync(int id)
        {
            return await context.Jobs.FirstOrDefaultAsync(j => j.JobId == id);
        }
    }
}