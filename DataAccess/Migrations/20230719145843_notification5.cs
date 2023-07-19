using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class notification5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Add_CustomerPeyGiry_User",
                table: "CustomerPeyGiries");

            migrationBuilder.DropForeignKey(
                name: "FK_CustomerPeyGiries_AspNetUsers_IdUserNavigationId",
                table: "CustomerPeyGiries");

            migrationBuilder.DropForeignKey(
                name: "FK_Update_CustomerPeyGiry_User",
                table: "CustomerPeyGiries");

            migrationBuilder.DropIndex(
                name: "IX_CustomerPeyGiries_IdUserAdded",
                table: "CustomerPeyGiries");

            migrationBuilder.DropIndex(
                name: "IX_CustomerPeyGiries_IdUserUpdated",
                table: "CustomerPeyGiries");

            migrationBuilder.AlterColumn<string>(
                name: "IdUserNavigationId",
                table: "CustomerPeyGiries",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddColumn<string>(
                name: "IdUserAddNavigationId",
                table: "CustomerPeyGiries",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IdUserUpdateNavigationId",
                table: "CustomerPeyGiries",
                type: "text",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CustomerPeyGiries_IdUserAddNavigationId",
                table: "CustomerPeyGiries",
                column: "IdUserAddNavigationId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerPeyGiries_IdUserUpdateNavigationId",
                table: "CustomerPeyGiries",
                column: "IdUserUpdateNavigationId");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerPeyGiries_AspNetUsers_IdUserAddNavigationId",
                table: "CustomerPeyGiries",
                column: "IdUserAddNavigationId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerPeyGiries_AspNetUsers_IdUserNavigationId",
                table: "CustomerPeyGiries",
                column: "IdUserNavigationId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerPeyGiries_AspNetUsers_IdUserUpdateNavigationId",
                table: "CustomerPeyGiries",
                column: "IdUserUpdateNavigationId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CustomerPeyGiries_AspNetUsers_IdUserAddNavigationId",
                table: "CustomerPeyGiries");

            migrationBuilder.DropForeignKey(
                name: "FK_CustomerPeyGiries_AspNetUsers_IdUserNavigationId",
                table: "CustomerPeyGiries");

            migrationBuilder.DropForeignKey(
                name: "FK_CustomerPeyGiries_AspNetUsers_IdUserUpdateNavigationId",
                table: "CustomerPeyGiries");

            migrationBuilder.DropIndex(
                name: "IX_CustomerPeyGiries_IdUserAddNavigationId",
                table: "CustomerPeyGiries");

            migrationBuilder.DropIndex(
                name: "IX_CustomerPeyGiries_IdUserUpdateNavigationId",
                table: "CustomerPeyGiries");

            migrationBuilder.DropColumn(
                name: "IdUserAddNavigationId",
                table: "CustomerPeyGiries");

            migrationBuilder.DropColumn(
                name: "IdUserUpdateNavigationId",
                table: "CustomerPeyGiries");

            migrationBuilder.AlterColumn<string>(
                name: "IdUserNavigationId",
                table: "CustomerPeyGiries",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CustomerPeyGiries_IdUserAdded",
                table: "CustomerPeyGiries",
                column: "IdUserAdded");

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
                name: "FK_CustomerPeyGiries_AspNetUsers_IdUserNavigationId",
                table: "CustomerPeyGiries",
                column: "IdUserNavigationId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Update_CustomerPeyGiry_User",
                table: "CustomerPeyGiries",
                column: "IdUserUpdated",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
