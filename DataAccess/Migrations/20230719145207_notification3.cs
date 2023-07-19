using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class notification3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CustomerPeyGiries_AspNetUsers_IdUserAddNavigationId",
                table: "CustomerPeyGiries");

            migrationBuilder.AlterColumn<string>(
                name: "IdUserAddNavigationId",
                table: "CustomerPeyGiries",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerPeyGiries_AspNetUsers_IdUserAddNavigationId",
                table: "CustomerPeyGiries",
                column: "IdUserAddNavigationId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CustomerPeyGiries_AspNetUsers_IdUserAddNavigationId",
                table: "CustomerPeyGiries");

            migrationBuilder.AlterColumn<string>(
                name: "IdUserAddNavigationId",
                table: "CustomerPeyGiries",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerPeyGiries_AspNetUsers_IdUserAddNavigationId",
                table: "CustomerPeyGiries",
                column: "IdUserAddNavigationId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
