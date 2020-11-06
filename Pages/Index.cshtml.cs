using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JobTrackerRazorApp.Models;
using JobTrackerRazorApp.Models.JobViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace JobTrackerRazorApp.Pages
{
    public class IndexModel : PageModel
    {
        
        /*private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }*/
        
        private readonly JobTrackerRazorApp.Data.TrackerContext _context;

        public IndexModel(JobTrackerRazorApp.Data.TrackerContext context)
        {
            _context = context;
        }

        public static int Active { get; set; }

        public static int Ghosted { get; set; }

        public static int Rejected { get; set; }

        public async Task OnGetAsync()
        {
            DateTime today = DateTime.Today;
            DateTime ghostTime = today.AddDays(-100);
            
            IQueryable<Job> jobsRejected = from j in _context.Jobs
                where j.Rejected == true
                select j;
            Rejected = jobsRejected.Count();
            
            IQueryable<Job> jobsGhost = from j in _context.Jobs
                where j.Rejected == false
                where j.LastContact < ghostTime
                select j;
            Ghosted = jobsGhost.Count();
            
            IQueryable<Job> jobsActive = from j in _context.Jobs
                where j.Rejected == false
                where j.LastContact > ghostTime
                where j.LastContact <= today
                select j;
            Active = jobsActive.Count();
        }
    }
}