using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DyreInternatApp.Migrations
{
    /// <inheritdoc />
    public partial class ImageIdAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c0a5af48-ebc2-492d-be11-3e739e55bfb4");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d60c8477-1890-4311-adcf-7a7da061ac15");

            migrationBuilder.AddColumn<string>(
                name: "ImageId",
                table: "Animals",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "a227247c-5650-4b39-b1ad-83f0db7292e2", "cf44bde3-7239-447a-bc17-d872142412a8", "Admin", "ADMIN" },
                    { "de450d59-55f6-4bbf-9d3b-2425b46bb861", "cb79f1ea-e595-468e-9a88-5df6a75642cb", "Customer", "CUSTOMER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a227247c-5650-4b39-b1ad-83f0db7292e2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "de450d59-55f6-4bbf-9d3b-2425b46bb861");

            migrationBuilder.DropColumn(
                name: "ImageId",
                table: "Animals");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "c0a5af48-ebc2-492d-be11-3e739e55bfb4", "c0c87616-694e-4439-bdf2-cc3eea1d3fdd", "Admin", "ADMIN" },
                    { "d60c8477-1890-4311-adcf-7a7da061ac15", "ff76f67a-a3ec-48c7-a455-1cb126e6d17d", "Customer", "CUSTOMER" }
                });
        }
    }
}
