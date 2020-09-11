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

namespace JobTrackerRazorApp.Pages.Recruiters
{
    public class EditModel : PageModel
    {
        private readonly JobTrackerRazorApp.Data.TrackerContext _context;

        public EditModel(JobTrackerRazorApp.Data.TrackerContext context)
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

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Recruiter).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RecruiterExists(Recruiter.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool RecruiterExists(int id)
        {
            return _context.Recruiters.Any(e => e.ID == id);
        }
    }
}
