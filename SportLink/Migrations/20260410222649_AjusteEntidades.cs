using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SportLink.Migrations
{
    /// <inheritdoc />
    public partial class AjusteEntidades : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LogoUrl",
                table: "Equipos");

            migrationBuilder.AddColumn<string>(
                name: "LogoPath",
                table: "Equipos",
                type: "TEXT",
                maxLength: 255,
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LogoPath",
                table: "Equipos");

            migrationBuilder.AddColumn<string>(
                name: "LogoUrl",
                table: "Equipos",
                type: "TEXT",
                nullable: true);
        }
    }
}
