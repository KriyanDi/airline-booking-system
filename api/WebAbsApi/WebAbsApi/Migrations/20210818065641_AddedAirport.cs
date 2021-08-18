using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAbsApi.Migrations
{
    public partial class AddedAirport : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Airports",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Airports", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Airports",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "AAY" },
                    { 2, "ABA" },
                    { 3, "MAC" },
                    { 4, "FSD" },
                    { 5, "ZAG" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Airports_Name",
                table: "Airports",
                column: "Name",
                unique: true,
                filter: "[Name] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Airports");
        }
    }
}
