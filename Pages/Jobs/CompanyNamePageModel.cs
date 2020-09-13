using JobTrackerRazorApp.Data;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace JobTrackerRazorApp.Pages.Jobs
{
    public class CompanyNamePageModel : PageModel
    {
        public SelectList CompanyNameSL { get; set; }

        public void PopulateCompanyDropDownList(TrackerContext _context,
            object selectedCompany = null)
        {
            var companiesQuery = from d in _context.Companies
                orderby d.CompanyName
                select d;
            
            CompanyNameSL = new SelectList(companiesQuery.AsNoTracking(),
                "CompanyID",
                "CompanyName", selectedCompany);
        }
    }
}