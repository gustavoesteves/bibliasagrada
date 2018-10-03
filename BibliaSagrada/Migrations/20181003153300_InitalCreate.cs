using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BibliaSagrada.Migrations
{
    public partial class InitalCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BibleUsers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Book = table.Column<int>(nullable: false),
                    Charpter = table.Column<int>(nullable: false),
                    Vercicle = table.Column<int>(nullable: false),
                    NumbersVercicle = table.Column<int>(nullable: false),
                    ApplicationUserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BibleUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BibleUsers_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Number = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Charpters",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Number = table.Column<int>(nullable: false),
                    BookId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Charpters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Charpters_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Vercicles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Number = table.Column<int>(nullable: false),
                    Text = table.Column<string>(nullable: false),
                    CharpterId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vercicles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Vercicles_Charpters_CharpterId",
                        column: x => x.CharpterId,
                        principalTable: "Charpters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BibleUsers_ApplicationUserId",
                table: "BibleUsers",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Charpters_BookId",
                table: "Charpters",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_Vercicles_CharpterId",
                table: "Vercicles",
                column: "CharpterId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BibleUsers");

            migrationBuilder.DropTable(
                name: "Vercicles");

            migrationBuilder.DropTable(
                name: "Charpters");

            migrationBuilder.DropTable(
                name: "Books");
        }
    }
}
