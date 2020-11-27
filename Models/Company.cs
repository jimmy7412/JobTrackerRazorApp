using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JobTrackerRazorApp.Models
{
    /*This is the model for the Company objects
     it won't use the size enum anymore, but I don't want to delete it yet.*/
    public enum Size
    {
        Tiny, Small, Medium, Large, Huge
    }
    public class Company
    {
        /*These are the attributes, all it really needs is the ID, Name and Notes,
         all the other ones could probably be gotten rid of, but because of how I did the tables
         I think it would be hard or annoying.*/
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