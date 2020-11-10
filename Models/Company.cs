using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JobTrackerRazorApp.Models
{
    public enum Size
    {
        Tiny, Small, Medium, Large, Huge
    }
    public class Company
    {
        public int CompanyID { get; set; }
        [StringLength(50, MinimumLength = 3)]
        public string CompanyName { get; set; }
        public Size? Size { get; set; }

        public int SectorID { get; set; }
        public Sector Sector { get; set; }
        
        public string Notes { get; set; }
        
        public ICollection<Tag> Tags { get; set; }
        public ICollection<CompanyAssignment> CompanyAssignments { get; set; }
    }
}