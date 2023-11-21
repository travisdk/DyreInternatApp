using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DyreInternatApp.Migrations
{
    /// <inheritdoc />
    public partial class ShoppingCartItemsAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1df1653e-389c-4815-80f0-a4f1e206f094");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "909f3578-1645-4749-8998-b8a09e14e2a0");

            migrationBuilder.CreateTable(
                name: "ShoppingCartItems",
                columns: table => new
                {
                    ShoppingCartItemId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AnimalId = table.Column<int>(type: "int", nullable: false),
                    ShoppingCartId = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShoppingCartItems", x => x.ShoppingCartItemId);
                    table.ForeignKey(
                        name: "FK_ShoppingCartItems_Animals_AnimalId",
                        column: x => x.AnimalId,
                        principalTable: "Animals",
                        principalColumn: "AnimalId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "c0a5af48-ebc2-492d-be11-3e739e55bfb4", "c0c87616-694e-4439-bdf2-cc3eea1d3fdd", "Admin", "ADMIN" },
                    { "d60c8477-1890-4311-adcf-7a7da061ac15", "ff76f67a-a3ec-48c7-a455-1cb126e6d17d", "Customer", "CUSTOMER" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingCartItems_AnimalId",
                table: "ShoppingCartItems",
                column: "AnimalId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ShoppingCartItems");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c0a5af48-ebc2-492d-be11-3e739e55bfb4");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d60c8477-1890-4311-adcf-7a7da061ac15");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1df1653e-389c-4815-80f0-a4f1e206f094", "19495d28-8f11-426b-8d8a-72501b85552c", "Customer", "CUSTOMER" },
                    { "909f3578-1645-4749-8998-b8a09e14e2a0", "e0c1c3c1-eebb-4b0e-8abd-cdf146e8020d", "Admin", "ADMIN" }
                });
        }
    }
}
