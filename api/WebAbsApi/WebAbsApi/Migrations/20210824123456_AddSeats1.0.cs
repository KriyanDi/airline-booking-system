using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAbsApi.Migrations
{
    public partial class AddSeats10 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Seat_FlightSectionId",
                table: "Seat");

            migrationBuilder.AlterColumn<string>(
                name: "Row",
                table: "Seat",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Column",
                table: "Seat",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "Seat",
                columns: new[] { "Id", "Column", "FlightSectionId", "IsBooked", "Row" },
                values: new object[,]
                {
                    { 7427, "A", 1, false, "0" },
                    { 2694, "B", 1, false, "4" },
                    { 8982, "A", 1, false, "4" },
                    { 1651, "D", 1, false, "3" },
                    { 4078, "C", 1, false, "3" },
                    { 2444, "B", 1, false, "3" },
                    { 5722, "A", 1, false, "3" },
                    { 3463, "D", 1, false, "2" },
                    { 7279, "C", 1, false, "2" },
                    { 1309, "B", 1, false, "2" },
                    { 922, "A", 1, false, "2" },
                    { 1108, "D", 1, false, "1" },
                    { 2069, "C", 1, false, "1" },
                    { 8451, "B", 1, false, "1" },
                    { 1909, "A", 1, false, "1" },
                    { 8018, "D", 1, false, "0" },
                    { 1341, "C", 1, false, "0" },
                    { 7590, "B", 1, false, "0" },
                    { 1826, "C", 1, false, "4" },
                    { 9749, "D", 1, false, "4" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Seat_FlightSectionId_Row_Column",
                table: "Seat",
                columns: new[] { "FlightSectionId", "Row", "Column" },
                unique: true,
                filter: "[Row] IS NOT NULL AND [Column] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Seat_FlightSectionId_Row_Column",
                table: "Seat");

            migrationBuilder.DeleteData(
                table: "Seat",
                keyColumn: "Id",
                keyValue: 922);

            migrationBuilder.DeleteData(
                table: "Seat",
                keyColumn: "Id",
                keyValue: 1108);

            migrationBuilder.DeleteData(
                table: "Seat",
                keyColumn: "Id",
                keyValue: 1309);

            migrationBuilder.DeleteData(
                table: "Seat",
                keyColumn: "Id",
                keyValue: 1341);

            migrationBuilder.DeleteData(
                table: "Seat",
                keyColumn: "Id",
                keyValue: 1651);

            migrationBuilder.DeleteData(
                table: "Seat",
                keyColumn: "Id",
                keyValue: 1826);

            migrationBuilder.DeleteData(
                table: "Seat",
                keyColumn: "Id",
                keyValue: 1909);

            migrationBuilder.DeleteData(
                table: "Seat",
                keyColumn: "Id",
                keyValue: 2069);

            migrationBuilder.DeleteData(
                table: "Seat",
                keyColumn: "Id",
                keyValue: 2444);

            migrationBuilder.DeleteData(
                table: "Seat",
                keyColumn: "Id",
                keyValue: 2694);

            migrationBuilder.DeleteData(
                table: "Seat",
                keyColumn: "Id",
                keyValue: 3463);

            migrationBuilder.DeleteData(
                table: "Seat",
                keyColumn: "Id",
                keyValue: 4078);

            migrationBuilder.DeleteData(
                table: "Seat",
                keyColumn: "Id",
                keyValue: 5722);

            migrationBuilder.DeleteData(
                table: "Seat",
                keyColumn: "Id",
                keyValue: 7279);

            migrationBuilder.DeleteData(
                table: "Seat",
                keyColumn: "Id",
                keyValue: 7427);

            migrationBuilder.DeleteData(
                table: "Seat",
                keyColumn: "Id",
                keyValue: 7590);

            migrationBuilder.DeleteData(
                table: "Seat",
                keyColumn: "Id",
                keyValue: 8018);

            migrationBuilder.DeleteData(
                table: "Seat",
                keyColumn: "Id",
                keyValue: 8451);

            migrationBuilder.DeleteData(
                table: "Seat",
                keyColumn: "Id",
                keyValue: 8982);

            migrationBuilder.DeleteData(
                table: "Seat",
                keyColumn: "Id",
                keyValue: 9749);

            migrationBuilder.AlterColumn<string>(
                name: "Row",
                table: "Seat",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Column",
                table: "Seat",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Seat_FlightSectionId",
                table: "Seat",
                column: "FlightSectionId");
        }
    }
}
