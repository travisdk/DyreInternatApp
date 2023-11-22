using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DyreInternatApp.Migrations
{
    /// <inheritdoc />
    public partial class PricePrecision : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "Animals",
                type: "decimal(8,0)",
                precision: 8,
                scale: 0,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a227247c-5650-4b39-b1ad-83f0db7292e2",
                column: "ConcurrencyStamp",
                value: "4df01192-abfd-4c21-86a2-b95e621ccf0f");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "de450d59-55f6-4bbf-9d3b-2425b46bb861",
                column: "ConcurrencyStamp",
                value: "6c0a9050-97d0-4328-9be1-f9efed07ee39");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "Animals",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(8,0)",
                oldPrecision: 8,
                oldScale: 0);

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
    }
}
