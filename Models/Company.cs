using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace JobTrackerRazorApp.Models
{
    public enum Size
    {
        Tiny, Small, Medium, Large, Huge
    }
    public class Company
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CompanyID { get; set; }
        public string CompanyName { get; set; }
        public Size? Size { get; set; }
        
        public ICollection<Tag> Tags { get; set; }
    }
}