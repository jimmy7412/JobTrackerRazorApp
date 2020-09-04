using JobTrackerRazorApp.Data;
using JobTrackerRazorApp.Models;
using System;
using System.Linq;

namespace JobTrackerRazorApp.Data
{
    public class DbInitializer
    {
        public static void Initialize(TrackerContext context)
        {
            context.Database.EnsureCreated();
            
            //Look for any jobs
            if (context.Jobs.Any())
            {
                return; //db has been seeded
            }

            var jobs = new Job[]
            {
                new Job
                {
                    Title = "Unemployed SDE", Company = "Amazon",
                    ApplicationDate = DateTime.Parse("2020-07-01"), City = "Seattle",
                    State = "Washington", Country = "USA",
                    Interview = false, Rejected = true,
                    LastChecked = DateTime.Parse("2020-08-01"),
                    LastContact = DateTime.Parse("2020-07-01")
                },
                new Job
                {
                    Title = "SDE", Company = "Amazon",
                    ApplicationDate = DateTime.Parse("2020-06-01"), City = "Seattle",
                    State = "Washington", Country = "USA",
                    Interview = false, Rejected = true,
                    LastChecked = DateTime.Parse("2020-07-01"),
                    LastContact = DateTime.Parse("2020-06-01")
                },
                new Job
                {
                    Title = "SDE Rejecter", Company = "Amazon",
                    ApplicationDate = DateTime.Parse("2020-05-01"), City = "Seattle",
                    State = "Washington", Country = "USA",
                    Interview = false, Rejected = true,
                    LastChecked = DateTime.Parse("2020-05-01"),
                    LastContact = DateTime.Parse("2020-05-01")
                },
                new Job
                {
                    Title = "Unemployed SDE", Company = "Microsoft",
                    ApplicationDate = DateTime.Parse("2020-03-01"), City = "Seattle",
                    State = "Washington", Country = "USA",
                    Interview = false, Rejected = true,
                    LastChecked = DateTime.Parse("2020-05-01"),
                    LastContact = DateTime.Parse("2020-03-01")
                }
            };
            
            context.Jobs.AddRange(jobs);
            context.SaveChanges();
            
            var companies = new Company[]
            {
                new Company
                {
                    CompanyName = "Amazon", Size = Size.Huge
                }, 
                new Company
                {
                    CompanyName = "Microsoft", Size = Size.Huge
                } 
            };
            
            context.Companies.AddRange(companies);
            context.SaveChanges();
            
            var tags = new Tag[]
            {
                new Tag{JobID = 1, CompanyID = 1},
                new Tag{JobID = 2, CompanyID = 1},
                new Tag{JobID = 3, CompanyID = 1},
                new Tag{JobID = 4, CompanyID = 1},
                new Tag{JobID = 5, CompanyID = 2}
            };
            
            context.Tags.AddRange(tags);
            context.SaveChanges();
        }
    }
}