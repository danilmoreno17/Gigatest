using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Kameyo.Infrastructure.Persistence.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Catalog",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    parent_id = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    name = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: false),
                    description = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: true),
                    value = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: false),
                    value1 = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: true),
                    value2 = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: true),
                    order = table.Column<int>(type: "int", nullable: false),
                    IsSystemOwner = table.Column<bool>(type: "bit", nullable: false),
                    status = table.Column<int>(type: "int", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getutcdate()"),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Catalog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Company",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    CatalogTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    NumberId = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Name = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: false),
                    CatalogRegionCountryId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CatalogRegionStateId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CatalogRegionCityId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Address = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getutcdate()"),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Company", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "IdentityRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdentityRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "IdentityUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PersonTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    PersonId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdentityUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PercentageParticipationTable",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SubsidiaryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MinValue = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MaxValue = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Percent = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PercentageParticipationTable", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MenuRole",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CatalogMenuId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getutcdate()"),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MenuRole", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MenuRole_Catalog_CatalogMenuId",
                        column: x => x.CatalogMenuId,
                        principalTable: "Catalog",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Subsidiary",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    CompanyId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CatalogTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    NumberId = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Name = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: false),
                    CatalogRegionCountryId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CatalogRegionStateId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CatalogRegionCityId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Address = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: true),
                    PctPartIndrctCommissions = table.Column<decimal>(type: "decimal(18,2)", nullable: false, defaultValueSql: "((1))"),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getutcdate()"),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subsidiary", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Subsidiary_Company",
                        column: x => x.CompanyId,
                        principalTable: "Company",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "IdentityRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ApplicationRoleId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdentityRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IdentityRoleClaims_IdentityRoles_ApplicationRoleId",
                        column: x => x.ApplicationRoleId,
                        principalTable: "IdentityRoles",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_IdentityRoleClaims_IdentityRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "IdentityRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "IdentityUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdentityUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IdentityUserClaims_IdentityUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "IdentityUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "IdentityUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdentityUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_IdentityUserLogins_IdentityUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "IdentityUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "IdentityUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdentityUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_IdentityUserRoles_IdentityRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "IdentityRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IdentityUserRoles_IdentityUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "IdentityUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "IdentityUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdentityUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_IdentityUserTokens_IdentityUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "IdentityUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Customer",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    SubsidiaryId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CatalogTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    NumberId = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: true),
                    Name = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: true),
                    CatalogRegionCountryId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CatalogRegionStateId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CatalogRegionCityId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Address = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: true),
                    Phone = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    CatalogIndustryTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CatalogIndustrySubTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CatalogCurrencyId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Deadlinebilling = table.Column<int>(type: "int", nullable: true, defaultValueSql: "((0))"),
                    CostHourMen = table.Column<decimal>(type: "money", nullable: false, defaultValueSql: "((1))"),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getutcdate()"),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Customer_Subsidiary",
                        column: x => x.SubsidiaryId,
                        principalTable: "Subsidiary",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Employee",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    ParentId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    SubsidiaryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Names = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: false),
                    LastName = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: true),
                    CatalogAreaId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CatalogDepartmentId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CatalogCostCenterId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CatalogPositionId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CatalogCurrencyId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CatalogEmployeeTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CostHour = table.Column<decimal>(type: "money", nullable: false, defaultValueSql: "((0))"),
                    PhoneOffice = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    PhoneOfficeExt = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    PhoneMobile = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    CalculateFactor = table.Column<decimal>(type: "decimal(18,2)", nullable: false, defaultValueSql: "((1))"),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getutcdate()"),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Employee_Subsidiary",
                        column: x => x.SubsidiaryId,
                        principalTable: "Subsidiary",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Rules",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    SubsidiaryId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Name = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: true),
                    Formula = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getutcdate()"),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rules", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Rules_Subsidiary",
                        column: x => x.SubsidiaryId,
                        principalTable: "Subsidiary",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Contact",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    ParentId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CustomerId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Names = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: false),
                    LastName = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: true),
                    Area = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: true),
                    Department = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: true),
                    Position = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: true),
                    Email = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: true),
                    PhoneOffice = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    PhoneOfficeExt = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    PhoneMobile = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getutcdate()"),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contact", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Contact_Customer",
                        column: x => x.CustomerId,
                        principalTable: "Customer",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "HourBank",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    CustomerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: false),
                    Description = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: true),
                    PurchaseOrderNumber = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    InvoiceNumber = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    CatalogHourBankTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ApplyValidity = table.Column<bool>(type: "bit", nullable: true),
                    DateValidity = table.Column<DateTime>(type: "date", nullable: true),
                    Terms = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    CatalogCurrencyId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    HourCost = table.Column<decimal>(type: "money", nullable: false, defaultValueSql: "((0))"),
                    HourBalance = table.Column<int>(type: "int", nullable: false),
                    HourSet = table.Column<int>(type: "int", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getutcdate()"),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HourBank", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HourBank_Customer",
                        column: x => x.CustomerId,
                        principalTable: "Customer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Project",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    CustomerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: true),
                    Description = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: true),
                    CatalogProjectTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CatalogProjectCategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CatalogProjectStateId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    MainContactId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    StartDate = table.Column<DateTime>(type: "date", nullable: true),
                    EndDate = table.Column<DateTime>(type: "date", nullable: true),
                    DurationHour = table.Column<int>(type: "int", nullable: true, defaultValueSql: "((0))"),
                    CloseDate = table.Column<DateTime>(type: "date", nullable: true),
                    CostHourMenCustomer = table.Column<decimal>(type: "money", nullable: false),
                    CostHourMenProject = table.Column<decimal>(type: "money", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getutcdate()"),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Project", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Project_Customer",
                        column: x => x.CustomerId,
                        principalTable: "Customer",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "EmployeeAward",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    EmployeeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Institution = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: false),
                    Description = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: true),
                    AwardDate = table.Column<DateTime>(type: "date", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getutcdate()"),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeAward", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmployeeAward_Employee",
                        column: x => x.EmployeeId,
                        principalTable: "Employee",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "EmployeeCertification",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    EmployeeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: false),
                    Institution = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: false),
                    EmissionDate = table.Column<DateTime>(type: "date", nullable: true),
                    ProductionDate = table.Column<DateTime>(type: "date", nullable: true),
                    ExpirationDate = table.Column<DateTime>(type: "date", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getutcdate()"),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeCertification", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmployeeCertification_Employee",
                        column: x => x.EmployeeId,
                        principalTable: "Employee",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "EmployeeExperience",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    EmployeeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: false),
                    CompanyName = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: false),
                    Type = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: true),
                    CompanyCity = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: true),
                    BeginDate = table.Column<DateTime>(type: "date", nullable: true),
                    FinishDate = table.Column<DateTime>(type: "date", nullable: true),
                    Description = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getutcdate()"),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeExperience", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmployeeExperience_Employee",
                        column: x => x.EmployeeId,
                        principalTable: "Employee",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "EmployeeSkillAbility",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    EmployeeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Description = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getutcdate()"),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeSkillAbility", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmployeeSkillAbility_Employee",
                        column: x => x.EmployeeId,
                        principalTable: "Employee",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "EmployeeStudy",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    EmployeeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Institution = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: false),
                    Degree = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: false),
                    FieldKnowledge = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: true),
                    EmissionDate = table.Column<DateTime>(type: "date", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getutcdate()"),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeStudy", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmployeeStudy_Employee",
                        column: x => x.EmployeeId,
                        principalTable: "Employee",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "FinancialParticipation",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EmployeeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(1)", nullable: false),
                    CatalogDiscretionaryTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Value = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(1)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Year = table.Column<int>(type: "int", nullable: false),
                    Month = table.Column<int>(type: "int", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FinancialParticipation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FinancialParticipation_Employee",
                        column: x => x.EmployeeId,
                        principalTable: "Employee",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ProjectHourBank",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    ProjectId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    HourBankId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getutcdate()"),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectHourBank", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProjectHourBank_HourBank_HourBankId",
                        column: x => x.HourBankId,
                        principalTable: "HourBank",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProjectHourBank_Project",
                        column: x => x.ProjectId,
                        principalTable: "Project",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ProjectManager",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    ProjectId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EmployeeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StartDate = table.Column<DateTime>(type: "date", nullable: false),
                    EndDate = table.Column<DateTime>(type: "date", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectManager", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProjectManager_Employee",
                        column: x => x.EmployeeId,
                        principalTable: "Employee",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ProjectManager_Project",
                        column: x => x.ProjectId,
                        principalTable: "Project",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ProjectReport",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    ProjectId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CustomerApproved = table.Column<bool>(type: "bit", nullable: false),
                    CustomerApprovedDate = table.Column<DateTime>(type: "date", nullable: true),
                    Invoiced = table.Column<bool>(type: "bit", nullable: false),
                    InvoicedDate = table.Column<DateTime>(type: "date", nullable: true),
                    Paid = table.Column<bool>(type: "bit", nullable: false),
                    PaidDate = table.Column<DateTime>(type: "date", nullable: true),
                    Year = table.Column<int>(type: "int", nullable: false),
                    Month = table.Column<int>(type: "int", nullable: false),
                    RealInvoiceDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    InvoiceComment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    State = table.Column<string>(type: "nvarchar(1)", nullable: false),
                    ProjectReportDate = table.Column<DateTime>(type: "date", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "(getutcdate())"),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectReport", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProjectReport_Project",
                        column: x => x.ProjectId,
                        principalTable: "Project",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ProjectResource",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    ProjectId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EmployeeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CatalogEmployeeRolId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CalculateFactorEmployee = table.Column<decimal>(type: "decimal(18,2)", nullable: false, defaultValueSql: "((1))"),
                    CalculateFactorProject = table.Column<decimal>(type: "decimal(18,2)", nullable: false, defaultValueSql: "((1))"),
                    ParticipationValue = table.Column<decimal>(type: "money", nullable: false, defaultValueSql: "((0))"),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getutcdate()"),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectResource", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProjectResource_Employee_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employee",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProjectResource_Project",
                        column: x => x.ProjectId,
                        principalTable: "Project",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ProjectTask",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    ProjectId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: true),
                    Description = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: true),
                    CatalogTaskTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Order = table.Column<int>(type: "int", nullable: true),
                    StartDate = table.Column<DateTime>(type: "date", nullable: true),
                    EndDate = table.Column<DateTime>(type: "date", nullable: true),
                    CloseDate = table.Column<DateTime>(type: "date", nullable: true),
                    DurationHour = table.Column<int>(type: "int", nullable: true, defaultValueSql: "((0))"),
                    Progress = table.Column<int>(type: "int", nullable: true),
                    CatalogTaskStateId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getutcdate()"),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectTask", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProjectTask_Project",
                        column: x => x.ProjectId,
                        principalTable: "Project",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TaskActivity",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    ProjectTaskId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EmployeeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Description = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    TotalTimeHour = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TotalTimeHourApproved = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IsBillable = table.Column<bool>(type: "bit", nullable: false),
                    InProjectReport = table.Column<bool>(type: "bit", nullable: false),
                    InProjectReportDate = table.Column<DateTime>(type: "date", nullable: true),
                    Invoiced = table.Column<bool>(type: "bit", nullable: false),
                    InvoicedDate = table.Column<DateTime>(type: "date", nullable: true),
                    Paid = table.Column<bool>(type: "bit", nullable: false),
                    PaidDate = table.Column<DateTime>(type: "date", nullable: true),
                    CalculateFactor = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    HourCost = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    TotalCost = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    CommissionId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ExchangeRate = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getutcdate()"),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskActivity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TaskActivity_Employee_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employee",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TaskActivity_ProjectTask",
                        column: x => x.ProjectTaskId,
                        principalTable: "ProjectTask",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ProjectReportDetail",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    ProjectReportId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TaskActivityId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FinancialParticipationId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Observation = table.Column<string>(type: "varchar(164)", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectReportDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProjectReportDetail_FinancialParticipation_FinancialParticipationId",
                        column: x => x.FinancialParticipationId,
                        principalTable: "FinancialParticipation",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ProjectReportDetail_ProjectReport",
                        column: x => x.ProjectReportId,
                        principalTable: "ProjectReport",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ProjectReportDetail_TaskActivity",
                        column: x => x.TaskActivityId,
                        principalTable: "TaskActivity",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Catalog",
                columns: new[] { "Id", "Active", "Created", "CreatedBy", "description", "IsSystemOwner", "LastModified", "LastModifiedBy", "name", "order", "parent_id", "status", "value", "value1", "value2" },
                values: new object[,]
                {
                    { new Guid("02647d85-581b-4e74-acce-9adddaecf680"), true, new DateTime(2022, 6, 28, 3, 20, 58, 532, DateTimeKind.Utc).AddTicks(9319), "System", "Resumen de Participaciones", true, null, null, "MENUS", 0, new Guid("6a9157ad-d1a8-464d-8f6f-a065a9b6c61c"), null, "Resumen", "/participaciones/general", null },
                    { new Guid("0576c349-ce1e-4761-a4ec-7ef228f426f5"), true, new DateTime(2022, 6, 28, 3, 20, 58, 532, DateTimeKind.Utc).AddTicks(8363), "System", "Sub Tipo de industria - CONFITERIA", true, null, null, "INDUSTRYSUBTYPE", 0, null, null, "CONFITERIA", null, null },
                    { new Guid("064cdae7-d711-4b3f-ae64-35447988825c"), true, new DateTime(2022, 6, 28, 3, 20, 58, 532, DateTimeKind.Utc).AddTicks(8331), "System", "Ciudad DURAN", true, null, null, "CITY", 0, new Guid("5afe07a2-fd5e-478c-93ad-cc6c8aee7e8e"), null, "DURAN", null, null },
                    { new Guid("0c0d36bd-b065-40e8-aa03-a7e11ab5be37"), true, new DateTime(2022, 6, 28, 3, 20, 58, 532, DateTimeKind.Utc).AddTicks(8449), "System", "ESTADO DE PROYECTO", true, null, null, "PROJECTSTATE", 0, null, null, "ESTADO DE PROYECTO 1", null, null },
                    { new Guid("1003026b-9d77-4032-b23c-d0a1e603ce18"), true, new DateTime(2022, 6, 28, 3, 20, 58, 532, DateTimeKind.Utc).AddTicks(8498), "System", "TIPO DE PRODUCTO 02", true, null, null, "PRODUCTTYPE", 0, null, null, "TIPO DE PRODUCTO 2", null, null },
                    { new Guid("112f1c62-e1bd-47c0-8056-82e51afeb5d0"), true, new DateTime(2022, 6, 28, 3, 20, 58, 532, DateTimeKind.Utc).AddTicks(8440), "System", "CATEGORIA DE PROYECTO", true, null, null, "PROJECTCATEGORY", 0, null, null, "CATEGORIA DE PROYECTO 2", null, null },
                    { new Guid("15299e9a-ebc1-45e1-9a7a-293253a01f1e"), true, new DateTime(2022, 6, 28, 3, 20, 58, 532, DateTimeKind.Utc).AddTicks(9146), "System", "Movimientos", true, null, null, "MENUS", 2, null, null, "Movimientos", null, "icon-folder" },
                    { new Guid("15be86da-51b5-40d8-92ee-e426a2a5df8f"), true, new DateTime(2022, 6, 28, 3, 20, 58, 532, DateTimeKind.Utc).AddTicks(9266), "System", "Reportes Facturación vs Actividades", true, null, null, "MENUS", 1, new Guid("dd84c814-812e-4a54-a7d3-ea863da1a5c8"), null, "Facturación vs Actividades", "/reportes/facturacion/actividades", null },
                    { new Guid("1bcf3c7b-2e0e-4401-aa5f-d1460363b885"), true, new DateTime(2022, 6, 28, 3, 20, 58, 532, DateTimeKind.Utc).AddTicks(8356), "System", "Tipo de industria - COMERCIO", true, null, null, "INDUSTRYTYPE", 0, null, null, "COMERCIO", null, null },
                    { new Guid("1d49a30e-921e-4e9b-b1ca-d4bdce4cf431"), true, new DateTime(2022, 6, 28, 3, 20, 58, 532, DateTimeKind.Utc).AddTicks(8391), "System", "Peso colombiano", true, null, null, "CURRENCY", 0, null, null, "PESO COLOMBIANO", null, null },
                    { new Guid("20ec3f22-9ab7-4b29-bc15-d6359ac16e29"), true, new DateTime(2022, 6, 28, 3, 20, 58, 532, DateTimeKind.Utc).AddTicks(8562), "System", "TIPO DE PRODUCTO 03", true, null, null, "PRODUCTTYPE", 0, null, null, "TIPO DE PRODUCTO 3", null, null },
                    { new Guid("22874dde-3ef1-4875-bc02-88c7863444f1"), true, new DateTime(2022, 6, 28, 3, 20, 58, 532, DateTimeKind.Utc).AddTicks(8170), "System", "Tipo de identificacion ruc", true, null, null, "IDENTIFICATIONTYPE", 0, null, null, "Ruc", null, null },
                    { new Guid("24f884da-f77e-4f92-bef7-c594c9099cd3"), true, new DateTime(2022, 6, 28, 3, 20, 58, 532, DateTimeKind.Utc).AddTicks(8445), "System", "CATEGORIA DE PROYECTO", true, null, null, "PROJECTCATEGORY", 0, null, null, "CATEGORIA DE PROYECTO 3", null, null },
                    { new Guid("2565e61d-86d4-4a72-8886-296733908e5b"), true, new DateTime(2022, 6, 28, 3, 20, 58, 532, DateTimeKind.Utc).AddTicks(8969), "System", "Dashboard Analytical", true, null, null, "MENUS", 0, new Guid("43c4bce9-c056-43e7-84f3-1c67877a2c70"), null, "Analytical", "/dashboard/index", null },
                    { new Guid("279db491-1a2a-4043-baf5-70835351a3ca"), true, new DateTime(2022, 6, 28, 3, 20, 58, 532, DateTimeKind.Utc).AddTicks(8976), "System", "Mantenimientos", true, null, null, "MENUS", 1, null, null, "Mantenimientos", null, "icon-grid" },
                    { new Guid("2a9977da-8282-46ce-a944-9897b13ba477"), true, new DateTime(2022, 6, 28, 3, 20, 58, 532, DateTimeKind.Utc).AddTicks(8306), "System", "Ciudad MANTA", true, null, null, "CITY", 0, new Guid("d7e2a0ba-f955-4717-bf72-26c72ad4305b"), null, "MANTA", null, null },
                    { new Guid("2d5a5fb0-d3ca-44e1-abdc-bbe58d29fb6b"), true, new DateTime(2022, 6, 28, 3, 20, 58, 532, DateTimeKind.Utc).AddTicks(8581), "System", "Usuario tipo Usuario", true, null, null, "USERSTYPE", 0, null, null, "Usuario", null, null },
                    { new Guid("30f9eaa1-9029-495d-866a-2b6b5f41c2b6"), true, new DateTime(2022, 6, 28, 3, 20, 58, 532, DateTimeKind.Utc).AddTicks(8575), "System", "ROL DEL EMPLEADO  03", true, null, null, "EMPLOYEEROL", 0, null, null, "ROL DEL EMPLEADO 3", null, null },
                    { new Guid("32855971-ebcd-49ab-ad62-6150d5e7695b"), true, new DateTime(2022, 6, 28, 3, 20, 58, 532, DateTimeKind.Utc).AddTicks(8421), "System", "TIPO DE PROYECTO", true, null, null, "PROJECTTYPE", 0, null, null, "TIPO DE PROYECTO 1", null, null },
                    { new Guid("33220a02-5ae9-46b9-9f3e-664cfe140320"), true, new DateTime(2022, 6, 28, 3, 20, 58, 532, DateTimeKind.Utc).AddTicks(8409), "System", "DOLAR", true, null, null, "COSTCENTER", 0, null, null, "COSTCENTER1", null, null },
                    { new Guid("38d321e1-6c32-4adf-bc6e-461061fc2b66"), true, new DateTime(2022, 6, 28, 3, 20, 58, 532, DateTimeKind.Utc).AddTicks(9269), "System", "Reportes Estados de Clientes Unificados", true, null, null, "MENUS", 2, new Guid("dd84c814-812e-4a54-a7d3-ea863da1a5c8"), null, "Estados de Clientes Unificados", "/reportes/clientes/unificados", null },
                    { new Guid("43c4bce9-c056-43e7-84f3-1c67877a2c70"), true, new DateTime(2022, 6, 28, 3, 20, 58, 532, DateTimeKind.Utc).AddTicks(8887), "System", "Dashboard", true, null, null, "MENUS", 0, null, null, "Dashboard", null, "icon-home" },
                    { new Guid("4c748e6e-60a6-47fd-b83a-d91fc57feb0f"), true, new DateTime(2022, 6, 28, 3, 20, 58, 532, DateTimeKind.Utc).AddTicks(9323), "System", "Participaciones Discrecionales", true, null, null, "MENUS", 1, new Guid("6a9157ad-d1a8-464d-8f6f-a065a9b6c61c"), null, "Participaciones Discrecionales", "/participaciones/discresionales", null },
                    { new Guid("4fd6aa25-040a-4a58-8f3d-ea1aeff04bd6"), true, new DateTime(2022, 6, 28, 3, 20, 58, 532, DateTimeKind.Utc).AddTicks(9058), "System", "Mantenimientos Usuarios", true, null, null, "MENUS", 5, new Guid("279db491-1a2a-4043-baf5-70835351a3ca"), null, "Usuarios", "/mantenimientos/usuarios", null },
                    { new Guid("5286a15e-2883-4165-b1df-3896319fa80d"), true, new DateTime(2022, 6, 28, 3, 20, 58, 532, DateTimeKind.Utc).AddTicks(8347), "System", "Pais COLOMBIA", true, null, null, "COUNTRIES", 1, null, null, "COLOMBIA", null, null },
                    { new Guid("5359a438-abcd-4e21-9a7c-9f0107059b3e"), true, new DateTime(2022, 6, 28, 3, 20, 58, 532, DateTimeKind.Utc).AddTicks(8571), "System", "ROL DEL EMPLEADO  02", true, null, null, "EMPLOYEEROL", 0, null, null, "ROL DEL EMPLEADO 2", null, null },
                    { new Guid("5afe07a2-fd5e-478c-93ad-cc6c8aee7e8e"), true, new DateTime(2022, 6, 28, 3, 20, 58, 532, DateTimeKind.Utc).AddTicks(8295), "System", "Provincia GUAYAS", true, null, null, "STATES", 0, new Guid("f504e9d9-edd3-475f-8452-e5fc899fa033"), null, "GUAYAS", null, null },
                    { new Guid("5cbdbb13-b93d-46a3-852e-9ec0a5083a83"), true, new DateTime(2022, 6, 28, 3, 20, 58, 532, DateTimeKind.Utc).AddTicks(8217), "System", "Provincia PICHINCHA", true, null, null, "STATES", 0, new Guid("f504e9d9-edd3-475f-8452-e5fc899fa033"), null, "PICHINCHA", null, null },
                    { new Guid("5fadbd15-2505-44f9-b197-8c8b255cb3e6"), true, new DateTime(2022, 6, 28, 3, 20, 58, 532, DateTimeKind.Utc).AddTicks(8417), "System", "CONSULTOR", true, null, null, "EMPLOYEETYPE", 0, null, null, "CONSULTOR", null, null },
                    { new Guid("655b2ad6-6c94-4a67-a3de-9cbe3501d7c0"), true, new DateTime(2022, 6, 28, 3, 20, 58, 532, DateTimeKind.Utc).AddTicks(9048), "System", "Mantenimientos Clientes", true, null, null, "MENUS", 2, new Guid("279db491-1a2a-4043-baf5-70835351a3ca"), null, "Clientes", "/mantenimientos/clientes", null },
                    { new Guid("6a9157ad-d1a8-464d-8f6f-a065a9b6c61c"), true, new DateTime(2022, 6, 28, 3, 20, 58, 532, DateTimeKind.Utc).AddTicks(9273), "System", "Participaciones", true, null, null, "MENUS", 4, null, null, "Participaciones", null, "icon-folder" },
                    { new Guid("749d90e3-e39c-4630-9316-71cc814ab1ee"), true, new DateTime(2022, 6, 28, 3, 20, 58, 532, DateTimeKind.Utc).AddTicks(9055), "System", "Mantenimientos Catalogos", true, null, null, "MENUS", 4, new Guid("279db491-1a2a-4043-baf5-70835351a3ca"), null, "Catalogos", "/mantenimientos/catalogos", null },
                    { new Guid("84e9e9c9-afbb-4944-9699-67cf269b91ae"), true, new DateTime(2022, 6, 28, 3, 20, 58, 532, DateTimeKind.Utc).AddTicks(9051), "System", "Mantenimientos Proyectos", true, null, null, "MENUS", 3, new Guid("279db491-1a2a-4043-baf5-70835351a3ca"), null, "Proyectos", "/mantenimientos/proyectos", null },
                    { new Guid("85db29c8-6df0-481b-8065-c10f55d4050b"), true, new DateTime(2022, 6, 28, 3, 20, 58, 532, DateTimeKind.Utc).AddTicks(9201), "System", "Movimientos Actividades proyecto", true, null, null, "MENUS", 1, new Guid("15299e9a-ebc1-45e1-9a7a-293253a01f1e"), null, "Actividades proyecto", "/movimientos/proyectos/actividades", null },
                    { new Guid("8804915e-1694-486b-8fa0-5b47d0fdaa11"), true, new DateTime(2022, 6, 28, 3, 20, 58, 532, DateTimeKind.Utc).AddTicks(9135), "System", "Mantenimientos Tareas", true, null, null, "MENUS", 10, new Guid("279db491-1a2a-4043-baf5-70835351a3ca"), null, "Tareas", "/mantenimientos/proyectos/tareas", null },
                    { new Guid("8fcee89a-2264-4d49-89ef-e97cb37f39ce"), true, new DateTime(2022, 6, 28, 3, 20, 58, 532, DateTimeKind.Utc).AddTicks(8566), "System", "ROL DEL EMPLEADO  01", true, null, null, "EMPLOYEEROL", 0, null, null, "ROL DEL EMPLEADO 1", null, null },
                    { new Guid("90eba23b-5ccd-49b2-9e58-c86b440ae431"), true, new DateTime(2022, 6, 28, 3, 20, 58, 532, DateTimeKind.Utc).AddTicks(9139), "System", "Mantenimientos Menus", true, null, null, "MENUS", 11, new Guid("279db491-1a2a-4043-baf5-70835351a3ca"), null, "Menu", "/mantenimientos/menus", null },
                    { new Guid("917f29ea-ade8-4b47-bbf4-1b13b5ea3fa8"), true, new DateTime(2022, 6, 28, 3, 20, 58, 532, DateTimeKind.Utc).AddTicks(9207), "System", "Revisión de Reportes PM", true, null, null, "MENUS", 4, new Guid("15299e9a-ebc1-45e1-9a7a-293253a01f1e"), null, "Revisión de Reportes PM", "/movimientos/proyectos/reportes-pm", null },
                    { new Guid("9b09536a-ec98-4303-8506-b4ba43f67812"), true, new DateTime(2022, 6, 28, 3, 20, 58, 532, DateTimeKind.Utc).AddTicks(8183), "System", "Tipo de identificacion cedula", true, null, null, "IDENTIFICATIONTYPE", 1, null, null, "Cedula", null, null },
                    { new Guid("9e07bed6-eee4-4fd6-afc1-bcb13b0ea7cc"), true, new DateTime(2022, 6, 28, 3, 20, 58, 532, DateTimeKind.Utc).AddTicks(8325), "System", "Ciudad GUAYAQUIL", true, null, null, "CITY", 0, new Guid("5afe07a2-fd5e-478c-93ad-cc6c8aee7e8e"), null, "GUAYAQUIL", null, null },
                    { new Guid("abc3cd41-a3bf-4167-b7c9-c0d03cb6c84f"), true, new DateTime(2022, 6, 28, 3, 20, 58, 532, DateTimeKind.Utc).AddTicks(9204), "System", "Movimientos Reporte de Proyectos", true, null, null, "MENUS", 3, new Guid("15299e9a-ebc1-45e1-9a7a-293253a01f1e"), null, "Generar Reporte de Proyectos", "/movimientos/proyectos/reportes", null },
                    { new Guid("aebe7952-8a9d-49fa-bc6f-dc501bc89082"), true, new DateTime(2022, 6, 28, 3, 20, 58, 532, DateTimeKind.Utc).AddTicks(9044), "System", "Mantenimientos Empresas", true, null, null, "MENUS", 0, new Guid("279db491-1a2a-4043-baf5-70835351a3ca"), null, "Empresas", "/mantenimientos/empresas", null }
                });

            migrationBuilder.InsertData(
                table: "Catalog",
                columns: new[] { "Id", "Active", "Created", "CreatedBy", "description", "IsSystemOwner", "LastModified", "LastModifiedBy", "name", "order", "parent_id", "status", "value", "value1", "value2" },
                values: new object[,]
                {
                    { new Guid("b05309c0-9b19-4474-a025-b59b526f1930"), true, new DateTime(2022, 6, 28, 3, 20, 58, 532, DateTimeKind.Utc).AddTicks(9198), "System", "Movimientos Facturacion", true, null, null, "MENUS", 0, new Guid("15299e9a-ebc1-45e1-9a7a-293253a01f1e"), null, "Facturacion", "/movimientos/facturacion", null },
                    { new Guid("b0df1134-a322-4a26-8a48-26d3376aecdd"), true, new DateTime(2022, 6, 28, 3, 20, 58, 532, DateTimeKind.Utc).AddTicks(8434), "System", "CATEGORIA DE PROYECTO", true, null, null, "PROJECTCATEGORY", 0, null, null, "CATEGORIA DE PROYECTO 1", null, null },
                    { new Guid("b2e7412c-d120-4cc3-a77e-b97b3796a46f"), true, new DateTime(2022, 6, 28, 3, 20, 58, 532, DateTimeKind.Utc).AddTicks(9066), "System", "Mantenimientos Contactos", true, null, null, "MENUS", 8, new Guid("279db491-1a2a-4043-baf5-70835351a3ca"), null, "Contactos", "/mantenimientos/empresas/contactos", null },
                    { new Guid("b7571cdb-50bb-4c0d-ae2e-f854f5fddc24"), true, new DateTime(2022, 6, 28, 3, 20, 58, 532, DateTimeKind.Utc).AddTicks(8397), "System", "DOLAR", true, null, null, "AREA", 0, null, null, "AREA1", null, null },
                    { new Guid("baa8773a-9f1d-40d5-ae96-44dbf5993656"), true, new DateTime(2022, 6, 28, 3, 20, 58, 532, DateTimeKind.Utc).AddTicks(8190), "System", "Tipo de identificacion DNI", true, null, null, "IDENTIFICATIONTYPE", 2, null, null, "DNI", null, null },
                    { new Guid("bc49bc14-4834-4b5a-a1e8-26715ae2c57e"), true, new DateTime(2022, 6, 28, 3, 20, 58, 532, DateTimeKind.Utc).AddTicks(9210), "System", "Aprob. de Reportes Cust", true, null, null, "MENUS", 5, new Guid("15299e9a-ebc1-45e1-9a7a-293253a01f1e"), null, "Aprob. de Reportes Cust", "/movimientos/proyectos/reportes-customer", null },
                    { new Guid("bda11fce-1441-4818-9db1-8743c0c1e8ba"), true, new DateTime(2022, 6, 28, 3, 20, 58, 532, DateTimeKind.Utc).AddTicks(8336), "System", "Ciudad DAULE", true, null, null, "CITY", 0, new Guid("5afe07a2-fd5e-478c-93ad-cc6c8aee7e8e"), null, "DAULE", null, null },
                    { new Guid("bf2f0e91-3a1c-4843-a148-c9c053ab1bed"), true, new DateTime(2022, 6, 28, 3, 20, 58, 532, DateTimeKind.Utc).AddTicks(8460), "System", "ESTADO DE PROYECTO", true, null, null, "PROJECTSTATE", 0, null, null, "ESTADO DE PROYECTO 3", null, null },
                    { new Guid("bf39e8be-8707-4a80-bf9b-a30486a6b4bb"), true, new DateTime(2022, 6, 28, 3, 20, 58, 532, DateTimeKind.Utc).AddTicks(9064), "System", "Mantenimientos Filiales", true, null, null, "MENUS", 7, new Guid("279db491-1a2a-4043-baf5-70835351a3ca"), null, "Filiales", "/mantenimientos/filiales", null },
                    { new Guid("c051f36c-5c8d-4aae-8c82-57a284c6929e"), true, new DateTime(2022, 6, 28, 3, 20, 58, 532, DateTimeKind.Utc).AddTicks(9332), "System", "CULMINACIÓN DE PROYECTO", true, null, null, "DISCRETIONARYTYPE", 0, null, null, "CULMINACIÓN DE PROYECTO", null, null },
                    { new Guid("c072e641-926b-4b31-8f3f-9d0c156fc101"), true, new DateTime(2022, 6, 28, 3, 20, 58, 532, DateTimeKind.Utc).AddTicks(8426), "System", "TIPO DE PROYECTO", true, null, null, "PROJECTTYPE", 0, null, null, "TIPO DE PROYECTO 2", null, null },
                    { new Guid("c3908d96-19a5-40cf-a870-c3d34e96ac1b"), true, new DateTime(2022, 6, 28, 3, 20, 58, 532, DateTimeKind.Utc).AddTicks(8479), "System", "ESTADO DE TAREA DE PROYECTO  01", true, null, null, "PROJECTTASKSTATE", 0, null, null, "ESTADO DE TAREA DE PROYECTO 1", null, null },
                    { new Guid("c73fe620-e152-4b29-87ad-9ae2004cdfbf"), true, new DateTime(2022, 6, 28, 3, 20, 58, 532, DateTimeKind.Utc).AddTicks(8484), "System", "ESTADO DE TAREA DE PROYECTO  02", true, null, null, "PROJECTTASKSTATE", 0, null, null, "ESTADO DE TAREA DE PROYECTO 2", null, null },
                    { new Guid("c7d0f2c1-8039-4171-b4a2-e67defafd387"), true, new DateTime(2022, 6, 28, 3, 20, 58, 532, DateTimeKind.Utc).AddTicks(8413), "System", "DOLAR", true, null, null, "POSITION", 0, null, null, "POSITION1", null, null },
                    { new Guid("cf546c4c-bf37-46a7-b96c-a8091972cd03"), true, new DateTime(2022, 6, 28, 3, 20, 58, 532, DateTimeKind.Utc).AddTicks(8351), "System", "Pais SAN SALVADOR", true, null, null, "COUNTRIES", 2, null, null, "SAN SALVADOR", null, null },
                    { new Guid("d40e4b16-77d9-4bdc-bed3-2a57628ac33f"), true, new DateTime(2022, 6, 28, 3, 20, 58, 532, DateTimeKind.Utc).AddTicks(8430), "System", "TIPO DE PROYECTO", true, null, null, "PROJECTTYPE", 0, null, null, "TIPO DE PROYECTO 3", null, null },
                    { new Guid("d42cc742-599a-452f-a26f-bb9fb04766f8"), true, new DateTime(2022, 6, 28, 3, 20, 58, 532, DateTimeKind.Utc).AddTicks(8470), "System", "TIPO DE TAREA DE PROYECTO  02", true, null, null, "PROJECTTASKTYPE", 0, null, null, "TIPO DE TAREA DE PROYECTO 2", null, null },
                    { new Guid("d574f93d-f75f-469d-aed6-d5b294f73911"), true, new DateTime(2022, 6, 28, 3, 20, 58, 532, DateTimeKind.Utc).AddTicks(8493), "System", "TIPO DE PRODUCTO 01", true, null, null, "PRODUCTTYPE", 0, null, null, "TIPO DE PRODUCTO 1", null, null },
                    { new Guid("d7e2a0ba-f955-4717-bf72-26c72ad4305b"), true, new DateTime(2022, 6, 28, 3, 20, 58, 532, DateTimeKind.Utc).AddTicks(8207), "System", "Provincia MANABI", true, null, null, "STATES", 0, new Guid("f504e9d9-edd3-475f-8452-e5fc899fa033"), null, "MANABI", null, null },
                    { new Guid("d81648db-ef11-4e71-b33b-5b47f5344bdd"), true, new DateTime(2022, 6, 28, 3, 20, 58, 532, DateTimeKind.Utc).AddTicks(8488), "System", "ESTADO DE TAREA DE PROYECTO  03", true, null, null, "PROJECTTASKSTATE", 0, null, null, "ESTADO DE TAREA DE PROYECTO 3", null, null },
                    { new Guid("dd84c814-812e-4a54-a7d3-ea863da1a5c8"), true, new DateTime(2022, 6, 28, 3, 20, 58, 532, DateTimeKind.Utc).AddTicks(9214), "System", "Reportes", true, null, null, "MENUS", 3, null, null, "Reportes", null, "icon-globe" },
                    { new Guid("e1cf4d2a-de84-4f11-a480-e4acad0a689d"), true, new DateTime(2022, 6, 28, 3, 20, 58, 532, DateTimeKind.Utc).AddTicks(8405), "System", "DOLAR", true, null, null, "DEPARTMEN", 0, null, null, "DEPARTMEN1", null, null },
                    { new Guid("eae6dd86-2c18-4a8b-be0a-751e533c8ce9"), true, new DateTime(2022, 6, 28, 3, 20, 58, 532, DateTimeKind.Utc).AddTicks(8314), "System", "Ciudad QUITO", true, null, null, "CITY", 0, new Guid("5cbdbb13-b93d-46a3-852e-9ec0a5083a83"), null, "QUITO", null, null },
                    { new Guid("ed2fb04f-dcd9-4351-868c-88447e128e70"), true, new DateTime(2022, 6, 28, 3, 20, 58, 532, DateTimeKind.Utc).AddTicks(8474), "System", "TIPO DE TAREA DE PROYECTO  03", true, null, null, "PROJECTTASKTYPE", 0, null, null, "TIPO DE TAREA DE PROYECTO 3", null, null },
                    { new Guid("edc0e8f7-47a3-40c4-ad3f-bac12f653c02"), true, new DateTime(2022, 6, 28, 3, 20, 58, 532, DateTimeKind.Utc).AddTicks(8466), "System", "TIPO DE TAREA DE PROYECTO  01", true, null, null, "PROJECTTASKTYPE", 0, null, null, "TIPO DE TAREA DE PROYECTO 1", null, null },
                    { new Guid("efd0f32b-cbf5-460e-b6d1-f17dfee2a13e"), true, new DateTime(2022, 6, 28, 3, 20, 58, 532, DateTimeKind.Utc).AddTicks(8594), "System", "Usuario tipo Administrador", true, null, null, "USERSTYPE", 0, null, null, "Administrador", null, null },
                    { new Guid("f11d7e55-f12e-4214-b100-0989b38f66bc"), true, new DateTime(2022, 6, 28, 3, 20, 58, 532, DateTimeKind.Utc).AddTicks(8585), "System", "Usuario tipo Contacto", true, null, null, "USERSTYPE", 0, null, null, "Contacto", null, null },
                    { new Guid("f124a4c3-b3e2-4e6b-96d4-26d4712be343"), true, new DateTime(2022, 6, 28, 3, 20, 58, 532, DateTimeKind.Utc).AddTicks(8368), "System", "DOLAR", true, null, null, "CURRENCY", 0, null, null, "DOLAR", null, null },
                    { new Guid("f35d8016-c93b-4a05-9301-4c228d639a02"), true, new DateTime(2022, 6, 28, 3, 20, 58, 532, DateTimeKind.Utc).AddTicks(8588), "System", "Usuario tipo Empleado", true, null, null, "USERSTYPE", 0, null, null, "Empleado", null, null },
                    { new Guid("f3f6bde7-0c6a-4dc2-b785-674f1ca77b95"), true, new DateTime(2022, 6, 28, 3, 20, 58, 532, DateTimeKind.Utc).AddTicks(9061), "System", "Mantenimientos Roles", true, null, null, "MENUS", 6, new Guid("279db491-1a2a-4043-baf5-70835351a3ca"), null, "Roles", "/mantenimientos/roles", null },
                    { new Guid("f49725ee-8d2d-44b7-b995-1830348c6b86"), true, new DateTime(2022, 6, 28, 3, 20, 58, 532, DateTimeKind.Utc).AddTicks(8591), "System", "Usuario tipo Gerente", true, null, null, "USERSTYPE", 0, null, null, "Gerente", null, null },
                    { new Guid("f504e9d9-edd3-475f-8452-e5fc899fa033"), true, new DateTime(2022, 6, 28, 3, 20, 58, 532, DateTimeKind.Utc).AddTicks(8196), "System", "Pais Ecuador", true, null, null, "COUNTRIES", 0, null, null, "ECUADOR", null, null },
                    { new Guid("f535972a-7807-4335-91ec-a82b19eea803"), true, new DateTime(2022, 6, 28, 3, 20, 58, 532, DateTimeKind.Utc).AddTicks(9069), "System", "Mantenimientos Empleados", true, null, null, "MENUS", 9, new Guid("279db491-1a2a-4043-baf5-70835351a3ca"), null, "Empleados", "/mantenimientos/empleados", null },
                    { new Guid("f601b318-b0f9-4940-b5eb-bcb33ae7f5ea"), true, new DateTime(2022, 6, 28, 3, 20, 58, 532, DateTimeKind.Utc).AddTicks(9336), "System", "PREMIO", true, null, null, "DISCRETIONARYTYPE", 0, null, null, "PREMIO", null, null },
                    { new Guid("f9d2e8b0-5309-479a-a9a0-e5272002a68c"), true, new DateTime(2022, 6, 28, 3, 20, 58, 532, DateTimeKind.Utc).AddTicks(8301), "System", "Ciudad PORTOVIEJO", true, null, null, "CITY", 0, new Guid("d7e2a0ba-f955-4717-bf72-26c72ad4305b"), null, "PORTOVIEJO", null, null },
                    { new Guid("fa1fc274-168b-4485-ad16-00ea5f172ffa"), true, new DateTime(2022, 6, 28, 3, 20, 58, 532, DateTimeKind.Utc).AddTicks(8454), "System", "ESTADO DE PROYECTO", true, null, null, "PROJECTSTATE", 0, null, null, "ESTADO DE PROYECTO 2", null, null },
                    { new Guid("fa6f37f1-7b11-44fe-be08-7004f1f2bd99"), true, new DateTime(2022, 6, 28, 3, 20, 58, 532, DateTimeKind.Utc).AddTicks(8320), "System", "Ciudad SANGOLQUI", true, null, null, "CITY", 0, new Guid("5cbdbb13-b93d-46a3-852e-9ec0a5083a83"), null, "SANGOLQUI", null, null },
                    { new Guid("fb439685-8613-4b10-bed0-64dfc71a433c"), true, new DateTime(2022, 6, 28, 3, 20, 58, 532, DateTimeKind.Utc).AddTicks(9262), "System", "Reportes Proyectos y actividades", true, null, null, "MENUS", 0, new Guid("dd84c814-812e-4a54-a7d3-ea863da1a5c8"), null, "Proyectos y actividades", "/reportes/proyectos/actividades", null }
                });

            migrationBuilder.InsertData(
                table: "Company",
                columns: new[] { "Id", "Active", "Address", "CatalogRegionCityId", "CatalogRegionCountryId", "CatalogRegionStateId", "CatalogTypeId", "Created", "CreatedBy", "LastModified", "LastModifiedBy", "Name", "NumberId" },
                values: new object[] { new Guid("f20971a2-2b7b-46df-b8ff-2964e5e8d37b"), true, "Address", new Guid("4a4dfebf-6cd4-42bb-aeee-36775ec5b70c"), new Guid("f504e9d9-edd3-475f-8452-e5fc899fa033"), new Guid("5afe07a2-fd5e-478c-93ad-cc6c8aee7e8e"), new Guid("22874dde-3ef1-4875-bc02-88c7863444f1"), new DateTime(2022, 6, 28, 3, 20, 58, 533, DateTimeKind.Utc).AddTicks(176), "System", null, null, "Giga", "123456789" });

            migrationBuilder.InsertData(
                table: "MenuRole",
                columns: new[] { "Id", "Active", "CatalogMenuId", "Created", "CreatedBy", "LastModified", "LastModifiedBy", "RoleId", "UserId" },
                values: new object[,]
                {
                    { new Guid("0487c0d5-b756-4b24-bfde-c82970924441"), true, new Guid("f535972a-7807-4335-91ec-a82b19eea803"), new DateTime(2022, 6, 28, 3, 20, 58, 533, DateTimeKind.Utc).AddTicks(3199), "System", null, null, new Guid("c3b6a8a7-943b-49f8-b002-b8e197fb47f0"), null },
                    { new Guid("04aa051a-ce2e-483b-8ead-ad1a380cbab8"), true, new Guid("2565e61d-86d4-4a72-8886-296733908e5b"), new DateTime(2022, 6, 28, 3, 20, 58, 533, DateTimeKind.Utc).AddTicks(3042), "System", null, null, new Guid("c3b6a8a7-943b-49f8-b002-b8e197fb47f0"), null },
                    { new Guid("05308713-9652-400c-be78-67248c3a26f3"), true, new Guid("85db29c8-6df0-481b-8065-c10f55d4050b"), new DateTime(2022, 6, 28, 3, 20, 58, 533, DateTimeKind.Utc).AddTicks(2725), "System", null, null, new Guid("77115b3b-ef96-4735-b0df-de871f78075b"), null },
                    { new Guid("09d701f3-56f0-4704-bb0b-7e88159319eb"), true, new Guid("279db491-1a2a-4043-baf5-70835351a3ca"), new DateTime(2022, 6, 28, 3, 20, 58, 533, DateTimeKind.Utc).AddTicks(3048), "System", null, null, new Guid("c3b6a8a7-943b-49f8-b002-b8e197fb47f0"), null },
                    { new Guid("0e2a263c-2cd0-447b-b435-5bd5a26fb07a"), true, new Guid("bf39e8be-8707-4a80-bf9b-a30486a6b4bb"), new DateTime(2022, 6, 28, 3, 20, 58, 533, DateTimeKind.Utc).AddTicks(3191), "System", null, null, new Guid("c3b6a8a7-943b-49f8-b002-b8e197fb47f0"), null },
                    { new Guid("198f619c-3476-469b-aaaf-dc1a56da146d"), true, new Guid("abc3cd41-a3bf-4167-b7c9-c0d03cb6c84f"), new DateTime(2022, 6, 28, 3, 20, 58, 533, DateTimeKind.Utc).AddTicks(2733), "System", null, null, new Guid("77115b3b-ef96-4735-b0df-de871f78075b"), null },
                    { new Guid("1a975413-ae22-4a11-ad3a-4174dea35991"), true, new Guid("aebe7952-8a9d-49fa-bc6f-dc501bc89082"), new DateTime(2022, 6, 28, 3, 20, 58, 533, DateTimeKind.Utc).AddTicks(2615), "System", null, null, new Guid("77115b3b-ef96-4735-b0df-de871f78075b"), null },
                    { new Guid("1f587f95-6891-4856-936e-cccc6f487ff0"), true, new Guid("15299e9a-ebc1-45e1-9a7a-293253a01f1e"), new DateTime(2022, 6, 28, 3, 20, 58, 533, DateTimeKind.Utc).AddTicks(3214), "System", null, null, new Guid("c3b6a8a7-943b-49f8-b002-b8e197fb47f0"), null },
                    { new Guid("207a75d1-8968-4061-905c-54885edf0197"), true, new Guid("15be86da-51b5-40d8-92ee-e426a2a5df8f"), new DateTime(2022, 6, 28, 3, 20, 58, 533, DateTimeKind.Utc).AddTicks(2276), "System", null, null, new Guid("fd4535d2-7103-498e-85bd-9651778a4b72"), null },
                    { new Guid("24854fe2-f0f8-41cc-8fd8-a8f8a86e898b"), true, new Guid("90eba23b-5ccd-49b2-9e58-c86b440ae431"), new DateTime(2022, 6, 28, 3, 20, 58, 533, DateTimeKind.Utc).AddTicks(3206), "System", null, null, new Guid("c3b6a8a7-943b-49f8-b002-b8e197fb47f0"), null },
                    { new Guid("270de161-b0a0-4606-8f39-8523b24176d6"), true, new Guid("fb439685-8613-4b10-bed0-64dfc71a433c"), new DateTime(2022, 6, 28, 3, 20, 58, 533, DateTimeKind.Utc).AddTicks(2245), "System", null, null, new Guid("da7afbba-57a0-40da-a3b4-4542c20ff2a5"), null },
                    { new Guid("2ecbac56-0b3e-445c-84af-59115f45f49d"), true, new Guid("917f29ea-ade8-4b47-bbf4-1b13b5ea3fa8"), new DateTime(2022, 6, 28, 3, 20, 58, 533, DateTimeKind.Utc).AddTicks(3281), "System", null, null, new Guid("c3b6a8a7-943b-49f8-b002-b8e197fb47f0"), null },
                    { new Guid("31e3493a-e66f-48f2-8e51-dfe10be1c534"), true, new Guid("dd84c814-812e-4a54-a7d3-ea863da1a5c8"), new DateTime(2022, 6, 28, 3, 20, 58, 533, DateTimeKind.Utc).AddTicks(2750), "System", null, null, new Guid("77115b3b-ef96-4735-b0df-de871f78075b"), null },
                    { new Guid("340d734e-5722-4a66-beac-74276bff6945"), true, new Guid("38d321e1-6c32-4adf-bc6e-461061fc2b66"), new DateTime(2022, 6, 28, 3, 20, 58, 533, DateTimeKind.Utc).AddTicks(2227), "System", null, null, new Guid("1b48ee96-5788-4fef-90f0-34e891ad661f"), null },
                    { new Guid("3890b8d1-e097-4bf6-9ea0-c1c1cf276ae3"), true, new Guid("15be86da-51b5-40d8-92ee-e426a2a5df8f"), new DateTime(2022, 6, 28, 3, 20, 58, 533, DateTimeKind.Utc).AddTicks(2220), "System", null, null, new Guid("1b48ee96-5788-4fef-90f0-34e891ad661f"), null },
                    { new Guid("3fa2ff59-ac59-44da-a82f-5d73a5e35cb3"), true, new Guid("fb439685-8613-4b10-bed0-64dfc71a433c"), new DateTime(2022, 6, 28, 3, 20, 58, 533, DateTimeKind.Utc).AddTicks(2858), "System", null, null, new Guid("77115b3b-ef96-4735-b0df-de871f78075b"), null },
                    { new Guid("413e5b4c-99ba-4506-8324-e4cb072c45e8"), true, new Guid("02647d85-581b-4e74-acce-9adddaecf680"), new DateTime(2022, 6, 28, 3, 20, 58, 533, DateTimeKind.Utc).AddTicks(3469), "System", null, null, new Guid("c3b6a8a7-943b-49f8-b002-b8e197fb47f0"), null },
                    { new Guid("426d84e2-7449-4792-a85a-6c868aee68de"), true, new Guid("abc3cd41-a3bf-4167-b7c9-c0d03cb6c84f"), new DateTime(2022, 6, 28, 3, 20, 58, 533, DateTimeKind.Utc).AddTicks(2235), "System", null, null, new Guid("da7afbba-57a0-40da-a3b4-4542c20ff2a5"), null },
                    { new Guid("44a3cc8a-a4bc-4081-81cf-a5021bcc03ea"), true, new Guid("15299e9a-ebc1-45e1-9a7a-293253a01f1e"), new DateTime(2022, 6, 28, 3, 20, 58, 533, DateTimeKind.Utc).AddTicks(2231), "System", null, null, new Guid("da7afbba-57a0-40da-a3b4-4542c20ff2a5"), null },
                    { new Guid("462d75d5-513e-48fb-a83b-1426903a0722"), true, new Guid("6a9157ad-d1a8-464d-8f6f-a065a9b6c61c"), new DateTime(2022, 6, 28, 3, 20, 58, 533, DateTimeKind.Utc).AddTicks(2870), "System", null, null, new Guid("77115b3b-ef96-4735-b0df-de871f78075b"), null },
                    { new Guid("48e3cc25-5f7e-4b6c-adc8-ba884800b983"), true, new Guid("b2e7412c-d120-4cc3-a77e-b97b3796a46f"), new DateTime(2022, 6, 28, 3, 20, 58, 533, DateTimeKind.Utc).AddTicks(2643), "System", null, null, new Guid("77115b3b-ef96-4735-b0df-de871f78075b"), null },
                    { new Guid("4e232506-eedb-4f35-ac38-ac6c24769fba"), true, new Guid("f535972a-7807-4335-91ec-a82b19eea803"), new DateTime(2022, 6, 28, 3, 20, 58, 533, DateTimeKind.Utc).AddTicks(2651), "System", null, null, new Guid("77115b3b-ef96-4735-b0df-de871f78075b"), null },
                    { new Guid("4ffd125c-6882-40e1-ad67-ed917128eb63"), true, new Guid("dd84c814-812e-4a54-a7d3-ea863da1a5c8"), new DateTime(2022, 6, 28, 3, 20, 58, 533, DateTimeKind.Utc).AddTicks(2196), "System", null, null, new Guid("1b48ee96-5788-4fef-90f0-34e891ad661f"), null },
                    { new Guid("502eed91-c4e2-4987-9f07-2ee8ac0c3410"), true, new Guid("749d90e3-e39c-4630-9316-71cc814ab1ee"), new DateTime(2022, 6, 28, 3, 20, 58, 533, DateTimeKind.Utc).AddTicks(2625), "System", null, null, new Guid("77115b3b-ef96-4735-b0df-de871f78075b"), null },
                    { new Guid("55018408-f16e-4d37-88b7-682b7279c445"), true, new Guid("f3f6bde7-0c6a-4dc2-b785-674f1ca77b95"), new DateTime(2022, 6, 28, 3, 20, 58, 533, DateTimeKind.Utc).AddTicks(3188), "System", null, null, new Guid("c3b6a8a7-943b-49f8-b002-b8e197fb47f0"), null },
                    { new Guid("550899b0-e283-42e7-a81c-d8372811cb28"), true, new Guid("6a9157ad-d1a8-464d-8f6f-a065a9b6c61c"), new DateTime(2022, 6, 28, 3, 20, 58, 533, DateTimeKind.Utc).AddTicks(3359), "System", null, null, new Guid("c3b6a8a7-943b-49f8-b002-b8e197fb47f0"), null },
                    { new Guid("56060cb0-2b72-4aee-8cb2-a284e00a72f2"), true, new Guid("b05309c0-9b19-4474-a025-b59b526f1930"), new DateTime(2022, 6, 28, 3, 20, 58, 533, DateTimeKind.Utc).AddTicks(2721), "System", null, null, new Guid("77115b3b-ef96-4735-b0df-de871f78075b"), null },
                    { new Guid("5bfcbcdf-efa9-4f79-bf6c-9914c42231e3"), true, new Guid("85db29c8-6df0-481b-8065-c10f55d4050b"), new DateTime(2022, 6, 28, 3, 20, 58, 533, DateTimeKind.Utc).AddTicks(3274), "System", null, null, new Guid("c3b6a8a7-943b-49f8-b002-b8e197fb47f0"), null },
                    { new Guid("5c7f5bef-7c8f-47a0-8172-7ecd86a413a3"), true, new Guid("655b2ad6-6c94-4a67-a3de-9cbe3501d7c0"), new DateTime(2022, 6, 28, 3, 20, 58, 533, DateTimeKind.Utc).AddTicks(3168), "System", null, null, new Guid("c3b6a8a7-943b-49f8-b002-b8e197fb47f0"), null },
                    { new Guid("626cea29-8fc9-477e-a438-2f6fb25cbcb2"), true, new Guid("4c748e6e-60a6-47fd-b83a-d91fc57feb0f"), new DateTime(2022, 6, 28, 3, 20, 58, 533, DateTimeKind.Utc).AddTicks(2929), "System", null, null, new Guid("77115b3b-ef96-4735-b0df-de871f78075b"), null },
                    { new Guid("64ac7f16-1025-49ea-b23e-863abf418e50"), true, new Guid("15be86da-51b5-40d8-92ee-e426a2a5df8f"), new DateTime(2022, 6, 28, 3, 20, 58, 533, DateTimeKind.Utc).AddTicks(3351), "System", null, null, new Guid("c3b6a8a7-943b-49f8-b002-b8e197fb47f0"), null },
                    { new Guid("6a6ac217-6ca5-4919-9b46-e5f9670a8c2e"), true, new Guid("15be86da-51b5-40d8-92ee-e426a2a5df8f"), new DateTime(2022, 6, 28, 3, 20, 58, 533, DateTimeKind.Utc).AddTicks(2862), "System", null, null, new Guid("77115b3b-ef96-4735-b0df-de871f78075b"), null },
                    { new Guid("714643e0-4b1f-476b-a97a-066426a8de19"), true, new Guid("fb439685-8613-4b10-bed0-64dfc71a433c"), new DateTime(2022, 6, 28, 3, 20, 58, 533, DateTimeKind.Utc).AddTicks(3343), "System", null, null, new Guid("c3b6a8a7-943b-49f8-b002-b8e197fb47f0"), null },
                    { new Guid("7433cd8a-d844-44c1-868b-93e0db2a6970"), true, new Guid("38d321e1-6c32-4adf-bc6e-461061fc2b66"), new DateTime(2022, 6, 28, 3, 20, 58, 533, DateTimeKind.Utc).AddTicks(2865), "System", null, null, new Guid("77115b3b-ef96-4735-b0df-de871f78075b"), null },
                    { new Guid("76ee48d8-6aa2-41c4-9e7f-803a69b5ac93"), true, new Guid("aebe7952-8a9d-49fa-bc6f-dc501bc89082"), new DateTime(2022, 6, 28, 3, 20, 58, 533, DateTimeKind.Utc).AddTicks(3105), "System", null, null, new Guid("c3b6a8a7-943b-49f8-b002-b8e197fb47f0"), null },
                    { new Guid("77beca01-de59-4117-86b9-dc78e9fa2bd6"), true, new Guid("8804915e-1694-486b-8fa0-5b47d0fdaa11"), new DateTime(2022, 6, 28, 3, 20, 58, 533, DateTimeKind.Utc).AddTicks(3202), "System", null, null, new Guid("c3b6a8a7-943b-49f8-b002-b8e197fb47f0"), null },
                    { new Guid("783e4229-d50d-48fb-b4e3-4a0fa063564c"), true, new Guid("84e9e9c9-afbb-4944-9699-67cf269b91ae"), new DateTime(2022, 6, 28, 3, 20, 58, 533, DateTimeKind.Utc).AddTicks(2621), "System", null, null, new Guid("77115b3b-ef96-4735-b0df-de871f78075b"), null },
                    { new Guid("7a87bbc9-9f4a-41ed-8477-7cc083378214"), true, new Guid("b2e7412c-d120-4cc3-a77e-b97b3796a46f"), new DateTime(2022, 6, 28, 3, 20, 58, 533, DateTimeKind.Utc).AddTicks(3195), "System", null, null, new Guid("c3b6a8a7-943b-49f8-b002-b8e197fb47f0"), null },
                    { new Guid("7be4b62b-d817-47d0-a47b-c7094e805b56"), true, new Guid("38d321e1-6c32-4adf-bc6e-461061fc2b66"), new DateTime(2022, 6, 28, 3, 20, 58, 533, DateTimeKind.Utc).AddTicks(3355), "System", null, null, new Guid("c3b6a8a7-943b-49f8-b002-b8e197fb47f0"), null },
                    { new Guid("82033dec-9b11-4881-91e8-ec5e84de8869"), true, new Guid("abc3cd41-a3bf-4167-b7c9-c0d03cb6c84f"), new DateTime(2022, 6, 28, 3, 20, 58, 533, DateTimeKind.Utc).AddTicks(3277), "System", null, null, new Guid("c3b6a8a7-943b-49f8-b002-b8e197fb47f0"), null },
                    { new Guid("8541407c-0944-4548-a760-71f4dbac0e36"), true, new Guid("749d90e3-e39c-4630-9316-71cc814ab1ee"), new DateTime(2022, 6, 28, 3, 20, 58, 533, DateTimeKind.Utc).AddTicks(3180), "System", null, null, new Guid("c3b6a8a7-943b-49f8-b002-b8e197fb47f0"), null },
                    { new Guid("8a267a83-aba7-469d-a9cd-97a5a1b86a06"), true, new Guid("4fd6aa25-040a-4a58-8f3d-ea1aeff04bd6"), new DateTime(2022, 6, 28, 3, 20, 58, 533, DateTimeKind.Utc).AddTicks(3184), "System", null, null, new Guid("c3b6a8a7-943b-49f8-b002-b8e197fb47f0"), null }
                });

            migrationBuilder.InsertData(
                table: "MenuRole",
                columns: new[] { "Id", "Active", "CatalogMenuId", "Created", "CreatedBy", "LastModified", "LastModifiedBy", "RoleId", "UserId" },
                values: new object[,]
                {
                    { new Guid("8c4c307a-0461-454d-870c-8f6eb92bebef"), true, new Guid("15be86da-51b5-40d8-92ee-e426a2a5df8f"), new DateTime(2022, 6, 28, 3, 20, 58, 533, DateTimeKind.Utc).AddTicks(2249), "System", null, null, new Guid("da7afbba-57a0-40da-a3b4-4542c20ff2a5"), null },
                    { new Guid("94d274be-8273-456d-82c9-09cc0a039ba1"), true, new Guid("15299e9a-ebc1-45e1-9a7a-293253a01f1e"), new DateTime(2022, 6, 28, 3, 20, 58, 533, DateTimeKind.Utc).AddTicks(2663), "System", null, null, new Guid("77115b3b-ef96-4735-b0df-de871f78075b"), null },
                    { new Guid("964f044a-5562-4a11-a173-6df4d0f4768f"), true, new Guid("dd84c814-812e-4a54-a7d3-ea863da1a5c8"), new DateTime(2022, 6, 28, 3, 20, 58, 533, DateTimeKind.Utc).AddTicks(2239), "System", null, null, new Guid("da7afbba-57a0-40da-a3b4-4542c20ff2a5"), null },
                    { new Guid("9853480e-65ed-4d76-9aed-aef77a1ff24e"), true, new Guid("2565e61d-86d4-4a72-8886-296733908e5b"), new DateTime(2022, 6, 28, 3, 20, 58, 533, DateTimeKind.Utc).AddTicks(2191), "System", null, null, new Guid("1b48ee96-5788-4fef-90f0-34e891ad661f"), null },
                    { new Guid("a8aca147-8cd5-4e43-baa0-dee519b2c888"), true, new Guid("bc49bc14-4834-4b5a-a1e8-26715ae2c57e"), new DateTime(2022, 6, 28, 3, 20, 58, 533, DateTimeKind.Utc).AddTicks(2741), "System", null, null, new Guid("77115b3b-ef96-4735-b0df-de871f78075b"), null },
                    { new Guid("aa9cf51d-35a5-4976-9e4d-8b1e3440a01d"), true, new Guid("279db491-1a2a-4043-baf5-70835351a3ca"), new DateTime(2022, 6, 28, 3, 20, 58, 533, DateTimeKind.Utc).AddTicks(2542), "System", null, null, new Guid("77115b3b-ef96-4735-b0df-de871f78075b"), null },
                    { new Guid("b3dc1ada-5c45-4116-9405-7a1360ed3b8e"), true, new Guid("90eba23b-5ccd-49b2-9e58-c86b440ae431"), new DateTime(2022, 6, 28, 3, 20, 58, 533, DateTimeKind.Utc).AddTicks(2659), "System", null, null, new Guid("77115b3b-ef96-4735-b0df-de871f78075b"), null },
                    { new Guid("b4e0b979-8a0b-407c-be37-ee3e7a0f980c"), true, new Guid("8804915e-1694-486b-8fa0-5b47d0fdaa11"), new DateTime(2022, 6, 28, 3, 20, 58, 533, DateTimeKind.Utc).AddTicks(2655), "System", null, null, new Guid("77115b3b-ef96-4735-b0df-de871f78075b"), null },
                    { new Guid("b4fbfa04-1937-4cb1-9497-477b9d24661f"), true, new Guid("dd84c814-812e-4a54-a7d3-ea863da1a5c8"), new DateTime(2022, 6, 28, 3, 20, 58, 533, DateTimeKind.Utc).AddTicks(3293), "System", null, null, new Guid("c3b6a8a7-943b-49f8-b002-b8e197fb47f0"), null },
                    { new Guid("b848c439-b668-4312-8052-9b698a342edd"), true, new Guid("2565e61d-86d4-4a72-8886-296733908e5b"), new DateTime(2022, 6, 28, 3, 20, 58, 533, DateTimeKind.Utc).AddTicks(2535), "System", null, null, new Guid("77115b3b-ef96-4735-b0df-de871f78075b"), null },
                    { new Guid("c0a83538-4493-40fb-9241-59b7e58defa7"), true, new Guid("4fd6aa25-040a-4a58-8f3d-ea1aeff04bd6"), new DateTime(2022, 6, 28, 3, 20, 58, 533, DateTimeKind.Utc).AddTicks(2628), "System", null, null, new Guid("77115b3b-ef96-4735-b0df-de871f78075b"), null },
                    { new Guid("c2fceb82-e309-4905-8662-713e74f2d274"), true, new Guid("43c4bce9-c056-43e7-84f3-1c67877a2c70"), new DateTime(2022, 6, 28, 3, 20, 58, 533, DateTimeKind.Utc).AddTicks(2983), "System", null, null, new Guid("c3b6a8a7-943b-49f8-b002-b8e197fb47f0"), null },
                    { new Guid("c313c01b-67eb-4d8c-a9b2-9f8b909f528e"), true, new Guid("43c4bce9-c056-43e7-84f3-1c67877a2c70"), new DateTime(2022, 6, 28, 3, 20, 58, 533, DateTimeKind.Utc).AddTicks(2262), "System", null, null, new Guid("fd4535d2-7103-498e-85bd-9651778a4b72"), null },
                    { new Guid("c924cee4-4342-465c-b583-2f56cc65bb16"), true, new Guid("f3f6bde7-0c6a-4dc2-b785-674f1ca77b95"), new DateTime(2022, 6, 28, 3, 20, 58, 533, DateTimeKind.Utc).AddTicks(2631), "System", null, null, new Guid("77115b3b-ef96-4735-b0df-de871f78075b"), null },
                    { new Guid("d9b3b27b-280c-48bc-8a22-a4c7758055f8"), true, new Guid("bf39e8be-8707-4a80-bf9b-a30486a6b4bb"), new DateTime(2022, 6, 28, 3, 20, 58, 533, DateTimeKind.Utc).AddTicks(2639), "System", null, null, new Guid("77115b3b-ef96-4735-b0df-de871f78075b"), null },
                    { new Guid("da4793b2-f08b-41d4-af2b-8e5973dd62c1"), true, new Guid("43c4bce9-c056-43e7-84f3-1c67877a2c70"), new DateTime(2022, 6, 28, 3, 20, 58, 533, DateTimeKind.Utc).AddTicks(2383), "System", null, null, new Guid("77115b3b-ef96-4735-b0df-de871f78075b"), null },
                    { new Guid("dff01add-03cb-45da-99e5-1162f73bd90d"), true, new Guid("655b2ad6-6c94-4a67-a3de-9cbe3501d7c0"), new DateTime(2022, 6, 28, 3, 20, 58, 533, DateTimeKind.Utc).AddTicks(2618), "System", null, null, new Guid("77115b3b-ef96-4735-b0df-de871f78075b"), null },
                    { new Guid("e2e0efb7-51e2-4e8e-81df-686587f17dc0"), true, new Guid("02647d85-581b-4e74-acce-9adddaecf680"), new DateTime(2022, 6, 28, 3, 20, 58, 533, DateTimeKind.Utc).AddTicks(2925), "System", null, null, new Guid("77115b3b-ef96-4735-b0df-de871f78075b"), null },
                    { new Guid("e409b58c-0a1b-4384-a7e0-9b3c87612443"), true, new Guid("bc49bc14-4834-4b5a-a1e8-26715ae2c57e"), new DateTime(2022, 6, 28, 3, 20, 58, 533, DateTimeKind.Utc).AddTicks(3285), "System", null, null, new Guid("c3b6a8a7-943b-49f8-b002-b8e197fb47f0"), null },
                    { new Guid("e6426a5a-d87a-4141-8cbf-312a17e9ead5"), true, new Guid("917f29ea-ade8-4b47-bbf4-1b13b5ea3fa8"), new DateTime(2022, 6, 28, 3, 20, 58, 533, DateTimeKind.Utc).AddTicks(2737), "System", null, null, new Guid("77115b3b-ef96-4735-b0df-de871f78075b"), null },
                    { new Guid("e6bfa274-1ea6-40c4-838c-99080b2f12b0"), true, new Guid("4c748e6e-60a6-47fd-b83a-d91fc57feb0f"), new DateTime(2022, 6, 28, 3, 20, 58, 533, DateTimeKind.Utc).AddTicks(3473), "System", null, null, new Guid("c3b6a8a7-943b-49f8-b002-b8e197fb47f0"), null },
                    { new Guid("ec31ea54-8bd2-434a-8b3c-87449939ba72"), true, new Guid("43c4bce9-c056-43e7-84f3-1c67877a2c70"), new DateTime(2022, 6, 28, 3, 20, 58, 533, DateTimeKind.Utc).AddTicks(2182), "System", null, null, new Guid("1b48ee96-5788-4fef-90f0-34e891ad661f"), null },
                    { new Guid("ec8f2cc8-98dc-434e-824a-a36583a49ced"), true, new Guid("dd84c814-812e-4a54-a7d3-ea863da1a5c8"), new DateTime(2022, 6, 28, 3, 20, 58, 533, DateTimeKind.Utc).AddTicks(2269), "System", null, null, new Guid("fd4535d2-7103-498e-85bd-9651778a4b72"), null },
                    { new Guid("ecc354ef-7d97-4a97-95be-83008055f236"), true, new Guid("fb439685-8613-4b10-bed0-64dfc71a433c"), new DateTime(2022, 6, 28, 3, 20, 58, 533, DateTimeKind.Utc).AddTicks(2273), "System", null, null, new Guid("fd4535d2-7103-498e-85bd-9651778a4b72"), null },
                    { new Guid("f085187d-db95-4af4-bf92-902c189d00c3"), true, new Guid("84e9e9c9-afbb-4944-9699-67cf269b91ae"), new DateTime(2022, 6, 28, 3, 20, 58, 533, DateTimeKind.Utc).AddTicks(3171), "System", null, null, new Guid("c3b6a8a7-943b-49f8-b002-b8e197fb47f0"), null },
                    { new Guid("f41e8eb2-b27c-470b-9a76-2d42bb7e2d70"), true, new Guid("2565e61d-86d4-4a72-8886-296733908e5b"), new DateTime(2022, 6, 28, 3, 20, 58, 533, DateTimeKind.Utc).AddTicks(2265), "System", null, null, new Guid("fd4535d2-7103-498e-85bd-9651778a4b72"), null },
                    { new Guid("f77281af-8e2e-44a4-b10a-849d4ad220dc"), true, new Guid("fb439685-8613-4b10-bed0-64dfc71a433c"), new DateTime(2022, 6, 28, 3, 20, 58, 533, DateTimeKind.Utc).AddTicks(2216), "System", null, null, new Guid("1b48ee96-5788-4fef-90f0-34e891ad661f"), null },
                    { new Guid("f9854432-f787-4e0a-be39-0a6b49c8252a"), true, new Guid("38d321e1-6c32-4adf-bc6e-461061fc2b66"), new DateTime(2022, 6, 28, 3, 20, 58, 533, DateTimeKind.Utc).AddTicks(2258), "System", null, null, new Guid("da7afbba-57a0-40da-a3b4-4542c20ff2a5"), null },
                    { new Guid("fab62a48-c159-4880-8638-61d1d121deb7"), true, new Guid("38d321e1-6c32-4adf-bc6e-461061fc2b66"), new DateTime(2022, 6, 28, 3, 20, 58, 533, DateTimeKind.Utc).AddTicks(2282), "System", null, null, new Guid("fd4535d2-7103-498e-85bd-9651778a4b72"), null },
                    { new Guid("feaef8d7-b8de-414e-a560-f5cfa556323b"), true, new Guid("b05309c0-9b19-4474-a025-b59b526f1930"), new DateTime(2022, 6, 28, 3, 20, 58, 533, DateTimeKind.Utc).AddTicks(3270), "System", null, null, new Guid("c3b6a8a7-943b-49f8-b002-b8e197fb47f0"), null }
                });

            migrationBuilder.InsertData(
                table: "Subsidiary",
                columns: new[] { "Id", "Active", "Address", "CatalogRegionCityId", "CatalogRegionCountryId", "CatalogRegionStateId", "CatalogTypeId", "CompanyId", "Created", "CreatedBy", "LastModified", "LastModifiedBy", "Name", "NumberId" },
                values: new object[,]
                {
                    { new Guid("0a206aab-bc50-4683-be7b-f6adf4ad1209"), true, "Address", new Guid("9e07bed6-eee4-4fd6-afc1-bcb13b0ea7cc"), new Guid("f504e9d9-edd3-475f-8452-e5fc899fa033"), new Guid("5afe07a2-fd5e-478c-93ad-cc6c8aee7e8e"), new Guid("22874dde-3ef1-4875-bc02-88c7863444f1"), new Guid("f20971a2-2b7b-46df-b8ff-2964e5e8d37b"), new DateTime(2022, 6, 28, 3, 20, 58, 533, DateTimeKind.Utc).AddTicks(4015), "System", null, null, "Giga El Salvador", "123456789" },
                    { new Guid("6ea91b88-a679-4864-bc0c-853e2c92c91e"), true, "Address", new Guid("9e07bed6-eee4-4fd6-afc1-bcb13b0ea7cc"), new Guid("f504e9d9-edd3-475f-8452-e5fc899fa033"), new Guid("5afe07a2-fd5e-478c-93ad-cc6c8aee7e8e"), new Guid("22874dde-3ef1-4875-bc02-88c7863444f1"), new Guid("f20971a2-2b7b-46df-b8ff-2964e5e8d37b"), new DateTime(2022, 6, 28, 3, 20, 58, 533, DateTimeKind.Utc).AddTicks(4004), "System", null, null, "Giga Colombia", "123456789" },
                    { new Guid("8d5f7b87-f06f-4168-b67e-cbb897f0f1c5"), true, "Address", new Guid("9e07bed6-eee4-4fd6-afc1-bcb13b0ea7cc"), new Guid("f504e9d9-edd3-475f-8452-e5fc899fa033"), new Guid("5afe07a2-fd5e-478c-93ad-cc6c8aee7e8e"), new Guid("22874dde-3ef1-4875-bc02-88c7863444f1"), new Guid("f20971a2-2b7b-46df-b8ff-2964e5e8d37b"), new DateTime(2022, 6, 28, 3, 20, 58, 533, DateTimeKind.Utc).AddTicks(3986), "System", null, null, "Giga Ecuador", "123456789" }
                });

            migrationBuilder.InsertData(
                table: "Customer",
                columns: new[] { "Id", "Active", "Address", "CatalogCurrencyId", "CatalogIndustrySubTypeId", "CatalogIndustryTypeId", "CatalogRegionCityId", "CatalogRegionCountryId", "CatalogRegionStateId", "CatalogTypeId", "Created", "CreatedBy", "LastModified", "LastModifiedBy", "Name", "NumberId", "Phone", "SubsidiaryId" },
                values: new object[,]
                {
                    { new Guid("2c3eca7b-dcaa-4618-8984-6b96369fbd06"), true, "Customer1 address", new Guid("f124a4c3-b3e2-4e6b-96d4-26d4712be343"), new Guid("0576c349-ce1e-4761-a4ec-7ef228f426f5"), new Guid("1bcf3c7b-2e0e-4401-aa5f-d1460363b885"), new Guid("9e07bed6-eee4-4fd6-afc1-bcb13b0ea7cc"), new Guid("f504e9d9-edd3-475f-8452-e5fc899fa033"), new Guid("5afe07a2-fd5e-478c-93ad-cc6c8aee7e8e"), new Guid("22874dde-3ef1-4875-bc02-88c7863444f1"), new DateTime(2022, 6, 28, 3, 20, 58, 533, DateTimeKind.Utc).AddTicks(1155), "System", null, null, "Customer 5", "123456789", "000 123456789", new Guid("8d5f7b87-f06f-4168-b67e-cbb897f0f1c5") },
                    { new Guid("3ba8ddcb-55d2-4bf4-a06f-80876ad56cb5"), true, "Customer1 address", new Guid("f124a4c3-b3e2-4e6b-96d4-26d4712be343"), new Guid("0576c349-ce1e-4761-a4ec-7ef228f426f5"), new Guid("1bcf3c7b-2e0e-4401-aa5f-d1460363b885"), new Guid("9e07bed6-eee4-4fd6-afc1-bcb13b0ea7cc"), new Guid("f504e9d9-edd3-475f-8452-e5fc899fa033"), new Guid("5afe07a2-fd5e-478c-93ad-cc6c8aee7e8e"), new Guid("22874dde-3ef1-4875-bc02-88c7863444f1"), new DateTime(2022, 6, 28, 3, 20, 58, 533, DateTimeKind.Utc).AddTicks(1121), "System", null, null, "Customer 3", "123456789", "000 123456789", new Guid("8d5f7b87-f06f-4168-b67e-cbb897f0f1c5") },
                    { new Guid("4060dac4-83c1-48c6-ba0d-47cc426bd426"), true, "Customer1 address", new Guid("f124a4c3-b3e2-4e6b-96d4-26d4712be343"), new Guid("0576c349-ce1e-4761-a4ec-7ef228f426f5"), new Guid("1bcf3c7b-2e0e-4401-aa5f-d1460363b885"), new Guid("9e07bed6-eee4-4fd6-afc1-bcb13b0ea7cc"), new Guid("f504e9d9-edd3-475f-8452-e5fc899fa033"), new Guid("5afe07a2-fd5e-478c-93ad-cc6c8aee7e8e"), new Guid("22874dde-3ef1-4875-bc02-88c7863444f1"), new DateTime(2022, 6, 28, 3, 20, 58, 533, DateTimeKind.Utc).AddTicks(1194), "System", null, null, "Customer 7", "123456789", "000 123456789", new Guid("8d5f7b87-f06f-4168-b67e-cbb897f0f1c5") },
                    { new Guid("7ee0ef41-f62d-43c3-8ece-a3eb4a66c311"), true, "Customer1 address", new Guid("f124a4c3-b3e2-4e6b-96d4-26d4712be343"), new Guid("0576c349-ce1e-4761-a4ec-7ef228f426f5"), new Guid("1bcf3c7b-2e0e-4401-aa5f-d1460363b885"), new Guid("9e07bed6-eee4-4fd6-afc1-bcb13b0ea7cc"), new Guid("f504e9d9-edd3-475f-8452-e5fc899fa033"), new Guid("5afe07a2-fd5e-478c-93ad-cc6c8aee7e8e"), new Guid("22874dde-3ef1-4875-bc02-88c7863444f1"), new DateTime(2022, 6, 28, 3, 20, 58, 533, DateTimeKind.Utc).AddTicks(1139), "System", null, null, "Customer 4", "123456789", "000 123456789", new Guid("8d5f7b87-f06f-4168-b67e-cbb897f0f1c5") },
                    { new Guid("80f19c33-2a57-4767-8a1e-c58e0ebfd6fb"), true, "Customer address", new Guid("f124a4c3-b3e2-4e6b-96d4-26d4712be343"), new Guid("0576c349-ce1e-4761-a4ec-7ef228f426f5"), new Guid("1bcf3c7b-2e0e-4401-aa5f-d1460363b885"), new Guid("9e07bed6-eee4-4fd6-afc1-bcb13b0ea7cc"), new Guid("f504e9d9-edd3-475f-8452-e5fc899fa033"), new Guid("5afe07a2-fd5e-478c-93ad-cc6c8aee7e8e"), new Guid("22874dde-3ef1-4875-bc02-88c7863444f1"), new DateTime(2022, 6, 28, 3, 20, 58, 533, DateTimeKind.Utc).AddTicks(1073), "System", null, null, "Customer 1", "123456789", "000 123456789", new Guid("8d5f7b87-f06f-4168-b67e-cbb897f0f1c5") },
                    { new Guid("c53e126c-506c-45a1-a328-126deef87cee"), true, "Customer1 address", new Guid("f124a4c3-b3e2-4e6b-96d4-26d4712be343"), new Guid("0576c349-ce1e-4761-a4ec-7ef228f426f5"), new Guid("1bcf3c7b-2e0e-4401-aa5f-d1460363b885"), new Guid("9e07bed6-eee4-4fd6-afc1-bcb13b0ea7cc"), new Guid("f504e9d9-edd3-475f-8452-e5fc899fa033"), new Guid("5afe07a2-fd5e-478c-93ad-cc6c8aee7e8e"), new Guid("22874dde-3ef1-4875-bc02-88c7863444f1"), new DateTime(2022, 6, 28, 3, 20, 58, 533, DateTimeKind.Utc).AddTicks(1175), "System", null, null, "Customer 6", "123456789", "000 123456789", new Guid("8d5f7b87-f06f-4168-b67e-cbb897f0f1c5") },
                    { new Guid("f1b98eda-a3f0-4006-b947-1cd45ffd2cac"), true, "Customer1 address", new Guid("f124a4c3-b3e2-4e6b-96d4-26d4712be343"), new Guid("0576c349-ce1e-4761-a4ec-7ef228f426f5"), new Guid("1bcf3c7b-2e0e-4401-aa5f-d1460363b885"), new Guid("9e07bed6-eee4-4fd6-afc1-bcb13b0ea7cc"), new Guid("f504e9d9-edd3-475f-8452-e5fc899fa033"), new Guid("5afe07a2-fd5e-478c-93ad-cc6c8aee7e8e"), new Guid("22874dde-3ef1-4875-bc02-88c7863444f1"), new DateTime(2022, 6, 28, 3, 20, 58, 533, DateTimeKind.Utc).AddTicks(1105), "System", null, null, "Customer 2", "123456789", "000 123456789", new Guid("8d5f7b87-f06f-4168-b67e-cbb897f0f1c5") }
                });

            migrationBuilder.InsertData(
                table: "Employee",
                columns: new[] { "Id", "Active", "CatalogAreaId", "CatalogCostCenterId", "CatalogCurrencyId", "CatalogDepartmentId", "CatalogEmployeeTypeId", "CatalogPositionId", "CostHour", "Created", "CreatedBy", "LastModified", "LastModifiedBy", "LastName", "Names", "ParentId", "PhoneMobile", "PhoneOffice", "PhoneOfficeExt", "SubsidiaryId" },
                values: new object[,]
                {
                    { new Guid("2e54cc33-b22d-4cf7-9ba0-4bf8298fc348"), true, new Guid("b7571cdb-50bb-4c0d-ae2e-f854f5fddc24"), new Guid("33220a02-5ae9-46b9-9f3e-664cfe140320"), new Guid("f124a4c3-b3e2-4e6b-96d4-26d4712be343"), new Guid("e1cf4d2a-de84-4f11-a480-e4acad0a689d"), new Guid("5fadbd15-2505-44f9-b197-8c8b255cb3e6"), new Guid("c7d0f2c1-8039-4171-b4a2-e67defafd387"), 10m, new DateTime(2022, 6, 28, 3, 20, 58, 533, DateTimeKind.Utc).AddTicks(1748), "System", null, null, "Empleado 4", "Empleado 1", null, "123456789", "123456789", "123456789", new Guid("8d5f7b87-f06f-4168-b67e-cbb897f0f1c5") },
                    { new Guid("456aa0b7-58a6-4c2d-9475-c7656f6fa793"), true, new Guid("b7571cdb-50bb-4c0d-ae2e-f854f5fddc24"), new Guid("33220a02-5ae9-46b9-9f3e-664cfe140320"), new Guid("f124a4c3-b3e2-4e6b-96d4-26d4712be343"), new Guid("e1cf4d2a-de84-4f11-a480-e4acad0a689d"), new Guid("5fadbd15-2505-44f9-b197-8c8b255cb3e6"), new Guid("c7d0f2c1-8039-4171-b4a2-e67defafd387"), 10m, new DateTime(2022, 6, 28, 3, 20, 58, 533, DateTimeKind.Utc).AddTicks(1780), "System", null, null, "Empleado 6", "Empleado 1", null, "123456789", "123456789", "123456789", new Guid("8d5f7b87-f06f-4168-b67e-cbb897f0f1c5") },
                    { new Guid("56da204e-c648-4beb-85cd-2e20333c24c5"), true, new Guid("b7571cdb-50bb-4c0d-ae2e-f854f5fddc24"), new Guid("33220a02-5ae9-46b9-9f3e-664cfe140320"), new Guid("f124a4c3-b3e2-4e6b-96d4-26d4712be343"), new Guid("e1cf4d2a-de84-4f11-a480-e4acad0a689d"), new Guid("5fadbd15-2505-44f9-b197-8c8b255cb3e6"), new Guid("c7d0f2c1-8039-4171-b4a2-e67defafd387"), 10m, new DateTime(2022, 6, 28, 3, 20, 58, 533, DateTimeKind.Utc).AddTicks(1667), "System", null, null, "Empleado 3", "Empleado 1", null, "123456789", "123456789", "123456789", new Guid("8d5f7b87-f06f-4168-b67e-cbb897f0f1c5") },
                    { new Guid("782e2879-42fe-4206-8516-4cb7c1bd6270"), true, new Guid("b7571cdb-50bb-4c0d-ae2e-f854f5fddc24"), new Guid("33220a02-5ae9-46b9-9f3e-664cfe140320"), new Guid("f124a4c3-b3e2-4e6b-96d4-26d4712be343"), new Guid("e1cf4d2a-de84-4f11-a480-e4acad0a689d"), new Guid("5fadbd15-2505-44f9-b197-8c8b255cb3e6"), new Guid("c7d0f2c1-8039-4171-b4a2-e67defafd387"), 10m, new DateTime(2022, 6, 28, 3, 20, 58, 533, DateTimeKind.Utc).AddTicks(1653), "System", null, null, "Empleado 2", "Empleado 1", null, "123456789", "123456789", "123456789", new Guid("8d5f7b87-f06f-4168-b67e-cbb897f0f1c5") },
                    { new Guid("78ebf29f-dcfe-4e3c-bf77-069b158262e8"), true, new Guid("b7571cdb-50bb-4c0d-ae2e-f854f5fddc24"), new Guid("33220a02-5ae9-46b9-9f3e-664cfe140320"), new Guid("f124a4c3-b3e2-4e6b-96d4-26d4712be343"), new Guid("e1cf4d2a-de84-4f11-a480-e4acad0a689d"), new Guid("5fadbd15-2505-44f9-b197-8c8b255cb3e6"), new Guid("c7d0f2c1-8039-4171-b4a2-e67defafd387"), 10m, new DateTime(2022, 6, 28, 3, 20, 58, 533, DateTimeKind.Utc).AddTicks(1632), "System", null, null, "Empleado 1", "Empleado 1", null, "123456789", "123456789", "123456789", new Guid("8d5f7b87-f06f-4168-b67e-cbb897f0f1c5") },
                    { new Guid("fdf458d7-d43a-43b6-be92-70212348633b"), true, new Guid("b7571cdb-50bb-4c0d-ae2e-f854f5fddc24"), new Guid("33220a02-5ae9-46b9-9f3e-664cfe140320"), new Guid("f124a4c3-b3e2-4e6b-96d4-26d4712be343"), new Guid("e1cf4d2a-de84-4f11-a480-e4acad0a689d"), new Guid("5fadbd15-2505-44f9-b197-8c8b255cb3e6"), new Guid("c7d0f2c1-8039-4171-b4a2-e67defafd387"), 10m, new DateTime(2022, 6, 28, 3, 20, 58, 533, DateTimeKind.Utc).AddTicks(1763), "System", null, null, "Empleado 5", "Empleado 1", null, "123456789", "123456789", "123456789", new Guid("8d5f7b87-f06f-4168-b67e-cbb897f0f1c5") }
                });

            migrationBuilder.InsertData(
                table: "Contact",
                columns: new[] { "Id", "Active", "Area", "Created", "CreatedBy", "CustomerId", "Department", "Email", "LastModified", "LastModifiedBy", "LastName", "Names", "ParentId", "PhoneMobile", "PhoneOffice", "PhoneOfficeExt", "Position" },
                values: new object[,]
                {
                    { new Guid("95147ae2-93ee-43fd-acf0-d5eb248a597d"), true, null, new DateTime(2022, 6, 28, 3, 20, 58, 533, DateTimeKind.Utc).AddTicks(644), "System", new Guid("80f19c33-2a57-4767-8a1e-c58e0ebfd6fb"), null, "contact1@mail.com", null, null, "Contact 1", "Contact 1", null, null, null, null, null },
                    { new Guid("aaf570a8-39da-4c43-bcce-11f92a7e025c"), true, null, new DateTime(2022, 6, 28, 3, 20, 58, 533, DateTimeKind.Utc).AddTicks(663), "System", new Guid("f1b98eda-a3f0-4006-b947-1cd45ffd2cac"), null, "contact1@mail.com", null, null, "Contact 2", "Contact 2", null, null, null, null, null },
                    { new Guid("f1e66b7a-3e34-4df8-ab10-f372ea2ba8d6"), true, null, new DateTime(2022, 6, 28, 3, 20, 58, 533, DateTimeKind.Utc).AddTicks(668), "System", new Guid("f1b98eda-a3f0-4006-b947-1cd45ffd2cac"), null, "contact2_1@mail.com", null, null, "Contact 2.1", "Contact 2.1", null, null, null, null, null },
                    { new Guid("f234e182-b274-4109-bacf-3edc0d6d6ab8"), true, null, new DateTime(2022, 6, 28, 3, 20, 58, 533, DateTimeKind.Utc).AddTicks(656), "System", new Guid("80f19c33-2a57-4767-8a1e-c58e0ebfd6fb"), null, "contact1_1@mail.com", null, null, "Contact 1.1", "Contact 1.1", null, null, null, null, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Contact_CustomerId",
                table: "Contact",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Customer_SubsidiaryId",
                table: "Customer",
                column: "SubsidiaryId");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_SubsidiaryId",
                table: "Employee",
                column: "SubsidiaryId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeAward_EmployeeId",
                table: "EmployeeAward",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeCertification_EmployeeId",
                table: "EmployeeCertification",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeExperience_EmployeeId",
                table: "EmployeeExperience",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeSkillAbility_EmployeeId",
                table: "EmployeeSkillAbility",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeStudy_EmployeeId",
                table: "EmployeeStudy",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_FinancialParticipation_EmployeeId",
                table: "FinancialParticipation",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_HourBank_CustomerId",
                table: "HourBank",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_IdentityRoleClaims_ApplicationRoleId",
                table: "IdentityRoleClaims",
                column: "ApplicationRoleId");

            migrationBuilder.CreateIndex(
                name: "IX_IdentityRoleClaims_RoleId",
                table: "IdentityRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "IdentityRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_IdentityUserClaims_UserId",
                table: "IdentityUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_IdentityUserLogins_UserId",
                table: "IdentityUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_IdentityUserRoles_RoleId",
                table: "IdentityUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "IdentityUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "IdentityUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_MenuRole_CatalogMenuId",
                table: "MenuRole",
                column: "CatalogMenuId");

            migrationBuilder.CreateIndex(
                name: "IX_Project_CustomerId",
                table: "Project",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectHourBank_HourBankId",
                table: "ProjectHourBank",
                column: "HourBankId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectHourBank_ProjectId",
                table: "ProjectHourBank",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectManager_EmployeeId",
                table: "ProjectManager",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectManager_ProjectId",
                table: "ProjectManager",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectReport_ProjectId",
                table: "ProjectReport",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectReportDetail_FinancialParticipationId",
                table: "ProjectReportDetail",
                column: "FinancialParticipationId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectReportDetail_ProjectReportId",
                table: "ProjectReportDetail",
                column: "ProjectReportId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectReportDetail_TaskActivityId",
                table: "ProjectReportDetail",
                column: "TaskActivityId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProjectResource_EmployeeId",
                table: "ProjectResource",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectResource_ProjectId",
                table: "ProjectResource",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectTask_ProjectId",
                table: "ProjectTask",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Rules_SubsidiaryId",
                table: "Rules",
                column: "SubsidiaryId");

            migrationBuilder.CreateIndex(
                name: "IX_Subsidiary_CompanyId",
                table: "Subsidiary",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_TaskActivity_EmployeeId",
                table: "TaskActivity",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_TaskActivity_ProjectTaskId",
                table: "TaskActivity",
                column: "ProjectTaskId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Contact");

            migrationBuilder.DropTable(
                name: "EmployeeAward");

            migrationBuilder.DropTable(
                name: "EmployeeCertification");

            migrationBuilder.DropTable(
                name: "EmployeeExperience");

            migrationBuilder.DropTable(
                name: "EmployeeSkillAbility");

            migrationBuilder.DropTable(
                name: "EmployeeStudy");

            migrationBuilder.DropTable(
                name: "IdentityRoleClaims");

            migrationBuilder.DropTable(
                name: "IdentityUserClaims");

            migrationBuilder.DropTable(
                name: "IdentityUserLogins");

            migrationBuilder.DropTable(
                name: "IdentityUserRoles");

            migrationBuilder.DropTable(
                name: "IdentityUserTokens");

            migrationBuilder.DropTable(
                name: "MenuRole");

            migrationBuilder.DropTable(
                name: "PercentageParticipationTable");

            migrationBuilder.DropTable(
                name: "ProjectHourBank");

            migrationBuilder.DropTable(
                name: "ProjectManager");

            migrationBuilder.DropTable(
                name: "ProjectReportDetail");

            migrationBuilder.DropTable(
                name: "ProjectResource");

            migrationBuilder.DropTable(
                name: "Rules");

            migrationBuilder.DropTable(
                name: "IdentityRoles");

            migrationBuilder.DropTable(
                name: "IdentityUsers");

            migrationBuilder.DropTable(
                name: "Catalog");

            migrationBuilder.DropTable(
                name: "HourBank");

            migrationBuilder.DropTable(
                name: "FinancialParticipation");

            migrationBuilder.DropTable(
                name: "ProjectReport");

            migrationBuilder.DropTable(
                name: "TaskActivity");

            migrationBuilder.DropTable(
                name: "Employee");

            migrationBuilder.DropTable(
                name: "ProjectTask");

            migrationBuilder.DropTable(
                name: "Project");

            migrationBuilder.DropTable(
                name: "Customer");

            migrationBuilder.DropTable(
                name: "Subsidiary");

            migrationBuilder.DropTable(
                name: "Company");
        }
    }
}
