using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DyreInternatApp.Migrations
{
    /// <inheritdoc />
    public partial class test : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a227247c-5650-4b39-b1ad-83f0db7292e2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "de450d59-55f6-4bbf-9d3b-2425b46bb861");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "06943b44-5cea-4ae3-9405-5ccd842a28bb", "e009f5b0-67fc-4288-8b8f-c9f6a8688aa4", "Customer", "CUSTOMER" },
                    { "d1c2152d-1a76-4d2f-bf74-c18d84e4072b", "4f98ab71-25e1-452c-ad26-a89f916d329f", "Admin", "ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "06943b44-5cea-4ae3-9405-5ccd842a28bb");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d1c2152d-1a76-4d2f-bf74-c18d84e4072b");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "a227247c-5650-4b39-b1ad-83f0db7292e2", "cf44bde3-7239-447a-bc17-d872142412a8", "Admin", "ADMIN" },
                    { "de450d59-55f6-4bbf-9d3b-2425b46bb861", "cb79f1ea-e595-468e-9a88-5df6a75642cb", "Customer", "CUSTOMER" }
                });
        }
    }
}
