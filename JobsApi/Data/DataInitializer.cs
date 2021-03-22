using System;
using System.Linq;
using JobsApi.Models;

namespace JobsApi.Data
{
    public class DataInitializer
    {
        public static void Initialize(JobsContext context)
        {
            context.Database.EnsureCreated();
            if(context.Jobs.Any())
            {
                return;
            }
            var jobs = new Job[]
            {
                new Job { Title = "Senior Software Engineer", Description = "Seeking pipol for the Senior Software Engineer position", PostedDate= DateTime.UtcNow, Location = "Toronto"},
                new Job { Title = "Jr Software Engineer", Description = "Seeking Jr Software Engineer", PostedDate= DateTime.UtcNow, Location = "Toronto"},
                new Job { Title = "Senior Developer", Description = "Looking 4 a seasoned Senior Developer", PostedDate= DateTime.UtcNow, Location = "Toronto"},
                new Job { Title = "Jr .Net Core Developer", Description = "Get me a n00b", PostedDate= DateTime.UtcNow, Location = "Toronto"}
            };
            context.Jobs.AddRange(jobs);
            context.SaveChanges();
        }
    }
}