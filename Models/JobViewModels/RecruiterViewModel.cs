using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobTrackerRazorApp.Models.JobViewModels
{
    public class RecruiterViewModel
    {
        public IEnumerable<Recruiter> Recruiters { get; set; }
        public IEnumerable<Company> Companies { get; set; }
        public IEnumerable<Tag> Tags { get; set; }
    }
}