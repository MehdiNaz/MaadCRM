using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class Update1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CustomerPeyGiries_AspNetUsers_IdUserUpdateNavigationId",
                table: "CustomerPeyGiries");

            migrationBuilder.DropForeignKey(
                name: "FK_Update_CustomerPeyGiry_User",
                table: "CustomerPeyGiries");

            migrationBuilder.DropIndex(
                name: "IX_CustomerPeyGiries_IdUserUpdateNavigationId",
                table: "CustomerPeyGiries");

            migrationBuilder.DropColumn(
                name: "IdUserUpdateNavigationId",
                table: "CustomerPeyGiries");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerPeyGiries_IdUserUpdated",
                table: "CustomerPeyGiries",
                column: "IdUserUpdated");

            migrationBuilder.AddForeignKey(
                name: "FK_Add_CustomerPeyGiry_User",
                table: "CustomerPeyGiries",
                column: "IdUserAdded",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Update_CustomerPeyGiry_User",
                table: "CustomerPeyGiries",
                column: "IdUserUpdated",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Add_CustomerPeyGiry_User",
                table: "CustomerPeyGiries");

            migrationBuilder.DropForeignKey(
                name: "FK_Update_CustomerPeyGiry_User",
                table: "CustomerPeyGiries");

            migrationBuilder.DropIndex(
                name: "IX_CustomerPeyGiries_IdUserUpdated",
                table: "CustomerPeyGiries");

            migrationBuilder.AddColumn<string>(
                name: "IdUserUpdateNavigationId",
                table: "CustomerPeyGiries",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerPeyGiries_IdUserUpdateNavigationId",
                table: "CustomerPeyGiries",
                column: "IdUserUpdateNavigationId");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerPeyGiries_AspNetUsers_IdUserUpdateNavigationId",
                table: "CustomerPeyGiries",
                column: "IdUserUpdateNavigationId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Update_CustomerPeyGiry_User",
                table: "CustomerPeyGiries",
                column: "IdUserAdded",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
