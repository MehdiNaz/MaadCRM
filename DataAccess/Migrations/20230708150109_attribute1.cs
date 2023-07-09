using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class attribute1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Value",
                table: "AttributesCustomer",
                newName: "ValueString");

            migrationBuilder.AddColumn<bool>(
                name: "ValueBool",
                table: "AttributesCustomer",
                type: "boolean",
                nullable: true);

            migrationBuilder.AddColumn<DateOnly>(
                name: "ValueDate",
                table: "AttributesCustomer",
                type: "date",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ValueNumber",
                table: "AttributesCustomer",
                type: "integer",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ValueBool",
                table: "AttributesCustomer");

            migrationBuilder.DropColumn(
                name: "ValueDate",
                table: "AttributesCustomer");

            migrationBuilder.DropColumn(
                name: "ValueNumber",
                table: "AttributesCustomer");

            migrationBuilder.RenameColumn(
                name: "ValueString",
                table: "AttributesCustomer",
                newName: "Value");
        }
    }
}
