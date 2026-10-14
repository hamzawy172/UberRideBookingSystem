using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UberRideBookingSystem.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "rides",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PickUpLocation = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    DropOffLocation = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Fare = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ReiderId = table.Column<int>(type: "int", nullable: false),
                    DriverId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_rides", x => x.Id);
                    table.ForeignKey(
                        name: "FK_rides_users_DriverId",
                        column: x => x.DriverId,
                        principalTable: "users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_rides_users_ReiderId",
                        column: x => x.ReiderId,
                        principalTable: "users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "vehicles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Model = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PlateNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Color = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DriverId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_vehicles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_vehicles_users_DriverId",
                        column: x => x.DriverId,
                        principalTable: "users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "payments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PaymentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RideId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_payments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_payments_rides_RideId",
                        column: x => x.RideId,
                        principalTable: "rides",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ratings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Score = table.Column<int>(type: "int", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    RideId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ratings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ratings_rides_RideId",
                        column: x => x.RideId,
                        principalTable: "rides",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_payments_RideId",
                table: "payments",
                column: "RideId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ratings_RideId",
                table: "ratings",
                column: "RideId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_rides_DriverId",
                table: "rides",
                column: "DriverId");

            migrationBuilder.CreateIndex(
                name: "IX_rides_ReiderId",
                table: "rides",
                column: "ReiderId");

            migrationBuilder.CreateIndex(
                name: "IX_vehicles_DriverId",
                table: "vehicles",
                column: "DriverId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "payments");

            migrationBuilder.DropTable(
                name: "ratings");

            migrationBuilder.DropTable(
                name: "vehicles");

            migrationBuilder.DropTable(
                name: "rides");

            migrationBuilder.DropTable(
                name: "users");
        }
    }
}
