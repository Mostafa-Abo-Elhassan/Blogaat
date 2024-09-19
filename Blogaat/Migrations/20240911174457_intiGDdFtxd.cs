using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Blogaat.Migrations
{
    /// <inheritdoc />
    public partial class intiGDdFtxd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                    { "4d3d890b-28b3-489a-950b-9d5153d4f315", "36bcf23d-bee2-4294-9459-459af74aa058", "Super_Admin", "super_admin" },
                    { "5e5a6c8f-7502-4272-9a8c-d7c26f6048d3", "32d8482c-05d2-4f82-ba77-ac40d49266b7", "User", "user" },
                    { "8f6bf939-c3de-4ed8-8b50-48465ed24187", "30e79dd6-2c94-4ecc-bd50-8d6de303b740", "Admin", "admin" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4d3d890b-28b3-489a-950b-9d5153d4f315");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5e5a6c8f-7502-4272-9a8c-d7c26f6048d3");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8f6bf939-c3de-4ed8-8b50-48465ed24187");

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
    }
}
