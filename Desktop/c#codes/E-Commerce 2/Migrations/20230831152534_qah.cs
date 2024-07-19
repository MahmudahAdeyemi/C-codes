using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace E_Commerce_2.Migrations
{
    public partial class qah : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0a32114c-08b7-470e-a524-800520b2259b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3a307190-94fd-4797-a85e-fbda984da647");

            migrationBuilder.DropColumn(
                name: "Picture",
                table: "Products");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "7122ae5f-8502-4f18-afdd-246d9e11765e", "d27fa878-2806-468d-97a8-bf053b2d3f0b", "CUSTOMER", "CUSTOMER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "a9ac06c4-bf37-4b67-843f-ae4c3f80bb96", "f0a1ea84-c11e-47f0-b23e-48521cf44fae", "Admin", "ADMIN" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7122ae5f-8502-4f18-afdd-246d9e11765e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a9ac06c4-bf37-4b67-843f-ae4c3f80bb96");

            migrationBuilder.AddColumn<string>(
                name: "Picture",
                table: "Products",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "0a32114c-08b7-470e-a524-800520b2259b", "644ef6f4-c8c0-49bb-8b68-dfb678d0dcee", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "3a307190-94fd-4797-a85e-fbda984da647", "20977862-0239-48fd-9f9d-cd5329b857fd", "CUSTOMER", "CUSTOMER" });
        }
    }
}
