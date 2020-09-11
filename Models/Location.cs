using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JobTrackerRazorApp.Models
{
    public class Location
    {
        [Key]
        public int RecruiterID { get; set; }
        [StringLength(50)]
        [Display(Name = "Office Location")]
        public string OfficeLocation { get; set; }

        public Recruiter Recruiter { get; set; }
    }
}