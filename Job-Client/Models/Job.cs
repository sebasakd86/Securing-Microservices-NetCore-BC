using System;

namespace Job_Client.Models
{
    public class Job
    {
        public string JobId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Company { get; set; }
        public DateTime PostedDate { get; set; }
        public string Location { get; set; }
    }
}