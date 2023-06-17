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
                name: "Businesses",
                columns: table => new
                {
                    Id = table.Column<string>(type: "character varying(26)", nullable: false),
                    BusinessName = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    Url = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    Hosts = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    CompanyName = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    CompanyAddress = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    DisplayOrder = table.Column<int>(type: "integer", nullable: true),
                    StatusTypeBusiness = table.Column<int>(type: "integer", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DateLastUpdate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Version = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Businesses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ContactGroups",
                columns: table => new
                {
                    Id = table.Column<string>(type: "character varying(26)", nullable: false),
                    GroupName = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    DisplayOrder = table.Column<int>(type: "integer", nullable: false),
                    ContactGroupStatusType = table.Column<int>(type: "integer", nullable: false),
                    BusinessId = table.Column<string>(type: "character varying(26)", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DateLastUpdate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Version = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactGroups", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    Id = table.Column<string>(type: "character varying(26)", nullable: false),
                    CountryName = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    IsDefault = table.Column<bool>(type: "boolean", nullable: false),
                    DisplayOrder = table.Column<long>(type: "bigint", nullable: false),
                    CountryStatusType = table.Column<int>(type: "integer", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DateLastUpdate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Version = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CustomerActivities",
                columns: table => new
                {
                    Id = table.Column<string>(type: "character varying(26)", nullable: false),
                    CustomerActivityName = table.Column<string>(type: "text", nullable: false),
                    CustomerActivityDescription = table.Column<string>(type: "text", nullable: false),
                    CustomerId = table.Column<string>(type: "character varying(26)", nullable: false),
                    CustomerActivityStatusType = table.Column<int>(type: "integer", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DateLastUpdate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Version = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerActivities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Plans",
                columns: table => new
                {
                    Id = table.Column<string>(type: "character varying(26)", nullable: false),
                    PlanName = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    CountOfUsers = table.Column<long>(type: "bigint", nullable: false),
                    PriceOfUsers = table.Column<decimal>(type: "numeric", nullable: false),
                    CountOfDay = table.Column<long>(type: "bigint", nullable: false),
                    PriceOfDay = table.Column<decimal>(type: "numeric", nullable: false),
                    Discount = table.Column<decimal>(type: "numeric", nullable: true),
                    PriceFinal = table.Column<decimal>(type: "numeric", nullable: false),
                    StatusTypePlan = table.Column<int>(type: "integer", nullable: false),
                    UserId = table.Column<string>(type: "text", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DateLastUpdate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Version = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Plans", x => x.Id);
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
                    UserStatusType = table.Column<int>(type: "integer", nullable: true),
                    Token = table.Column<string>(type: "text", nullable: true),
                    IdBusiness = table.Column<string>(type: "character varying(26)", nullable: true),
                    UserName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    PasswordHash = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    SecurityStamp = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    PhoneNumber = table.Column<string>(type: "character varying(11)", maxLength: 11, nullable: true),
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
                        name: "FK_Business_User",
                        column: x => x.IdBusiness,
                        principalTable: "Businesses",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "NoteHashTables",
                columns: table => new
                {
                    Id = table.Column<string>(type: "character varying(26)", nullable: false),
                    Title = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    NoteHashTagStatusType = table.Column<int>(type: "integer", nullable: false),
                    IdBusiness = table.Column<string>(type: "character varying(26)", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DateLastUpdate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    xmin = table.Column<uint>(type: "xid", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NoteHashTables", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CustomersEmailAddress_Business",
                        column: x => x.IdBusiness,
                        principalTable: "Businesses",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Contacts",
                columns: table => new
                {
                    Id = table.Column<string>(type: "character varying(26)", nullable: false),
                    FirstName = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    LastName = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    MobileNumberId = table.Column<string>(type: "character varying(26)", nullable: true),
                    EmailId = table.Column<string>(type: "character varying(26)", nullable: true),
                    Job = table.Column<string>(type: "text", nullable: true),
                    BusinessId = table.Column<string>(type: "character varying(26)", nullable: false),
                    ContactStatusType = table.Column<int>(type: "integer", nullable: false),
                    ContactGroupId = table.Column<string>(type: "character varying(26)", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DateLastUpdate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Version = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contacts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ContactGroup_Contact",
                        column: x => x.ContactGroupId,
                        principalTable: "ContactGroups",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Provinces",
                columns: table => new
                {
                    Id = table.Column<string>(type: "character varying(26)", nullable: false),
                    ProvinceName = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    IsDefault = table.Column<bool>(type: "boolean", nullable: false),
                    DisplayOrder = table.Column<long>(type: "bigint", nullable: false),
                    ProvinceStatusType = table.Column<int>(type: "integer", nullable: false),
                    IdCountry = table.Column<string>(type: "character varying(26)", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DateLastUpdate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Version = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Provinces", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Province_Country",
                        column: x => x.IdCountry,
                        principalTable: "Countries",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "BusinessPlans",
                columns: table => new
                {
                    Id = table.Column<string>(type: "character varying(26)", nullable: false),
                    PlanId = table.Column<string>(type: "character varying(26)", nullable: false),
                    BusinessId = table.Column<string>(type: "character varying(26)", nullable: false),
                    CountOfDay = table.Column<long>(type: "bigint", nullable: false),
                    CountOfUsers = table.Column<long>(type: "bigint", nullable: false),
                    StartDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    FinishDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    BusinessPlansStatusType = table.Column<int>(type: "integer", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DateLastUpdate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Version = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BusinessPlans", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BusinessPlans_Plans_PlanId",
                        column: x => x.PlanId,
                        principalTable: "Plans",
                        principalColumn: "Id",
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
                        principalColumn: "Id",
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
                        principalColumn: "Id",
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
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
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
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Attributes",
                columns: table => new
                {
                    Id = table.Column<string>(type: "character varying(26)", nullable: false),
                    Label = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    DisplayOrder = table.Column<int>(type: "integer", nullable: false),
                    IsRequired = table.Column<bool>(type: "boolean", nullable: false),
                    AttributeInputTypeId = table.Column<byte>(type: "smallint", nullable: false),
                    AttributeTypeId = table.Column<byte>(type: "smallint", nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    ValidationMinLength = table.Column<int>(type: "integer", nullable: true),
                    ValidationMaxLength = table.Column<int>(type: "integer", nullable: true),
                    ValidationFileAllowExtension = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    ValidationFileMaximumSize = table.Column<int>(type: "integer", nullable: true),
                    DefaultValue = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    IdBusiness = table.Column<string>(type: "character varying(26)", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DateLastUpdate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Version = table.Column<long>(type: "bigint", nullable: false),
                    IdUserUpdated = table.Column<string>(type: "text", nullable: false),
                    IdUserAdded = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Attributes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Attribute_Business",
                        column: x => x.IdBusiness,
                        principalTable: "Businesses",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Attribute_User_Added",
                        column: x => x.IdUserAdded,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Attribute_User_Updated",
                        column: x => x.IdUserUpdated,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CustomerFeedbackCategories",
                columns: table => new
                {
                    Id = table.Column<string>(type: "character varying(26)", nullable: false),
                    Name = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    TypeFeedback = table.Column<int>(type: "integer", nullable: false),
                    PositiveNegative = table.Column<bool>(type: "boolean", nullable: false),
                    CustomerFeedbackCategoryStatusType = table.Column<int>(type: "integer", nullable: false),
                    IdBusiness = table.Column<string>(type: "character varying(26)", nullable: false),
                    UserId = table.Column<string>(type: "text", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DateLastUpdate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    xmin = table.Column<uint>(type: "xid", rowVersion: true, nullable: false),
                    IdUserUpdated = table.Column<string>(type: "text", nullable: false),
                    IdUserAdded = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerFeedbackCategories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CustomerFeedbackCategories_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CustomerFeedbackCategory_Business",
                        column: x => x.IdBusiness,
                        principalTable: "Businesses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CustomerFeedbackCategory_User_Updated",
                        column: x => x.IdUserUpdated,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CustomerFeedbacksCategory_User_Added",
                        column: x => x.IdUserAdded,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PeyGiryCategories",
                columns: table => new
                {
                    Id = table.Column<string>(type: "character varying(26)", nullable: false),
                    Kind = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    BusinessId = table.Column<string>(type: "character varying(26)", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DateLastUpdate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Version = table.Column<long>(type: "bigint", nullable: false),
                    IdUserUpdated = table.Column<string>(type: "text", nullable: false),
                    IdUserAdded = table.Column<string>(type: "text", nullable: false),
                    IdUser = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PeyGiryCategories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Business_PeyGiryCategory",
                        column: x => x.BusinessId,
                        principalTable: "Businesses",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UserAdded_PeyGiryCategory",
                        column: x => x.IdUserAdded,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UserUpdated_PeyGiryCategory",
                        column: x => x.IdUserUpdated,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_User_PeyGiryCategory",
                        column: x => x.IdUser,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ProductCategories",
                columns: table => new
                {
                    Id = table.Column<string>(type: "character varying(26)", nullable: false),
                    Order = table.Column<byte>(type: "smallint", nullable: true),
                    ProductCategoryName = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    Description = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    Icon = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    ProductCategoryStatusType = table.Column<int>(type: "integer", nullable: false),
                    BusinessId = table.Column<string>(type: "character varying(26)", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DateLastUpdate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Version = table.Column<long>(type: "bigint", nullable: false),
                    IdUserUpdated = table.Column<string>(type: "text", nullable: false),
                    IdUserUpdateNavigationId = table.Column<string>(type: "text", nullable: true),
                    IdUserAdded = table.Column<string>(type: "text", nullable: false),
                    IdUserAddNavigationId = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductCategories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductCategories_AspNetUsers_IdUserAddNavigationId",
                        column: x => x.IdUserAddNavigationId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ProductCategories_AspNetUsers_IdUserUpdateNavigationId",
                        column: x => x.IdUserUpdateNavigationId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ProductCategories_Business",
                        column: x => x.BusinessId,
                        principalTable: "Businesses",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ContactPhoneNumbers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "character varying(26)", nullable: false),
                    ContactId = table.Column<string>(type: "character varying(26)", nullable: false),
                    PhoneNo = table.Column<string>(type: "character varying(11)", maxLength: 11, nullable: false),
                    PhoneType = table.Column<int>(type: "integer", nullable: false),
                    CustomerId = table.Column<string>(type: "character varying(26)", nullable: false),
                    ContactPhoneNumberStatusType = table.Column<int>(type: "integer", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DateLastUpdate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Version = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactPhoneNumbers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ContactPhoneNumbers_Contacts_ContactId",
                        column: x => x.ContactId,
                        principalTable: "Contacts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ContactsEmailAddress",
                columns: table => new
                {
                    Id = table.Column<string>(type: "character varying(26)", nullable: false),
                    ContactId = table.Column<string>(type: "character varying(26)", nullable: false),
                    ContactEmailAddress = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    ContactsEmailAddressStatusType = table.Column<int>(type: "integer", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DateLastUpdate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Version = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactsEmailAddress", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ContactsEmailAddress_Contacts_ContactId",
                        column: x => x.ContactId,
                        principalTable: "Contacts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    Id = table.Column<string>(type: "character varying(26)", nullable: false),
                    CityName = table.Column<string>(type: "text", nullable: false),
                    IsDefault = table.Column<bool>(type: "boolean", nullable: false),
                    DisplayOrder = table.Column<long>(type: "bigint", nullable: false),
                    IdProvince = table.Column<string>(type: "character varying(26)", nullable: false),
                    CityStatusType = table.Column<int>(type: "integer", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DateLastUpdate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    xmin = table.Column<uint>(type: "xid", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_City_Province",
                        column: x => x.IdProvince,
                        principalTable: "Provinces",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AttributeOptions",
                columns: table => new
                {
                    Id = table.Column<string>(type: "character varying(26)", nullable: false),
                    Title = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    ColorSquaresRgb = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    DisplayOrder = table.Column<int>(type: "integer", nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    IdAttribute = table.Column<string>(type: "character varying(26)", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DateLastUpdate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Version = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AttributeOptions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AttributeOption_Attribute",
                        column: x => x.IdAttribute,
                        principalTable: "Attributes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<string>(type: "character varying(26)", nullable: false),
                    ProductName = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    Title = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    Summery = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    Price = table.Column<decimal>(type: "numeric", nullable: true),
                    SecondaryPrice = table.Column<decimal>(type: "numeric", nullable: true),
                    Discount = table.Column<decimal>(type: "numeric", nullable: true),
                    DiscountPercent = table.Column<byte>(type: "smallint", nullable: true),
                    Picture = table.Column<byte[]>(type: "bytea", nullable: true),
                    StatusPublish = table.Column<byte>(type: "smallint", nullable: false),
                    StatusTypeProduct = table.Column<int>(type: "integer", nullable: false),
                    IdProductCategory = table.Column<string>(type: "character varying(26)", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DateLastUpdate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Version = table.Column<long>(type: "bigint", nullable: false),
                    IdUserUpdated = table.Column<string>(type: "text", nullable: false),
                    IdUserUpdateNavigationId = table.Column<string>(type: "text", nullable: true),
                    IdUserAdded = table.Column<string>(type: "text", nullable: false),
                    IdUserAddNavigationId = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Product_ProductCategory",
                        column: x => x.IdProductCategory,
                        principalTable: "ProductCategories",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Products_AspNetUsers_IdUserAddNavigationId",
                        column: x => x.IdUserAddNavigationId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Products_AspNetUsers_IdUserUpdateNavigationId",
                        column: x => x.IdUserUpdateNavigationId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "character varying(26)", nullable: false),
                    FirstName = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    LastName = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    BirthDayDate = table.Column<DateOnly>(type: "date", nullable: true),
                    CustomerPic = table.Column<byte[]>(type: "bytea", nullable: true),
                    Gender = table.Column<byte>(type: "smallint", nullable: true),
                    CustomerStatusType = table.Column<int>(type: "integer", nullable: false),
                    CustomerState = table.Column<int>(type: "integer", nullable: false),
                    CustomerActivationStatus = table.Column<int>(type: "integer", nullable: false),
                    IdMoaref = table.Column<string>(type: "character varying(26)", nullable: true),
                    IdCity = table.Column<string>(type: "character varying(26)", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DateLastUpdate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    xmin = table.Column<uint>(type: "xid", rowVersion: true, nullable: false),
                    IdUserUpdated = table.Column<string>(type: "text", nullable: false),
                    IdUserAdded = table.Column<string>(type: "text", nullable: false),
                    IdUser = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Customer_City",
                        column: x => x.IdCity,
                        principalTable: "Cities",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Customer_MoAref",
                        column: x => x.IdMoaref,
                        principalTable: "Customers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Customer_User",
                        column: x => x.IdUser,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Customers_User_Added",
                        column: x => x.IdUserAdded,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Customers_User_Updated",
                        column: x => x.IdUserUpdated,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AttributeOptionsValues",
                columns: table => new
                {
                    Id = table.Column<string>(type: "character varying(26)", nullable: false),
                    Value = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    FilePath = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    IdAttributeOption = table.Column<string>(type: "character varying(26)", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DateLastUpdate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Version = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AttributeOptionsValues", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AttributeOption_AttributeOptionValue",
                        column: x => x.IdAttributeOption,
                        principalTable: "AttributeOptions",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CustomerAddresses",
                columns: table => new
                {
                    Id = table.Column<string>(type: "character varying(26)", nullable: false),
                    Address = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    CodePost = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    PhoneNo = table.Column<string>(type: "character varying(11)", maxLength: 11, nullable: true),
                    Description = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    StatusTypeCustomersAddress = table.Column<int>(type: "integer", nullable: false),
                    IdCustomer = table.Column<string>(type: "character varying(26)", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DateLastUpdate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    xmin = table.Column<uint>(type: "xid", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerAddresses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CustomerAddresses_Customers",
                        column: x => x.IdCustomer,
                        principalTable: "Customers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CustomerAttribute",
                columns: table => new
                {
                    Id = table.Column<string>(type: "character varying(26)", nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    Value = table.Column<string>(type: "text", nullable: false),
                    FilePath = table.Column<string>(type: "text", nullable: true),
                    IdAttributeOption = table.Column<string>(type: "character varying(26)", nullable: true),
                    IdAttributeOptionNavigationId = table.Column<string>(type: "character varying(26)", nullable: true),
                    IdCustomer = table.Column<string>(type: "character varying(26)", nullable: false),
                    IdCustomerNavigationId = table.Column<string>(type: "character varying(26)", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DateLastUpdate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
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

            migrationBuilder.CreateTable(
                name: "CustomerFeedbacks",
                columns: table => new
                {
                    Id = table.Column<string>(type: "character varying(26)", nullable: false),
                    Description = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    CustomerFeedbackStatusType = table.Column<int>(type: "integer", nullable: false),
                    IdCategory = table.Column<string>(type: "character varying(26)", nullable: false),
                    IdProduct = table.Column<string>(type: "character varying(26)", nullable: true),
                    IdCustomer = table.Column<string>(type: "character varying(26)", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DateLastUpdate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Version = table.Column<long>(type: "bigint", nullable: false),
                    IdUserUpdated = table.Column<string>(type: "text", nullable: false),
                    IdUserAdded = table.Column<string>(type: "text", nullable: false),
                    IdUser = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerFeedbacks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CustomerFeedbacks_Category",
                        column: x => x.IdCategory,
                        principalTable: "CustomerFeedbackCategories",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CustomerFeedbacks_Customer",
                        column: x => x.IdCustomer,
                        principalTable: "Customers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CustomerFeedbacks_Product",
                        column: x => x.IdProduct,
                        principalTable: "Products",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CustomerFeedbacks_User",
                        column: x => x.IdUser,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CustomerFeedbacks_User_Added",
                        column: x => x.IdUserAdded,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CustomerFeedbacks_User_Updated",
                        column: x => x.IdUserUpdated,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CustomerNotes",
                columns: table => new
                {
                    Id = table.Column<string>(type: "character varying(26)", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    CustomerNoteStatusType = table.Column<int>(type: "integer", nullable: false),
                    IdProduct = table.Column<string>(type: "character varying(26)", nullable: true),
                    IdCustomer = table.Column<string>(type: "character varying(26)", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DateLastUpdate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    xmin = table.Column<uint>(type: "xid", rowVersion: true, nullable: false),
                    IdUserUpdated = table.Column<string>(type: "text", nullable: false),
                    IdUserAdded = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerNotes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Add_CustomerNote_User",
                        column: x => x.IdUserAdded,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CustomerNote_Customers",
                        column: x => x.IdCustomer,
                        principalTable: "Customers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CustomerNote_Product",
                        column: x => x.IdProduct,
                        principalTable: "Products",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Update_CustomerNote_User",
                        column: x => x.IdUserUpdated,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CustomerPeyGiries",
                columns: table => new
                {
                    Id = table.Column<string>(type: "character varying(26)", nullable: false),
                    Description = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    DatePeyGiry = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    IdCustomer = table.Column<string>(type: "character varying(26)", nullable: false),
                    IdPeyGiryCategory = table.Column<string>(type: "character varying(26)", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DateLastUpdate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    xmin = table.Column<uint>(type: "xid", rowVersion: true, nullable: false),
                    IdUserUpdated = table.Column<string>(type: "text", nullable: false),
                    IdUserAdded = table.Column<string>(type: "text", nullable: false),
                    IdUser = table.Column<string>(type: "text", nullable: true),
                    IdUserNavigationId = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerPeyGiries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Add_CustomerPeyGiry_User",
                        column: x => x.IdUserAdded,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CustomerPeyGiries_AspNetUsers_IdUserNavigationId",
                        column: x => x.IdUserNavigationId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CustomerPeyGiry_Customers",
                        column: x => x.IdCustomer,
                        principalTable: "Customers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PeyGiryCategory_CustomerPeyGiry",
                        column: x => x.IdPeyGiryCategory,
                        principalTable: "PeyGiryCategories",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Update_CustomerPeyGiry_User",
                        column: x => x.IdUserUpdated,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "EmailAddresses",
                columns: table => new
                {
                    Id = table.Column<string>(type: "character varying(26)", nullable: false),
                    CustomerEmailAddress = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    StatusTypeCustomerEmailAddress = table.Column<int>(type: "integer", nullable: false),
                    IdCustomer = table.Column<string>(type: "character varying(26)", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DateLastUpdate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    xmin = table.Column<uint>(type: "xid", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmailAddresses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CustomersEmailAddress_Customers",
                        column: x => x.IdCustomer,
                        principalTable: "Customers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PhoneNumbers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "character varying(26)", nullable: false),
                    PhoneNo = table.Column<string>(type: "character varying(11)", maxLength: 11, nullable: false),
                    PhoneType = table.Column<int>(type: "integer", nullable: false),
                    StatusTypeCustomersPhoneNumber = table.Column<int>(type: "integer", nullable: false),
                    IdCustomer = table.Column<string>(type: "character varying(26)", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DateLastUpdate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    xmin = table.Column<uint>(type: "xid", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhoneNumbers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CustomersPhoneNumber_Customers",
                        column: x => x.IdCustomer,
                        principalTable: "Customers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ProductCustomerFavoritesLists",
                columns: table => new
                {
                    IdProduct = table.Column<string>(type: "character varying(26)", nullable: false),
                    IdCustomer = table.Column<string>(type: "character varying(26)", nullable: false),
                    StatusTypeProductCustomerFavoritesList = table.Column<int>(type: "integer", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DateLastUpdate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    xmin = table.Column<uint>(type: "xid", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductCustomerFavoritesLists", x => new { x.IdProduct, x.IdCustomer });
                    table.ForeignKey(
                        name: "FK_ProductCustomerFavoritesList_Customers",
                        column: x => x.IdCustomer,
                        principalTable: "Customers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ProductCustomerFavoritesList_Products",
                        column: x => x.IdProduct,
                        principalTable: "Products",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ForooshFactors",
                columns: table => new
                {
                    Id = table.Column<string>(type: "character varying(26)", nullable: false),
                    Amount = table.Column<decimal>(type: "numeric", nullable: false),
                    AmountTax = table.Column<decimal>(type: "numeric", nullable: false),
                    AmountDiscount = table.Column<decimal>(type: "numeric", nullable: false),
                    AmountTotal = table.Column<decimal>(type: "numeric", nullable: false),
                    StatusTypeForooshFactor = table.Column<int>(type: "integer", nullable: false),
                    DatePayed = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    PaymentMethod = table.Column<byte>(type: "smallint", nullable: false),
                    ShippingMethodType = table.Column<int>(type: "integer", nullable: true),
                    TedadeAghsat = table.Column<long>(type: "bigint", nullable: true),
                    BazeyeZamany = table.Column<long>(type: "bigint", nullable: true),
                    DarSadeSoud = table.Column<decimal>(type: "numeric", nullable: true),
                    PishPardakht = table.Column<decimal>(type: "numeric", nullable: true),
                    MablagheKoleSoud = table.Column<decimal>(type: "numeric", nullable: true),
                    ShoroAghsat = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    IdCustomer = table.Column<string>(type: "character varying(26)", nullable: false),
                    IdCustomerAddress = table.Column<string>(type: "character varying(26)", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DateLastUpdate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    xmin = table.Column<uint>(type: "xid", rowVersion: true, nullable: false),
                    IdUserUpdated = table.Column<string>(type: "text", nullable: false),
                    IdUserAdded = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ForooshFactors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Add_ForooshFactor_User",
                        column: x => x.IdUserAdded,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ForooshFactor_CustomerAddress",
                        column: x => x.IdCustomerAddress,
                        principalTable: "CustomerAddresses",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ForooshFactor_Customers",
                        column: x => x.IdCustomer,
                        principalTable: "Customers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Update_ForooshFactor_User",
                        column: x => x.IdUserUpdated,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CustomerFeedbackAttachments",
                columns: table => new
                {
                    Id = table.Column<string>(type: "character varying(26)", nullable: false),
                    Name = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    FileName = table.Column<byte[]>(type: "bytea", nullable: false),
                    Extenstion = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    CustomerFeedbackAttachmentStatusType = table.Column<int>(type: "integer", nullable: false),
                    IdCustomerFeedback = table.Column<string>(type: "character varying(26)", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DateLastUpdate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Version = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerFeedbackAttachments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CustomerFeedback_CustomerFeedbackAttachment",
                        column: x => x.IdCustomerFeedback,
                        principalTable: "CustomerFeedbacks",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "NoteAttachments",
                columns: table => new
                {
                    Id = table.Column<string>(type: "character varying(26)", nullable: false),
                    FileName = table.Column<byte[]>(type: "bytea", nullable: false),
                    Extenstion = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    NoteAttachmentStatusType = table.Column<int>(type: "integer", nullable: false),
                    IdCustomerNote = table.Column<string>(type: "character varying(26)", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DateLastUpdate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    xmin = table.Column<uint>(type: "xid", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NoteAttachments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CustomerNoteAttachment_CustomerNote",
                        column: x => x.IdCustomerNote,
                        principalTable: "CustomerNotes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "NoteHashTags",
                columns: table => new
                {
                    IdCustomerNote = table.Column<string>(type: "character varying(26)", nullable: false),
                    IdNoteHashTable = table.Column<string>(type: "character varying(26)", nullable: false),
                    Id = table.Column<string>(type: "character varying(26)", nullable: false),
                    StatusTypeNoteHashTag = table.Column<int>(type: "integer", nullable: false),
                    IdCustomerNoteNavigationId = table.Column<string>(type: "character varying(26)", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DateLastUpdate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    xmin = table.Column<uint>(type: "xid", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NoteHashTags", x => new { x.IdCustomerNote, x.IdNoteHashTable });
                    table.ForeignKey(
                        name: "FK_CustomerNoteHashTag_CustomerNoteHashTable",
                        column: x => x.IdNoteHashTable,
                        principalTable: "NoteHashTables",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_NoteHashTags_CustomerNotes_IdCustomerNoteNavigationId",
                        column: x => x.IdCustomerNoteNavigationId,
                        principalTable: "CustomerNotes",
                        principalColumn: "Id");
                });

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

            migrationBuilder.CreateTable(
                name: "PeyGiryAttachments",
                columns: table => new
                {
                    Id = table.Column<string>(type: "character varying(26)", nullable: false),
                    FileName = table.Column<byte[]>(type: "bytea", nullable: false),
                    Extenstion = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    StatusTypePeyGiryAttachment = table.Column<int>(type: "integer", nullable: false),
                    IdPeyGiry = table.Column<string>(type: "character varying(26)", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DateLastUpdate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    xmin = table.Column<uint>(type: "xid", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PeyGiryAttachments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PeyGiryAttachment_PeyGiry",
                        column: x => x.IdPeyGiry,
                        principalTable: "CustomerPeyGiries",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ForooshOrders",
                columns: table => new
                {
                    Id = table.Column<string>(type: "character varying(26)", nullable: false),
                    Price = table.Column<decimal>(type: "numeric", nullable: false),
                    PriceTotal = table.Column<decimal>(type: "numeric", nullable: false),
                    Tedad = table.Column<long>(type: "bigint", nullable: false),
                    PriceDiscount = table.Column<decimal>(type: "numeric", nullable: false),
                    PriceShipping = table.Column<decimal>(type: "numeric", nullable: false),
                    StatusTypeForooshOrder = table.Column<int>(type: "integer", nullable: false),
                    IdProduct = table.Column<string>(type: "character varying(26)", nullable: false),
                    IdForooshFactor = table.Column<string>(type: "character varying(26)", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DateLastUpdate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    xmin = table.Column<uint>(type: "xid", rowVersion: true, nullable: false),
                    IdUserUpdated = table.Column<string>(type: "text", nullable: false),
                    IdUserAdded = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ForooshOrders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Add_ForooshOrder_User",
                        column: x => x.IdUserAdded,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ForooshFactor_ForooshOrder",
                        column: x => x.IdForooshFactor,
                        principalTable: "ForooshFactors",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ForooshOrder_Product",
                        column: x => x.IdProduct,
                        principalTable: "Products",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Update_ForooshOrder_User",
                        column: x => x.IdUserUpdated,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Logs",
                columns: table => new
                {
                    Id = table.Column<string>(type: "character varying(26)", nullable: false),
                    PeyGiryId = table.Column<string>(type: "character varying(26)", nullable: true),
                    NoteId = table.Column<string>(type: "character varying(26)", nullable: true),
                    FeedBackId = table.Column<string>(type: "character varying(26)", nullable: true),
                    CustomerId = table.Column<string>(type: "character varying(26)", nullable: true),
                    ProductId = table.Column<string>(type: "character varying(26)", nullable: true),
                    ProductCategoryId = table.Column<string>(type: "character varying(26)", nullable: true),
                    ForooshId = table.Column<string>(type: "character varying(26)", nullable: true),
                    Type = table.Column<byte>(type: "smallint", nullable: false),
                    UserId = table.Column<string>(type: "text", nullable: false),
                    IpAddress = table.Column<string>(type: "text", nullable: false),
                    UserAgent = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    ForooshFactorId = table.Column<string>(type: "character varying(26)", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DateLastUpdate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Version = table.Column<long>(type: "bigint", nullable: false)
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
                    table.ForeignKey(
                        name: "FK_Logs_CustomerFeedbacks_FeedBackId",
                        column: x => x.FeedBackId,
                        principalTable: "CustomerFeedbacks",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Logs_CustomerNotes_NoteId",
                        column: x => x.NoteId,
                        principalTable: "CustomerNotes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Logs_CustomerPeyGiries_PeyGiryId",
                        column: x => x.PeyGiryId,
                        principalTable: "CustomerPeyGiries",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Logs_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Logs_ForooshFactors_ForooshFactorId",
                        column: x => x.ForooshFactorId,
                        principalTable: "ForooshFactors",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Logs_ProductCategories_ProductCategoryId",
                        column: x => x.ProductCategoryId,
                        principalTable: "ProductCategories",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Logs_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Payments",
                columns: table => new
                {
                    Id = table.Column<string>(type: "character varying(26)", nullable: false),
                    DatePay = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    PaymentAmount = table.Column<decimal>(type: "numeric", nullable: false),
                    PaymentStatusType = table.Column<int>(type: "integer", nullable: false),
                    IdForooshFactor = table.Column<string>(type: "character varying(26)", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DateLastUpdate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Version = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Payment_ForooshFactor",
                        column: x => x.IdForooshFactor,
                        principalTable: "ForooshFactors",
                        principalColumn: "Id");
                });

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
                name: "IX_AspNetUsers_IdBusiness",
                table: "AspNetUsers",
                column: "IdBusiness");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AttributeOptions_IdAttribute",
                table: "AttributeOptions",
                column: "IdAttribute");

            migrationBuilder.CreateIndex(
                name: "IX_AttributeOptionsValues_IdAttributeOption",
                table: "AttributeOptionsValues",
                column: "IdAttributeOption");

            migrationBuilder.CreateIndex(
                name: "IX_Attributes_IdBusiness",
                table: "Attributes",
                column: "IdBusiness");

            migrationBuilder.CreateIndex(
                name: "IX_Attributes_IdUserAdded",
                table: "Attributes",
                column: "IdUserAdded");

            migrationBuilder.CreateIndex(
                name: "IX_Attributes_IdUserUpdated",
                table: "Attributes",
                column: "IdUserUpdated");

            migrationBuilder.CreateIndex(
                name: "IX_BusinessPlans_PlanId",
                table: "BusinessPlans",
                column: "PlanId");

            migrationBuilder.CreateIndex(
                name: "IX_Cities_IdProvince",
                table: "Cities",
                column: "IdProvince");

            migrationBuilder.CreateIndex(
                name: "IX_ContactPhoneNumbers_ContactId",
                table: "ContactPhoneNumbers",
                column: "ContactId");

            migrationBuilder.CreateIndex(
                name: "IX_Contacts_ContactGroupId",
                table: "Contacts",
                column: "ContactGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_ContactsEmailAddress_ContactId",
                table: "ContactsEmailAddress",
                column: "ContactId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerAddresses_IdCustomer",
                table: "CustomerAddresses",
                column: "IdCustomer");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerAttribute_IdAttributeOptionNavigationId",
                table: "CustomerAttribute",
                column: "IdAttributeOptionNavigationId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerAttribute_IdCustomerNavigationId",
                table: "CustomerAttribute",
                column: "IdCustomerNavigationId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerFeedbackAttachments_IdCustomerFeedback",
                table: "CustomerFeedbackAttachments",
                column: "IdCustomerFeedback");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerFeedbackCategories_IdBusiness",
                table: "CustomerFeedbackCategories",
                column: "IdBusiness");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerFeedbackCategories_IdUserAdded",
                table: "CustomerFeedbackCategories",
                column: "IdUserAdded");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerFeedbackCategories_IdUserUpdated",
                table: "CustomerFeedbackCategories",
                column: "IdUserUpdated");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerFeedbackCategories_UserId",
                table: "CustomerFeedbackCategories",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerFeedbacks_IdCategory",
                table: "CustomerFeedbacks",
                column: "IdCategory");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerFeedbacks_IdCustomer",
                table: "CustomerFeedbacks",
                column: "IdCustomer");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerFeedbacks_IdProduct",
                table: "CustomerFeedbacks",
                column: "IdProduct");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerFeedbacks_IdUser",
                table: "CustomerFeedbacks",
                column: "IdUser");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerFeedbacks_IdUserAdded",
                table: "CustomerFeedbacks",
                column: "IdUserAdded");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerFeedbacks_IdUserUpdated",
                table: "CustomerFeedbacks",
                column: "IdUserUpdated");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerNotes_IdCustomer",
                table: "CustomerNotes",
                column: "IdCustomer");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerNotes_IdProduct",
                table: "CustomerNotes",
                column: "IdProduct");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerNotes_IdUserAdded",
                table: "CustomerNotes",
                column: "IdUserAdded");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerNotes_IdUserUpdated",
                table: "CustomerNotes",
                column: "IdUserUpdated");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerPeyGiries_IdCustomer",
                table: "CustomerPeyGiries",
                column: "IdCustomer");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerPeyGiries_IdPeyGiryCategory",
                table: "CustomerPeyGiries",
                column: "IdPeyGiryCategory");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerPeyGiries_IdUserAdded",
                table: "CustomerPeyGiries",
                column: "IdUserAdded");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerPeyGiries_IdUserNavigationId",
                table: "CustomerPeyGiries",
                column: "IdUserNavigationId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerPeyGiries_IdUserUpdated",
                table: "CustomerPeyGiries",
                column: "IdUserUpdated");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_IdCity",
                table: "Customers",
                column: "IdCity");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_IdMoaref",
                table: "Customers",
                column: "IdMoaref");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_IdUser",
                table: "Customers",
                column: "IdUser");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_IdUserAdded",
                table: "Customers",
                column: "IdUserAdded");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_IdUserUpdated",
                table: "Customers",
                column: "IdUserUpdated");

            migrationBuilder.CreateIndex(
                name: "IX_EmailAddresses_IdCustomer",
                table: "EmailAddresses",
                column: "IdCustomer");

            migrationBuilder.CreateIndex(
                name: "IX_ForooshFactors_IdCustomer",
                table: "ForooshFactors",
                column: "IdCustomer");

            migrationBuilder.CreateIndex(
                name: "IX_ForooshFactors_IdCustomerAddress",
                table: "ForooshFactors",
                column: "IdCustomerAddress");

            migrationBuilder.CreateIndex(
                name: "IX_ForooshFactors_IdUserAdded",
                table: "ForooshFactors",
                column: "IdUserAdded");

            migrationBuilder.CreateIndex(
                name: "IX_ForooshFactors_IdUserUpdated",
                table: "ForooshFactors",
                column: "IdUserUpdated");

            migrationBuilder.CreateIndex(
                name: "IX_ForooshOrders_IdForooshFactor",
                table: "ForooshOrders",
                column: "IdForooshFactor");

            migrationBuilder.CreateIndex(
                name: "IX_ForooshOrders_IdProduct",
                table: "ForooshOrders",
                column: "IdProduct");

            migrationBuilder.CreateIndex(
                name: "IX_ForooshOrders_IdUserAdded",
                table: "ForooshOrders",
                column: "IdUserAdded");

            migrationBuilder.CreateIndex(
                name: "IX_ForooshOrders_IdUserUpdated",
                table: "ForooshOrders",
                column: "IdUserUpdated");

            migrationBuilder.CreateIndex(
                name: "IX_Logs_CustomerId",
                table: "Logs",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Logs_FeedBackId",
                table: "Logs",
                column: "FeedBackId");

            migrationBuilder.CreateIndex(
                name: "IX_Logs_ForooshFactorId",
                table: "Logs",
                column: "ForooshFactorId");

            migrationBuilder.CreateIndex(
                name: "IX_Logs_NoteId",
                table: "Logs",
                column: "NoteId");

            migrationBuilder.CreateIndex(
                name: "IX_Logs_PeyGiryId",
                table: "Logs",
                column: "PeyGiryId");

            migrationBuilder.CreateIndex(
                name: "IX_Logs_ProductCategoryId",
                table: "Logs",
                column: "ProductCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Logs_ProductId",
                table: "Logs",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Logs_UserId",
                table: "Logs",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_NoteAttachments_IdCustomerNote",
                table: "NoteAttachments",
                column: "IdCustomerNote");

            migrationBuilder.CreateIndex(
                name: "IX_NoteHashTables_IdBusiness",
                table: "NoteHashTables",
                column: "IdBusiness");

            migrationBuilder.CreateIndex(
                name: "IX_NoteHashTags_IdCustomerNoteNavigationId",
                table: "NoteHashTags",
                column: "IdCustomerNoteNavigationId");

            migrationBuilder.CreateIndex(
                name: "IX_NoteHashTags_IdNoteHashTable",
                table: "NoteHashTags",
                column: "IdNoteHashTable");

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

            migrationBuilder.CreateIndex(
                name: "IX_Payments_IdForooshFactor",
                table: "Payments",
                column: "IdForooshFactor");

            migrationBuilder.CreateIndex(
                name: "IX_PeyGiryAttachments_IdPeyGiry",
                table: "PeyGiryAttachments",
                column: "IdPeyGiry");

            migrationBuilder.CreateIndex(
                name: "IX_PeyGiryCategories_BusinessId",
                table: "PeyGiryCategories",
                column: "BusinessId");

            migrationBuilder.CreateIndex(
                name: "IX_PeyGiryCategories_IdUser",
                table: "PeyGiryCategories",
                column: "IdUser");

            migrationBuilder.CreateIndex(
                name: "IX_PeyGiryCategories_IdUserAdded",
                table: "PeyGiryCategories",
                column: "IdUserAdded");

            migrationBuilder.CreateIndex(
                name: "IX_PeyGiryCategories_IdUserUpdated",
                table: "PeyGiryCategories",
                column: "IdUserUpdated");

            migrationBuilder.CreateIndex(
                name: "IX_PhoneNumbers_IdCustomer",
                table: "PhoneNumbers",
                column: "IdCustomer");

            migrationBuilder.CreateIndex(
                name: "IX_ProductCategories_BusinessId",
                table: "ProductCategories",
                column: "BusinessId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductCategories_IdUserAddNavigationId",
                table: "ProductCategories",
                column: "IdUserAddNavigationId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductCategories_IdUserUpdateNavigationId",
                table: "ProductCategories",
                column: "IdUserUpdateNavigationId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductCustomerFavoritesLists_IdCustomer",
                table: "ProductCustomerFavoritesLists",
                column: "IdCustomer");

            migrationBuilder.CreateIndex(
                name: "IX_Products_IdProductCategory",
                table: "Products",
                column: "IdProductCategory");

            migrationBuilder.CreateIndex(
                name: "IX_Products_IdUserAddNavigationId",
                table: "Products",
                column: "IdUserAddNavigationId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_IdUserUpdateNavigationId",
                table: "Products",
                column: "IdUserUpdateNavigationId");

            migrationBuilder.CreateIndex(
                name: "IX_Provinces_IdCountry",
                table: "Provinces",
                column: "IdCountry");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
                name: "BusinessPlans");

            migrationBuilder.DropTable(
                name: "ContactPhoneNumbers");

            migrationBuilder.DropTable(
                name: "ContactsEmailAddress");

            migrationBuilder.DropTable(
                name: "CustomerActivities");

            migrationBuilder.DropTable(
                name: "CustomerAttribute");

            migrationBuilder.DropTable(
                name: "CustomerFeedbackAttachments");

            migrationBuilder.DropTable(
                name: "EmailAddresses");

            migrationBuilder.DropTable(
                name: "ForooshOrders");

            migrationBuilder.DropTable(
                name: "Logs");

            migrationBuilder.DropTable(
                name: "NoteAttachments");

            migrationBuilder.DropTable(
                name: "NoteHashTags");

            migrationBuilder.DropTable(
                name: "Notifications");

            migrationBuilder.DropTable(
                name: "Payments");

            migrationBuilder.DropTable(
                name: "PeyGiryAttachments");

            migrationBuilder.DropTable(
                name: "PhoneNumbers");

            migrationBuilder.DropTable(
                name: "ProductCustomerFavoritesLists");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Plans");

            migrationBuilder.DropTable(
                name: "Contacts");

            migrationBuilder.DropTable(
                name: "AttributeOptions");

            migrationBuilder.DropTable(
                name: "CustomerFeedbacks");

            migrationBuilder.DropTable(
                name: "NoteHashTables");

            migrationBuilder.DropTable(
                name: "CustomerNotes");

            migrationBuilder.DropTable(
                name: "ForooshFactors");

            migrationBuilder.DropTable(
                name: "CustomerPeyGiries");

            migrationBuilder.DropTable(
                name: "ContactGroups");

            migrationBuilder.DropTable(
                name: "Attributes");

            migrationBuilder.DropTable(
                name: "CustomerFeedbackCategories");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "CustomerAddresses");

            migrationBuilder.DropTable(
                name: "PeyGiryCategories");

            migrationBuilder.DropTable(
                name: "ProductCategories");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Cities");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Provinces");

            migrationBuilder.DropTable(
                name: "Businesses");

            migrationBuilder.DropTable(
                name: "Countries");
        }
    }
}
