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
            //context.Database.EnsureCreated();
            
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
            
            var sectors = new Sector[]
            {
                new Sector
                {
                    Name = "Tech",
                    
                },
                new Sector{Name = "Finance"}
            };
            
            context.Sectors.AddRange(sectors);
            context.SaveChanges();
            
            var companies = new Company[]
            {
                new Company
                {
                    CompanyName = "Amazon", Size = Size.Huge, SectorID = sectors.Single(s => s.Name == "Tech").SectorID
                }, 
                new Company
                {
                    CompanyName = "Microsoft", Size = Size.Huge, SectorID = sectors.Single(s => s.Name == "Tech").SectorID
                } 
            };
            
            context.Companies.AddRange(companies);
            context.SaveChanges();
            
            var recruiters = new Recruiter[]
            {
                new Recruiter{FirstMidName = "Jim", LastName = "Jimerson", LastContactDate = DateTime.Parse("2020-07-05")},
                new Recruiter{FirstMidName = "Kim", LastName = "Kimerson", LastContactDate = DateTime.Parse("2020-07-05")}
            };
            
            context.Recruiters.AddRange(recruiters);
            context.SaveChanges();
            
            var locations = new Location[]
            {
                new Location
                {
                    RecruiterID = recruiters.Single(i => i.LastName == "Jimerson").ID,
                    OfficeLocation = "Seattle"
                }, 
                new Location
                {
                    RecruiterID = recruiters.Single(i => i.LastName == "Kimerson").ID,
                    OfficeLocation = "Washington D.C."
                }
            };
            
            context.Locations.AddRange(locations);
            context.SaveChanges();
            
            var companyRecruiters = new CompanyAssignment[]
            {
                new CompanyAssignment
                {
                    CompanyID = companies.Single(c => c.CompanyName == "Microsoft").CompanyID,
                    RecruiterID = recruiters.Single(i => i.LastName == "Jimerson").ID
                }, 
                new CompanyAssignment
                {
                    CompanyID = companies.Single(c => c.CompanyName == "Amazon").CompanyID,
                    RecruiterID = recruiters.Single(i => i.LastName == "Kimerson").ID
                }, 
            };
            
            context.CompanyAssignments.AddRange(companyRecruiters);
            context.SaveChanges();
            
            var tags = new Tag[]
            {
                new Tag{JobID = 1, CompanyID = companies.Single(c => c.CompanyName == "Amazon").CompanyID},
                new Tag{JobID = 2, CompanyID = companies.Single(c => c.CompanyName == "Amazon").CompanyID},
                new Tag{JobID = 3, CompanyID = companies.Single(c => c.CompanyName == "Amazon").CompanyID},
                new Tag{JobID = 4, CompanyID = companies.Single(c => c.CompanyName == "Microsoft").CompanyID}
            };
            
            context.Tags.AddRange(tags);
            context.SaveChanges();

            foreach (Tag t in tags)
            {
                var tagInDataBase = context.Tags.Where(s => s.Job.ID == t.JobID && s.Company.CompanyID == t.CompanyID).SingleOrDefault();

                if (tagInDataBase == null)
                {
                    context.Tags.Add(t);
                }
            }

            context.SaveChanges();
        }
    }
}