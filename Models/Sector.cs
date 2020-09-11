using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JobTrackerRazorApp.Models
{
    public class Sector
    {
        public int SectorID { get; set; }
        public string Name { get; set; }
        
        public int? RecruiterID { get; set; }
        
        
        public ICollection<Company> Companies { get; set; }
    }
}