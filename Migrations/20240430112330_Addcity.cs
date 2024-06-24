using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BYO3WebAPI.Migrations
{
    /// <inheritdoc />
    public partial class Addcity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "Service",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "Ads",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "City",
                table: "Service");

            migrationBuilder.DropColumn(
                name: "City",
                table: "Ads");
        }
    }
}
