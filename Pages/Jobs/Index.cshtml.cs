using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using JobTrackerRazorApp.Data;
using JobTrackerRazorApp.Models;

namespace JobTrackerRazorApp.Pages.Jobs
{
    public class IndexModel : PageModel
    {
        private readonly JobTrackerRazorApp.Data.TrackerContext _context;

        public IndexModel(JobTrackerRazorApp.Data.TrackerContext context)
        {
            _context = context;
        }
        
        public string TitleSort { get; set; }
        public string CompanySort { get; set; }
        public string CheckedSort { get; set; }
        public string CurrentFilter { get; set; }
        public string CurrentSort { get; set; }

        public PaginatedList<Job> Jobs { get;set; }

        public async Task OnGetAsync(string sortOrder, 
            string currentFilter, 
            string searchString,
            int? pageIndex)
        {
            CurrentSort = sortOrder;
            TitleSort = string.IsNullOrEmpty(sortOrder) ? "title_desc" : "";
            CheckedSort = sortOrder == "Date" ? "date_desc" : "Date";
            if (searchString != null)
            {
                pageIndex = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            CurrentFilter = searchString;

            IQueryable<Job> jobsIQ = from j in _context.Jobs select j;

            if (!String.IsNullOrEmpty(searchString))
            {
                jobsIQ = jobsIQ.Where(s => s.Title.ToUpper().Contains(searchString.ToUpper())
                                           || s.Company.CompanyName.ToUpper().Contains(searchString.ToUpper()));
            }

            switch (sortOrder)
            {
                case "title_desc":
                    jobsIQ = jobsIQ.OrderByDescending(s => s.Title);
                    break;
                case "Date":
                    jobsIQ = jobsIQ.OrderBy(s => s.LastChecked);
                    break;
                case "date_desc":
                    jobsIQ = jobsIQ.OrderByDescending(s => s.LastChecked);
                    break;
                default:
                    jobsIQ = jobsIQ.OrderBy(s => s.Title);
                    break;
            }

            int pageSize = 3;
            Jobs = await PaginatedList<Job>.CreateAsync(
                jobsIQ.AsNoTracking(), pageIndex ?? 1, pageSize);
        }
    }
}
