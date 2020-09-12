using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using JobTrackerRazorApp.Data;
using JobTrackerRazorApp.Models;

namespace JobTrackerRazorApp.Pages.Companies
{
    public class CreateModel : SectorNamePageModel
    {
        private readonly JobTrackerRazorApp.Data.TrackerContext _context;

        public CreateModel(JobTrackerRazorApp.Data.TrackerContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            PopulateSectorsDropDownList(_context);
            return Page();
        }

        [BindProperty]
        public Company Company { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            var emptyCompany = new Company();
            
            if (await TryUpdateModelAsync<Company>(
                emptyCompany, "company",
                s=> s.CompanyID,
                s=> s.SectorID,
                s=> s.CompanyName))
            {
                _context.Companies.Add(emptyCompany);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            
            PopulateSectorsDropDownList(_context, emptyCompany.SectorID);

            return Page();
        }
    }
}
