using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class MaadMigration : Migration
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
                name: "ContactPhoneNumbers",
                columns: table => new
                {
                    ContactPhoneNumberId = table.Column<string>(type: "character varying(26)", nullable: false),
                    PhoneNo = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    PhoneType = table.Column<int>(type: "integer", nullable: false),
                    CustomerId = table.Column<string>(type: "character varying(26)", nullable: false),
                    ContactPhoneNumberStatus = table.Column<int>(type: "integer", nullable: false),
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
                    ContactsEmailAddressStatus = table.Column<int>(type: "integer", nullable: false),
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
                    CountryStatus = table.Column<int>(type: "integer", nullable: false),
                    Country = table.Column<string>(type: "character varying(26)", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DateLastUpdate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.CountryId);
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
                        principalColumn: "Id",
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
                    ProvinceStatus = table.Column<int>(type: "integer", nullable: false),
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
                name: "Products",
                columns: table => new
                {
                    ProductId = table.Column<string>(type: "character varying(26)", nullable: false),
                    ProductName = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    ProductCategoryId = table.Column<string>(type: "character varying(26)", nullable: false),
                    Title = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    Summery = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    Price = table.Column<decimal>(type: "numeric", nullable: false),
                    SecondaryPrice = table.Column<decimal>(type: "numeric", nullable: false),
                    Discount = table.Column<decimal>(type: "numeric", nullable: false),
                    DiscountPercent = table.Column<byte>(type: "smallint", nullable: false),
                    FavoritesListId = table.Column<string>(type: "character varying(26)", nullable: false),
                    Picture = table.Column<byte[]>(type: "bytea", nullable: false),
                    PublishStatus = table.Column<byte>(type: "smallint", nullable: false),
                    ProductStatus = table.Column<int>(type: "integer", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DateLastUpdate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductId);
                    table.ForeignKey(
                        name: "FK_Products_ProductCategories_ProductCategoryId",
                        column: x => x.ProductCategoryId,
                        principalTable: "ProductCategories",
                        principalColumn: "ProductCategoryId",
                        onDelete: ReferentialAction.Cascade);
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
                    CityStatus = table.Column<int>(type: "integer", nullable: false),
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
                name: "Visit",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    IdUser = table.Column<string>(type: "text", nullable: false),
                    IpAddress = table.Column<string>(type: "text", nullable: false),
                    UserAgent = table.Column<string>(type: "text", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ProductId = table.Column<string>(type: "character varying(26)", nullable: true),
                    DateLastUpdate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
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
                    AddressStatus = table.Column<int>(type: "integer", nullable: false),
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
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Discriminator = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    Family = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    CodeMelli = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    Address = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    PostalCode = table.Column<string>(type: "text", nullable: true),
                    Married = table.Column<byte>(type: "smallint", nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Gender = table.Column<byte>(type: "smallint", nullable: true),
                    CityId = table.Column<string>(type: "character varying(26)", nullable: true),
                    LoginCount = table.Column<int>(type: "integer", nullable: true),
                    LastLogin = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    UserAgent = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    LastIp = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    Flag = table.Column<byte>(type: "smallint", nullable: true),
                    Limited = table.Column<bool>(type: "boolean", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    WebSite = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    OtpPassword = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    OtpPasswordExpired = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    LastLoginDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    BusinessId = table.Column<string>(type: "character varying(26)", nullable: true),
                    UserStatus = table.Column<int>(type: "integer", nullable: true),
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
                    table.ForeignKey(
                        name: "FK_AspNetUsers_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "CityId");
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
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CustomerCategories",
                columns: table => new
                {
                    CustomerCategoryId = table.Column<string>(type: "character varying(26)", nullable: false),
                    CustomerCategoryName = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    CustomerCategoryStatus = table.Column<int>(type: "integer", nullable: false),
                    UserId = table.Column<string>(type: "text", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DateLastUpdate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerCategories", x => x.CustomerCategoryId);
                    table.ForeignKey(
                        name: "FK_CustomerCategories_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Logs",
                columns: table => new
                {
                    Id = table.Column<string>(type: "character varying(26)", nullable: false),
                    UserId = table.Column<string>(type: "text", nullable: false),
                    Kind = table.Column<byte>(type: "smallint", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Log = table.Column<string>(type: "character varying(26)", nullable: false),
                    DateLastUpdate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Logs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Logs_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Plans",
                columns: table => new
                {
                    PlanId = table.Column<string>(type: "character varying(26)", nullable: false),
                    PlanName = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    CountOfUsers = table.Column<long>(type: "bigint", nullable: false),
                    PriceOfUsers = table.Column<decimal>(type: "numeric", nullable: false),
                    CountOfDay = table.Column<long>(type: "bigint", nullable: false),
                    PriceOfDay = table.Column<decimal>(type: "numeric", nullable: false),
                    Discount = table.Column<decimal>(type: "numeric", nullable: true),
                    FinalPrice = table.Column<decimal>(type: "numeric", nullable: false),
                    UserId = table.Column<string>(type: "text", nullable: false),
                    PlanStatus = table.Column<int>(type: "integer", nullable: false),
                    Plan = table.Column<string>(type: "character varying(26)", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DateLastUpdate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: false),
                    UpdatedBy = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Plans", x => x.PlanId);
                    table.ForeignKey(
                        name: "FK_Plans_AspNetUsers_UpdatedBy",
                        column: x => x.UpdatedBy,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Plans_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SanAts",
                columns: table => new
                {
                    SanAtId = table.Column<string>(type: "character varying(26)", nullable: false),
                    SanAtName = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false),
                    UserId = table.Column<string>(type: "text", nullable: false),
                    SanAtStatus = table.Column<int>(type: "integer", nullable: false),
                    SanAt = table.Column<string>(type: "character varying(26)", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DateLastUpdate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SanAts", x => x.SanAtId);
                    table.ForeignKey(
                        name: "FK_SanAts_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    CustomerId = table.Column<string>(type: "character varying(26)", nullable: false),
                    FirstName = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    LastName = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    BirthDayDate = table.Column<DateOnly>(type: "date", nullable: false),
                    CustomerPic = table.Column<byte[]>(type: "bytea", nullable: true),
                    CityId = table.Column<string>(type: "character varying(26)", nullable: false),
                    CustomerCategoryId = table.Column<string>(type: "character varying(26)", nullable: false),
                    Gender = table.Column<byte>(type: "smallint", nullable: false),
                    CustomerStatus = table.Column<int>(type: "integer", nullable: false),
                    CustomerState = table.Column<int>(type: "integer", nullable: false),
                    CustomerActivationStatus = table.Column<int>(type: "integer", nullable: false),
                    CustomerMoarefId = table.Column<string>(type: "character varying(26)", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DateLastUpdate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: false),
                    UpdatedBy = table.Column<string>(type: "text", nullable: true),
                    UpdaterUserId = table.Column<string>(type: "text", nullable: true),
                    UserId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.CustomerId);
                    table.ForeignKey(
                        name: "FK_Customers_AspNetUsers_UpdaterUserId",
                        column: x => x.UpdaterUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Customers_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
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
                        principalColumn: "CustomerId");
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
                    CustomerId = table.Column<string>(type: "character varying(26)", nullable: false),
                    CustomerNoteStatus = table.Column<int>(type: "integer", nullable: false),
                    CustomerNote = table.Column<string>(type: "character varying(26)", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DateLastUpdate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: false),
                    UpdatedBy = table.Column<string>(type: "text", nullable: true),
                    UpdaterUserId = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerNotes", x => x.CustomerNoteId);
                    table.ForeignKey(
                        name: "FK_CustomerNotes_AspNetUsers_UpdatedBy",
                        column: x => x.UpdatedBy,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CustomerNotes_AspNetUsers_UpdaterUserId",
                        column: x => x.UpdaterUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
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
                    CustomerId = table.Column<string>(type: "character varying(26)", nullable: false),
                    CustomerPeyGiryStatus = table.Column<int>(type: "integer", nullable: false),
                    CustomerPeyGiry = table.Column<string>(type: "character varying(26)", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DateLastUpdate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: false),
                    UpdatedBy = table.Column<string>(type: "text", nullable: true),
                    UpdaterUserId = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerPeyGiries", x => x.CustomerPeyGiryId);
                    table.ForeignKey(
                        name: "FK_CustomerPeyGiries_AspNetUsers_UpdatedBy",
                        column: x => x.UpdatedBy,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CustomerPeyGiries_AspNetUsers_UpdaterUserId",
                        column: x => x.UpdaterUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
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
                    CustomersAddressStatus = table.Column<int>(type: "integer", nullable: false),
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
                        name: "FK_CustomerSubmissions_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CustomerSubmissions_Customers_CustomerSubmissionId",
                        column: x => x.CustomerSubmissionId,
                        principalTable: "Customers",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EmailAddresses",
                columns: table => new
                {
                    CustomersEmailAddressId = table.Column<string>(type: "character varying(26)", nullable: false),
                    CustomersEmailAddrs = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    CustomerId = table.Column<string>(type: "character varying(26)", nullable: false),
                    CustomersEmailAddressStatus = table.Column<int>(type: "integer", nullable: false),
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
                    CustomersPhoneNumberStatus = table.Column<int>(type: "integer", nullable: false),
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
                    ProductCustomerFavoritesListStatus = table.Column<int>(type: "integer", nullable: false),
                    ProductCustomerFavoritesList = table.Column<string>(type: "character varying(26)", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DateLastUpdate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
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
                name: "CustomerHashTags",
                columns: table => new
                {
                    NoteHashTagId = table.Column<string>(type: "character varying(26)", nullable: false),
                    Title = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    CustomerNoteId = table.Column<string>(type: "character varying(26)", nullable: false),
                    NoteHashTagStatus = table.Column<int>(type: "integer", nullable: false),
                    NoteHashTag = table.Column<string>(type: "character varying(26)", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DateLastUpdate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: false),
                    UpdatedBy = table.Column<string>(type: "text", nullable: true),
                    UpdaterUserId = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerHashTags", x => x.NoteHashTagId);
                    table.ForeignKey(
                        name: "FK_CustomerHashTags_AspNetUsers_UpdatedBy",
                        column: x => x.UpdatedBy,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CustomerHashTags_AspNetUsers_UpdaterUserId",
                        column: x => x.UpdaterUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
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
                    NoteAttachmentStatus = table.Column<int>(type: "integer", nullable: false),
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
                    StatusPeyGiryAttachment = table.Column<int>(type: "integer", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DateLastUpdate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: false),
                    UpdatedBy = table.Column<string>(type: "text", nullable: true),
                    UpdaterUserId = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PeyGiryAttachments", x => x.PeyGiryAttachmentId);
                    table.ForeignKey(
                        name: "FK_PeyGiryAttachments_AspNetUsers_UpdatedBy",
                        column: x => x.UpdatedBy,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PeyGiryAttachments_AspNetUsers_UpdaterUserId",
                        column: x => x.UpdaterUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PeyGiryAttachments_CustomerPeyGiries_PeyGiryAttachmentId",
                        column: x => x.PeyGiryAttachmentId,
                        principalTable: "CustomerPeyGiries",
                        principalColumn: "CustomerPeyGiryId",
                        onDelete: ReferentialAction.Cascade);
                });

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
                name: "AttributeOptions",
                columns: table => new
                {
                    AttributeOptionsId = table.Column<string>(type: "character varying(26)", nullable: false),
                    Title = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    ColorSquaresRgb = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    BusinessAttributeId = table.Column<string>(type: "character varying(26)", nullable: false),
                    DisplayOrder = table.Column<int>(type: "integer", nullable: false),
                    BusinessId = table.Column<string>(type: "character varying(26)", nullable: true),
                    AttributeOptionsStatus = table.Column<int>(type: "integer", nullable: false),
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
                    BusinessId = table.Column<string>(type: "character varying(26)", nullable: false),
                    AttributeOptionsValueStatus = table.Column<int>(type: "integer", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DateLastUpdate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AttributeOptionsValues", x => x.AttributeOptionsValueId);
                    table.ForeignKey(
                        name: "FK_AttributeOptionsValues_AttributeOptions_AttributeOptionId",
                        column: x => x.AttributeOptionId,
                        principalTable: "AttributeOptions",
                        principalColumn: "AttributeOptionsId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AttributeOptionsValues_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "CustomerId",
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
                    BusinessAttributeStatus = table.Column<int>(type: "integer", nullable: false),
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
                    Url = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    Hosts = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    CompanyName = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    CompanyAddress = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    DisplayOrder = table.Column<int>(type: "integer", nullable: true),
                    BusinessStatus = table.Column<int>(type: "integer", nullable: false),
                    BusinessAttributeId = table.Column<string>(type: "character varying(26)", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DateLastUpdate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Businesses", x => x.BusinessId);
                    table.ForeignKey(
                        name: "FK_Businesses_BusinessAttributes_BusinessAttributeId",
                        column: x => x.BusinessAttributeId,
                        principalTable: "BusinessAttributes",
                        principalColumn: "BusinessAttributeId");
                });

            migrationBuilder.CreateTable(
                name: "CategoryAttributes",
                columns: table => new
                {
                    CategoryAttributeId = table.Column<string>(type: "character varying(26)", nullable: false),
                    Name = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    Description = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    DisplayOrder = table.Column<int>(type: "integer", nullable: false),
                    CategoryAttributeStatus = table.Column<int>(type: "integer", nullable: false),
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
                name: "ContactGroups",
                columns: table => new
                {
                    ContactGroupId = table.Column<string>(type: "character varying(26)", nullable: false),
                    GroupName = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    DisplayOrder = table.Column<int>(type: "integer", nullable: false),
                    ContactGroupStatus = table.Column<int>(type: "integer", nullable: false),
                    BusinessId = table.Column<string>(type: "character varying(26)", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DateLastUpdate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactGroups", x => x.ContactGroupId);
                    table.ForeignKey(
                        name: "FK_ContactGroups_Businesses_BusinessId",
                        column: x => x.BusinessId,
                        principalTable: "Businesses",
                        principalColumn: "BusinessId",
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
                name: "UsersPlans",
                columns: table => new
                {
                    BusinessPlansId = table.Column<string>(type: "character varying(26)", nullable: false),
                    PlanId = table.Column<string>(type: "character varying(26)", nullable: false),
                    BusinessId = table.Column<string>(type: "character varying(26)", nullable: false),
                    CountOfDay = table.Column<long>(type: "bigint", nullable: false),
                    CountOfUsers = table.Column<long>(type: "bigint", nullable: false),
                    StartDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    FinishDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    BusinessPlansStatus = table.Column<int>(type: "integer", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DateLastUpdate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: false),
                    UpdatedBy = table.Column<string>(type: "text", nullable: true),
                    CreatorUserId = table.Column<string>(type: "text", nullable: false),
                    UpdaterUserId = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsersPlans", x => x.BusinessPlansId);
                    table.ForeignKey(
                        name: "FK_UsersPlans_AspNetUsers_CreatorUserId",
                        column: x => x.CreatorUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UsersPlans_AspNetUsers_UpdaterUserId",
                        column: x => x.UpdaterUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UsersPlans_Businesses_BusinessId",
                        column: x => x.BusinessId,
                        principalTable: "Businesses",
                        principalColumn: "BusinessId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UsersPlans_Plans_PlanId",
                        column: x => x.PlanId,
                        principalTable: "Plans",
                        principalColumn: "PlanId",
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
                    BusinessId = table.Column<string>(type: "character varying(26)", nullable: false),
                    ContactStatus = table.Column<int>(type: "integer", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DateLastUpdate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contacts", x => x.ContactId);
                    table.ForeignKey(
                        name: "FK_Contacts_Businesses_BusinessId",
                        column: x => x.BusinessId,
                        principalTable: "Businesses",
                        principalColumn: "BusinessId",
                        onDelete: ReferentialAction.Cascade);
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
                name: "IX_AspNetUsers_BusinessId",
                table: "AspNetUsers",
                column: "BusinessId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_CityId",
                table: "AspNetUsers",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_Email",
                table: "AspNetUsers",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_UserName",
                table: "AspNetUsers",
                column: "UserName",
                unique: true);

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
                name: "IX_AttributeOptions_BusinessId",
                table: "AttributeOptions",
                column: "BusinessId");

            migrationBuilder.CreateIndex(
                name: "IX_AttributeOptionsValues_AttributeOptionId",
                table: "AttributeOptionsValues",
                column: "AttributeOptionId");

            migrationBuilder.CreateIndex(
                name: "IX_AttributeOptionsValues_BusinessId",
                table: "AttributeOptionsValues",
                column: "BusinessId");

            migrationBuilder.CreateIndex(
                name: "IX_AttributeOptionsValues_CustomerId",
                table: "AttributeOptionsValues",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_BusinessAttributes_CategoryAttributeId",
                table: "BusinessAttributes",
                column: "CategoryAttributeId");

            migrationBuilder.CreateIndex(
                name: "IX_Businesses_BusinessAttributeId",
                table: "Businesses",
                column: "BusinessAttributeId");

            migrationBuilder.CreateIndex(
                name: "IX_CategoryAttributes_BusinessId",
                table: "CategoryAttributes",
                column: "BusinessId");

            migrationBuilder.CreateIndex(
                name: "IX_Cities_ProvinceId",
                table: "Cities",
                column: "ProvinceId");

            migrationBuilder.CreateIndex(
                name: "IX_ContactGroups_BusinessId",
                table: "ContactGroups",
                column: "BusinessId");

            migrationBuilder.CreateIndex(
                name: "IX_Contacts_BusinessId",
                table: "Contacts",
                column: "BusinessId");

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
                name: "IX_CustomerCategories_UserId",
                table: "CustomerCategories",
                column: "UserId");

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
                name: "IX_CustomerHashTags_UpdatedBy",
                table: "CustomerHashTags",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerHashTags_UpdaterUserId",
                table: "CustomerHashTags",
                column: "UpdaterUserId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerNotes_CustomerId",
                table: "CustomerNotes",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerNotes_UpdatedBy",
                table: "CustomerNotes",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerNotes_UpdaterUserId",
                table: "CustomerNotes",
                column: "UpdaterUserId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerPeyGiries_CustomerId",
                table: "CustomerPeyGiries",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerPeyGiries_UpdatedBy",
                table: "CustomerPeyGiries",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerPeyGiries_UpdaterUserId",
                table: "CustomerPeyGiries",
                column: "UpdaterUserId");

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
                name: "IX_Customers_UpdaterUserId",
                table: "Customers",
                column: "UpdaterUserId");

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
                name: "IX_Logs_UserId",
                table: "Logs",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_NoteAttachments_CustomerNoteId",
                table: "NoteAttachments",
                column: "CustomerNoteId");

            migrationBuilder.CreateIndex(
                name: "IX_PeyGiryAttachments_UpdatedBy",
                table: "PeyGiryAttachments",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_PeyGiryAttachments_UpdaterUserId",
                table: "PeyGiryAttachments",
                column: "UpdaterUserId");

            migrationBuilder.CreateIndex(
                name: "IX_PhoneNumbers_CustomerId",
                table: "PhoneNumbers",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Plans_UpdatedBy",
                table: "Plans",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Plans_UserId",
                table: "Plans",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductCategories_ParentId",
                table: "ProductCategories",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductCustomerFavoritesLists_CustomerId",
                table: "ProductCustomerFavoritesLists",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_ProductCategoryId",
                table: "Products",
                column: "ProductCategoryId");

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
                name: "IX_UsersPlans_BusinessId",
                table: "UsersPlans",
                column: "BusinessId");

            migrationBuilder.CreateIndex(
                name: "IX_UsersPlans_CreatorUserId",
                table: "UsersPlans",
                column: "CreatorUserId");

            migrationBuilder.CreateIndex(
                name: "IX_UsersPlans_PlanId",
                table: "UsersPlans",
                column: "PlanId");

            migrationBuilder.CreateIndex(
                name: "IX_UsersPlans_UpdaterUserId",
                table: "UsersPlans",
                column: "UpdaterUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Visit_ProductId",
                table: "Visit",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                table: "AspNetUserClaims",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                table: "AspNetUserLogins",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                table: "AspNetUserRoles",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Businesses_BusinessId",
                table: "AspNetUsers",
                column: "BusinessId",
                principalTable: "Businesses",
                principalColumn: "BusinessId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AttributeOptions_BusinessAttributes_BusinessAttributeId",
                table: "AttributeOptions",
                column: "BusinessAttributeId",
                principalTable: "BusinessAttributes",
                principalColumn: "BusinessAttributeId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AttributeOptions_Businesses_BusinessId",
                table: "AttributeOptions",
                column: "BusinessId",
                principalTable: "Businesses",
                principalColumn: "BusinessId");

            migrationBuilder.AddForeignKey(
                name: "FK_AttributeOptionsValues_Businesses_BusinessId",
                table: "AttributeOptionsValues",
                column: "BusinessId",
                principalTable: "Businesses",
                principalColumn: "BusinessId",
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
                name: "FK_CategoryAttributes_Businesses_BusinessId",
                table: "CategoryAttributes");

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
                name: "AttributeOptionsValues");

            migrationBuilder.DropTable(
                name: "Contacts");

            migrationBuilder.DropTable(
                name: "CustomerActivities");

            migrationBuilder.DropTable(
                name: "CustomerFeedbackHistories");

            migrationBuilder.DropTable(
                name: "CustomerHashTags");

            migrationBuilder.DropTable(
                name: "CustomerRepresentativeHistories");

            migrationBuilder.DropTable(
                name: "CustomerSubmissions");

            migrationBuilder.DropTable(
                name: "EmailAddresses");

            migrationBuilder.DropTable(
                name: "ForoshFactors");

            migrationBuilder.DropTable(
                name: "ForoshOrders");

            migrationBuilder.DropTable(
                name: "Logs");

            migrationBuilder.DropTable(
                name: "NoteAttachments");

            migrationBuilder.DropTable(
                name: "PeyGiryAttachments");

            migrationBuilder.DropTable(
                name: "PhoneNumbers");

            migrationBuilder.DropTable(
                name: "ProductCustomerFavoritesLists");

            migrationBuilder.DropTable(
                name: "SanAts");

            migrationBuilder.DropTable(
                name: "Settings");

            migrationBuilder.DropTable(
                name: "UsersPlans");

            migrationBuilder.DropTable(
                name: "Visit");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AttributeOptions");

            migrationBuilder.DropTable(
                name: "ContactGroups");

            migrationBuilder.DropTable(
                name: "ContactPhoneNumbers");

            migrationBuilder.DropTable(
                name: "ContactsEmailAddress");

            migrationBuilder.DropTable(
                name: "CustomerFeedbacks");

            migrationBuilder.DropTable(
                name: "CustomerRepresentativeTypes");

            migrationBuilder.DropTable(
                name: "CustomersAddresses");

            migrationBuilder.DropTable(
                name: "CustomerNotes");

            migrationBuilder.DropTable(
                name: "CustomerPeyGiries");

            migrationBuilder.DropTable(
                name: "Plans");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "ProductCategories");

            migrationBuilder.DropTable(
                name: "CustomerCategories");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Cities");

            migrationBuilder.DropTable(
                name: "Provinces");

            migrationBuilder.DropTable(
                name: "Countries");

            migrationBuilder.DropTable(
                name: "Businesses");

            migrationBuilder.DropTable(
                name: "BusinessAttributes");

            migrationBuilder.DropTable(
                name: "CategoryAttributes");
        }
    }
}
