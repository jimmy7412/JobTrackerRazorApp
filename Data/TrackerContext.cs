using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using JobTrackerRazorApp.Models;

namespace JobTrackerRazorApp.Data
{
    public class TrackerContext : DbContext
    {
        public TrackerContext (DbContextOptions<TrackerContext> options)
            : base(options)
        {
        }

        public DbSet<Job> Jobs { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Company> Companies { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Company>().ToTable("Company");
            modelBuilder.Entity<Job>().ToTable("Job");
            modelBuilder.Entity<Tag>().ToTable("Tag");
        }
    }
}
