﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JobTrackerRazorApp.Models
{
    public class Job
    {
        public int ID { get; set; }
        [Required]
        [StringLength(50)]
        [Display(Name = "Title")]
        public string Title { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Application Date")]
        public DateTime ApplicationDate { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Last Contact Date")]
        public DateTime LastContact { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Last Checked Date")]
        public DateTime LastChecked { get; set; }
        [StringLength(50)]
        [Display(Name = "City")]
        public string City { get; set; }
        [StringLength(50)]
        [Display(Name = "State")]
        public string State { get; set; }
        [StringLength(50)]
        [Display(Name = "Country")]
        public string Country { get; set; }
        [StringLength(100000)]
        [Display(Name = "Notes")]
        public string Notes { get; set; }
        public bool Rejected { get; set; }
        public bool Interview { get; set; }
        [Display(Name = "Company")]
        public Company Company { get; set; }
        public int CompanyID { get; set; }

        public ICollection<Tag> Tags { get; set; }
        
        [Display(Name = "Job Number")]
        public string JobNumber { get; set; }
    }
}