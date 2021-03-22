using System;

namespace JobsApi.Models
{
    public class Job
    {
        [System.ComponentModel.DataAnnotations.Key]
        public int JobId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime PostedDate { get; set; }
        public string Location { get; set; }
   }
}