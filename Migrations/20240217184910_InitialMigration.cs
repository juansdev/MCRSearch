using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MCRSearch.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(255)", nullable: false),
                    Name = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "longtext", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(255)", nullable: false),
                    Name = table.Column<string>(type: "longtext", nullable: true),
                    UserName = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    PasswordHash = table.Column<string>(type: "longtext", nullable: true),
                    SecurityStamp = table.Column<string>(type: "longtext", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "longtext", nullable: true),
                    PhoneNumber = table.Column<string>(type: "longtext", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetime(6)", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "VehicleBrands",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehicleBrands", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "VehicleModels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehicleModels", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "VehicleTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehicleTypes", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    RoleId = table.Column<string>(type: "varchar(255)", nullable: false),
                    ClaimType = table.Column<string>(type: "longtext", nullable: true),
                    ClaimValue = table.Column<string>(type: "longtext", nullable: true)
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
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<string>(type: "varchar(255)", nullable: false),
                    ClaimType = table.Column<string>(type: "longtext", nullable: true),
                    ClaimValue = table.Column<string>(type: "longtext", nullable: true)
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
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "varchar(255)", nullable: false),
                    ProviderKey = table.Column<string>(type: "varchar(255)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "longtext", nullable: true),
                    UserId = table.Column<string>(type: "varchar(255)", nullable: false)
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
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "varchar(255)", nullable: false),
                    RoleId = table.Column<string>(type: "varchar(255)", nullable: false)
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
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "varchar(255)", nullable: false),
                    LoginProvider = table.Column<string>(type: "varchar(255)", nullable: false),
                    Name = table.Column<string>(type: "varchar(255)", nullable: false),
                    Value = table.Column<string>(type: "longtext", nullable: true)
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
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false),
                    CountryId = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Departments_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Vehicles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    VehicleBrandId = table.Column<int>(type: "int", nullable: false),
                    VehicleModelId = table.Column<int>(type: "int", nullable: false),
                    VehicleTypeId = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Vehicles_VehicleBrands_VehicleBrandId",
                        column: x => x.VehicleBrandId,
                        principalTable: "VehicleBrands",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Vehicles_VehicleModels_VehicleModelId",
                        column: x => x.VehicleModelId,
                        principalTable: "VehicleModels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Vehicles_VehicleTypes_VehicleTypeId",
                        column: x => x.VehicleTypeId,
                        principalTable: "VehicleTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false),
                    DepartmentId = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cities_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AvailableVehicles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    VehicleId = table.Column<int>(type: "int", nullable: false),
                    PickUpCityId = table.Column<int>(type: "int", nullable: false),
                    ReturnCityId = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AvailableVehicles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AvailableVehicles_Cities_PickUpCityId",
                        column: x => x.PickUpCityId,
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AvailableVehicles_Cities_ReturnCityId",
                        column: x => x.ReturnCityId,
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AvailableVehicles_Vehicles_VehicleId",
                        column: x => x.VehicleId,
                        principalTable: "Vehicles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "341743f0-asd2-42de-afbf-59kmkkmk72cf6", "341743f0-asd2-42de-afbf-59kmkkmk72cf6", "admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "02174cf0–9412–4cfe-afbf-59f706d72cf6", 0, "3c129d9d-6c58-4dba-9178-b377c3e03b91", "admin@admin.com", true, false, null, "admin", null, "ADMIN", "AQAAAAIAAYagAAAAELLjMjzlFL4Pcg9+TwHp1ZdHxhajPJWUlFKXxZYwebqRLII8lFkP1f6v8QgpCOERGw==", null, false, "6946b7ff-7ee4-447a-8ae9-1337c347ceb0", false, "admin" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "CreateDate", "Name", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 2, 17, 13, 49, 10, 474, DateTimeKind.Local).AddTicks(1338), "Colombia", null },
                    { 2, new DateTime(2024, 2, 17, 13, 49, 10, 474, DateTimeKind.Local).AddTicks(1357), "Brazil", null }
                });

            migrationBuilder.InsertData(
                table: "VehicleBrands",
                columns: new[] { "Id", "CreateDate", "Name", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 2, 17, 13, 49, 10, 474, DateTimeKind.Local).AddTicks(1420), "Toyota", null },
                    { 2, new DateTime(2024, 2, 17, 13, 49, 10, 474, DateTimeKind.Local).AddTicks(1421), "Honda", null },
                    { 3, new DateTime(2024, 2, 17, 13, 49, 10, 474, DateTimeKind.Local).AddTicks(1422), "Ford", null },
                    { 4, new DateTime(2024, 2, 17, 13, 49, 10, 474, DateTimeKind.Local).AddTicks(1423), "Chevrolet", null },
                    { 5, new DateTime(2024, 2, 17, 13, 49, 10, 474, DateTimeKind.Local).AddTicks(1424), "Nissan", null },
                    { 6, new DateTime(2024, 2, 17, 13, 49, 10, 474, DateTimeKind.Local).AddTicks(1425), "Jeep", null },
                    { 7, new DateTime(2024, 2, 17, 13, 49, 10, 474, DateTimeKind.Local).AddTicks(1426), "Volkswagen", null },
                    { 8, new DateTime(2024, 2, 17, 13, 49, 10, 474, DateTimeKind.Local).AddTicks(1426), "BMW", null },
                    { 9, new DateTime(2024, 2, 17, 13, 49, 10, 474, DateTimeKind.Local).AddTicks(1427), "Mercedes-Benz", null },
                    { 10, new DateTime(2024, 2, 17, 13, 49, 10, 474, DateTimeKind.Local).AddTicks(1428), "Subaru", null },
                    { 11, new DateTime(2024, 2, 17, 13, 49, 10, 474, DateTimeKind.Local).AddTicks(1429), "Ford", null },
                    { 12, new DateTime(2024, 2, 17, 13, 49, 10, 474, DateTimeKind.Local).AddTicks(1430), "Tesla", null },
                    { 13, new DateTime(2024, 2, 17, 13, 49, 10, 474, DateTimeKind.Local).AddTicks(1431), "GMC", null },
                    { 14, new DateTime(2024, 2, 17, 13, 49, 10, 474, DateTimeKind.Local).AddTicks(1432), "Audi", null },
                    { 15, new DateTime(2024, 2, 17, 13, 49, 10, 474, DateTimeKind.Local).AddTicks(1432), "Hyundai", null },
                    { 16, new DateTime(2024, 2, 17, 13, 49, 10, 474, DateTimeKind.Local).AddTicks(1433), "Lexus", null },
                    { 17, new DateTime(2024, 2, 17, 13, 49, 10, 474, DateTimeKind.Local).AddTicks(1434), "Kia", null },
                    { 18, new DateTime(2024, 2, 17, 13, 49, 10, 474, DateTimeKind.Local).AddTicks(1435), "Jaguar", null },
                    { 19, new DateTime(2024, 2, 17, 13, 49, 10, 474, DateTimeKind.Local).AddTicks(1436), "Land Rover", null },
                    { 20, new DateTime(2024, 2, 17, 13, 49, 10, 474, DateTimeKind.Local).AddTicks(1437), "Ford", null }
                });

            migrationBuilder.InsertData(
                table: "VehicleModels",
                columns: new[] { "Id", "CreateDate", "Name", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 2, 17, 13, 49, 10, 474, DateTimeKind.Local).AddTicks(1470), "Camry", null },
                    { 2, new DateTime(2024, 2, 17, 13, 49, 10, 474, DateTimeKind.Local).AddTicks(1471), "Accord", null },
                    { 3, new DateTime(2024, 2, 17, 13, 49, 10, 474, DateTimeKind.Local).AddTicks(1472), "Explorer", null },
                    { 4, new DateTime(2024, 2, 17, 13, 49, 10, 474, DateTimeKind.Local).AddTicks(1473), "Malibu", null },
                    { 5, new DateTime(2024, 2, 17, 13, 49, 10, 474, DateTimeKind.Local).AddTicks(1474), "Rogue", null },
                    { 6, new DateTime(2024, 2, 17, 13, 49, 10, 474, DateTimeKind.Local).AddTicks(1474), "Wrangler", null },
                    { 7, new DateTime(2024, 2, 17, 13, 49, 10, 474, DateTimeKind.Local).AddTicks(1475), "Golf", null },
                    { 8, new DateTime(2024, 2, 17, 13, 49, 10, 474, DateTimeKind.Local).AddTicks(1476), "X5", null },
                    { 9, new DateTime(2024, 2, 17, 13, 49, 10, 474, DateTimeKind.Local).AddTicks(1477), "C-Class", null },
                    { 10, new DateTime(2024, 2, 17, 13, 49, 10, 474, DateTimeKind.Local).AddTicks(1478), "Outback", null },
                    { 11, new DateTime(2024, 2, 17, 13, 49, 10, 474, DateTimeKind.Local).AddTicks(1478), "F-150", null },
                    { 12, new DateTime(2024, 2, 17, 13, 49, 10, 474, DateTimeKind.Local).AddTicks(1479), "Model S", null },
                    { 13, new DateTime(2024, 2, 17, 13, 49, 10, 474, DateTimeKind.Local).AddTicks(1480), "Sierra", null },
                    { 14, new DateTime(2024, 2, 17, 13, 49, 10, 474, DateTimeKind.Local).AddTicks(1480), "Q7", null },
                    { 15, new DateTime(2024, 2, 17, 13, 49, 10, 474, DateTimeKind.Local).AddTicks(1481), "Santa Fe", null },
                    { 16, new DateTime(2024, 2, 17, 13, 49, 10, 474, DateTimeKind.Local).AddTicks(1482), "RX", null },
                    { 17, new DateTime(2024, 2, 17, 13, 49, 10, 474, DateTimeKind.Local).AddTicks(1482), "Sportage", null },
                    { 18, new DateTime(2024, 2, 17, 13, 49, 10, 474, DateTimeKind.Local).AddTicks(1483), "F-PACE", null },
                    { 19, new DateTime(2024, 2, 17, 13, 49, 10, 474, DateTimeKind.Local).AddTicks(1484), "Discovery", null },
                    { 20, new DateTime(2024, 2, 17, 13, 49, 10, 474, DateTimeKind.Local).AddTicks(1484), "Mustang", null }
                });

            migrationBuilder.InsertData(
                table: "VehicleTypes",
                columns: new[] { "Id", "CreateDate", "Name", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 2, 17, 13, 49, 10, 474, DateTimeKind.Local).AddTicks(1505), "Automóvil", null },
                    { 2, new DateTime(2024, 2, 17, 13, 49, 10, 474, DateTimeKind.Local).AddTicks(1506), "Camioneta", null },
                    { 3, new DateTime(2024, 2, 17, 13, 49, 10, 474, DateTimeKind.Local).AddTicks(1507), "SUV", null },
                    { 4, new DateTime(2024, 2, 17, 13, 49, 10, 474, DateTimeKind.Local).AddTicks(1508), "Campero", null }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "341743f0-asd2-42de-afbf-59kmkkmk72cf6", "02174cf0–9412–4cfe-afbf-59f706d72cf6" });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "CountryId", "CreateDate", "Name", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2024, 2, 17, 13, 49, 10, 474, DateTimeKind.Local).AddTicks(1382), "Cundinamarca", null },
                    { 2, 2, new DateTime(2024, 2, 17, 13, 49, 10, 474, DateTimeKind.Local).AddTicks(1384), "Goiás", null }
                });

            migrationBuilder.InsertData(
                table: "Vehicles",
                columns: new[] { "Id", "CreateDate", "UpdatedDate", "VehicleBrandId", "VehicleModelId", "VehicleTypeId" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 2, 17, 13, 49, 10, 474, DateTimeKind.Local).AddTicks(1521), null, 1, 1, 1 },
                    { 2, new DateTime(2024, 2, 17, 13, 49, 10, 474, DateTimeKind.Local).AddTicks(1523), null, 2, 2, 1 },
                    { 3, new DateTime(2024, 2, 17, 13, 49, 10, 474, DateTimeKind.Local).AddTicks(1524), null, 3, 3, 2 },
                    { 4, new DateTime(2024, 2, 17, 13, 49, 10, 474, DateTimeKind.Local).AddTicks(1525), null, 4, 4, 1 },
                    { 5, new DateTime(2024, 2, 17, 13, 49, 10, 474, DateTimeKind.Local).AddTicks(1526), null, 5, 5, 3 },
                    { 6, new DateTime(2024, 2, 17, 13, 49, 10, 474, DateTimeKind.Local).AddTicks(1527), null, 6, 6, 4 },
                    { 7, new DateTime(2024, 2, 17, 13, 49, 10, 474, DateTimeKind.Local).AddTicks(1528), null, 7, 7, 1 },
                    { 8, new DateTime(2024, 2, 17, 13, 49, 10, 474, DateTimeKind.Local).AddTicks(1529), null, 8, 8, 3 },
                    { 9, new DateTime(2024, 2, 17, 13, 49, 10, 474, DateTimeKind.Local).AddTicks(1530), null, 9, 9, 1 },
                    { 10, new DateTime(2024, 2, 17, 13, 49, 10, 474, DateTimeKind.Local).AddTicks(1531), null, 10, 10, 2 },
                    { 11, new DateTime(2024, 2, 17, 13, 49, 10, 474, DateTimeKind.Local).AddTicks(1531), null, 11, 11, 2 },
                    { 12, new DateTime(2024, 2, 17, 13, 49, 10, 474, DateTimeKind.Local).AddTicks(1532), null, 12, 12, 1 },
                    { 13, new DateTime(2024, 2, 17, 13, 49, 10, 474, DateTimeKind.Local).AddTicks(1533), null, 13, 13, 2 },
                    { 14, new DateTime(2024, 2, 17, 13, 49, 10, 474, DateTimeKind.Local).AddTicks(1534), null, 14, 14, 2 },
                    { 15, new DateTime(2024, 2, 17, 13, 49, 10, 474, DateTimeKind.Local).AddTicks(1535), null, 15, 15, 3 },
                    { 16, new DateTime(2024, 2, 17, 13, 49, 10, 474, DateTimeKind.Local).AddTicks(1536), null, 16, 16, 3 },
                    { 17, new DateTime(2024, 2, 17, 13, 49, 10, 474, DateTimeKind.Local).AddTicks(1536), null, 17, 17, 3 },
                    { 18, new DateTime(2024, 2, 17, 13, 49, 10, 474, DateTimeKind.Local).AddTicks(1537), null, 18, 18, 3 },
                    { 19, new DateTime(2024, 2, 17, 13, 49, 10, 474, DateTimeKind.Local).AddTicks(1538), null, 19, 19, 3 },
                    { 20, new DateTime(2024, 2, 17, 13, 49, 10, 474, DateTimeKind.Local).AddTicks(1567), null, 20, 20, 1 }
                });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "CreateDate", "DepartmentId", "Name", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 2, 17, 13, 49, 10, 474, DateTimeKind.Local).AddTicks(1399), 1, "Bogotá D.C.", null },
                    { 2, new DateTime(2024, 2, 17, 13, 49, 10, 474, DateTimeKind.Local).AddTicks(1402), 1, "Tunja", null },
                    { 3, new DateTime(2024, 2, 17, 13, 49, 10, 474, DateTimeKind.Local).AddTicks(1404), 2, "Brasilia", null },
                    { 4, new DateTime(2024, 2, 17, 13, 49, 10, 474, DateTimeKind.Local).AddTicks(1405), 2, "Goiânia", null }
                });

            migrationBuilder.InsertData(
                table: "AvailableVehicles",
                columns: new[] { "Id", "CreateDate", "PickUpCityId", "ReturnCityId", "UpdatedDate", "VehicleId" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 2, 17, 13, 49, 10, 474, DateTimeKind.Local).AddTicks(1584), 1, 1, null, 1 },
                    { 2, new DateTime(2024, 2, 17, 13, 49, 10, 474, DateTimeKind.Local).AddTicks(1588), 1, 1, null, 2 },
                    { 3, new DateTime(2024, 2, 17, 13, 49, 10, 474, DateTimeKind.Local).AddTicks(1589), 1, 1, null, 3 },
                    { 4, new DateTime(2024, 2, 17, 13, 49, 10, 474, DateTimeKind.Local).AddTicks(1590), 1, 1, null, 2 },
                    { 5, new DateTime(2024, 2, 17, 13, 49, 10, 474, DateTimeKind.Local).AddTicks(1591), 1, 1, null, 5 },
                    { 6, new DateTime(2024, 2, 17, 13, 49, 10, 474, DateTimeKind.Local).AddTicks(1592), 1, 2, null, 6 },
                    { 7, new DateTime(2024, 2, 17, 13, 49, 10, 474, DateTimeKind.Local).AddTicks(1593), 1, 2, null, 5 },
                    { 8, new DateTime(2024, 2, 17, 13, 49, 10, 474, DateTimeKind.Local).AddTicks(1593), 2, 1, null, 8 },
                    { 9, new DateTime(2024, 2, 17, 13, 49, 10, 474, DateTimeKind.Local).AddTicks(1594), 3, 3, null, 5 },
                    { 10, new DateTime(2024, 2, 17, 13, 49, 10, 474, DateTimeKind.Local).AddTicks(1596), 3, 3, null, 10 },
                    { 11, new DateTime(2024, 2, 17, 13, 49, 10, 474, DateTimeKind.Local).AddTicks(1596), 3, 3, null, 14 },
                    { 12, new DateTime(2024, 2, 17, 13, 49, 10, 474, DateTimeKind.Local).AddTicks(1597), 3, 3, null, 3 },
                    { 13, new DateTime(2024, 2, 17, 13, 49, 10, 474, DateTimeKind.Local).AddTicks(1598), 4, 3, null, 12 },
                    { 14, new DateTime(2024, 2, 17, 13, 49, 10, 474, DateTimeKind.Local).AddTicks(1599), 4, 3, null, 14 },
                    { 15, new DateTime(2024, 2, 17, 13, 49, 10, 474, DateTimeKind.Local).AddTicks(1600), 4, 3, null, 20 },
                    { 16, new DateTime(2024, 2, 17, 13, 49, 10, 474, DateTimeKind.Local).AddTicks(1601), 4, 3, null, 1 },
                    { 17, new DateTime(2024, 2, 17, 13, 49, 10, 474, DateTimeKind.Local).AddTicks(1602), 2, 2, null, 17 },
                    { 18, new DateTime(2024, 2, 17, 13, 49, 10, 474, DateTimeKind.Local).AddTicks(1602), 2, 2, null, 14 },
                    { 19, new DateTime(2024, 2, 17, 13, 49, 10, 474, DateTimeKind.Local).AddTicks(1603), 2, 2, null, 19 },
                    { 20, new DateTime(2024, 2, 17, 13, 49, 10, 474, DateTimeKind.Local).AddTicks(1604), 4, 4, null, 20 }
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
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AvailableVehicles_PickUpCityId",
                table: "AvailableVehicles",
                column: "PickUpCityId");

            migrationBuilder.CreateIndex(
                name: "IX_AvailableVehicles_ReturnCityId",
                table: "AvailableVehicles",
                column: "ReturnCityId");

            migrationBuilder.CreateIndex(
                name: "IX_AvailableVehicles_VehicleId",
                table: "AvailableVehicles",
                column: "VehicleId");

            migrationBuilder.CreateIndex(
                name: "IX_Cities_DepartmentId",
                table: "Cities",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Departments_CountryId",
                table: "Departments",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_VehicleBrandId",
                table: "Vehicles",
                column: "VehicleBrandId");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_VehicleModelId",
                table: "Vehicles",
                column: "VehicleModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_VehicleTypeId",
                table: "Vehicles",
                column: "VehicleTypeId");
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
                name: "AvailableVehicles");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Cities");

            migrationBuilder.DropTable(
                name: "Vehicles");

            migrationBuilder.DropTable(
                name: "Departments");

            migrationBuilder.DropTable(
                name: "VehicleBrands");

            migrationBuilder.DropTable(
                name: "VehicleModels");

            migrationBuilder.DropTable(
                name: "VehicleTypes");

            migrationBuilder.DropTable(
                name: "Countries");
        }
    }
}
