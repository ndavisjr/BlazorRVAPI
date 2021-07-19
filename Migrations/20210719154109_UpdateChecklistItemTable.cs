using Microsoft.EntityFrameworkCore.Migrations;

namespace BlazorRVAPI.Migrations
{
    public partial class UpdateChecklistItemTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Priority",
                table: "ChecklistItems",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Priority",
                table: "ChecklistItems");
        }
    }
}
