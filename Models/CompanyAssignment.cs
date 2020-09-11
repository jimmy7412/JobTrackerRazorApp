namespace JobTrackerRazorApp.Models
{
    public class CompanyAssignment
    {
        public int RecruiterID { get; set; }
        public int CompanyID { get; set; }
        public Recruiter Recruiter { get; set; }
        public Company Company { get; set; }
    }
}