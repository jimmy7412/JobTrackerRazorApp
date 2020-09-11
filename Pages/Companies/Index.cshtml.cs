using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using JobTrackerRazorApp.Data;
using JobTrackerRazorApp.Models;

namespace JobTrackerRazorApp.Pages.Companies
{
    public class IndexModel : PageModel
    {
        private readonly JobTrackerRazorApp.Data.TrackerContext _context;

        public IndexModel(JobTrackerRazorApp.Data.TrackerContext context)
        {
            _context = context;
        }

        public IList<Company> Companies { get;set; }

        public async Task OnGetAsync()
        {
            Companies = await _context.Companies
                .Include(c=> c.Sector)
                .AsNoTracking()
                .ToListAsync();
        }
    }
}
