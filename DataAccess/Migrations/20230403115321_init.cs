using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    UserName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    PasswordHash = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    SecurityStamp = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    PhoneNumber = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    IdParrent = table.Column<int>(type: "integer", nullable: true),
                    OrderC = table.Column<byte>(type: "smallint", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Icon = table.Column<string>(type: "text", nullable: false),
                    SeoName = table.Column<string>(type: "text", nullable: false),
                    Show = table.Column<byte>(type: "smallint", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    RowVersion = table.Column<byte[]>(type: "bytea", nullable: false),
                    IdParrentNavigationId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.Id);
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
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Address = table.Column<string>(type: "text", nullable: false),
                    Tel1 = table.Column<string>(type: "text", nullable: false),
                    Tel2 = table.Column<string>(type: "text", nullable: false),
                    Mobile = table.Column<string>(type: "text", nullable: false),
                    WebSite = table.Column<string>(type: "text", nullable: false),
                    Ceo = table.Column<string>(type: "text", nullable: false),
                    CeoMobile = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    BankName = table.Column<string>(type: "text", nullable: false),
                    BankNo = table.Column<string>(type: "text", nullable: false),
                    CardNo = table.Column<string>(type: "text", nullable: false),
                    Makan = table.Column<string>(type: "text", nullable: false),
                    IdCity = table.Column<short>(type: "smallint", nullable: true),
                    Pass = table.Column<string>(type: "text", nullable: false),
                    Lat = table.Column<string>(type: "text", nullable: false),
                    Long = table.Column<string>(type: "text", nullable: false),
                    UserName = table.Column<string>(type: "text", nullable: false),
                    Rate = table.Column<decimal>(type: "numeric", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DateLastUpdate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Company", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ContactGroups",
                columns: table => new
                {
                    ContactGroupId = table.Column<string>(type: "character varying(26)", nullable: false),
                    GroupName = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    DisplayOrder = table.Column<int>(type: "integer", nullable: false),
                    IsDeleted = table.Column<byte>(type: "smallint", nullable: false),
                    IsShown = table.Column<int>(type: "integer", nullable: false),
                    ContactGroup = table.Column<string>(type: "character varying(26)", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DateLastUpdate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactGroups", x => x.ContactGroupId);
                });

            migrationBuilder.CreateTable(
                name: "ContactPhoneNumbers",
                columns: table => new
                {
                    ContactPhoneNumberId = table.Column<string>(type: "character varying(26)", nullable: false),
                    PhoneNo = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    PhoneType = table.Column<int>(type: "integer", nullable: false),
                    CustomerId = table.Column<string>(type: "character varying(26)", nullable: false),
                    IsDeleted = table.Column<byte>(type: "smallint", nullable: false),
                    IsShown = table.Column<int>(type: "integer", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DateLastUpdate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactPhoneNumbers", x => x.ContactPhoneNumberId);
                });

            migrationBuilder.CreateTable(
                name: "ContactsEmailAddress",
                columns: table => new
                {
                    CustomersEmailAddressId = table.Column<string>(type: "character varying(26)", nullable: false),
                    CustomersEmailAddrs = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    IsDeleted = table.Column<byte>(type: "smallint", nullable: false),
                    IsShown = table.Column<int>(type: "integer", nullable: false),
                    ContactsEmailAddress = table.Column<string>(type: "character varying(26)", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DateLastUpdate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactsEmailAddress", x => x.CustomersEmailAddressId);
                });

            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    CountryId = table.Column<string>(type: "character varying(26)", nullable: false),
                    CountryName = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    IsDefault = table.Column<bool>(type: "boolean", nullable: false),
                    DisplayOrder = table.Column<int>(type: "integer", nullable: false),
                    Country = table.Column<string>(type: "character varying(26)", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DateLastUpdate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.CountryId);
                });

            migrationBuilder.CreateTable(
                name: "CustomerCategories",
                columns: table => new
                {
                    CustomerCategoryId = table.Column<string>(type: "character varying(26)", nullable: false),
                    CustomerCategoryName = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    CustomerId = table.Column<string>(type: "character varying(26)", nullable: false),
                    IsDeleted = table.Column<byte>(type: "smallint", nullable: false),
                    IsShown = table.Column<int>(type: "integer", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DateLastUpdate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerCategories", x => x.CustomerCategoryId);
                });

            migrationBuilder.CreateTable(
                name: "CustomerFeedbacks",
                columns: table => new
                {
                    CustomerFeedbackId = table.Column<string>(type: "character varying(26)", nullable: false),
                    FeedbackName = table.Column<string>(type: "text", nullable: false),
                    DisplayOrder = table.Column<int>(type: "integer", nullable: false),
                    Point = table.Column<decimal>(type: "numeric", nullable: false),
                    BalancePoint = table.Column<int>(type: "integer", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DateLastUpdate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerFeedbacks", x => x.CustomerFeedbackId);
                });

            migrationBuilder.CreateTable(
                name: "CustomerRepresentativeTypes",
                columns: table => new
                {
                    CustomerRepresentativeTypeId = table.Column<string>(type: "character varying(26)", nullable: false),
                    CustomerRepresentativeName = table.Column<int>(type: "integer", nullable: false),
                    DisplayOrder = table.Column<int>(type: "integer", nullable: false),
                    Point = table.Column<decimal>(type: "numeric", nullable: false),
                    BalancePoint = table.Column<int>(type: "integer", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DateLastUpdate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerRepresentativeTypes", x => x.CustomerRepresentativeTypeId);
                });

            migrationBuilder.CreateTable(
                name: "Plans",
                columns: table => new
                {
                    Id = table.Column<string>(type: "character varying(26)", nullable: false),
                    PlanName = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false),
                    DayDurations = table.Column<long>(type: "bigint", nullable: false),
                    CountOfUsers = table.Column<long>(type: "bigint", nullable: false),
                    Price = table.Column<decimal>(type: "numeric", nullable: false),
                    Discount = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false),
                    FinalPrice = table.Column<decimal>(type: "numeric", nullable: false),
                    Plan = table.Column<string>(type: "character varying(26)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Plans", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Posts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Content = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: true),
                    DateCreated = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    LastModfied = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RoleId = table.Column<string>(type: "text", nullable: false),
                    ClaimType = table.Column<string>(type: "text", nullable: true),
                    ClaimValue = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "PlanId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<string>(type: "text", nullable: false),
                    ClaimType = table.Column<string>(type: "text", nullable: true),
                    ClaimValue = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "PlanId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "text", nullable: false),
                    ProviderKey = table.Column<string>(type: "text", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "text", nullable: true),
                    UserId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "PlanId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "text", nullable: false),
                    RoleId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "PlanId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "PlanId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "text", nullable: false),
                    LoginProvider = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Value = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "PlanId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductId = table.Column<string>(type: "character varying(26)", nullable: false),
                    ProductName = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    Published = table.Column<bool>(type: "boolean", nullable: false),
                    Id = table.Column<int>(type: "integer", nullable: false),
                    IdParent = table.Column<int>(type: "integer", nullable: true),
                    IdCompany = table.Column<int>(type: "integer", nullable: false),
                    IdCategory = table.Column<int>(type: "integer", nullable: false),
                    Title = table.Column<string>(type: "text", nullable: false),
                    Summery = table.Column<string>(type: "text", nullable: false),
                    DateStart = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DateEnd = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Mablagh = table.Column<decimal>(type: "numeric", nullable: true),
                    Takhfif = table.Column<decimal>(type: "numeric", nullable: true),
                    TakhfifPercent = table.Column<byte>(type: "smallint", nullable: true),
                    Pardakht = table.Column<decimal>(type: "numeric", nullable: true),
                    SpecialOffer = table.Column<byte>(type: "smallint", nullable: true),
                    Status = table.Column<byte>(type: "smallint", nullable: true),
                    TakhfifMePerent = table.Column<byte>(type: "smallint", nullable: true),
                    MinSell = table.Column<short>(type: "smallint", nullable: true),
                    MinSellPerPerson = table.Column<short>(type: "smallint", nullable: true),
                    MaxSellPerPerson = table.Column<short>(type: "smallint", nullable: true),
                    FavoritesListId = table.Column<string>(type: "character varying(26)", nullable: false),
                    IdCategoryNavigationId = table.Column<int>(type: "integer", nullable: false),
                    IdCompanyNavigationId = table.Column<int>(type: "integer", nullable: false),
                    IdParrentNavigationProductId = table.Column<string>(type: "character varying(26)", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DateLastUpdate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductId);
                    table.ForeignKey(
                        name: "FK_Products_Category_IdCategoryNavigationId",
                        column: x => x.IdCategoryNavigationId,
                        principalTable: "Category",
                        principalColumn: "PlanId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Products_Company_IdCompanyNavigationId",
                        column: x => x.IdCompanyNavigationId,
                        principalTable: "Company",
                        principalColumn: "PlanId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Products_Products_IdParrentNavigationProductId",
                        column: x => x.IdParrentNavigationProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Contacts",
                columns: table => new
                {
                    ContactId = table.Column<string>(type: "character varying(26)", nullable: false),
                    FirstName = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    LastName = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    MobileNumberId = table.Column<string>(type: "character varying(26)", nullable: false),
                    EmailId = table.Column<string>(type: "character varying(26)", nullable: false),
                    ContactGroupId = table.Column<string>(type: "character varying(26)", nullable: false),
                    Job = table.Column<string>(type: "text", nullable: false),
                    IsDeleted = table.Column<byte>(type: "smallint", nullable: false),
                    IsShown = table.Column<int>(type: "integer", nullable: false),
                    BusinessId = table.Column<string>(type: "character varying(26)", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DateLastUpdate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contacts", x => x.ContactId);
                    table.ForeignKey(
                        name: "FK_Contacts_ContactGroups_ContactGroupId",
                        column: x => x.ContactGroupId,
                        principalTable: "ContactGroups",
                        principalColumn: "ContactGroupId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Contacts_ContactPhoneNumbers_MobileNumberId",
                        column: x => x.MobileNumberId,
                        principalTable: "ContactPhoneNumbers",
                        principalColumn: "ContactPhoneNumberId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Contacts_ContactsEmailAddress_EmailId",
                        column: x => x.EmailId,
                        principalTable: "ContactsEmailAddress",
                        principalColumn: "CustomersEmailAddressId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Provinces",
                columns: table => new
                {
                    ProvinceId = table.Column<string>(type: "character varying(26)", nullable: false),
                    ProvinceName = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    IsDefault = table.Column<bool>(type: "boolean", nullable: false),
                    DisplayOrder = table.Column<int>(type: "integer", nullable: false),
                    CountryId = table.Column<string>(type: "character varying(26)", nullable: false),
                    Province = table.Column<string>(type: "character varying(26)", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DateLastUpdate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Provinces", x => x.ProvinceId);
                    table.ForeignKey(
                        name: "FK_Provinces_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "CountryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Visit",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    IdUser = table.Column<string>(type: "text", nullable: false),
                    IpAddress = table.Column<string>(type: "text", nullable: false),
                    UserAgent = table.Column<string>(type: "text", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ProductId = table.Column<string>(type: "character varying(26)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Visit", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Visit_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId");
                });

            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    CityId = table.Column<string>(type: "character varying(26)", nullable: false),
                    CityName = table.Column<string>(type: "text", nullable: false),
                    IsDefault = table.Column<bool>(type: "boolean", nullable: false),
                    DisplayOrder = table.Column<int>(type: "integer", nullable: false),
                    ProvinceId = table.Column<string>(type: "character varying(26)", nullable: false),
                    CustomerId = table.Column<string>(type: "character varying(26)", nullable: false),
                    IsDeleted = table.Column<byte>(type: "smallint", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DateLastUpdate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.CityId);
                    table.ForeignKey(
                        name: "FK_Cities_Provinces_ProvinceId",
                        column: x => x.ProvinceId,
                        principalTable: "Provinces",
                        principalColumn: "ProvinceId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    AddressId = table.Column<string>(type: "character varying(26)", nullable: false),
                    Address1 = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    Address2 = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    CompanyName = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    ZipPostalCode = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    Description = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    CityId = table.Column<string>(type: "character varying(26)", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DateLastUpdate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.AddressId);
                    table.ForeignKey(
                        name: "FK_Addresses_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "CityId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    Family = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    CodeMelli = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    Address = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    PostalCode = table.Column<string>(type: "text", nullable: true),
                    Married = table.Column<byte>(type: "smallint", nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Gender = table.Column<byte>(type: "smallint", nullable: true),
                    CityId = table.Column<string>(type: "character varying(26)", nullable: false),
                    CustomerId = table.Column<string>(type: "text", nullable: false),
                    LoginCount = table.Column<int>(type: "integer", nullable: true),
                    LastLogin = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    UserAgent = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    LastIp = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    Flag = table.Column<byte>(type: "smallint", nullable: true),
                    Limited = table.Column<bool>(type: "boolean", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    WebSite = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    OtpPassword = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    OtpPasswordExpired = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    LastLoginDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    IsDeleted = table.Column<byte>(type: "smallint", nullable: false),
                    IsShown = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_AspNetUsers_Id",
                        column: x => x.Id,
                        principalTable: "AspNetUsers",
                        principalColumn: "PlanId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Users_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "CityId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Logs",
                columns: table => new
                {
                    Id = table.Column<string>(type: "character varying(26)", nullable: false),
                    UserId = table.Column<string>(type: "text", nullable: false),
                    Kind = table.Column<byte>(type: "smallint", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Log = table.Column<string>(type: "character varying(26)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Logs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Logs_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "PlanId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SanAts",
                columns: table => new
                {
                    SanAtId = table.Column<string>(type: "character varying(26)", nullable: false),
                    SanAtName = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false),
                    UserId = table.Column<string>(type: "text", nullable: false),
                    IsDeleted = table.Column<byte>(type: "smallint", nullable: false),
                    IsShown = table.Column<int>(type: "integer", nullable: false),
                    SanAt = table.Column<string>(type: "character varying(26)", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DateLastUpdate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SanAts", x => x.SanAtId);
                    table.ForeignKey(
                        name: "FK_SanAts_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "PlanId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AttributeOptions",
                columns: table => new
                {
                    AttributeOptionsId = table.Column<string>(type: "character varying(26)", nullable: false),
                    Title = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    ColorSquaresRgb = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    BusinessAttributeId = table.Column<string>(type: "character varying(26)", nullable: false),
                    DisplayOrder = table.Column<int>(type: "integer", nullable: false),
                    IsDeleted = table.Column<byte>(type: "smallint", nullable: false),
                    IsShown = table.Column<int>(type: "integer", nullable: false),
                    AttributeOptions = table.Column<string>(type: "character varying(26)", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DateLastUpdate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AttributeOptions", x => x.AttributeOptionsId);
                });

            migrationBuilder.CreateTable(
                name: "AttributeOptionsValues",
                columns: table => new
                {
                    AttributeOptionsValueId = table.Column<string>(type: "character varying(26)", nullable: false),
                    ForCustomerId = table.Column<int>(type: "integer", nullable: false),
                    AttributeDescriptionValue = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    AttributeXMLValue = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    AttributeJsonValue = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    FileId = table.Column<int>(type: "integer", nullable: true),
                    PictureId = table.Column<int>(type: "integer", nullable: true),
                    FilePath = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    ImagePath = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    CustomerId = table.Column<string>(type: "character varying(26)", nullable: false),
                    AttributeOptionId = table.Column<string>(type: "character varying(26)", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DateLastUpdate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AttributeOptionsValues", x => x.AttributeOptionsValueId);
                    table.ForeignKey(
                        name: "FK_AttributeOptionsValues_AttributeOptions_AttributeOptionsVal~",
                        column: x => x.AttributeOptionsValueId,
                        principalTable: "AttributeOptions",
                        principalColumn: "AttributeOptionsId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BusinessAttributes",
                columns: table => new
                {
                    BusinessAttributeId = table.Column<string>(type: "character varying(26)", nullable: false),
                    TextPrompt = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    IsRequired = table.Column<bool>(type: "boolean", nullable: false),
                    AttributeTypeId = table.Column<int>(type: "integer", nullable: false),
                    DisplayOrder = table.Column<int>(type: "integer", nullable: false),
                    ValidationMinLength = table.Column<int>(type: "integer", nullable: true),
                    ValidationMaxLength = table.Column<int>(type: "integer", nullable: true),
                    ValidationFileAllowExtention = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    ValidationFileMaximumSize = table.Column<int>(type: "integer", nullable: true),
                    DefaultValue = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    ConditionValue = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    CategoryAttributeId = table.Column<string>(type: "character varying(26)", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DateLastUpdate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BusinessAttributes", x => x.BusinessAttributeId);
                });

            migrationBuilder.CreateTable(
                name: "Businesses",
                columns: table => new
                {
                    BusinessId = table.Column<string>(type: "character varying(26)", nullable: false),
                    BusinessName = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    Url = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    Hosts = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    CompanyName = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    CompanyAddress = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    SslEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    DisplayOrder = table.Column<int>(type: "integer", nullable: false),
                    UserId = table.Column<string>(type: "text", nullable: false),
                    CustomerId = table.Column<string>(type: "character varying(26)", nullable: false),
                    ContactId = table.Column<string>(type: "character varying(26)", nullable: false),
                    ContactGroupId = table.Column<string>(type: "character varying(26)", nullable: false),
                    AttributeOptionsId = table.Column<string>(type: "character varying(26)", nullable: false),
                    AttributeOptionsValueId = table.Column<string>(type: "character varying(26)", nullable: false),
                    BusinessAttributeId = table.Column<string>(type: "character varying(26)", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DateLastUpdate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Businesses", x => x.BusinessId);
                    table.ForeignKey(
                        name: "FK_Businesses_AttributeOptionsValues_AttributeOptionsValueId",
                        column: x => x.AttributeOptionsValueId,
                        principalTable: "AttributeOptionsValues",
                        principalColumn: "AttributeOptionsValueId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Businesses_AttributeOptions_AttributeOptionsId",
                        column: x => x.AttributeOptionsId,
                        principalTable: "AttributeOptions",
                        principalColumn: "AttributeOptionsId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Businesses_BusinessAttributes_BusinessAttributeId",
                        column: x => x.BusinessAttributeId,
                        principalTable: "BusinessAttributes",
                        principalColumn: "BusinessAttributeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Businesses_ContactGroups_ContactGroupId",
                        column: x => x.ContactGroupId,
                        principalTable: "ContactGroups",
                        principalColumn: "ContactGroupId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Businesses_Contacts_ContactId",
                        column: x => x.ContactId,
                        principalTable: "Contacts",
                        principalColumn: "ContactId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Businesses_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "PlanId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CategoryAttributes",
                columns: table => new
                {
                    CategoryAttributeId = table.Column<string>(type: "character varying(26)", nullable: false),
                    Name = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    Description = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    DisplayOrder = table.Column<int>(type: "integer", nullable: false),
                    BusinessId = table.Column<string>(type: "character varying(26)", nullable: true),
                    CategoryAttribute = table.Column<string>(type: "character varying(26)", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DateLastUpdate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryAttributes", x => x.CategoryAttributeId);
                    table.ForeignKey(
                        name: "FK_CategoryAttributes_Businesses_BusinessId",
                        column: x => x.BusinessId,
                        principalTable: "Businesses",
                        principalColumn: "BusinessId");
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    CustomerId = table.Column<string>(type: "character varying(26)", nullable: false),
                    FirstName = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    LastName = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    BirthDayDate = table.Column<DateOnly>(type: "date", nullable: false),
                    CustomerPic = table.Column<byte[]>(type: "bytea", nullable: false),
                    UserId = table.Column<string>(type: "text", nullable: false),
                    CityId = table.Column<string>(type: "character varying(26)", nullable: false),
                    BusinessId = table.Column<string>(type: "character varying(26)", nullable: false),
                    CustomerCategoryId = table.Column<string>(type: "character varying(26)", nullable: false),
                    Gender = table.Column<byte>(type: "smallint", nullable: false),
                    IsShown = table.Column<int>(type: "integer", nullable: false),
                    CustomerState = table.Column<int>(type: "integer", nullable: false),
                    CustomerStatus = table.Column<int>(type: "integer", nullable: false),
                    InsertedBy = table.Column<string>(type: "text", nullable: false),
                    UpdatedBy = table.Column<string>(type: "text", nullable: false),
                    IsDeleted = table.Column<byte>(type: "smallint", nullable: false),
                    CustomerMoarefId = table.Column<string>(type: "character varying(26)", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DateLastUpdate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.CustomerId);
                    table.ForeignKey(
                        name: "FK_Customers_Businesses_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Businesses",
                        principalColumn: "BusinessId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Customers_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "CityId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Customers_CustomerCategories_CustomerCategoryId",
                        column: x => x.CustomerCategoryId,
                        principalTable: "CustomerCategories",
                        principalColumn: "CustomerCategoryId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Customers_Customers_CustomerMoarefId",
                        column: x => x.CustomerMoarefId,
                        principalTable: "Customers",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Customers_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "PlanId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Settings",
                columns: table => new
                {
                    SettingId = table.Column<string>(type: "character varying(26)", nullable: false),
                    Name = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    Value = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    BusinessId = table.Column<string>(type: "character varying(26)", nullable: false),
                    DisplayOrder = table.Column<int>(type: "integer", nullable: false),
                    Setting = table.Column<string>(type: "character varying(26)", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DateLastUpdate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Settings", x => x.SettingId);
                    table.ForeignKey(
                        name: "FK_Settings_Businesses_BusinessId",
                        column: x => x.BusinessId,
                        principalTable: "Businesses",
                        principalColumn: "BusinessId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CustomerActivities",
                columns: table => new
                {
                    CustomerActivityId = table.Column<string>(type: "character varying(26)", nullable: false),
                    CustomerActivityName = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false),
                    CustomerActivityDescription = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    CustomerId = table.Column<string>(type: "character varying(26)", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DateLastUpdate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerActivities", x => x.CustomerActivityId);
                    table.ForeignKey(
                        name: "FK_CustomerActivities_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CustomerFeedbackHistories",
                columns: table => new
                {
                    CustomerFeedbackHistoryId = table.Column<string>(type: "character varying(26)", nullable: false),
                    CustomerId = table.Column<string>(type: "character varying(26)", nullable: false),
                    CustomerFeedbackId = table.Column<string>(type: "character varying(26)", nullable: false),
                    Description = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    IsActivePoint = table.Column<bool>(type: "boolean", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DateLastUpdate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerFeedbackHistories", x => x.CustomerFeedbackHistoryId);
                    table.ForeignKey(
                        name: "FK_CustomerFeedbackHistories_CustomerFeedbacks_CustomerFeedbac~",
                        column: x => x.CustomerFeedbackId,
                        principalTable: "CustomerFeedbacks",
                        principalColumn: "CustomerFeedbackId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CustomerFeedbackHistories_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CustomerNotes",
                columns: table => new
                {
                    CustomerNoteId = table.Column<string>(type: "character varying(26)", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    IsDeleted = table.Column<byte>(type: "smallint", nullable: false),
                    CustomerId = table.Column<string>(type: "character varying(26)", nullable: false),
                    CustomerNote = table.Column<string>(type: "character varying(26)", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DateLastUpdate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerNotes", x => x.CustomerNoteId);
                    table.ForeignKey(
                        name: "FK_CustomerNotes_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CustomerPeyGiries",
                columns: table => new
                {
                    CustomerPeyGiryId = table.Column<string>(type: "character varying(26)", nullable: false),
                    Description = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    IsDeleted = table.Column<byte>(type: "smallint", nullable: false),
                    CustomerId = table.Column<string>(type: "character varying(26)", nullable: false),
                    CustomerPeyGiry = table.Column<string>(type: "character varying(26)", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DateLastUpdate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerPeyGiries", x => x.CustomerPeyGiryId);
                    table.ForeignKey(
                        name: "FK_CustomerPeyGiries_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CustomerRepresentativeHistories",
                columns: table => new
                {
                    CustomerRepresentativeHistoryId = table.Column<string>(type: "character varying(26)", nullable: false),
                    CustomerId = table.Column<string>(type: "character varying(26)", nullable: false),
                    CustomerRepresentativeTypeId = table.Column<string>(type: "character varying(26)", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DateLastUpdate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerRepresentativeHistories", x => x.CustomerRepresentativeHistoryId);
                    table.ForeignKey(
                        name: "FK_CustomerRepresentativeHistories_CustomerRepresentativeTypes~",
                        column: x => x.CustomerRepresentativeTypeId,
                        principalTable: "CustomerRepresentativeTypes",
                        principalColumn: "CustomerRepresentativeTypeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CustomerRepresentativeHistories_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CustomersAddresses",
                columns: table => new
                {
                    CustomersAddressId = table.Column<string>(type: "character varying(26)", nullable: false),
                    Address = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    CodePost = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    PhoneNo = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    Description = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    CustomerId = table.Column<string>(type: "character varying(26)", nullable: false),
                    IsDeleted = table.Column<byte>(type: "smallint", nullable: false),
                    CustomersAddress = table.Column<string>(type: "character varying(26)", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DateLastUpdate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomersAddresses", x => x.CustomersAddressId);
                    table.ForeignKey(
                        name: "FK_CustomersAddresses_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CustomerSubmissions",
                columns: table => new
                {
                    CustomerSubmissionId = table.Column<string>(type: "character varying(26)", nullable: false),
                    CustomerId = table.Column<string>(type: "character varying(26)", nullable: false),
                    UserId = table.Column<string>(type: "text", nullable: false),
                    FollowDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DateLastUpdate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerSubmissions", x => x.CustomerSubmissionId);
                    table.ForeignKey(
                        name: "FK_CustomerSubmissions_Customers_CustomerSubmissionId",
                        column: x => x.CustomerSubmissionId,
                        principalTable: "Customers",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CustomerSubmissions_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "PlanId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EmailAddresses",
                columns: table => new
                {
                    CustomersEmailAddressId = table.Column<string>(type: "character varying(26)", nullable: false),
                    CustomersEmailAddrs = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    CustomerId = table.Column<string>(type: "character varying(26)", nullable: false),
                    IsDeleted = table.Column<byte>(type: "smallint", nullable: false),
                    IsShown = table.Column<int>(type: "integer", nullable: false),
                    CustomersEmailAddress = table.Column<string>(type: "character varying(26)", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DateLastUpdate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmailAddresses", x => x.CustomersEmailAddressId);
                    table.ForeignKey(
                        name: "FK_EmailAddresses_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PhoneNumbers",
                columns: table => new
                {
                    PhoneNumberId = table.Column<string>(type: "character varying(26)", nullable: false),
                    PhoneNo = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    PhoneType = table.Column<int>(type: "integer", nullable: false),
                    CustomerId = table.Column<string>(type: "character varying(26)", nullable: false),
                    IsDeleted = table.Column<byte>(type: "smallint", nullable: false),
                    IsShown = table.Column<int>(type: "integer", nullable: false),
                    CustomersPhoneNumber = table.Column<string>(type: "character varying(26)", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DateLastUpdate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhoneNumbers", x => x.PhoneNumberId);
                    table.ForeignKey(
                        name: "FK_PhoneNumbers_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductCustomerFavoritesLists",
                columns: table => new
                {
                    ProductId = table.Column<string>(type: "character varying(26)", nullable: false),
                    CustomerId = table.Column<string>(type: "character varying(26)", nullable: false),
                    IsDeleted = table.Column<byte>(type: "smallint", nullable: false),
                    IsShown = table.Column<int>(type: "integer", nullable: false),
                    ProductCustomerFavoritesList = table.Column<string>(type: "character varying(26)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductCustomerFavoritesLists", x => new { x.ProductId, x.CustomerId });
                    table.ForeignKey(
                        name: "FK_ProductCustomerFavoritesLists_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductCustomerFavoritesLists_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CustomerActivityHistories",
                columns: table => new
                {
                    CustomerActivityHistoryId = table.Column<string>(type: "character varying(26)", nullable: false),
                    CustomerId = table.Column<string>(type: "character varying(26)", nullable: false),
                    CustomerActivityId = table.Column<string>(type: "character varying(26)", nullable: false),
                    Description = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    IsActivePoint = table.Column<bool>(type: "boolean", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DateLastUpdate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerActivityHistories", x => x.CustomerActivityHistoryId);
                    table.ForeignKey(
                        name: "FK_CustomerActivityHistories_CustomerActivities_CustomerActivi~",
                        column: x => x.CustomerActivityId,
                        principalTable: "CustomerActivities",
                        principalColumn: "CustomerActivityId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CustomerActivityHistories_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CustomerHashTags",
                columns: table => new
                {
                    NoteHashTagId = table.Column<string>(type: "character varying(26)", nullable: false),
                    Title = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    CustomerNoteId = table.Column<string>(type: "character varying(26)", nullable: false),
                    IsDeleted = table.Column<byte>(type: "smallint", nullable: false),
                    NoteHashTag = table.Column<string>(type: "character varying(26)", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DateLastUpdate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerHashTags", x => x.NoteHashTagId);
                    table.ForeignKey(
                        name: "FK_CustomerHashTags_CustomerNotes_CustomerNoteId",
                        column: x => x.CustomerNoteId,
                        principalTable: "CustomerNotes",
                        principalColumn: "CustomerNoteId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "NoteAttachments",
                columns: table => new
                {
                    NoteAttachmentId = table.Column<string>(type: "character varying(26)", nullable: false),
                    CustomerNoteId = table.Column<string>(type: "character varying(26)", nullable: false),
                    FileName = table.Column<byte[]>(type: "bytea", nullable: false),
                    Extenstion = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    IsDeleted = table.Column<byte>(type: "smallint", nullable: false),
                    NoteAttachment = table.Column<string>(type: "character varying(26)", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DateLastUpdate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NoteAttachments", x => x.NoteAttachmentId);
                    table.ForeignKey(
                        name: "FK_NoteAttachments_CustomerNotes_CustomerNoteId",
                        column: x => x.CustomerNoteId,
                        principalTable: "CustomerNotes",
                        principalColumn: "CustomerNoteId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PeyGiryAttachments",
                columns: table => new
                {
                    PeyGiryAttachmentId = table.Column<string>(type: "character varying(26)", nullable: false),
                    PeyGiryNoteId = table.Column<string>(type: "character varying(26)", nullable: false),
                    FileName = table.Column<byte[]>(type: "bytea", nullable: false),
                    Extenstion = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    IsDeleted = table.Column<byte>(type: "smallint", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DateLastUpdate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PeyGiryAttachments", x => x.PeyGiryAttachmentId);
                    table.ForeignKey(
                        name: "FK_PeyGiryAttachments_CustomerPeyGiries_PeyGiryAttachmentId",
                        column: x => x.PeyGiryAttachmentId,
                        principalTable: "CustomerPeyGiries",
                        principalColumn: "CustomerPeyGiryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_CityId",
                table: "Addresses",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AttributeOptions_BusinessAttributeId",
                table: "AttributeOptions",
                column: "BusinessAttributeId");

            migrationBuilder.CreateIndex(
                name: "IX_AttributeOptionsValues_CustomerId",
                table: "AttributeOptionsValues",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_BusinessAttributes_CategoryAttributeId",
                table: "BusinessAttributes",
                column: "CategoryAttributeId");

            migrationBuilder.CreateIndex(
                name: "IX_Businesses_AttributeOptionsId",
                table: "Businesses",
                column: "AttributeOptionsId");

            migrationBuilder.CreateIndex(
                name: "IX_Businesses_AttributeOptionsValueId",
                table: "Businesses",
                column: "AttributeOptionsValueId");

            migrationBuilder.CreateIndex(
                name: "IX_Businesses_BusinessAttributeId",
                table: "Businesses",
                column: "BusinessAttributeId");

            migrationBuilder.CreateIndex(
                name: "IX_Businesses_ContactGroupId",
                table: "Businesses",
                column: "ContactGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Businesses_ContactId",
                table: "Businesses",
                column: "ContactId");

            migrationBuilder.CreateIndex(
                name: "IX_Businesses_UserId",
                table: "Businesses",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Category_IdParrentNavigationId",
                table: "Category",
                column: "IdParrentNavigationId");

            migrationBuilder.CreateIndex(
                name: "IX_CategoryAttributes_BusinessId",
                table: "CategoryAttributes",
                column: "BusinessId");

            migrationBuilder.CreateIndex(
                name: "IX_Cities_ProvinceId",
                table: "Cities",
                column: "ProvinceId");

            migrationBuilder.CreateIndex(
                name: "IX_Contacts_ContactGroupId",
                table: "Contacts",
                column: "ContactGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Contacts_EmailId",
                table: "Contacts",
                column: "EmailId");

            migrationBuilder.CreateIndex(
                name: "IX_Contacts_MobileNumberId",
                table: "Contacts",
                column: "MobileNumberId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerActivities_CustomerId",
                table: "CustomerActivities",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerActivityHistories_CustomerActivityId",
                table: "CustomerActivityHistories",
                column: "CustomerActivityId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerActivityHistories_CustomerId",
                table: "CustomerActivityHistories",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerFeedbackHistories_CustomerFeedbackId",
                table: "CustomerFeedbackHistories",
                column: "CustomerFeedbackId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerFeedbackHistories_CustomerId",
                table: "CustomerFeedbackHistories",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerHashTags_CustomerNoteId",
                table: "CustomerHashTags",
                column: "CustomerNoteId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerNotes_CustomerId",
                table: "CustomerNotes",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerPeyGiries_CustomerId",
                table: "CustomerPeyGiries",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerRepresentativeHistories_CustomerId",
                table: "CustomerRepresentativeHistories",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerRepresentativeHistories_CustomerRepresentativeTypeId",
                table: "CustomerRepresentativeHistories",
                column: "CustomerRepresentativeTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_CityId",
                table: "Customers",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_CustomerCategoryId",
                table: "Customers",
                column: "CustomerCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_CustomerMoarefId",
                table: "Customers",
                column: "CustomerMoarefId");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_UserId",
                table: "Customers",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomersAddresses_CustomerId",
                table: "CustomersAddresses",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerSubmissions_UserId",
                table: "CustomerSubmissions",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_EmailAddresses_CustomerId",
                table: "EmailAddresses",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Logs_UserId",
                table: "Logs",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_NoteAttachments_CustomerNoteId",
                table: "NoteAttachments",
                column: "CustomerNoteId");

            migrationBuilder.CreateIndex(
                name: "IX_PhoneNumbers_CustomerId",
                table: "PhoneNumbers",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductCustomerFavoritesLists_CustomerId",
                table: "ProductCustomerFavoritesLists",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_IdCategoryNavigationId",
                table: "Products",
                column: "IdCategoryNavigationId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_IdCompanyNavigationId",
                table: "Products",
                column: "IdCompanyNavigationId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_IdParrentNavigationProductId",
                table: "Products",
                column: "IdParrentNavigationProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Provinces_CountryId",
                table: "Provinces",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_SanAts_UserId",
                table: "SanAts",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Settings_BusinessId",
                table: "Settings",
                column: "BusinessId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_CityId",
                table: "Users",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Visit_ProductId",
                table: "Visit",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_AttributeOptions_BusinessAttributes_BusinessAttributeId",
                table: "AttributeOptions",
                column: "BusinessAttributeId",
                principalTable: "BusinessAttributes",
                principalColumn: "BusinessAttributeId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AttributeOptionsValues_Customers_CustomerId",
                table: "AttributeOptionsValues",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "CustomerId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BusinessAttributes_CategoryAttributes_CategoryAttributeId",
                table: "BusinessAttributes",
                column: "CategoryAttributeId",
                principalTable: "CategoryAttributes",
                principalColumn: "CategoryAttributeId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_Cities_CityId",
                table: "Customers");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Cities_CityId",
                table: "Users");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_AspNetUsers_Id",
                table: "Users");

            migrationBuilder.DropForeignKey(
                name: "FK_AttributeOptions_BusinessAttributes_BusinessAttributeId",
                table: "AttributeOptions");

            migrationBuilder.DropForeignKey(
                name: "FK_Businesses_BusinessAttributes_BusinessAttributeId",
                table: "Businesses");

            migrationBuilder.DropForeignKey(
                name: "FK_AttributeOptionsValues_AttributeOptions_AttributeOptionsVal~",
                table: "AttributeOptionsValues");

            migrationBuilder.DropForeignKey(
                name: "FK_Businesses_AttributeOptions_AttributeOptionsId",
                table: "Businesses");

            migrationBuilder.DropForeignKey(
                name: "FK_AttributeOptionsValues_Customers_CustomerId",
                table: "AttributeOptionsValues");

            migrationBuilder.DropTable(
                name: "Addresses");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "CustomerActivityHistories");

            migrationBuilder.DropTable(
                name: "CustomerFeedbackHistories");

            migrationBuilder.DropTable(
                name: "CustomerHashTags");

            migrationBuilder.DropTable(
                name: "CustomerRepresentativeHistories");

            migrationBuilder.DropTable(
                name: "CustomersAddresses");

            migrationBuilder.DropTable(
                name: "CustomerSubmissions");

            migrationBuilder.DropTable(
                name: "EmailAddresses");

            migrationBuilder.DropTable(
                name: "Logs");

            migrationBuilder.DropTable(
                name: "NoteAttachments");

            migrationBuilder.DropTable(
                name: "PeyGiryAttachments");

            migrationBuilder.DropTable(
                name: "PhoneNumbers");

            migrationBuilder.DropTable(
                name: "Plans");

            migrationBuilder.DropTable(
                name: "Posts");

            migrationBuilder.DropTable(
                name: "ProductCustomerFavoritesLists");

            migrationBuilder.DropTable(
                name: "SanAts");

            migrationBuilder.DropTable(
                name: "Settings");

            migrationBuilder.DropTable(
                name: "Visit");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "CustomerActivities");

            migrationBuilder.DropTable(
                name: "CustomerFeedbacks");

            migrationBuilder.DropTable(
                name: "CustomerRepresentativeTypes");

            migrationBuilder.DropTable(
                name: "CustomerNotes");

            migrationBuilder.DropTable(
                name: "CustomerPeyGiries");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropTable(
                name: "Company");

            migrationBuilder.DropTable(
                name: "Cities");

            migrationBuilder.DropTable(
                name: "Provinces");

            migrationBuilder.DropTable(
                name: "Countries");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "BusinessAttributes");

            migrationBuilder.DropTable(
                name: "CategoryAttributes");

            migrationBuilder.DropTable(
                name: "AttributeOptions");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Businesses");

            migrationBuilder.DropTable(
                name: "CustomerCategories");

            migrationBuilder.DropTable(
                name: "AttributeOptionsValues");

            migrationBuilder.DropTable(
                name: "Contacts");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "ContactGroups");

            migrationBuilder.DropTable(
                name: "ContactPhoneNumbers");

            migrationBuilder.DropTable(
                name: "ContactsEmailAddress");
        }
    }
}
