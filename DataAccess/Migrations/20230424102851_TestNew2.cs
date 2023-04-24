using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class TestNew2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CustomerNotes_Products_IdProductNavigationId",
                table: "CustomerNotes");

            migrationBuilder.RenameColumn(
                name: "IdProductNavigationId",
                table: "CustomerNotes",
                newName: "ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_CustomerNotes_IdProductNavigationId",
                table: "CustomerNotes",
                newName: "IX_CustomerNotes_ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerNotes_Products_ProductId",
                table: "CustomerNotes",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CustomerNotes_Products_ProductId",
                table: "CustomerNotes");

            migrationBuilder.RenameColumn(
                name: "ProductId",
                table: "CustomerNotes",
                newName: "IdProductNavigationId");

            migrationBuilder.RenameIndex(
                name: "IX_CustomerNotes_ProductId",
                table: "CustomerNotes",
                newName: "IX_CustomerNotes_IdProductNavigationId");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerNotes_Products_IdProductNavigationId",
                table: "CustomerNotes",
                column: "IdProductNavigationId",
                principalTable: "Products",
                principalColumn: "Id");
        }
    }
}
