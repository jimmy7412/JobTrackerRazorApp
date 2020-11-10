using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JobTrackerRazorApp.Data;
using JobTrackerRazorApp.Models;
using JobTrackerRazorApp.Models.JobViewModels;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace JobTrackerRazorApp.Pages
{
    public class JobsToCheck : PageModel
    {
        
        private readonly TrackerContext _context;
        
        //public static DateTime Today = DateTime.Today;
        
        //public static DateTime GhostTime = Today.AddDays(-100);
        
        public JobsToCheck(TrackerContext context)
        {
            _context = context;
        }
        
        public IList<Job> GhostedCheckedToday { get; set; }
        public IList<Job> CheckedToday { get; set; }
        public IList<Job> GhostedJobs { get; set; }
        
        public IList<Job> Jobs { get; set; }
        
        public async Task OnGetAsync()
        {
            DateTime today = DateTime.Today;
            DateTime ghostTime = today.AddDays(-100);

            IQueryable<Job> ghostedCheckedToday =
                from job in _context.Jobs
                where job.LastChecked == today
                where job.ApplicationDate != today
                where job.LastContact < ghostTime
                select new Job()
                {
                    ID = job.ID
                };

            GhostedCheckedToday = await ghostedCheckedToday.AsNoTracking().ToListAsync();

            int ghostCheckLimit = GhostedCheckedToday.Count;
            
            int ghostTakeAmount = (ghostCheckLimit >= 1) ? 0 : 1;
            
            IQueryable<Job> checkedToday =
                from job in _context.Jobs
                where job.LastChecked == today
                where job.ApplicationDate != today
                where job.LastContact > ghostTime
                select new Job()
                {
                    ID = job.ID
                };

            CheckedToday = await checkedToday.AsNoTracking().ToListAsync();

            int checkLimit = CheckedToday.Count;
            
            int takeAmount = (checkLimit >= 5) ? 0 : (5 - checkLimit);

            IQueryable<Job> ghostdata = 
                from job in _context.Jobs
                where job.LastContact < ghostTime
                where job.Rejected == false
                select new Job()
                {
                    ID = job.ID,
                    Title = job.Title,
                    Company = job.Company
                };

            GhostedJobs = await ghostdata.Take(ghostTakeAmount).AsNoTracking().ToListAsync();
            
            IQueryable<Job> data = 
                from job in _context.Jobs
                where job.LastContact > ghostTime
                where job.LastContact < today
                where job.Rejected == false
                orderby job.LastChecked
                select new Job()
                {
                    ID = job.ID,
                    Title = job.Title,
                    Company = job.Company
                };

            Jobs = await data.Take(takeAmount).AsNoTracking().ToListAsync();
        }
    }
}