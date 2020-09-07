using Microsoft.AspNetCore.Mvc.RazorPages;
using JobTrackerRazorApp.Models.JobViewModels;
using JobTrackerRazorApp.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JobTrackerRazorApp.Models;

namespace JobTrackerRazorApp.Pages
{
    public class JobsByCompany : PageModel
    {

        private readonly TrackerContext _context;

        public JobsByCompany(TrackerContext context)
        {
            _context = context;
        }

        public IList<CompanyGroup> Jobs { get; set; }
        
        public async Task OnGetAsync()
        {
            IQueryable<CompanyGroup> data = from job in _context.Jobs
                group job by job.Company into jobGroup
                select new CompanyGroup()
                {
                    Company = jobGroup.Key,
                    JobCount = jobGroup.Count()
                };

            Jobs = await data.AsNoTracking().ToListAsync();
        }
    }
    }