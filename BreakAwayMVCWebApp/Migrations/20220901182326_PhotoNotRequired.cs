using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BreakAwayMVCWebApp.Migrations
{
    public partial class PhotoNotRequired : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<byte[]>(
                name: "Photo",
                table: "Destination",
                type: "varbinary(max)",
                nullable: true,
                oldClrType: typeof(byte[]),
                oldType: "varbinary(max)");

            migrationBuilder.InsertData(
                table: "Destination",
                columns: new[] { "DestinationId", "Country", "Description", "DestinationName", "Photo" },
                values: new object[] { 1, "USA", "Eco Tourism at it's best in the exquite Bali", "Indonesia", new byte[] { 0 } });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Destination",
                keyColumn: "DestinationId",
                keyValue: 1);

            migrationBuilder.AlterColumn<byte[]>(
                name: "Photo",
                table: "Destination",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0],
                oldClrType: typeof(byte[]),
                oldType: "varbinary(max)",
                oldNullable: true);
        }
    }
}
