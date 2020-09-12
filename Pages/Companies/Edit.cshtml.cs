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

namespace JobTrackerRazorApp.Pages.Companies
{
    public class EditModel : SectorNamePageModel
    {
        private readonly JobTrackerRazorApp.Data.TrackerContext _context;

        public EditModel(JobTrackerRazorApp.Data.TrackerContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Company Company { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Company = await _context.Companies
                .Include(c=> c.Sector)
                .FirstOrDefaultAsync(m => m.CompanyID == id);

            if (Company == null)
            {
                return NotFound();
            }
            
            PopulateSectorsDropDownList(_context, Company.SectorID);
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

            var companyToUpdate = await _context.Companies.FindAsync(id);

            if (companyToUpdate == null)
            {
                return NotFound();
            }

            if (await TryUpdateModelAsync<Company>(
                companyToUpdate,
                "company",   // Prefix for form value.
                c => c.SectorID, c => c.CompanyName,
                c=> c.Size))
            {
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }

            // Select DepartmentID if TryUpdateModelAsync fails.
            PopulateSectorsDropDownList(_context, companyToUpdate.SectorID);
            return Page();
        }
    }
}
