using JobTrackerRazorApp.Data;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace JobTrackerRazorApp.Pages.Companies
{
    public class SectorNamePageModel : PageModel
    {
        public SelectList SectorNameSL { get; set; }

        public void PopulateSectorsDropDownList(TrackerContext _context,
            object selectedSector = null)
        {
            var sectorsQuery = from d in _context.Sectors
                orderby d.Name
                select d;
            
            SectorNameSL = new SelectList(sectorsQuery.AsNoTracking(),
                "SectorID",
                "Name", selectedSector);
        }
    }
}