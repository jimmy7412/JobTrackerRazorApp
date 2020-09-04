using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using JobTrackerRazorApp.Data;
using JobTrackerRazorApp.Models;

namespace JobTrackerRazorApp.Pages.Jobs
{
    public class IndexModel : PageModel
    {
        private readonly JobTrackerRazorApp.Data.TrackerContext _context;

        public IndexModel(JobTrackerRazorApp.Data.TrackerContext context)
        {
            _context = context;
        }

        public IList<Job> Job { get;set; }

        public async Task OnGetAsync()
        {
            Job = await _context.Jobs.ToListAsync();
        }
    }
}
