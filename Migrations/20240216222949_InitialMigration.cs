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
                values: new object[] { "02174cf0–9412–4cfe-afbf-59f706d72cf6", 0, "cc4d29b6-94ed-4b3e-b244-489b0195c17b", "admin@admin.com", true, false, null, "admin", null, "ADMIN", "AQAAAAIAAYagAAAAENCGropD1B8L4/Wp+2vGkZEkhTqtDGZJ1SP1GMoZ62bwaDFx33Kh3WNx7BzgIEVSWg==", null, false, "578308c7-ca68-415b-a4c9-1e42a46f3830", false, "admin" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "CreateDate", "Name", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 2, 16, 17, 29, 49, 159, DateTimeKind.Local).AddTicks(3169), "Colombia", null },
                    { 2, new DateTime(2024, 2, 16, 17, 29, 49, 159, DateTimeKind.Local).AddTicks(3189), "Brazil", null }
                });

            migrationBuilder.InsertData(
                table: "VehicleBrands",
                columns: new[] { "Id", "CreateDate", "Name", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 2, 16, 17, 29, 49, 159, DateTimeKind.Local).AddTicks(3256), "Toyota", null },
                    { 2, new DateTime(2024, 2, 16, 17, 29, 49, 159, DateTimeKind.Local).AddTicks(3257), "Honda", null },
                    { 3, new DateTime(2024, 2, 16, 17, 29, 49, 159, DateTimeKind.Local).AddTicks(3258), "Ford", null },
                    { 4, new DateTime(2024, 2, 16, 17, 29, 49, 159, DateTimeKind.Local).AddTicks(3260), "Chevrolet", null },
                    { 5, new DateTime(2024, 2, 16, 17, 29, 49, 159, DateTimeKind.Local).AddTicks(3260), "Nissan", null },
                    { 6, new DateTime(2024, 2, 16, 17, 29, 49, 159, DateTimeKind.Local).AddTicks(3261), "Jeep", null },
                    { 7, new DateTime(2024, 2, 16, 17, 29, 49, 159, DateTimeKind.Local).AddTicks(3262), "Volkswagen", null },
                    { 8, new DateTime(2024, 2, 16, 17, 29, 49, 159, DateTimeKind.Local).AddTicks(3263), "BMW", null },
                    { 9, new DateTime(2024, 2, 16, 17, 29, 49, 159, DateTimeKind.Local).AddTicks(3263), "Mercedes-Benz", null },
                    { 10, new DateTime(2024, 2, 16, 17, 29, 49, 159, DateTimeKind.Local).AddTicks(3264), "Subaru", null },
                    { 11, new DateTime(2024, 2, 16, 17, 29, 49, 159, DateTimeKind.Local).AddTicks(3265), "Ford", null },
                    { 12, new DateTime(2024, 2, 16, 17, 29, 49, 159, DateTimeKind.Local).AddTicks(3265), "Tesla", null },
                    { 13, new DateTime(2024, 2, 16, 17, 29, 49, 159, DateTimeKind.Local).AddTicks(3267), "GMC", null },
                    { 14, new DateTime(2024, 2, 16, 17, 29, 49, 159, DateTimeKind.Local).AddTicks(3267), "Audi", null },
                    { 15, new DateTime(2024, 2, 16, 17, 29, 49, 159, DateTimeKind.Local).AddTicks(3332), "Hyundai", null },
                    { 16, new DateTime(2024, 2, 16, 17, 29, 49, 159, DateTimeKind.Local).AddTicks(3333), "Lexus", null },
                    { 17, new DateTime(2024, 2, 16, 17, 29, 49, 159, DateTimeKind.Local).AddTicks(3334), "Kia", null },
                    { 18, new DateTime(2024, 2, 16, 17, 29, 49, 159, DateTimeKind.Local).AddTicks(3335), "Jaguar", null },
                    { 19, new DateTime(2024, 2, 16, 17, 29, 49, 159, DateTimeKind.Local).AddTicks(3336), "Land Rover", null },
                    { 20, new DateTime(2024, 2, 16, 17, 29, 49, 159, DateTimeKind.Local).AddTicks(3336), "Ford", null }
                });

            migrationBuilder.InsertData(
                table: "VehicleModels",
                columns: new[] { "Id", "CreateDate", "Name", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 2, 16, 17, 29, 49, 159, DateTimeKind.Local).AddTicks(3373), "Camry", null },
                    { 2, new DateTime(2024, 2, 16, 17, 29, 49, 159, DateTimeKind.Local).AddTicks(3374), "Accord", null },
                    { 3, new DateTime(2024, 2, 16, 17, 29, 49, 159, DateTimeKind.Local).AddTicks(3375), "Explorer", null },
                    { 4, new DateTime(2024, 2, 16, 17, 29, 49, 159, DateTimeKind.Local).AddTicks(3376), "Malibu", null },
                    { 5, new DateTime(2024, 2, 16, 17, 29, 49, 159, DateTimeKind.Local).AddTicks(3377), "Rogue", null },
                    { 6, new DateTime(2024, 2, 16, 17, 29, 49, 159, DateTimeKind.Local).AddTicks(3378), "Wrangler", null },
                    { 7, new DateTime(2024, 2, 16, 17, 29, 49, 159, DateTimeKind.Local).AddTicks(3379), "Golf", null },
                    { 8, new DateTime(2024, 2, 16, 17, 29, 49, 159, DateTimeKind.Local).AddTicks(3380), "X5", null },
                    { 9, new DateTime(2024, 2, 16, 17, 29, 49, 159, DateTimeKind.Local).AddTicks(3380), "C-Class", null },
                    { 10, new DateTime(2024, 2, 16, 17, 29, 49, 159, DateTimeKind.Local).AddTicks(3381), "Outback", null },
                    { 11, new DateTime(2024, 2, 16, 17, 29, 49, 159, DateTimeKind.Local).AddTicks(3382), "F-150", null },
                    { 12, new DateTime(2024, 2, 16, 17, 29, 49, 159, DateTimeKind.Local).AddTicks(3382), "Model S", null },
                    { 13, new DateTime(2024, 2, 16, 17, 29, 49, 159, DateTimeKind.Local).AddTicks(3383), "Sierra", null },
                    { 14, new DateTime(2024, 2, 16, 17, 29, 49, 159, DateTimeKind.Local).AddTicks(3384), "Q7", null },
                    { 15, new DateTime(2024, 2, 16, 17, 29, 49, 159, DateTimeKind.Local).AddTicks(3384), "Santa Fe", null },
                    { 16, new DateTime(2024, 2, 16, 17, 29, 49, 159, DateTimeKind.Local).AddTicks(3385), "RX", null },
                    { 17, new DateTime(2024, 2, 16, 17, 29, 49, 159, DateTimeKind.Local).AddTicks(3386), "Sportage", null },
                    { 18, new DateTime(2024, 2, 16, 17, 29, 49, 159, DateTimeKind.Local).AddTicks(3386), "F-PACE", null },
                    { 19, new DateTime(2024, 2, 16, 17, 29, 49, 159, DateTimeKind.Local).AddTicks(3387), "Discovery", null },
                    { 20, new DateTime(2024, 2, 16, 17, 29, 49, 159, DateTimeKind.Local).AddTicks(3387), "Mustang", null }
                });

            migrationBuilder.InsertData(
                table: "VehicleTypes",
                columns: new[] { "Id", "CreateDate", "Name", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 2, 16, 17, 29, 49, 159, DateTimeKind.Local).AddTicks(3411), "Automóvil", null },
                    { 2, new DateTime(2024, 2, 16, 17, 29, 49, 159, DateTimeKind.Local).AddTicks(3413), "Camioneta", null },
                    { 3, new DateTime(2024, 2, 16, 17, 29, 49, 159, DateTimeKind.Local).AddTicks(3413), "SUV", null },
                    { 4, new DateTime(2024, 2, 16, 17, 29, 49, 159, DateTimeKind.Local).AddTicks(3414), "Campero", null }
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
                    { 1, 1, new DateTime(2024, 2, 16, 17, 29, 49, 159, DateTimeKind.Local).AddTicks(3210), "Cundinamarca", null },
                    { 2, 2, new DateTime(2024, 2, 16, 17, 29, 49, 159, DateTimeKind.Local).AddTicks(3213), "Goiás", null }
                });

            migrationBuilder.InsertData(
                table: "Vehicles",
                columns: new[] { "Id", "CreateDate", "UpdatedDate", "VehicleBrandId", "VehicleModelId", "VehicleTypeId" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 2, 16, 17, 29, 49, 159, DateTimeKind.Local).AddTicks(3430), null, 1, 1, 1 },
                    { 2, new DateTime(2024, 2, 16, 17, 29, 49, 159, DateTimeKind.Local).AddTicks(3433), null, 2, 2, 1 },
                    { 3, new DateTime(2024, 2, 16, 17, 29, 49, 159, DateTimeKind.Local).AddTicks(3434), null, 3, 3, 2 },
                    { 4, new DateTime(2024, 2, 16, 17, 29, 49, 159, DateTimeKind.Local).AddTicks(3435), null, 4, 4, 1 },
                    { 5, new DateTime(2024, 2, 16, 17, 29, 49, 159, DateTimeKind.Local).AddTicks(3435), null, 5, 5, 3 },
                    { 6, new DateTime(2024, 2, 16, 17, 29, 49, 159, DateTimeKind.Local).AddTicks(3436), null, 6, 6, 4 },
                    { 7, new DateTime(2024, 2, 16, 17, 29, 49, 159, DateTimeKind.Local).AddTicks(3437), null, 7, 7, 1 },
                    { 8, new DateTime(2024, 2, 16, 17, 29, 49, 159, DateTimeKind.Local).AddTicks(3438), null, 8, 8, 3 },
                    { 9, new DateTime(2024, 2, 16, 17, 29, 49, 159, DateTimeKind.Local).AddTicks(3439), null, 9, 9, 1 },
                    { 10, new DateTime(2024, 2, 16, 17, 29, 49, 159, DateTimeKind.Local).AddTicks(3440), null, 10, 10, 2 },
                    { 11, new DateTime(2024, 2, 16, 17, 29, 49, 159, DateTimeKind.Local).AddTicks(3442), null, 11, 11, 2 },
                    { 12, new DateTime(2024, 2, 16, 17, 29, 49, 159, DateTimeKind.Local).AddTicks(3443), null, 12, 12, 1 },
                    { 13, new DateTime(2024, 2, 16, 17, 29, 49, 159, DateTimeKind.Local).AddTicks(3444), null, 13, 13, 2 },
                    { 14, new DateTime(2024, 2, 16, 17, 29, 49, 159, DateTimeKind.Local).AddTicks(3444), null, 14, 14, 2 },
                    { 15, new DateTime(2024, 2, 16, 17, 29, 49, 159, DateTimeKind.Local).AddTicks(3445), null, 15, 15, 3 },
                    { 16, new DateTime(2024, 2, 16, 17, 29, 49, 159, DateTimeKind.Local).AddTicks(3446), null, 16, 16, 3 },
                    { 17, new DateTime(2024, 2, 16, 17, 29, 49, 159, DateTimeKind.Local).AddTicks(3447), null, 17, 17, 3 },
                    { 18, new DateTime(2024, 2, 16, 17, 29, 49, 159, DateTimeKind.Local).AddTicks(3448), null, 18, 18, 3 },
                    { 19, new DateTime(2024, 2, 16, 17, 29, 49, 159, DateTimeKind.Local).AddTicks(3449), null, 19, 19, 3 },
                    { 20, new DateTime(2024, 2, 16, 17, 29, 49, 159, DateTimeKind.Local).AddTicks(3449), null, 20, 20, 1 }
                });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "CreateDate", "DepartmentId", "Name", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 2, 16, 17, 29, 49, 159, DateTimeKind.Local).AddTicks(3232), 1, "Bogotá D.C.", null },
                    { 2, new DateTime(2024, 2, 16, 17, 29, 49, 159, DateTimeKind.Local).AddTicks(3236), 1, "Tunja", null },
                    { 3, new DateTime(2024, 2, 16, 17, 29, 49, 159, DateTimeKind.Local).AddTicks(3237), 2, "Brasilia", null },
                    { 4, new DateTime(2024, 2, 16, 17, 29, 49, 159, DateTimeKind.Local).AddTicks(3238), 2, "Goiânia", null }
                });

            migrationBuilder.InsertData(
                table: "AvailableVehicles",
                columns: new[] { "Id", "CreateDate", "PickUpCityId", "ReturnCityId", "UpdatedDate", "VehicleId" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 2, 16, 17, 29, 49, 159, DateTimeKind.Local).AddTicks(3469), 1, 1, null, 1 },
                    { 2, new DateTime(2024, 2, 16, 17, 29, 49, 159, DateTimeKind.Local).AddTicks(3476), 1, 1, null, 2 },
                    { 3, new DateTime(2024, 2, 16, 17, 29, 49, 159, DateTimeKind.Local).AddTicks(3477), 1, 1, null, 3 },
                    { 4, new DateTime(2024, 2, 16, 17, 29, 49, 159, DateTimeKind.Local).AddTicks(3478), 1, 1, null, 2 },
                    { 5, new DateTime(2024, 2, 16, 17, 29, 49, 159, DateTimeKind.Local).AddTicks(3479), 1, 1, null, 5 },
                    { 6, new DateTime(2024, 2, 16, 17, 29, 49, 159, DateTimeKind.Local).AddTicks(3480), 1, 2, null, 6 },
                    { 7, new DateTime(2024, 2, 16, 17, 29, 49, 159, DateTimeKind.Local).AddTicks(3481), 1, 2, null, 5 },
                    { 8, new DateTime(2024, 2, 16, 17, 29, 49, 159, DateTimeKind.Local).AddTicks(3482), 2, 1, null, 8 },
                    { 9, new DateTime(2024, 2, 16, 17, 29, 49, 159, DateTimeKind.Local).AddTicks(3482), 3, 3, null, 5 },
                    { 10, new DateTime(2024, 2, 16, 17, 29, 49, 159, DateTimeKind.Local).AddTicks(3483), 3, 3, null, 10 },
                    { 11, new DateTime(2024, 2, 16, 17, 29, 49, 159, DateTimeKind.Local).AddTicks(3484), 3, 3, null, 14 },
                    { 12, new DateTime(2024, 2, 16, 17, 29, 49, 159, DateTimeKind.Local).AddTicks(3485), 3, 3, null, 3 },
                    { 13, new DateTime(2024, 2, 16, 17, 29, 49, 159, DateTimeKind.Local).AddTicks(3486), 4, 3, null, 12 },
                    { 14, new DateTime(2024, 2, 16, 17, 29, 49, 159, DateTimeKind.Local).AddTicks(3487), 4, 3, null, 14 },
                    { 15, new DateTime(2024, 2, 16, 17, 29, 49, 159, DateTimeKind.Local).AddTicks(3488), 4, 3, null, 20 },
                    { 16, new DateTime(2024, 2, 16, 17, 29, 49, 159, DateTimeKind.Local).AddTicks(3488), 4, 3, null, 1 },
                    { 17, new DateTime(2024, 2, 16, 17, 29, 49, 159, DateTimeKind.Local).AddTicks(3517), 2, 2, null, 17 },
                    { 18, new DateTime(2024, 2, 16, 17, 29, 49, 159, DateTimeKind.Local).AddTicks(3518), 2, 2, null, 14 },
                    { 19, new DateTime(2024, 2, 16, 17, 29, 49, 159, DateTimeKind.Local).AddTicks(3519), 2, 2, null, 19 },
                    { 20, new DateTime(2024, 2, 16, 17, 29, 49, 159, DateTimeKind.Local).AddTicks(3520), 4, 4, null, 20 }
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
