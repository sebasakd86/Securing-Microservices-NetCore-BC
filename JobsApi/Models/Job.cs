using System;
using System.ComponentModel.DataAnnotations;

namespace JobsApi.Models
{
    public class Job
    {
        [Key]
        public int JobId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime PostedDate { get; set; }
        public string Location { get; set; }
   }
}