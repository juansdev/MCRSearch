using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MCRSearch.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
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
                table: "Countries",
                columns: new[] { "Id", "CreateDate", "Name", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 2, 16, 5, 6, 5, 532, DateTimeKind.Local).AddTicks(1406), "Colombia", null },
                    { 2, new DateTime(2024, 2, 16, 5, 6, 5, 532, DateTimeKind.Local).AddTicks(1419), "Brazil", null }
                });

            migrationBuilder.InsertData(
                table: "VehicleBrands",
                columns: new[] { "Id", "CreateDate", "Name", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 2, 16, 5, 6, 5, 532, DateTimeKind.Local).AddTicks(1599), "Toyota", null },
                    { 2, new DateTime(2024, 2, 16, 5, 6, 5, 532, DateTimeKind.Local).AddTicks(1601), "Honda", null },
                    { 3, new DateTime(2024, 2, 16, 5, 6, 5, 532, DateTimeKind.Local).AddTicks(1602), "Ford", null },
                    { 4, new DateTime(2024, 2, 16, 5, 6, 5, 532, DateTimeKind.Local).AddTicks(1603), "Chevrolet", null },
                    { 5, new DateTime(2024, 2, 16, 5, 6, 5, 532, DateTimeKind.Local).AddTicks(1604), "Nissan", null },
                    { 6, new DateTime(2024, 2, 16, 5, 6, 5, 532, DateTimeKind.Local).AddTicks(1604), "Jeep", null },
                    { 7, new DateTime(2024, 2, 16, 5, 6, 5, 532, DateTimeKind.Local).AddTicks(1605), "Volkswagen", null },
                    { 8, new DateTime(2024, 2, 16, 5, 6, 5, 532, DateTimeKind.Local).AddTicks(1605), "BMW", null },
                    { 9, new DateTime(2024, 2, 16, 5, 6, 5, 532, DateTimeKind.Local).AddTicks(1606), "Mercedes-Benz", null },
                    { 10, new DateTime(2024, 2, 16, 5, 6, 5, 532, DateTimeKind.Local).AddTicks(1607), "Subaru", null },
                    { 11, new DateTime(2024, 2, 16, 5, 6, 5, 532, DateTimeKind.Local).AddTicks(1607), "Ford", null },
                    { 12, new DateTime(2024, 2, 16, 5, 6, 5, 532, DateTimeKind.Local).AddTicks(1608), "Tesla", null },
                    { 13, new DateTime(2024, 2, 16, 5, 6, 5, 532, DateTimeKind.Local).AddTicks(1609), "GMC", null },
                    { 14, new DateTime(2024, 2, 16, 5, 6, 5, 532, DateTimeKind.Local).AddTicks(1609), "Audi", null },
                    { 15, new DateTime(2024, 2, 16, 5, 6, 5, 532, DateTimeKind.Local).AddTicks(1610), "Hyundai", null },
                    { 16, new DateTime(2024, 2, 16, 5, 6, 5, 532, DateTimeKind.Local).AddTicks(1611), "Lexus", null },
                    { 17, new DateTime(2024, 2, 16, 5, 6, 5, 532, DateTimeKind.Local).AddTicks(1611), "Kia", null },
                    { 18, new DateTime(2024, 2, 16, 5, 6, 5, 532, DateTimeKind.Local).AddTicks(1613), "Jaguar", null },
                    { 19, new DateTime(2024, 2, 16, 5, 6, 5, 532, DateTimeKind.Local).AddTicks(1613), "Land Rover", null },
                    { 20, new DateTime(2024, 2, 16, 5, 6, 5, 532, DateTimeKind.Local).AddTicks(1614), "Ford", null }
                });

            migrationBuilder.InsertData(
                table: "VehicleModels",
                columns: new[] { "Id", "CreateDate", "Name", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 2, 16, 5, 6, 5, 532, DateTimeKind.Local).AddTicks(1633), "Camry", null },
                    { 2, new DateTime(2024, 2, 16, 5, 6, 5, 532, DateTimeKind.Local).AddTicks(1635), "Accord", null },
                    { 3, new DateTime(2024, 2, 16, 5, 6, 5, 532, DateTimeKind.Local).AddTicks(1635), "Explorer", null },
                    { 4, new DateTime(2024, 2, 16, 5, 6, 5, 532, DateTimeKind.Local).AddTicks(1636), "Malibu", null },
                    { 5, new DateTime(2024, 2, 16, 5, 6, 5, 532, DateTimeKind.Local).AddTicks(1637), "Rogue", null },
                    { 6, new DateTime(2024, 2, 16, 5, 6, 5, 532, DateTimeKind.Local).AddTicks(1638), "Wrangler", null },
                    { 7, new DateTime(2024, 2, 16, 5, 6, 5, 532, DateTimeKind.Local).AddTicks(1638), "Golf", null },
                    { 8, new DateTime(2024, 2, 16, 5, 6, 5, 532, DateTimeKind.Local).AddTicks(1639), "X5", null },
                    { 9, new DateTime(2024, 2, 16, 5, 6, 5, 532, DateTimeKind.Local).AddTicks(1640), "C-Class", null },
                    { 10, new DateTime(2024, 2, 16, 5, 6, 5, 532, DateTimeKind.Local).AddTicks(1640), "Outback", null },
                    { 11, new DateTime(2024, 2, 16, 5, 6, 5, 532, DateTimeKind.Local).AddTicks(1641), "F-150", null },
                    { 12, new DateTime(2024, 2, 16, 5, 6, 5, 532, DateTimeKind.Local).AddTicks(1641), "Model S", null },
                    { 13, new DateTime(2024, 2, 16, 5, 6, 5, 532, DateTimeKind.Local).AddTicks(1642), "Sierra", null },
                    { 14, new DateTime(2024, 2, 16, 5, 6, 5, 532, DateTimeKind.Local).AddTicks(1643), "Q7", null },
                    { 15, new DateTime(2024, 2, 16, 5, 6, 5, 532, DateTimeKind.Local).AddTicks(1643), "Santa Fe", null },
                    { 16, new DateTime(2024, 2, 16, 5, 6, 5, 532, DateTimeKind.Local).AddTicks(1644), "RX", null },
                    { 17, new DateTime(2024, 2, 16, 5, 6, 5, 532, DateTimeKind.Local).AddTicks(1644), "Sportage", null },
                    { 18, new DateTime(2024, 2, 16, 5, 6, 5, 532, DateTimeKind.Local).AddTicks(1645), "F-PACE", null },
                    { 19, new DateTime(2024, 2, 16, 5, 6, 5, 532, DateTimeKind.Local).AddTicks(1646), "Discovery", null },
                    { 20, new DateTime(2024, 2, 16, 5, 6, 5, 532, DateTimeKind.Local).AddTicks(1646), "Mustang", null }
                });

            migrationBuilder.InsertData(
                table: "VehicleTypes",
                columns: new[] { "Id", "CreateDate", "Name", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 2, 16, 5, 6, 5, 532, DateTimeKind.Local).AddTicks(1662), "Automóvil", null },
                    { 2, new DateTime(2024, 2, 16, 5, 6, 5, 532, DateTimeKind.Local).AddTicks(1698), "Camioneta", null },
                    { 3, new DateTime(2024, 2, 16, 5, 6, 5, 532, DateTimeKind.Local).AddTicks(1699), "SUV", null },
                    { 4, new DateTime(2024, 2, 16, 5, 6, 5, 532, DateTimeKind.Local).AddTicks(1700), "Campero", null }
                });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "CountryId", "CreateDate", "Name", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2024, 2, 16, 5, 6, 5, 532, DateTimeKind.Local).AddTicks(1564), "Cundinamarca", null },
                    { 2, 2, new DateTime(2024, 2, 16, 5, 6, 5, 532, DateTimeKind.Local).AddTicks(1568), "Goiás", null }
                });

            migrationBuilder.InsertData(
                table: "Vehicles",
                columns: new[] { "Id", "CreateDate", "UpdatedDate", "VehicleBrandId", "VehicleModelId", "VehicleTypeId" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 2, 16, 5, 6, 5, 532, DateTimeKind.Local).AddTicks(1712), null, 1, 1, 1 },
                    { 2, new DateTime(2024, 2, 16, 5, 6, 5, 532, DateTimeKind.Local).AddTicks(1714), null, 2, 2, 1 },
                    { 3, new DateTime(2024, 2, 16, 5, 6, 5, 532, DateTimeKind.Local).AddTicks(1717), null, 3, 3, 2 },
                    { 4, new DateTime(2024, 2, 16, 5, 6, 5, 532, DateTimeKind.Local).AddTicks(1717), null, 4, 4, 1 },
                    { 5, new DateTime(2024, 2, 16, 5, 6, 5, 532, DateTimeKind.Local).AddTicks(1718), null, 5, 5, 3 },
                    { 6, new DateTime(2024, 2, 16, 5, 6, 5, 532, DateTimeKind.Local).AddTicks(1719), null, 6, 6, 4 },
                    { 7, new DateTime(2024, 2, 16, 5, 6, 5, 532, DateTimeKind.Local).AddTicks(1720), null, 7, 7, 1 },
                    { 8, new DateTime(2024, 2, 16, 5, 6, 5, 532, DateTimeKind.Local).AddTicks(1721), null, 8, 8, 3 },
                    { 9, new DateTime(2024, 2, 16, 5, 6, 5, 532, DateTimeKind.Local).AddTicks(1722), null, 9, 9, 1 },
                    { 10, new DateTime(2024, 2, 16, 5, 6, 5, 532, DateTimeKind.Local).AddTicks(1722), null, 10, 10, 2 },
                    { 11, new DateTime(2024, 2, 16, 5, 6, 5, 532, DateTimeKind.Local).AddTicks(1724), null, 11, 11, 2 },
                    { 12, new DateTime(2024, 2, 16, 5, 6, 5, 532, DateTimeKind.Local).AddTicks(1724), null, 12, 12, 1 },
                    { 13, new DateTime(2024, 2, 16, 5, 6, 5, 532, DateTimeKind.Local).AddTicks(1725), null, 13, 13, 2 },
                    { 14, new DateTime(2024, 2, 16, 5, 6, 5, 532, DateTimeKind.Local).AddTicks(1726), null, 14, 14, 2 },
                    { 15, new DateTime(2024, 2, 16, 5, 6, 5, 532, DateTimeKind.Local).AddTicks(1727), null, 15, 15, 3 },
                    { 16, new DateTime(2024, 2, 16, 5, 6, 5, 532, DateTimeKind.Local).AddTicks(1728), null, 16, 16, 3 },
                    { 17, new DateTime(2024, 2, 16, 5, 6, 5, 532, DateTimeKind.Local).AddTicks(1728), null, 17, 17, 3 },
                    { 18, new DateTime(2024, 2, 16, 5, 6, 5, 532, DateTimeKind.Local).AddTicks(1729), null, 18, 18, 3 },
                    { 19, new DateTime(2024, 2, 16, 5, 6, 5, 532, DateTimeKind.Local).AddTicks(1730), null, 19, 19, 3 },
                    { 20, new DateTime(2024, 2, 16, 5, 6, 5, 532, DateTimeKind.Local).AddTicks(1731), null, 20, 20, 1 }
                });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "CreateDate", "DepartmentId", "Name", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 2, 16, 5, 6, 5, 532, DateTimeKind.Local).AddTicks(1581), 1, "Bogotá D.C.", null },
                    { 2, new DateTime(2024, 2, 16, 5, 6, 5, 532, DateTimeKind.Local).AddTicks(1583), 1, "Tunja", null },
                    { 3, new DateTime(2024, 2, 16, 5, 6, 5, 532, DateTimeKind.Local).AddTicks(1584), 2, "Brasilia", null },
                    { 4, new DateTime(2024, 2, 16, 5, 6, 5, 532, DateTimeKind.Local).AddTicks(1585), 2, "Goiânia", null }
                });

            migrationBuilder.InsertData(
                table: "AvailableVehicles",
                columns: new[] { "Id", "CreateDate", "PickUpCityId", "ReturnCityId", "UpdatedDate", "VehicleId" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 2, 16, 5, 6, 5, 532, DateTimeKind.Local).AddTicks(1746), 1, 1, null, 1 },
                    { 2, new DateTime(2024, 2, 16, 5, 6, 5, 532, DateTimeKind.Local).AddTicks(1751), 1, 1, null, 2 },
                    { 3, new DateTime(2024, 2, 16, 5, 6, 5, 532, DateTimeKind.Local).AddTicks(1752), 1, 1, null, 3 },
                    { 4, new DateTime(2024, 2, 16, 5, 6, 5, 532, DateTimeKind.Local).AddTicks(1753), 1, 1, null, 4 },
                    { 5, new DateTime(2024, 2, 16, 5, 6, 5, 532, DateTimeKind.Local).AddTicks(1753), 1, 1, null, 5 },
                    { 6, new DateTime(2024, 2, 16, 5, 6, 5, 532, DateTimeKind.Local).AddTicks(1754), 1, 2, null, 6 },
                    { 7, new DateTime(2024, 2, 16, 5, 6, 5, 532, DateTimeKind.Local).AddTicks(1755), 1, 2, null, 7 },
                    { 8, new DateTime(2024, 2, 16, 5, 6, 5, 532, DateTimeKind.Local).AddTicks(1756), 2, 1, null, 8 },
                    { 9, new DateTime(2024, 2, 16, 5, 6, 5, 532, DateTimeKind.Local).AddTicks(1757), 3, 3, null, 9 },
                    { 10, new DateTime(2024, 2, 16, 5, 6, 5, 532, DateTimeKind.Local).AddTicks(1757), 3, 3, null, 10 },
                    { 11, new DateTime(2024, 2, 16, 5, 6, 5, 532, DateTimeKind.Local).AddTicks(1758), 3, 3, null, 11 },
                    { 12, new DateTime(2024, 2, 16, 5, 6, 5, 532, DateTimeKind.Local).AddTicks(1759), 3, 3, null, 12 },
                    { 13, new DateTime(2024, 2, 16, 5, 6, 5, 532, DateTimeKind.Local).AddTicks(1760), 4, 3, null, 13 },
                    { 14, new DateTime(2024, 2, 16, 5, 6, 5, 532, DateTimeKind.Local).AddTicks(1761), 4, 3, null, 14 },
                    { 15, new DateTime(2024, 2, 16, 5, 6, 5, 532, DateTimeKind.Local).AddTicks(1762), 4, 3, null, 15 },
                    { 16, new DateTime(2024, 2, 16, 5, 6, 5, 532, DateTimeKind.Local).AddTicks(1762), 4, 3, null, 16 },
                    { 17, new DateTime(2024, 2, 16, 5, 6, 5, 532, DateTimeKind.Local).AddTicks(1763), 2, 2, null, 17 },
                    { 18, new DateTime(2024, 2, 16, 5, 6, 5, 532, DateTimeKind.Local).AddTicks(1764), 2, 2, null, 18 },
                    { 19, new DateTime(2024, 2, 16, 5, 6, 5, 532, DateTimeKind.Local).AddTicks(1765), 2, 2, null, 19 },
                    { 20, new DateTime(2024, 2, 16, 5, 6, 5, 532, DateTimeKind.Local).AddTicks(1766), 4, 4, null, 20 }
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
