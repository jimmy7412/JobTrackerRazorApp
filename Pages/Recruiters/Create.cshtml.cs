using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using JobTrackerRazorApp.Data;
using JobTrackerRazorApp.Models;

namespace JobTrackerRazorApp.Pages.Recruiters
{
    public class CreateModel : PageModel
    {
        private readonly JobTrackerRazorApp.Data.TrackerContext _context;

        public CreateModel(JobTrackerRazorApp.Data.TrackerContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Recruiter Recruiter { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Recruiters.Add(Recruiter);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
