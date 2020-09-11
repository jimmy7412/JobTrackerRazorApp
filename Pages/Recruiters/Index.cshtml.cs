using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using JobTrackerRazorApp.Data;
using JobTrackerRazorApp.Models;
using JobTrackerRazorApp.Models.JobViewModels;

namespace JobTrackerRazorApp.Pages.Recruiters
{
    public class IndexModel : PageModel
    {
        private readonly JobTrackerRazorApp.Data.TrackerContext _context;

        public IndexModel(JobTrackerRazorApp.Data.TrackerContext context)
        {
            _context = context;
        }

        public RecruiterViewModel RecruiterData { get; set; }
        public int RecruiterID { get; set; }
        public int CompanyID { get; set; }

        public async Task OnGetAsync(int? id, int? companyID)
        {
            RecruiterData = new RecruiterViewModel();
            RecruiterData.Recruiters = await _context.Recruiters
                .Include(i => i.Location)
                .Include(i => i.CompanyAssignments)
                .ThenInclude(i => i.Company)
                .ThenInclude(i => i.Sector)
                //.Include(i => i.CompanyAssignments)
                //.ThenInclude(i => i.Company)
                //.ThenInclude(i => i.Tags)
                //.ThenInclude(i => i.Job)
                //.AsNoTracking()
                .OrderBy(i => i.LastName)
                .ToListAsync();

            if (id != null)
            {
                RecruiterID = id.Value;
                Recruiter recruiter = RecruiterData.Recruiters
                    .Where(i => i.ID == id.Value).Single();
                RecruiterData.Companies = recruiter.CompanyAssignments.Select(s => s.Company);
            }

            if (companyID != null)
            {
                RecruiterID = id.Value;
                var selectedCompany = RecruiterData.Companies
                    .Where(x => x.CompanyID == CompanyID).Single();
                await _context.Entry(selectedCompany).Collection(x => x.Tags).LoadAsync();
                foreach (Tag tag in selectedCompany.Tags)
                {
                    await _context.Entry(tag).Reference(x => x.Job).LoadAsync();
                }
                RecruiterData.Tags = selectedCompany.Tags;
            }
        }
    }
}
