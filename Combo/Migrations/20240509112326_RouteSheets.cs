using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Combo.Migrations
{
    /// <inheritdoc />
    public partial class RouteSheets : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<Guid>(
                name: "RouteSheetId",
                table: "Waybill",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AddColumn<Guid>(
                name: "RouteId",
                table: "Waybill",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "RouteSheets",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    DriverId = table.Column<Guid>(type: "uuid", nullable: false),
                    TruckId = table.Column<Guid>(type: "uuid", nullable: false),
                    TrailerId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreationDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    ArrivalDateReal = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    UploadDateReal = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    ArrivalDatePlanned = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    UploadDatePlanned = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    ShipmentDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RouteSheets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RouteSheets_Drivers_DriverId",
                        column: x => x.DriverId,
                        principalTable: "Drivers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RouteSheets_Trailers_TrailerId",
                        column: x => x.TrailerId,
                        principalTable: "Trailers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RouteSheets_Trucks_TruckId",
                        column: x => x.TruckId,
                        principalTable: "Trucks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Route",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    RouteSheetId = table.Column<Guid>(type: "uuid", nullable: false),
                    UnloadStart = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    UnloadEnd = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Route", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Route_RouteSheets_RouteSheetId",
                        column: x => x.RouteSheetId,
                        principalTable: "RouteSheets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Waybill_RouteId",
                table: "Waybill",
                column: "RouteId");

            migrationBuilder.CreateIndex(
                name: "IX_Waybill_RouteSheetId",
                table: "Waybill",
                column: "RouteSheetId");

            migrationBuilder.CreateIndex(
                name: "IX_Route_RouteSheetId",
                table: "Route",
                column: "RouteSheetId");

            migrationBuilder.CreateIndex(
                name: "IX_RouteSheets_DriverId",
                table: "RouteSheets",
                column: "DriverId");

            migrationBuilder.CreateIndex(
                name: "IX_RouteSheets_TrailerId",
                table: "RouteSheets",
                column: "TrailerId");

            migrationBuilder.CreateIndex(
                name: "IX_RouteSheets_TruckId",
                table: "RouteSheets",
                column: "TruckId");

            migrationBuilder.AddForeignKey(
                name: "FK_Waybill_RouteSheets_RouteSheetId",
                table: "Waybill",
                column: "RouteSheetId",
                principalTable: "RouteSheets",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Waybill_Route_RouteId",
                table: "Waybill",
                column: "RouteId",
                principalTable: "Route",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Waybill_RouteSheets_RouteSheetId",
                table: "Waybill");

            migrationBuilder.DropForeignKey(
                name: "FK_Waybill_Route_RouteId",
                table: "Waybill");

            migrationBuilder.DropTable(
                name: "Route");

            migrationBuilder.DropTable(
                name: "RouteSheets");

            migrationBuilder.DropIndex(
                name: "IX_Waybill_RouteId",
                table: "Waybill");

            migrationBuilder.DropIndex(
                name: "IX_Waybill_RouteSheetId",
                table: "Waybill");

            migrationBuilder.DropColumn(
                name: "RouteId",
                table: "Waybill");

            migrationBuilder.AlterColumn<Guid>(
                name: "RouteSheetId",
                table: "Waybill",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);
        }
    }
}
