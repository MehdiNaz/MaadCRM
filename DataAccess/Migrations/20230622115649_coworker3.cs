using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class coworker3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UserStatusType",
                table: "AspNetUsers",
                newName: "Status");

            migrationBuilder.RenameColumn(
                name: "CityId",
                table: "AspNetUsers",
                newName: "IdCity");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_IdCity",
                table: "AspNetUsers",
                column: "IdCity");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_City",
                table: "AspNetUsers",
                column: "IdCity",
                principalTable: "Cities",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_City",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_IdCity",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "Status",
                table: "AspNetUsers",
                newName: "UserStatusType");

            migrationBuilder.RenameColumn(
                name: "IdCity",
                table: "AspNetUsers",
                newName: "CityId");
        }
    }
}
