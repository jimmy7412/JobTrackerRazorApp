using Microsoft.EntityFrameworkCore.Migrations;

namespace JobTrackerRazorApp.Migrations
{
    public partial class RecruiterNotes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Notes",
                table: "Recruiter",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Notes",
                table: "Recruiter");
        }
    }
}
