using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAbsApi.Migrations
{
    public partial class AddUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 113);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 561);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 2097);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 3045);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 3682);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 3787);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 4005);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 4207);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 4247);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 4331);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 4858);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 6028);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 7118);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 7179);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 7215);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 7262);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 8094);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 8737);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 9790);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 9865);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "b3e5a105-d61e-4d28-9d67-d53ddfb18371", "faba502c-0a49-476e-b48f-425e140f52a3", "User", "USER" },
                    { "8f148bc0-de28-4203-b70d-0fb18c24c896", "e24239de-43b5-4439-8b07-264cb13158f8", "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Column", "FlightSectionId", "IsBooked", "Row" },
                values: new object[,]
                {
                    { 1594, "B", 1, false, "4" },
                    { 5342, "A", 1, false, "4" },
                    { 5060, "D", 1, false, "3" },
                    { 6211, "C", 1, false, "3" },
                    { 6035, "B", 1, false, "3" },
                    { 7574, "A", 1, false, "3" },
                    { 141, "D", 1, false, "2" },
                    { 4001, "C", 1, false, "2" },
                    { 4836, "B", 1, false, "2" },
                    { 6602, "A", 1, false, "2" },
                    { 6641, "D", 1, false, "1" },
                    { 1137, "C", 1, false, "1" },
                    { 3647, "B", 1, false, "1" },
                    { 3877, "A", 1, false, "1" },
                    { 9428, "D", 1, false, "0" },
                    { 5788, "C", 1, false, "0" },
                    { 1871, "B", 1, false, "0" },
                    { 7758, "A", 1, false, "0" },
                    { 94, "C", 1, false, "4" },
                    { 3089, "D", 1, false, "4" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8f148bc0-de28-4203-b70d-0fb18c24c896");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b3e5a105-d61e-4d28-9d67-d53ddfb18371");

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 94);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 141);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 1137);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 1594);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 1871);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 3089);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 3647);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 3877);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 4001);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 4836);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 5060);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 5342);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 5788);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 6035);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 6211);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 6602);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 6641);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 7574);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 7758);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 9428);

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Column", "FlightSectionId", "IsBooked", "Row" },
                values: new object[,]
                {
                    { 7118, "A", 1, false, "0" },
                    { 4858, "B", 1, false, "4" },
                    { 3682, "A", 1, false, "4" },
                    { 4331, "D", 1, false, "3" },
                    { 9790, "C", 1, false, "3" },
                    { 6028, "B", 1, false, "3" },
                    { 4207, "A", 1, false, "3" },
                    { 7179, "D", 1, false, "2" },
                    { 7262, "C", 1, false, "2" },
                    { 8737, "B", 1, false, "2" },
                    { 7215, "A", 1, false, "2" },
                    { 561, "D", 1, false, "1" },
                    { 4005, "C", 1, false, "1" },
                    { 3787, "B", 1, false, "1" },
                    { 8094, "A", 1, false, "1" },
                    { 113, "D", 1, false, "0" },
                    { 3045, "C", 1, false, "0" },
                    { 4247, "B", 1, false, "0" },
                    { 2097, "C", 1, false, "4" },
                    { 9865, "D", 1, false, "4" }
                });
        }
    }
}
