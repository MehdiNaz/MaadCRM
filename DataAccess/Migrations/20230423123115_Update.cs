using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class Update : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Add_Customer_User",
                table: "CustomerNotes");

            migrationBuilder.AddForeignKey(
                name: "FK_Update_CustomerPeyGiry_User",
                table: "CustomerPeyGiries",
                column: "IdUserAdded",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Update_CustomerPeyGiry_User",
                table: "CustomerPeyGiries");

            migrationBuilder.AddForeignKey(
                name: "FK_Add_Customer_User",
                table: "CustomerNotes",
                column: "IdUserAdded",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
