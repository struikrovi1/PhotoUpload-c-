using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Section1s",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Header = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Subheader = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhotoUrl = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Section1s", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Section2s",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Icon = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Header = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Section2s", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Section1s",
                columns: new[] { "Id", "Header", "PhotoUrl", "Subheader" },
                values: new object[] { 1, "Basliq", "test.jpg", "Sub Header" });

            migrationBuilder.InsertData(
                table: "Section2s",
                columns: new[] { "Id", "Description", "Header", "Icon" },
                values: new object[] { 1, "Test Desc", "Basliq", "icon.jpg" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Section1s");

            migrationBuilder.DropTable(
                name: "Section2s");
        }
    }
}
