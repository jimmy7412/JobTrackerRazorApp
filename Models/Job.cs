using System;
using System.Collections.Generic;

namespace JobTrackerRazorApp.Models
{
    public class Job
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Company { get; set; }
        public DateTime ApplicationDate { get; set; }
        public DateTime LastContact { get; set; }
        public DateTime LastChecked { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public bool Rejected { get; set; }
        public bool Interview { get; set; }
        
        public ICollection<Tag> Tags { get; set; }
    }
}