using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class attribute : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CustomerAttribute");

            migrationBuilder.CreateTable(
                name: "AttributesCustomer",
                columns: table => new
                {
                    Id = table.Column<string>(type: "character varying(26)", nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    Value = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    FilePath = table.Column<string>(type: "text", nullable: true),
                    IdAttributeOption = table.Column<string>(type: "character varying(26)", nullable: true),
                    IdCustomer = table.Column<string>(type: "character varying(26)", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DateLastUpdate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Version = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AttributesCustomer", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AttributeOption_AttributesCustomer",
                        column: x => x.IdAttributeOption,
                        principalTable: "AttributeOptions",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Customer_AttributesCustomer",
                        column: x => x.IdCustomer,
                        principalTable: "Customers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_AttributesCustomer_IdAttributeOption",
                table: "AttributesCustomer",
                column: "IdAttributeOption");

            migrationBuilder.CreateIndex(
                name: "IX_AttributesCustomer_IdCustomer",
                table: "AttributesCustomer",
                column: "IdCustomer");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AttributesCustomer");

            migrationBuilder.CreateTable(
                name: "CustomerAttribute",
                columns: table => new
                {
                    Id = table.Column<string>(type: "character varying(26)", nullable: false),
                    IdAttributeOptionNavigationId = table.Column<string>(type: "character varying(26)", nullable: true),
                    IdCustomerNavigationId = table.Column<string>(type: "character varying(26)", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DateLastUpdate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    FilePath = table.Column<string>(type: "text", nullable: true),
                    IdAttributeOption = table.Column<string>(type: "character varying(26)", nullable: true),
                    IdCustomer = table.Column<string>(type: "character varying(26)", nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    Value = table.Column<string>(type: "text", nullable: false),
                    Version = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerAttribute", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CustomerAttribute_AttributeOptions_IdAttributeOptionNavigat~",
                        column: x => x.IdAttributeOptionNavigationId,
                        principalTable: "AttributeOptions",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CustomerAttribute_Customers_IdCustomerNavigationId",
                        column: x => x.IdCustomerNavigationId,
                        principalTable: "Customers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_CustomerAttribute_IdAttributeOptionNavigationId",
                table: "CustomerAttribute",
                column: "IdAttributeOptionNavigationId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerAttribute_IdCustomerNavigationId",
                table: "CustomerAttribute",
                column: "IdCustomerNavigationId");
        }
    }
}
