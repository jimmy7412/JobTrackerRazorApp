using Microsoft.EntityFrameworkCore.Migrations;

namespace JobTrackerRazorApp.Migrations
{
    public partial class JobNumber : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "JobNumber",
                table: "Job",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "JobNumber",
                table: "Job");
        }
    }
}
