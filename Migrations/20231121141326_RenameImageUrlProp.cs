using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DyreInternatApp.Migrations
{
    /// <inheritdoc />
    public partial class RenameImageUrlProp : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ImageId",
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ImageUrl",
                table: "Animals",
                newName: "ImageId");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a227247c-5650-4b39-b1ad-83f0db7292e2",
                column: "ConcurrencyStamp",
                value: "435b1b58-75e1-4c0a-85da-7df00426bac6");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "de450d59-55f6-4bbf-9d3b-2425b46bb861",
                column: "ConcurrencyStamp",
                value: "f26ea5cd-e31f-4bbf-8b7e-c78075b7abf3");
        }
    }
}
