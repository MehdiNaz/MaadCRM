using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class coworker : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "IdGroup",
                table: "AspNetUsers",
                type: "character varying(26)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "UserGroups",
                columns: table => new
                {
                    Id = table.Column<string>(type: "character varying(26)", nullable: false),
                    Title = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    DisplayOrder = table.Column<int>(type: "integer", nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    IdBusiness = table.Column<string>(type: "character varying(26)", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DateLastUpdate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    xmin = table.Column<uint>(type: "xid", rowVersion: true, nullable: false),
                    IdUserUpdated = table.Column<string>(type: "text", nullable: false),
                    IdUserAdded = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserGroups", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserGroup_Business",
                        column: x => x.IdBusiness,
                        principalTable: "Businesses",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UserGroup_User_Added",
                        column: x => x.IdUserAdded,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserGroup_User_Updated",
                        column: x => x.IdUserUpdated,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_IdGroup",
                table: "AspNetUsers",
                column: "IdGroup");

            migrationBuilder.CreateIndex(
                name: "IX_UserGroups_IdBusiness",
                table: "UserGroups",
                column: "IdBusiness");

            migrationBuilder.CreateIndex(
                name: "IX_UserGroups_IdUserAdded",
                table: "UserGroups",
                column: "IdUserAdded");

            migrationBuilder.CreateIndex(
                name: "IX_UserGroups_IdUserUpdated",
                table: "UserGroups",
                column: "IdUserUpdated");

            migrationBuilder.AddForeignKey(
                name: "FK_UserGroup_User",
                table: "AspNetUsers",
                column: "IdGroup",
                principalTable: "UserGroups",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserGroup_User",
                table: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "UserGroups");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_IdGroup",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "IdGroup",
                table: "AspNetUsers");
        }
    }
}
