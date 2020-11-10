using Microsoft.EntityFrameworkCore.Migrations;

namespace JobTrackerRazorApp.Migrations
{
    public partial class CompanyNotes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Notes",
                table: "Company",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Notes",
                table: "Company");
        }
    }
}
