namespace JobTrackerRazorApp.Models
{
    public enum Strength
    {
        A, B, C, D, E
    }
    public class Tag
    {
        public int TagID { get; set; }
        public int CompanyID { get; set; }
        public int JobID { get; set; }
        public Strength? Strength { get; set; }
        
        public Company Company { get; set; }
        public Job Job { get; set; }
    }
}