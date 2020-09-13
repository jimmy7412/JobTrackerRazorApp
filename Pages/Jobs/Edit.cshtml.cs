using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using JobTrackerRazorApp.Data;
using JobTrackerRazorApp.Models;

namespace JobTrackerRazorApp.Pages.Jobs
{
    public class EditModel : CompanyNamePageModel
    {
        private readonly JobTrackerRazorApp.Data.TrackerContext _context;

        public EditModel(JobTrackerRazorApp.Data.TrackerContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Job Job { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Job = await _context.Jobs
                .Include(c=> c.Company)
                .FirstOrDefaultAsync(m => m.ID == id);

            if (Job == null)
            {
                return NotFound();
            }
            PopulateCompanyDropDownList(_context, Job.CompanyID);
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            
            var jobToUpdate = await _context.Jobs.FindAsync(id);
            
            if (jobToUpdate == null)
            {
                return NotFound();
            }

            if (await TryUpdateModelAsync<Job>(
                jobToUpdate,
                "job", 
                job => job.Title, 
                job => job.CompanyID, 
                job => job.ApplicationDate,
                job => job.Interview ))
            {
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }

            PopulateCompanyDropDownList(_context, jobToUpdate.CompanyID);
            return Page();
        }

        private bool JobExists(int id)
        {
            return _context.Jobs.Any(e => e.ID == id);
        }
    }
}
