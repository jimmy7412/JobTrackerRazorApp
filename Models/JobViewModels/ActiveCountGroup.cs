using System;
using System.ComponentModel.DataAnnotations;

namespace JobTrackerRazorApp.Models.JobViewModels
{
    public class ActiveCountGroup
    {
        public int JobCount { get; set; }

        public string Active { get; set; }
    }
}