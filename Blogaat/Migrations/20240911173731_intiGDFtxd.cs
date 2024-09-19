using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Blogaat.Migrations
{
    /// <inheritdoc />
    public partial class intiGDFtxd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "239670d0-48ec-4a2e-afff-7342f222df87");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a4775b2a-8fdf-4969-ade3-0ecca823f14f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "eb531904-2715-4de4-9813-c25edd2eed51");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "70071949-7a36-43c2-9850-49deb77756a5", "928a4783-b7af-4a4f-a718-698741bcdd24", "Admin", "admin" },
                    { "da0b3f67-5d63-49b7-a146-ec3836b0fc85", "9e12cec7-7a96-493f-b7c2-c1315f3cb2ac", "Super_Admin", "super_admin" },
                    { "ec8f86ad-8d82-4ca2-92d9-e1ded4f4e86f", "4a7e8575-4776-47ff-b318-346d97d37fa9", "User", "user" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "70071949-7a36-43c2-9850-49deb77756a5");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "da0b3f67-5d63-49b7-a146-ec3836b0fc85");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ec8f86ad-8d82-4ca2-92d9-e1ded4f4e86f");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "239670d0-48ec-4a2e-afff-7342f222df87", "f4c9b8a0-3ff3-4714-b15d-2a80b332fe56", "Super_Admin", "super_admin" },
                    { "a4775b2a-8fdf-4969-ade3-0ecca823f14f", "50f3cf49-d2c7-4235-89da-703091fc7eab", "Admin", "admin" },
                    { "eb531904-2715-4de4-9813-c25edd2eed51", "ffaf4db9-eec5-4369-a8ab-233c5123fa9d", "User", "user" }
                });
        }
    }
}
