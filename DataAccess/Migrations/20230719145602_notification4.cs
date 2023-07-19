using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class notification4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CustomerPeyGiries_AspNetUsers_IdUserAddNavigationId",
                table: "CustomerPeyGiries");

            migrationBuilder.DropForeignKey(
                name: "FK_user_CustomerPeyGiry_User",
                table: "CustomerPeyGiries");

            migrationBuilder.RenameColumn(
                name: "IdUserAddNavigationId",
                table: "CustomerPeyGiries",
                newName: "IdUserNavigationId");

            migrationBuilder.RenameIndex(
                name: "IX_CustomerPeyGiries_IdUserAddNavigationId",
                table: "CustomerPeyGiries",
                newName: "IX_CustomerPeyGiries_IdUserNavigationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Add_CustomerPeyGiry_User",
                table: "CustomerPeyGiries",
                column: "IdUserAdded",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerPeyGiries_AspNetUsers_IdUserNavigationId",
                table: "CustomerPeyGiries",
                column: "IdUserNavigationId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Add_CustomerPeyGiry_User",
                table: "CustomerPeyGiries");

            migrationBuilder.DropForeignKey(
                name: "FK_CustomerPeyGiries_AspNetUsers_IdUserNavigationId",
                table: "CustomerPeyGiries");

            migrationBuilder.RenameColumn(
                name: "IdUserNavigationId",
                table: "CustomerPeyGiries",
                newName: "IdUserAddNavigationId");

            migrationBuilder.RenameIndex(
                name: "IX_CustomerPeyGiries_IdUserNavigationId",
                table: "CustomerPeyGiries",
                newName: "IX_CustomerPeyGiries_IdUserAddNavigationId");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerPeyGiries_AspNetUsers_IdUserAddNavigationId",
                table: "CustomerPeyGiries",
                column: "IdUserAddNavigationId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_user_CustomerPeyGiry_User",
                table: "CustomerPeyGiries",
                column: "IdUserAdded",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
