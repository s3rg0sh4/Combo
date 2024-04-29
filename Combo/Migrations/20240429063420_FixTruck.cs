using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Combo.Migrations
{
    /// <inheritdoc />
    public partial class FixTruck : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "MotorNamber",
                table: "Trucks",
                newName: "MotorNumber");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "MotorNumber",
                table: "Trucks",
                newName: "MotorNamber");
        }
    }
}
