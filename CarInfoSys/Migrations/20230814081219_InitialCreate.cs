using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace CarInfoSys.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Car",
                columns: table => new
                {
                    viechleId = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    carType = table.Column<int>(nullable: false),
                    egnineCpacity = table.Column<int>(nullable: false),
                    color = table.Column<string>(nullable: true),
                    dailyFare = table.Column<double>(nullable: false),
                    rented = table.Column<bool>(nullable: false),
                    createdAt = table.Column<DateTime>(nullable: false),
                    updatedAt = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Car", x => x.viechleId);
                });

            migrationBuilder.CreateTable(
                name: "Customer",
                columns: table => new
                {
                    customerId = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    customerFirstName = table.Column<string>(nullable: true),
                    customerLastName = table.Column<string>(nullable: true),
                    phoneNumber = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.customerId);
                });

            migrationBuilder.CreateTable(
                name: "Driver",
                columns: table => new
                {
                    dirverId = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    driverName = table.Column<string>(nullable: true),
                    licence = table.Column<string>(nullable: true),
                    phoneNamber = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Driver", x => x.dirverId);
                });

            migrationBuilder.CreateTable(
                name: "Features",
                columns: table => new
                {
                    featureId = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    carType = table.Column<int>(nullable: false),
                    engineCapacity = table.Column<int>(nullable: false),
                    withDriver = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Features", x => x.featureId);
                });

            migrationBuilder.CreateTable(
                name: "CarRental",
                columns: table => new
                {
                    rentalId = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    viechleId = table.Column<long>(nullable: true),
                    customerId = table.Column<long>(nullable: false),
                    CarviechleId = table.Column<long>(nullable: true),
                    DriverdirverId = table.Column<long>(nullable: true),
                    startDate = table.Column<DateTime>(nullable: false),
                    endDate = table.Column<DateTime>(nullable: false),
                    createdAt = table.Column<DateTime>(nullable: false),
                    updatedAt = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarRental", x => x.rentalId);
                    table.ForeignKey(
                        name: "FK_CarRental_Car_CarviechleId",
                        column: x => x.CarviechleId,
                        principalTable: "Car",
                        principalColumn: "viechleId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CarRental_Driver_DriverdirverId",
                        column: x => x.DriverdirverId,
                        principalTable: "Driver",
                        principalColumn: "dirverId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CarRental_Customer_customerId",
                        column: x => x.customerId,
                        principalTable: "Customer",
                        principalColumn: "customerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CarRental_CarviechleId",
                table: "CarRental",
                column: "CarviechleId");

            migrationBuilder.CreateIndex(
                name: "IX_CarRental_DriverdirverId",
                table: "CarRental",
                column: "DriverdirverId");

            migrationBuilder.CreateIndex(
                name: "IX_CarRental_customerId",
                table: "CarRental",
                column: "customerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CarRental");

            migrationBuilder.DropTable(
                name: "Features");

            migrationBuilder.DropTable(
                name: "Car");

            migrationBuilder.DropTable(
                name: "Driver");

            migrationBuilder.DropTable(
                name: "Customer");
        }
    }
}
