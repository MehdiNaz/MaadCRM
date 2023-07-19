﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class notification9 : Migration
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

            migrationBuilder.DropIndex(
                name: "IX_CustomerPeyGiries_IdUserAddNavigationId",
                table: "CustomerPeyGiries");

            migrationBuilder.DropColumn(
                name: "IdUserAddNavigationId",
                table: "CustomerPeyGiries");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerPeyGiries_IdUser",
                table: "CustomerPeyGiries",
                column: "IdUser");

            migrationBuilder.AddForeignKey(
                name: "FK_Add_CustomerPeyGiry_User",
                table: "CustomerPeyGiries",
                column: "IdUserAdded",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_user_CustomerPeyGiry_User",
                table: "CustomerPeyGiries",
                column: "IdUser",
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
                name: "FK_user_CustomerPeyGiry_User",
                table: "CustomerPeyGiries");

            migrationBuilder.DropIndex(
                name: "IX_CustomerPeyGiries_IdUser",
                table: "CustomerPeyGiries");

            migrationBuilder.AddColumn<string>(
                name: "IdUserAddNavigationId",
                table: "CustomerPeyGiries",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerPeyGiries_IdUserAddNavigationId",
                table: "CustomerPeyGiries",
                column: "IdUserAddNavigationId");

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