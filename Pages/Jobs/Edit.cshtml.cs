using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
                j => j.Rejected,
                j => j.JobNumber,
                j => j.Notes
            ))
            {
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }

            PopulateCompanyDropDownList(_context, jobToUpdate.CompanyID);
            return Page();
        }
    }
}
