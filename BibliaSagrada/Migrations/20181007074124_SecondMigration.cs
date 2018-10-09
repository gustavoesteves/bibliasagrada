using Microsoft.EntityFrameworkCore.Migrations;

namespace BibliaSagrada.Migrations
{
    public partial class SecondMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Inline",
                table: "BibleUsers",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Inline",
                table: "BibleUsers");
        }
    }
}
