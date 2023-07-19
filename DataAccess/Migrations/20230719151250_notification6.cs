using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class notification6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                name: "IX_CustomerPeyGiries_IdUserNavigationId",
                table: "CustomerPeyGiries");

            migrationBuilder.DropIndex(
                name: "IX_CustomerPeyGiries_IdUserUpdateNavigationId",
                table: "CustomerPeyGiries");

            migrationBuilder.DropColumn(
                name: "IdUser",
                table: "CustomerPeyGiries");

            migrationBuilder.DropColumn(
                name: "IdUserAddNavigationId",
                table: "CustomerPeyGiries");

            migrationBuilder.DropColumn(
                name: "IdUserAdded",
                table: "CustomerPeyGiries");

            migrationBuilder.DropColumn(
                name: "IdUserNavigationId",
                table: "CustomerPeyGiries");

            migrationBuilder.DropColumn(
                name: "IdUserUpdateNavigationId",
                table: "CustomerPeyGiries");

            migrationBuilder.DropColumn(
                name: "IdUserUpdated",
                table: "CustomerPeyGiries");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "IdUser",
                table: "CustomerPeyGiries",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IdUserAddNavigationId",
                table: "CustomerPeyGiries",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IdUserAdded",
                table: "CustomerPeyGiries",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "IdUserNavigationId",
                table: "CustomerPeyGiries",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IdUserUpdateNavigationId",
                table: "CustomerPeyGiries",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IdUserUpdated",
                table: "CustomerPeyGiries",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerPeyGiries_IdUserAddNavigationId",
                table: "CustomerPeyGiries",
                column: "IdUserAddNavigationId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerPeyGiries_IdUserNavigationId",
                table: "CustomerPeyGiries",
                column: "IdUserNavigationId");

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
    }
}
