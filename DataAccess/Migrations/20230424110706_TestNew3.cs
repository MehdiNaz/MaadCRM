using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class TestNew3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CustomerNotes_Products_ProductId",
                table: "CustomerNotes");

            migrationBuilder.DropIndex(
                name: "IX_CustomerNotes_ProductId",
                table: "CustomerNotes");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "CustomerNotes");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerNotes_IdProduct",
                table: "CustomerNotes",
                column: "IdProduct");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerNote_Product",
                table: "CustomerNotes",
                column: "IdProduct",
                principalTable: "Products",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CustomerNote_Product",
                table: "CustomerNotes");

            migrationBuilder.DropIndex(
                name: "IX_CustomerNotes_IdProduct",
                table: "CustomerNotes");

            migrationBuilder.AddColumn<string>(
                name: "ProductId",
                table: "CustomerNotes",
                type: "character varying(26)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CustomerNotes_ProductId",
                table: "CustomerNotes",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerNotes_Products_ProductId",
                table: "CustomerNotes",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id");
        }
    }
}
