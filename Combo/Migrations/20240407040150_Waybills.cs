using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Combo.Migrations
{
    /// <inheritdoc />
    public partial class Waybills : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cargo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    PalleteCount = table.Column<int>(type: "integer", nullable: false),
                    BoxCount = table.Column<int>(type: "integer", nullable: false),
                    Weight = table.Column<decimal>(type: "numeric", nullable: false),
                    Price = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cargo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Waybill",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Temperature = table.Column<int>(type: "integer", nullable: false),
                    Destination = table.Column<string>(type: "text", nullable: false),
                    ArrivalDate = table.Column<DateOnly>(type: "date", nullable: false),
                    DeliveryDate = table.Column<DateOnly>(type: "date", nullable: false),
                    DeclaredCargoId = table.Column<Guid>(type: "uuid", nullable: false),
                    ActualCargoId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Waybill", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Waybill_Cargo_ActualCargoId",
                        column: x => x.ActualCargoId,
                        principalTable: "Cargo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Waybill_Cargo_DeclaredCargoId",
                        column: x => x.DeclaredCargoId,
                        principalTable: "Cargo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Waybill_ActualCargoId",
                table: "Waybill",
                column: "ActualCargoId");

            migrationBuilder.CreateIndex(
                name: "IX_Waybill_DeclaredCargoId",
                table: "Waybill",
                column: "DeclaredCargoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Waybill");

            migrationBuilder.DropTable(
                name: "Cargo");
        }
    }
}
