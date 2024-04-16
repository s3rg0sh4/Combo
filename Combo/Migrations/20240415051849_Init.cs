using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Combo.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
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
                name: "Destiantion",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    View = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Destiantion", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CreationDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ActualCargo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActualCargo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ActualCargo_Cargo_Id",
                        column: x => x.Id,
                        principalTable: "Cargo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DeclaredCargo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeclaredCargo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DeclaredCargo_Cargo_Id",
                        column: x => x.Id,
                        principalTable: "Cargo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Waybill",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    OrderId = table.Column<Guid>(type: "uuid", nullable: false),
                    RouteSheetId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreationDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    Temperature = table.Column<int>(type: "integer", nullable: false),
                    TemperatureRemark = table.Column<string>(type: "text", nullable: true),
                    DeclaredCargoId = table.Column<Guid>(type: "uuid", nullable: false),
                    ActualCargoId = table.Column<Guid>(type: "uuid", nullable: false),
                    ArrivalDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    DestinationId = table.Column<Guid>(type: "uuid", nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Waybill", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Waybill_ActualCargo_ActualCargoId",
                        column: x => x.ActualCargoId,
                        principalTable: "ActualCargo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Waybill_DeclaredCargo_DeclaredCargoId",
                        column: x => x.DeclaredCargoId,
                        principalTable: "DeclaredCargo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Waybill_Destiantion_DestinationId",
                        column: x => x.DestinationId,
                        principalTable: "Destiantion",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Waybill_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Commentary",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    Created = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    Message = table.Column<string>(type: "text", nullable: false),
                    CommentatorType = table.Column<int>(type: "integer", nullable: false),
                    WaybillId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Commentary", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Commentary_Waybill_WaybillId",
                        column: x => x.WaybillId,
                        principalTable: "Waybill",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Commentary_WaybillId",
                table: "Commentary",
                column: "WaybillId");

            migrationBuilder.CreateIndex(
                name: "IX_Waybill_ActualCargoId",
                table: "Waybill",
                column: "ActualCargoId");

            migrationBuilder.CreateIndex(
                name: "IX_Waybill_DeclaredCargoId",
                table: "Waybill",
                column: "DeclaredCargoId");

            migrationBuilder.CreateIndex(
                name: "IX_Waybill_DestinationId",
                table: "Waybill",
                column: "DestinationId");

            migrationBuilder.CreateIndex(
                name: "IX_Waybill_OrderId",
                table: "Waybill",
                column: "OrderId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Commentary");

            migrationBuilder.DropTable(
                name: "Waybill");

            migrationBuilder.DropTable(
                name: "ActualCargo");

            migrationBuilder.DropTable(
                name: "DeclaredCargo");

            migrationBuilder.DropTable(
                name: "Destiantion");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Cargo");
        }
    }
}
