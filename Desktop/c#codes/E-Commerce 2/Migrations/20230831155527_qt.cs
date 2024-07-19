using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace E_Commerce_2.Migrations
{
    public partial class qt : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6382241f-29fa-49e3-9a55-ba7b6211e7ad");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ea5e1ee8-5248-4da3-a961-1c6a63586e43");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Categories",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "5864f842-cfbd-4113-ad70-cadc2fd6cdfa", "d0e645c7-c3c4-4c68-86e7-bbe791015e63", "CUSTOMER", "CUSTOMER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "8db3ba60-61af-4dc5-bd0e-256553e9294c", "81f4fd7e-7083-4359-9e75-def6222f9dbd", "Admin", "ADMIN" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5864f842-cfbd-4113-ad70-cadc2fd6cdfa");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8db3ba60-61af-4dc5-bd0e-256553e9294c");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Categories");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "6382241f-29fa-49e3-9a55-ba7b6211e7ad", "4257dce7-07db-48b1-9b56-ce6ea836d6b0", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "ea5e1ee8-5248-4da3-a961-1c6a63586e43", "5dac77a6-af5b-4b3b-83eb-8b30ea0b6e7a", "CUSTOMER", "CUSTOMER" });
        }
    }
}
