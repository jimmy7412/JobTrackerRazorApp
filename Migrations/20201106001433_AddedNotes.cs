using Microsoft.EntityFrameworkCore.Migrations;

namespace JobTrackerRazorApp.Migrations
{
    public partial class AddedNotes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Notes",
                table: "Job",
                maxLength: 100000,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Notes",
                table: "Job");
        }
    }
}
