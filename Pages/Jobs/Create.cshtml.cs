using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using JobTrackerRazorApp.Data;
using JobTrackerRazorApp.Models;

namespace JobTrackerRazorApp.Pages.Jobs
{
    public class CreateModel : CompanyNamePageModel
    {
        private readonly JobTrackerRazorApp.Data.TrackerContext _context;

        public CreateModel(JobTrackerRazorApp.Data.TrackerContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            PopulateCompanyDropDownList(_context);
            return Page();
        }

        [BindProperty]
        public Job Job { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            var emptyJob = new Job();
            
            if (await TryUpdateModelAsync<Job>(
                emptyJob, "job",
                s => s.Title,s=>s.Company, s=> s.ApplicationDate, 
                s => s.ID, 
                s => s.CompanyID))
            {
                _context.Jobs.Add(Job);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }

            PopulateCompanyDropDownList(_context, emptyJob.CompanyID);
            return Page();
        }
    }
}
