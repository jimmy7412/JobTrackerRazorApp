using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using JobTrackerRazorApp.Data;
using JobTrackerRazorApp.Models;

namespace JobTrackerRazorApp.Pages.Recruiters
{
    public class DeleteModel : PageModel
    {
        private readonly JobTrackerRazorApp.Data.TrackerContext _context;

        public DeleteModel(JobTrackerRazorApp.Data.TrackerContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Recruiter Recruiter { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Recruiter = await _context.Recruiters.FirstOrDefaultAsync(m => m.ID == id);

            if (Recruiter == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Recruiter = await _context.Recruiters.FindAsync(id);

            if (Recruiter != null)
            {
                _context.Recruiters.Remove(Recruiter);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
