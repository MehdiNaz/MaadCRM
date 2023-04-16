using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class LastUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Setting",
                table: "Settings");

            migrationBuilder.DropColumn(
                name: "SanAt",
                table: "SanAts");

            migrationBuilder.DropColumn(
                name: "ProductCustomerFavoritesList",
                table: "ProductCustomerFavoritesLists");

            migrationBuilder.DropColumn(
                name: "Plan",
                table: "Plans");

            migrationBuilder.DropColumn(
                name: "Log",
                table: "Logs");

            migrationBuilder.DropColumn(
                name: "Country",
                table: "Countries");

            migrationBuilder.DropColumn(
                name: "ContactsEmailAddress",
                table: "ContactsEmailAddress");

            migrationBuilder.DropColumn(
                name: "CategoryAttribute",
                table: "CategoryAttributes");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Setting",
                table: "Settings",
                type: "character varying(26)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "SanAt",
                table: "SanAts",
                type: "character varying(26)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ProductCustomerFavoritesList",
                table: "ProductCustomerFavoritesLists",
                type: "character varying(26)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Plan",
                table: "Plans",
                type: "character varying(26)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Log",
                table: "Logs",
                type: "character varying(26)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Country",
                table: "Countries",
                type: "character varying(26)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ContactsEmailAddress",
                table: "ContactsEmailAddress",
                type: "character varying(26)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CategoryAttribute",
                table: "CategoryAttributes",
                type: "character varying(26)",
                nullable: false,
                defaultValue: "");
        }
    }
}
