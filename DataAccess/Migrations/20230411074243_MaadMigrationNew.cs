using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class MaadMigrationNew : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NoteAttachment",
                table: "NoteAttachments");

            migrationBuilder.DropColumn(
                name: "NoteHashTag",
                table: "CustomerHashTags");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "NoteAttachment",
                table: "NoteAttachments",
                type: "character varying(26)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "NoteHashTag",
                table: "CustomerHashTags",
                type: "character varying(26)",
                nullable: false,
                defaultValue: "");
        }
    }
}
