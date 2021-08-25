using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAbsApi.Migrations
{
    public partial class AddAirportAirlineFlightFlightsectionSeat : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Airlines",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Airlines", x => x.Id);
                });

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

            migrationBuilder.CreateTable(
                name: "Flights",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FlightNumber = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AirlineId = table.Column<int>(type: "int", nullable: false),
                    OriginId = table.Column<int>(type: "int", nullable: false),
                    DestinationId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Flights", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Flights_Airlines_AirlineId",
                        column: x => x.AirlineId,
                        principalTable: "Airlines",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Flights_Airports_DestinationId",
                        column: x => x.DestinationId,
                        principalTable: "Airports",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Flights_Airports_OriginId",
                        column: x => x.OriginId,
                        principalTable: "Airports",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "FlightSections",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SeatClass = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    FlightId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FlightSections", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FlightSections_Flights_FlightId",
                        column: x => x.FlightId,
                        principalTable: "Flights",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Seats",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Row = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Column = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    IsBooked = table.Column<bool>(type: "bit", nullable: false),
                    FlightSectionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Seats", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Seats_FlightSections_FlightSectionId",
                        column: x => x.FlightSectionId,
                        principalTable: "FlightSections",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Airlines",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "DELTA" },
                    { 2, "SSSKY" },
                    { 3, "FLYSS" },
                    { 4, "ARB" },
                    { 5, "WIZZ" }
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

            migrationBuilder.InsertData(
                table: "Flights",
                columns: new[] { "Id", "AirlineId", "Date", "DestinationId", "FlightNumber", "OriginId" },
                values: new object[] { 1, 2, new DateTime(2021, 5, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, "111111111", 1 });

            migrationBuilder.InsertData(
                table: "Flights",
                columns: new[] { "Id", "AirlineId", "Date", "DestinationId", "FlightNumber", "OriginId" },
                values: new object[] { 2, 2, new DateTime(2021, 5, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "211111111", 5 });

            migrationBuilder.InsertData(
                table: "FlightSections",
                columns: new[] { "Id", "FlightId", "SeatClass" },
                values: new object[] { 1, 1, "FIRST" });

            migrationBuilder.InsertData(
                table: "FlightSections",
                columns: new[] { "Id", "FlightId", "SeatClass" },
                values: new object[] { 2, 1, "ECONOMY" });

            migrationBuilder.InsertData(
                table: "FlightSections",
                columns: new[] { "Id", "FlightId", "SeatClass" },
                values: new object[] { 3, 2, "BUSINESS" });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Column", "FlightSectionId", "IsBooked", "Row" },
                values: new object[,]
                {
                    { 8226, "A", 1, false, "0" },
                    { 3786, "B", 1, false, "4" },
                    { 1569, "A", 1, false, "4" },
                    { 4871, "D", 1, false, "3" },
                    { 226, "C", 1, false, "3" },
                    { 406, "B", 1, false, "3" },
                    { 1140, "A", 1, false, "3" },
                    { 7536, "D", 1, false, "2" },
                    { 2292, "C", 1, false, "2" },
                    { 244, "B", 1, false, "2" },
                    { 1458, "A", 1, false, "2" },
                    { 6108, "D", 1, false, "1" },
                    { 6424, "C", 1, false, "1" },
                    { 1213, "B", 1, false, "1" },
                    { 3520, "A", 1, false, "1" },
                    { 9754, "D", 1, false, "0" },
                    { 7435, "C", 1, false, "0" },
                    { 1486, "B", 1, false, "0" },
                    { 3512, "C", 1, false, "4" },
                    { 3972, "D", 1, false, "4" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Airlines_Name",
                table: "Airlines",
                column: "Name",
                unique: true,
                filter: "[Name] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Airports_Name",
                table: "Airports",
                column: "Name",
                unique: true,
                filter: "[Name] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Flights_AirlineId",
                table: "Flights",
                column: "AirlineId");

            migrationBuilder.CreateIndex(
                name: "IX_Flights_DestinationId",
                table: "Flights",
                column: "DestinationId");

            migrationBuilder.CreateIndex(
                name: "IX_Flights_FlightNumber",
                table: "Flights",
                column: "FlightNumber",
                unique: true,
                filter: "[FlightNumber] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Flights_OriginId",
                table: "Flights",
                column: "OriginId");

            migrationBuilder.CreateIndex(
                name: "IX_FlightSections_FlightId_SeatClass",
                table: "FlightSections",
                columns: new[] { "FlightId", "SeatClass" },
                unique: true,
                filter: "[SeatClass] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Seats_FlightSectionId_Row_Column",
                table: "Seats",
                columns: new[] { "FlightSectionId", "Row", "Column" },
                unique: true,
                filter: "[Row] IS NOT NULL AND [Column] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Seats");

            migrationBuilder.DropTable(
                name: "FlightSections");

            migrationBuilder.DropTable(
                name: "Flights");

            migrationBuilder.DropTable(
                name: "Airlines");

            migrationBuilder.DropTable(
                name: "Airports");
        }
    }
}
