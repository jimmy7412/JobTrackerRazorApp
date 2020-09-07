using System;
using System.ComponentModel.DataAnnotations;

namespace JobTrackerRazorApp.Models.JobViewModels
{
    public class CompanyGroup
    {
        [DataType(DataType.Text)]
        public string Company { get; set; }
        
        public int JobCount { get; set; }
    }
}