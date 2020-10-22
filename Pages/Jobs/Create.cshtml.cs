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
                j => j.ID,
                j => j.Title, 
                j => j.CompanyID, 
                j => j.ApplicationDate, 
                j => j.Interview, 
                j => j.Company,
                j => j.City,
                j => j.Country,
                j => j.State,
                j => j.LastContact,
                j => j.LastChecked,
                j => j.Rejected))
            {
                _context.Jobs.Add(emptyJob);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }

            PopulateCompanyDropDownList(_context, emptyJob.CompanyID);
            return Page();
        }
    }
}
