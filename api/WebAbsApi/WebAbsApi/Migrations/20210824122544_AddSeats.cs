using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAbsApi.Migrations
{
    public partial class AddSeats : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Seat",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Row = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Column = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsBooked = table.Column<bool>(type: "bit", nullable: false),
                    FlightSectionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Seat", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Seat_FlightSections_FlightSectionId",
                        column: x => x.FlightSectionId,
                        principalTable: "FlightSections",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Seat_FlightSectionId",
                table: "Seat",
                column: "FlightSectionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Seat");
        }
    }
}
