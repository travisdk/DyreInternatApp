using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DyreInternatApp.Migrations
{
    /// <inheritdoc />
    public partial class RenameImageFileNameProp : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ImageUrl",
                table: "Animals",
                newName: "ImageFileName");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a227247c-5650-4b39-b1ad-83f0db7292e2",
                column: "ConcurrencyStamp",
                value: "e20bc4c8-1fd8-4e93-b276-e7dba4136697");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "de450d59-55f6-4bbf-9d3b-2425b46bb861",
                column: "ConcurrencyStamp",
                value: "e63a1e72-8d23-46ed-8132-73bbe23cd9b4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ImageFileName",
                table: "Animals",
                newName: "ImageUrl");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a227247c-5650-4b39-b1ad-83f0db7292e2",
                column: "ConcurrencyStamp",
                value: "8258093c-f2cb-4fed-ab19-015365aab8de");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "de450d59-55f6-4bbf-9d3b-2425b46bb861",
                column: "ConcurrencyStamp",
                value: "5a272c71-9fc2-4659-9ef4-bfae3f36650f");
        }
    }
}
