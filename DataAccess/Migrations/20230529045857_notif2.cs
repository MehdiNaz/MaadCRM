using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class notif2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "IdUser",
                table: "Customers",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.CreateTable(
                name: "Notifications",
                columns: table => new
                {
                    Id = table.Column<string>(type: "character varying(26)", nullable: false),
                    NotificationType = table.Column<int>(type: "integer", nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    DateDue = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IdPeyGiry = table.Column<string>(type: "character varying(26)", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DateLastUpdate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    xmin = table.Column<uint>(type: "xid", rowVersion: true, nullable: false),
                    IdUserUpdated = table.Column<string>(type: "text", nullable: false),
                    IdUserAdded = table.Column<string>(type: "text", nullable: false),
                    IdUser = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notifications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Add_Notifications_User",
                        column: x => x.IdUserAdded,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Notifications_CustomerPeyGiry",
                        column: x => x.IdPeyGiry,
                        principalTable: "CustomerPeyGiries",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Notifications_User",
                        column: x => x.IdUser,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Update_Notifications_User",
                        column: x => x.IdUserUpdated,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_IdPeyGiry",
                table: "Notifications",
                column: "IdPeyGiry");

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_IdUser",
                table: "Notifications",
                column: "IdUser");

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_IdUserAdded",
                table: "Notifications",
                column: "IdUserAdded");

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_IdUserUpdated",
                table: "Notifications",
                column: "IdUserUpdated");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Notifications");

            migrationBuilder.AlterColumn<string>(
                name: "IdUser",
                table: "Customers",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);
        }
    }
}
