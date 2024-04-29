using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Combo.Migrations
{
    /// <inheritdoc />
    public partial class FixTrailerModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Number",
                table: "Trailers");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Number",
                table: "Trailers",
                type: "text",
                nullable: false,
                defaultValue: "");
        }
    }
}
