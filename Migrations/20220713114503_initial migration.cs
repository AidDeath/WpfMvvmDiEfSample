using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WpfMvvmDiEfSample.Migrations
{
    public partial class initialmigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Bands",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Genre = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bands", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Bands",
                columns: new[] { "Id", "Genre", "Name" },
                values: new object[] { 1, "Metal", "As I Lay Dying" });

            migrationBuilder.InsertData(
                table: "Bands",
                columns: new[] { "Id", "Genre", "Name" },
                values: new object[] { 2, "Alternative", "Metallica" });

            migrationBuilder.InsertData(
                table: "Bands",
                columns: new[] { "Id", "Genre", "Name" },
                values: new object[] { 3, "NewWave", "Hobostank" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bands");
        }
    }
}
