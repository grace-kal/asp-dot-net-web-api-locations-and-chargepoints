using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LACP.Data.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Locations",
                columns: table => new
                {
                    LocationId = table.Column<string>(type: "varchar(39)", maxLength: 39, nullable: false),
                    Type = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Address = table.Column<string>(type: "nvarchar", nullable: false),
                    City = table.Column<string>(type: "nvarchar", nullable: false),
                    PostalCode = table.Column<string>(type: "nvarchar", nullable: false),
                    Country = table.Column<string>(type: "nvarchar", nullable: false),
                    LastUpdated = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.LocationId);
                });

            migrationBuilder.CreateTable(
                name: "ChargePoints",
                columns: table => new
                {
                    ChargePointId = table.Column<string>(type: "varchar(39)", maxLength: 39, nullable: false),
                    Status = table.Column<string>(type: "varchar(39)", maxLength: 39, nullable: false),
                    FloorLevel = table.Column<string>(type: "varchar(4)", maxLength: 4, nullable: true),
                    LastUpdated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LocationId = table.Column<string>(type: "varchar(39)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChargePoints", x => x.ChargePointId);
                    table.ForeignKey(
                        name: "FK_ChargePoints_Locations_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Locations",
                        principalColumn: "LocationId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ChargePoints_LocationId",
                table: "ChargePoints",
                column: "LocationId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChargePoints");

            migrationBuilder.DropTable(
                name: "Locations");
        }
    }
}
