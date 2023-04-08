using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class TestMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Category_IdCategoryNavigationId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Company_IdCompanyNavigationId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Products_IdParrentNavigationProductId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_AspNetUsers_PlanId",
                table: "Users");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropTable(
                name: "Company");

            migrationBuilder.DropIndex(
                name: "IX_Products_IdCategoryNavigationId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_IdCompanyNavigationId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "SanAts");

            migrationBuilder.DropColumn(
                name: "DateEnd",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "DateStart",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "IdCategory",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "IdCategoryNavigationId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "IdCompany",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "IdCompanyNavigationId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "IdParent",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Mablagh",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "MaxSellPerPerson",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "MinSell",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "MinSellPerPerson",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Pardakht",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Published",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "SpecialOffer",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Takhfif",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "TakhfifMePerent",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "TakhfifPercent",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "ProductCustomerFavoritesLists");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "PhoneNumbers");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "PeyGiryAttachments");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "NoteAttachments");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "EmailAddresses");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "CustomersAddresses");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "CustomerPeyGiries");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "CustomerNotes");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "CustomerHashTags");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "CustomerCategories");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "ContactsEmailAddress");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Contacts");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "ContactPhoneNumbers");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "ContactGroups");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Cities");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "AttributeOptions");

            migrationBuilder.RenameColumn(
                name: "PlanId",
                table: "Visit",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "IsShown",
                table: "Users",
                newName: "UserStatus");

            migrationBuilder.RenameColumn(
                name: "PlanId",
                table: "Users",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "IsShown",
                table: "SanAts",
                newName: "SanAtStatus");

            migrationBuilder.RenameColumn(
                name: "PlanId",
                table: "Products",
                newName: "ProductStatus");

            migrationBuilder.RenameColumn(
                name: "IdParrentNavigationProductId",
                table: "Products",
                newName: "ProductCategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_Products_IdParrentNavigationProductId",
                table: "Products",
                newName: "IX_Products_ProductCategoryId");

            migrationBuilder.RenameColumn(
                name: "IsShown",
                table: "ProductCustomerFavoritesLists",
                newName: "ProductCustomerFavoritesListStatus");

            migrationBuilder.RenameColumn(
                name: "Price",
                table: "Plans",
                newName: "PriceOfUsers");

            migrationBuilder.RenameColumn(
                name: "DayDurations",
                table: "Plans",
                newName: "CountOfDay");

            migrationBuilder.RenameColumn(
                name: "IsShown",
                table: "PhoneNumbers",
                newName: "CustomersPhoneNumberStatus");

            migrationBuilder.RenameColumn(
                name: "PlanId",
                table: "Logs",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "IsShown",
                table: "EmailAddresses",
                newName: "CustomersEmailAddressStatus");

            migrationBuilder.RenameColumn(
                name: "IsShown",
                table: "Customers",
                newName: "CustomerStatus");

            migrationBuilder.RenameColumn(
                name: "IsShown",
                table: "CustomerCategories",
                newName: "CustomerCategoryStatus");

            migrationBuilder.RenameColumn(
                name: "IsShown",
                table: "ContactsEmailAddress",
                newName: "ContactsEmailAddressStatus");

            migrationBuilder.RenameColumn(
                name: "IsShown",
                table: "Contacts",
                newName: "ContactStatus");

            migrationBuilder.RenameColumn(
                name: "IsShown",
                table: "ContactPhoneNumbers",
                newName: "ContactPhoneNumberStatus");

            migrationBuilder.RenameColumn(
                name: "IsShown",
                table: "ContactGroups",
                newName: "ContactGroupStatus");

            migrationBuilder.RenameColumn(
                name: "IsShown",
                table: "AttributeOptions",
                newName: "AttributeOptionsStatus");

            migrationBuilder.RenameColumn(
                name: "PlanId",
                table: "AspNetUsers",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "PlanId",
                table: "AspNetUserClaims",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "PlanId",
                table: "AspNetRoles",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "PlanId",
                table: "AspNetRoleClaims",
                newName: "Id");

            migrationBuilder.AddColumn<int>(
                name: "ProvinceStatus",
                table: "Provinces",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Products",
                type: "character varying(255)",
                maxLength: 255,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "Summery",
                table: "Products",
                type: "character varying(255)",
                maxLength: 255,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddColumn<decimal>(
                name: "Discount",
                table: "Products",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<byte>(
                name: "DiscountPercent",
                table: "Products",
                type: "smallint",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.AddColumn<byte[]>(
                name: "Picture",
                table: "Products",
                type: "bytea",
                nullable: false,
                defaultValue: new byte[0]);

            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "Products",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<byte>(
                name: "PublishStatus",
                table: "Products",
                type: "smallint",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.AddColumn<decimal>(
                name: "SecondaryPrice",
                table: "Products",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AlterColumn<string>(
                name: "PlanName",
                table: "Plans",
                type: "character varying(255)",
                maxLength: 255,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(250)",
                oldMaxLength: 250);

            migrationBuilder.AddColumn<int>(
                name: "PlanStatus",
                table: "Plans",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "PriceOfDay",
                table: "Plans",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "StatusPeyGiryAttachment",
                table: "PeyGiryAttachments",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "NoteAttachmentStatus",
                table: "NoteAttachments",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CustomersAddressStatus",
                table: "CustomersAddresses",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CustomerPeyGiryStatus",
                table: "CustomerPeyGiries",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CustomerNoteStatus",
                table: "CustomerNotes",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "NoteHashTagStatus",
                table: "CustomerHashTags",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CountryStatus",
                table: "Countries",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CityStatus",
                table: "Cities",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "BusinessStatus",
                table: "Businesses",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "BusinessAttributeStatus",
                table: "BusinessAttributes",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AttributeOptionsValueStatus",
                table: "AttributeOptionsValues",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AddressStatus",
                table: "Addresses",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "ForoshFactors",
                columns: table => new
                {
                    ForoshFactorId = table.Column<string>(type: "character varying(26)", nullable: false),
                    Price = table.Column<decimal>(type: "numeric", nullable: false),
                    DiscountPrice = table.Column<decimal>(type: "numeric", nullable: false),
                    FinalTotal = table.Column<decimal>(type: "numeric", nullable: false),
                    CustomerId = table.Column<string>(type: "character varying(26)", nullable: false),
                    CustomersAddressId = table.Column<string>(type: "character varying(26)", nullable: false),
                    ForoshFactorStatus = table.Column<int>(type: "integer", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DateLastUpdate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ForoshFactors", x => x.ForoshFactorId);
                    table.ForeignKey(
                        name: "FK_ForoshFactors_CustomersAddresses_CustomersAddressId",
                        column: x => x.CustomersAddressId,
                        principalTable: "CustomersAddresses",
                        principalColumn: "CustomersAddressId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ForoshFactors_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ForoshOrders",
                columns: table => new
                {
                    ForoshOrderId = table.Column<string>(type: "character varying(26)", nullable: false),
                    PaymentDate = table.Column<DateOnly>(type: "date", nullable: false),
                    Price = table.Column<decimal>(type: "numeric", nullable: false),
                    ShippingPrice = table.Column<decimal>(type: "numeric", nullable: false),
                    PriceTotal = table.Column<decimal>(type: "numeric", nullable: false),
                    DiscountPrice = table.Column<decimal>(type: "numeric", nullable: false),
                    Description = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    PaymentMethodType = table.Column<int>(type: "integer", nullable: false),
                    ShippingMethodType = table.Column<int>(type: "integer", nullable: false),
                    ForoshOrderStatus = table.Column<int>(type: "integer", nullable: false),
                    ProductId = table.Column<string>(type: "character varying(26)", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DateLastUpdate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ForoshOrders", x => x.ForoshOrderId);
                    table.ForeignKey(
                        name: "FK_ForoshOrders_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductCategories",
                columns: table => new
                {
                    ProductCategoryId = table.Column<string>(type: "character varying(26)", nullable: false),
                    ParentId = table.Column<string>(type: "character varying(26)", nullable: false),
                    Order = table.Column<byte>(type: "smallint", nullable: false),
                    ProductCategoryName = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    Description = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    Icon = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    ProductCategoryStatus = table.Column<int>(type: "integer", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DateLastUpdate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductCategories", x => x.ProductCategoryId);
                    table.ForeignKey(
                        name: "FK_ProductCategories_ProductCategories_ParentId",
                        column: x => x.ParentId,
                        principalTable: "ProductCategories",
                        principalColumn: "ProductCategoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UsersPlans",
                columns: table => new
                {
                    UsersPlansId = table.Column<string>(type: "character varying(26)", nullable: false),
                    PlanId = table.Column<string>(type: "character varying(26)", nullable: false),
                    UserId = table.Column<string>(type: "text", nullable: false),
                    CountOfDay = table.Column<long>(type: "bigint", nullable: false),
                    CountOfUsers = table.Column<long>(type: "bigint", nullable: false),
                    StartDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    FinishDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UsersPlansStatus = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsersPlans", x => x.UsersPlansId);
                    table.ForeignKey(
                        name: "FK_UsersPlans_Plans_PlanId",
                        column: x => x.PlanId,
                        principalTable: "Plans",
                        principalColumn: "PlanId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UsersPlans_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ForoshFactors_CustomerId",
                table: "ForoshFactors",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_ForoshFactors_CustomersAddressId",
                table: "ForoshFactors",
                column: "CustomersAddressId");

            migrationBuilder.CreateIndex(
                name: "IX_ForoshOrders_ProductId",
                table: "ForoshOrders",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductCategories_ParentId",
                table: "ProductCategories",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_UsersPlans_PlanId",
                table: "UsersPlans",
                column: "PlanId");

            migrationBuilder.CreateIndex(
                name: "IX_UsersPlans_UserId",
                table: "UsersPlans",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_ProductCategories_ProductCategoryId",
                table: "Products",
                column: "ProductCategoryId",
                principalTable: "ProductCategories",
                principalColumn: "ProductCategoryId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_AspNetUsers_Id",
                table: "Users",
                column: "Id",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_ProductCategories_ProductCategoryId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_AspNetUsers_Id",
                table: "Users");

            migrationBuilder.DropTable(
                name: "ForoshFactors");

            migrationBuilder.DropTable(
                name: "ForoshOrders");

            migrationBuilder.DropTable(
                name: "ProductCategories");

            migrationBuilder.DropTable(
                name: "UsersPlans");

            migrationBuilder.DropColumn(
                name: "ProvinceStatus",
                table: "Provinces");

            migrationBuilder.DropColumn(
                name: "Discount",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "DiscountPercent",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Picture",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "PublishStatus",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "SecondaryPrice",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "PlanStatus",
                table: "Plans");

            migrationBuilder.DropColumn(
                name: "PriceOfDay",
                table: "Plans");

            migrationBuilder.DropColumn(
                name: "StatusPeyGiryAttachment",
                table: "PeyGiryAttachments");

            migrationBuilder.DropColumn(
                name: "NoteAttachmentStatus",
                table: "NoteAttachments");

            migrationBuilder.DropColumn(
                name: "CustomersAddressStatus",
                table: "CustomersAddresses");

            migrationBuilder.DropColumn(
                name: "CustomerPeyGiryStatus",
                table: "CustomerPeyGiries");

            migrationBuilder.DropColumn(
                name: "CustomerNoteStatus",
                table: "CustomerNotes");

            migrationBuilder.DropColumn(
                name: "NoteHashTagStatus",
                table: "CustomerHashTags");

            migrationBuilder.DropColumn(
                name: "CountryStatus",
                table: "Countries");

            migrationBuilder.DropColumn(
                name: "CityStatus",
                table: "Cities");

            migrationBuilder.DropColumn(
                name: "BusinessStatus",
                table: "Businesses");

            migrationBuilder.DropColumn(
                name: "BusinessAttributeStatus",
                table: "BusinessAttributes");

            migrationBuilder.DropColumn(
                name: "AttributeOptionsValueStatus",
                table: "AttributeOptionsValues");

            migrationBuilder.DropColumn(
                name: "AddressStatus",
                table: "Addresses");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Visit",
                newName: "PlanId");

            migrationBuilder.RenameColumn(
                name: "UserStatus",
                table: "Users",
                newName: "IsShown");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Users",
                newName: "PlanId");

            migrationBuilder.RenameColumn(
                name: "SanAtStatus",
                table: "SanAts",
                newName: "IsShown");

            migrationBuilder.RenameColumn(
                name: "ProductStatus",
                table: "Products",
                newName: "PlanId");

            migrationBuilder.RenameColumn(
                name: "ProductCategoryId",
                table: "Products",
                newName: "IdParrentNavigationProductId");

            migrationBuilder.RenameIndex(
                name: "IX_Products_ProductCategoryId",
                table: "Products",
                newName: "IX_Products_IdParrentNavigationProductId");

            migrationBuilder.RenameColumn(
                name: "ProductCustomerFavoritesListStatus",
                table: "ProductCustomerFavoritesLists",
                newName: "IsShown");

            migrationBuilder.RenameColumn(
                name: "PriceOfUsers",
                table: "Plans",
                newName: "Price");

            migrationBuilder.RenameColumn(
                name: "CountOfDay",
                table: "Plans",
                newName: "DayDurations");

            migrationBuilder.RenameColumn(
                name: "CustomersPhoneNumberStatus",
                table: "PhoneNumbers",
                newName: "IsShown");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Logs",
                newName: "PlanId");

            migrationBuilder.RenameColumn(
                name: "CustomersEmailAddressStatus",
                table: "EmailAddresses",
                newName: "IsShown");

            migrationBuilder.RenameColumn(
                name: "CustomerStatus",
                table: "Customers",
                newName: "IsShown");

            migrationBuilder.RenameColumn(
                name: "CustomerCategoryStatus",
                table: "CustomerCategories",
                newName: "IsShown");

            migrationBuilder.RenameColumn(
                name: "ContactsEmailAddressStatus",
                table: "ContactsEmailAddress",
                newName: "IsShown");

            migrationBuilder.RenameColumn(
                name: "ContactStatus",
                table: "Contacts",
                newName: "IsShown");

            migrationBuilder.RenameColumn(
                name: "ContactPhoneNumberStatus",
                table: "ContactPhoneNumbers",
                newName: "IsShown");

            migrationBuilder.RenameColumn(
                name: "ContactGroupStatus",
                table: "ContactGroups",
                newName: "IsShown");

            migrationBuilder.RenameColumn(
                name: "AttributeOptionsStatus",
                table: "AttributeOptions",
                newName: "IsShown");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "AspNetUsers",
                newName: "PlanId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "AspNetUserClaims",
                newName: "PlanId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "AspNetRoles",
                newName: "PlanId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "AspNetRoleClaims",
                newName: "PlanId");

            migrationBuilder.AddColumn<byte>(
                name: "IsDeleted",
                table: "Users",
                type: "smallint",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.AddColumn<byte>(
                name: "IsDeleted",
                table: "SanAts",
                type: "smallint",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Products",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(255)",
                oldMaxLength: 255);

            migrationBuilder.AlterColumn<string>(
                name: "Summery",
                table: "Products",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(255)",
                oldMaxLength: 255);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateEnd",
                table: "Products",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateStart",
                table: "Products",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IdCategory",
                table: "Products",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdCategoryNavigationId",
                table: "Products",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdCompany",
                table: "Products",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdCompanyNavigationId",
                table: "Products",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdParent",
                table: "Products",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Mablagh",
                table: "Products",
                type: "numeric",
                nullable: true);

            migrationBuilder.AddColumn<short>(
                name: "MaxSellPerPerson",
                table: "Products",
                type: "smallint",
                nullable: true);

            migrationBuilder.AddColumn<short>(
                name: "MinSell",
                table: "Products",
                type: "smallint",
                nullable: true);

            migrationBuilder.AddColumn<short>(
                name: "MinSellPerPerson",
                table: "Products",
                type: "smallint",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Pardakht",
                table: "Products",
                type: "numeric",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Published",
                table: "Products",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<byte>(
                name: "SpecialOffer",
                table: "Products",
                type: "smallint",
                nullable: true);

            migrationBuilder.AddColumn<byte>(
                name: "Status",
                table: "Products",
                type: "smallint",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Takhfif",
                table: "Products",
                type: "numeric",
                nullable: true);

            migrationBuilder.AddColumn<byte>(
                name: "TakhfifMePerent",
                table: "Products",
                type: "smallint",
                nullable: true);

            migrationBuilder.AddColumn<byte>(
                name: "TakhfifPercent",
                table: "Products",
                type: "smallint",
                nullable: true);

            migrationBuilder.AddColumn<byte>(
                name: "IsDeleted",
                table: "ProductCustomerFavoritesLists",
                type: "smallint",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.AlterColumn<string>(
                name: "PlanName",
                table: "Plans",
                type: "character varying(250)",
                maxLength: 250,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(255)",
                oldMaxLength: 255);

            migrationBuilder.AddColumn<byte>(
                name: "IsDeleted",
                table: "PhoneNumbers",
                type: "smallint",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.AddColumn<byte>(
                name: "IsDeleted",
                table: "PeyGiryAttachments",
                type: "smallint",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.AddColumn<byte>(
                name: "IsDeleted",
                table: "NoteAttachments",
                type: "smallint",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.AddColumn<byte>(
                name: "IsDeleted",
                table: "EmailAddresses",
                type: "smallint",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.AddColumn<byte>(
                name: "IsDeleted",
                table: "CustomersAddresses",
                type: "smallint",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.AddColumn<byte>(
                name: "IsDeleted",
                table: "Customers",
                type: "smallint",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.AddColumn<byte>(
                name: "IsDeleted",
                table: "CustomerPeyGiries",
                type: "smallint",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.AddColumn<byte>(
                name: "IsDeleted",
                table: "CustomerNotes",
                type: "smallint",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.AddColumn<byte>(
                name: "IsDeleted",
                table: "CustomerHashTags",
                type: "smallint",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.AddColumn<byte>(
                name: "IsDeleted",
                table: "CustomerCategories",
                type: "smallint",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.AddColumn<byte>(
                name: "IsDeleted",
                table: "ContactsEmailAddress",
                type: "smallint",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.AddColumn<byte>(
                name: "IsDeleted",
                table: "Contacts",
                type: "smallint",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.AddColumn<byte>(
                name: "IsDeleted",
                table: "ContactPhoneNumbers",
                type: "smallint",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.AddColumn<byte>(
                name: "IsDeleted",
                table: "ContactGroups",
                type: "smallint",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.AddColumn<byte>(
                name: "IsDeleted",
                table: "Cities",
                type: "smallint",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.AddColumn<byte>(
                name: "IsDeleted",
                table: "AttributeOptions",
                type: "smallint",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    PlanId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    IdParrentNavigationId = table.Column<int>(type: "integer", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Icon = table.Column<string>(type: "text", nullable: false),
                    IdParrent = table.Column<int>(type: "integer", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: false),
                    OrderC = table.Column<byte>(type: "smallint", nullable: true),
                    RowVersion = table.Column<byte[]>(type: "bytea", nullable: false),
                    SeoName = table.Column<string>(type: "text", nullable: false),
                    Show = table.Column<byte>(type: "smallint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.PlanId);
                    table.ForeignKey(
                        name: "FK_Category_Category_IdParrentNavigationId",
                        column: x => x.IdParrentNavigationId,
                        principalTable: "Category",
                        principalColumn: "PlanId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Company",
                columns: table => new
                {
                    PlanId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Address = table.Column<string>(type: "text", nullable: false),
                    BankName = table.Column<string>(type: "text", nullable: false),
                    BankNo = table.Column<string>(type: "text", nullable: false),
                    CardNo = table.Column<string>(type: "text", nullable: false),
                    Ceo = table.Column<string>(type: "text", nullable: false),
                    CeoMobile = table.Column<string>(type: "text", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DateLastUpdate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    IdCity = table.Column<short>(type: "smallint", nullable: true),
                    Lat = table.Column<string>(type: "text", nullable: false),
                    Long = table.Column<string>(type: "text", nullable: false),
                    Makan = table.Column<string>(type: "text", nullable: false),
                    Mobile = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Pass = table.Column<string>(type: "text", nullable: false),
                    Rate = table.Column<decimal>(type: "numeric", nullable: true),
                    Tel1 = table.Column<string>(type: "text", nullable: false),
                    Tel2 = table.Column<string>(type: "text", nullable: false),
                    UserName = table.Column<string>(type: "text", nullable: false),
                    WebSite = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Company", x => x.PlanId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_IdCategoryNavigationId",
                table: "Products",
                column: "IdCategoryNavigationId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_IdCompanyNavigationId",
                table: "Products",
                column: "IdCompanyNavigationId");

            migrationBuilder.CreateIndex(
                name: "IX_Category_IdParrentNavigationId",
                table: "Category",
                column: "IdParrentNavigationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Category_IdCategoryNavigationId",
                table: "Products",
                column: "IdCategoryNavigationId",
                principalTable: "Category",
                principalColumn: "PlanId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Company_IdCompanyNavigationId",
                table: "Products",
                column: "IdCompanyNavigationId",
                principalTable: "Company",
                principalColumn: "PlanId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Products_IdParrentNavigationProductId",
                table: "Products",
                column: "IdParrentNavigationProductId",
                principalTable: "Products",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_AspNetUsers_PlanId",
                table: "Users",
                column: "PlanId",
                principalTable: "AspNetUsers",
                principalColumn: "PlanId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
