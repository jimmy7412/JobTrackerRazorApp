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
    public class DetailsModel : PageModel
    {
        private readonly JobTrackerRazorApp.Data.TrackerContext _context;

        public DetailsModel(JobTrackerRazorApp.Data.TrackerContext context)
        {
            _context = context;
        }

        public Company Company { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Company = await _context.Companies.FirstOrDefaultAsync(m => m.CompanyID == id);

            if (Company == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
