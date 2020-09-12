using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace JobTrackerRazorApp.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Recruiter",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    LastName = table.Column<string>(maxLength: 50, nullable: false),
                    FirstName = table.Column<string>(maxLength: 50, nullable: false),
                    LastContactDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recruiter", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Sector",
                columns: table => new
                {
                    SectorID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true),
                    RecruiterID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sector", x => x.SectorID);
                });

            migrationBuilder.CreateTable(
                name: "Location",
                columns: table => new
                {
                    RecruiterID = table.Column<int>(nullable: false),
                    OfficeLocation = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Location", x => x.RecruiterID);
                    table.ForeignKey(
                        name: "FK_Location_Recruiter_RecruiterID",
                        column: x => x.RecruiterID,
                        principalTable: "Recruiter",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Company",
                columns: table => new
                {
                    CompanyID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CompanyName = table.Column<string>(maxLength: 50, nullable: true),
                    Size = table.Column<int>(nullable: true),
                    SectorID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Company", x => x.CompanyID);
                    table.ForeignKey(
                        name: "FK_Company_Sector_SectorID",
                        column: x => x.SectorID,
                        principalTable: "Sector",
                        principalColumn: "SectorID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CompanyAssignment",
                columns: table => new
                {
                    RecruiterID = table.Column<int>(nullable: false),
                    CompanyID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyAssignment", x => new { x.CompanyID, x.RecruiterID });
                    table.ForeignKey(
                        name: "FK_CompanyAssignment_Company_CompanyID",
                        column: x => x.CompanyID,
                        principalTable: "Company",
                        principalColumn: "CompanyID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CompanyAssignment_Recruiter_RecruiterID",
                        column: x => x.RecruiterID,
                        principalTable: "Recruiter",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Job",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(maxLength: 50, nullable: false),
                    ApplicationDate = table.Column<DateTime>(nullable: false),
                    LastContact = table.Column<DateTime>(nullable: false),
                    LastChecked = table.Column<DateTime>(nullable: false),
                    City = table.Column<string>(maxLength: 50, nullable: true),
                    State = table.Column<string>(maxLength: 50, nullable: true),
                    Country = table.Column<string>(maxLength: 50, nullable: true),
                    Rejected = table.Column<bool>(nullable: false),
                    Interview = table.Column<bool>(nullable: false),
                    CompanyID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Job", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Job_Company_CompanyID",
                        column: x => x.CompanyID,
                        principalTable: "Company",
                        principalColumn: "CompanyID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tag",
                columns: table => new
                {
                    TagID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CompanyID = table.Column<int>(nullable: false),
                    JobID = table.Column<int>(nullable: false),
                    Strength = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tag", x => x.TagID);
                    table.ForeignKey(
                        name: "FK_Tag_Company_CompanyID",
                        column: x => x.CompanyID,
                        principalTable: "Company",
                        principalColumn: "CompanyID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tag_Job_JobID",
                        column: x => x.JobID,
                        principalTable: "Job",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Company_SectorID",
                table: "Company",
                column: "SectorID");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyAssignment_RecruiterID",
                table: "CompanyAssignment",
                column: "RecruiterID");

            migrationBuilder.CreateIndex(
                name: "IX_Job_CompanyID",
                table: "Job",
                column: "CompanyID");

            migrationBuilder.CreateIndex(
                name: "IX_Tag_CompanyID",
                table: "Tag",
                column: "CompanyID");

            migrationBuilder.CreateIndex(
                name: "IX_Tag_JobID",
                table: "Tag",
                column: "JobID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CompanyAssignment");

            migrationBuilder.DropTable(
                name: "Location");

            migrationBuilder.DropTable(
                name: "Tag");

            migrationBuilder.DropTable(
                name: "Recruiter");

            migrationBuilder.DropTable(
                name: "Job");

            migrationBuilder.DropTable(
                name: "Company");

            migrationBuilder.DropTable(
                name: "Sector");
        }
    }
}
