using Microsoft.EntityFrameworkCore.Migrations;

namespace EFRepository.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Vehicles",
                columns: table => new
                {
                    Series = table.Column<string>(nullable: false),
                    Number = table.Column<long>(nullable: false),
                    Passengers = table.Column<byte>(nullable: false),
                    Color = table.Column<string>(nullable: false),
                    Type = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicles", x => new { x.Series, x.Number });
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Vehicles");
        }
    }
}
