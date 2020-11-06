﻿// <auto-generated />
using System;
using JobTrackerRazorApp.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace JobTrackerRazorApp.Migrations
{
    [DbContext(typeof(TrackerContext))]
    partial class TrackerContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.7");

            modelBuilder.Entity("JobTrackerRazorApp.Models.Company", b =>
                {
                    b.Property<int>("CompanyID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("CompanyName")
                        .HasColumnType("TEXT")
                        .HasMaxLength(50);

                    b.Property<int>("SectorID")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("Size")
                        .HasColumnType("INTEGER");

                    b.HasKey("CompanyID");

                    b.HasIndex("SectorID");

                    b.ToTable("Company");
                });

            modelBuilder.Entity("JobTrackerRazorApp.Models.CompanyAssignment", b =>
                {
                    b.Property<int>("CompanyID")
                        .HasColumnType("INTEGER");

                    b.Property<int>("RecruiterID")
                        .HasColumnType("INTEGER");

                    b.HasKey("CompanyID", "RecruiterID");

                    b.HasIndex("RecruiterID");

                    b.ToTable("CompanyAssignment");
                });

            modelBuilder.Entity("JobTrackerRazorApp.Models.Job", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("ApplicationDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("City")
                        .HasColumnType("TEXT")
                        .HasMaxLength(50);

                    b.Property<int>("CompanyID")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Country")
                        .HasColumnType("TEXT")
                        .HasMaxLength(50);

                    b.Property<bool>("Interview")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("LastChecked")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("LastContact")
                        .HasColumnType("TEXT");

                    b.Property<string>("Notes")
                        .HasColumnType("TEXT")
                        .HasMaxLength(100000);

                    b.Property<bool>("Rejected")
                        .HasColumnType("INTEGER");

                    b.Property<string>("State")
                        .HasColumnType("TEXT")
                        .HasMaxLength(50);

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasMaxLength(50);

                    b.HasKey("ID");

                    b.HasIndex("CompanyID");

                    b.ToTable("Job");
                });

            modelBuilder.Entity("JobTrackerRazorApp.Models.Location", b =>
                {
                    b.Property<int>("RecruiterID")
                        .HasColumnType("INTEGER");

                    b.Property<string>("OfficeLocation")
                        .HasColumnType("TEXT")
                        .HasMaxLength(50);

                    b.HasKey("RecruiterID");

                    b.ToTable("Location");
                });

            modelBuilder.Entity("JobTrackerRazorApp.Models.Recruiter", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("FirstMidName")
                        .IsRequired()
                        .HasColumnName("FirstName")
                        .HasColumnType("TEXT")
                        .HasMaxLength(50);

                    b.Property<DateTime>("LastContactDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasMaxLength(50);

                    b.HasKey("ID");

                    b.ToTable("Recruiter");
                });

            modelBuilder.Entity("JobTrackerRazorApp.Models.Sector", b =>
                {
                    b.Property<int>("SectorID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<int?>("RecruiterID")
                        .HasColumnType("INTEGER");

                    b.HasKey("SectorID");

                    b.ToTable("Sector");
                });

            modelBuilder.Entity("JobTrackerRazorApp.Models.Tag", b =>
                {
                    b.Property<int>("TagID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CompanyID")
                        .HasColumnType("INTEGER");

                    b.Property<int>("JobID")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("Strength")
                        .HasColumnType("INTEGER");

                    b.HasKey("TagID");

                    b.HasIndex("CompanyID");

                    b.HasIndex("JobID");

                    b.ToTable("Tag");
                });

            modelBuilder.Entity("JobTrackerRazorApp.Models.Company", b =>
                {
                    b.HasOne("JobTrackerRazorApp.Models.Sector", "Sector")
                        .WithMany("Companies")
                        .HasForeignKey("SectorID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("JobTrackerRazorApp.Models.CompanyAssignment", b =>
                {
                    b.HasOne("JobTrackerRazorApp.Models.Company", "Company")
                        .WithMany("CompanyAssignments")
                        .HasForeignKey("CompanyID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("JobTrackerRazorApp.Models.Recruiter", "Recruiter")
                        .WithMany("CompanyAssignments")
                        .HasForeignKey("RecruiterID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("JobTrackerRazorApp.Models.Job", b =>
                {
                    b.HasOne("JobTrackerRazorApp.Models.Company", "Company")
                        .WithMany()
                        .HasForeignKey("CompanyID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("JobTrackerRazorApp.Models.Location", b =>
                {
                    b.HasOne("JobTrackerRazorApp.Models.Recruiter", "Recruiter")
                        .WithOne("Location")
                        .HasForeignKey("JobTrackerRazorApp.Models.Location", "RecruiterID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("JobTrackerRazorApp.Models.Tag", b =>
                {
                    b.HasOne("JobTrackerRazorApp.Models.Company", "Company")
                        .WithMany("Tags")
                        .HasForeignKey("CompanyID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("JobTrackerRazorApp.Models.Job", "Job")
                        .WithMany("Tags")
                        .HasForeignKey("JobID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
