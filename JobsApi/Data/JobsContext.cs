using JobsApi.Models;
using Microsoft.EntityFrameworkCore;

namespace JobsApi.Data
{
    public class JobsContext : DbContext
    {
        public JobsContext(DbContextOptions<JobsContext> options)
            :base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Job>().ToTable("Jobs");
        }
        public DbSet<Job> Jobs { get; set; }
    }
}