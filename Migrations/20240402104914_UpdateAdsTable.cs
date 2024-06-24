using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BYO3WebAPI.Migrations
{
    /// <inheritdoc />
    public partial class UpdateAdsTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AddOns",
                table: "Ads",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AdsType",
                table: "Ads",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AirConditionCount",
                table: "Ads",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AirConditionSize",
                table: "Ads",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AirConditionType",
                table: "Ads",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ColorIn",
                table: "Ads",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ColorOut",
                table: "Ads",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Cylinders",
                table: "Ads",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Faults",
                table: "Ads",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "GeneratorType",
                table: "Ads",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Height",
                table: "Ads",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Kilometer",
                table: "Ads",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NormalOrSaylant",
                table: "Ads",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NumberOfParson",
                table: "Ads",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PublicStatus",
                table: "Ads",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Security",
                table: "Ads",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Size",
                table: "Ads",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Specifications",
                table: "Ads",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "YearMake",
                table: "Ads",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AddOns",
                table: "Ads");

            migrationBuilder.DropColumn(
                name: "AdsType",
                table: "Ads");

            migrationBuilder.DropColumn(
                name: "AirConditionCount",
                table: "Ads");

            migrationBuilder.DropColumn(
                name: "AirConditionSize",
                table: "Ads");

            migrationBuilder.DropColumn(
                name: "AirConditionType",
                table: "Ads");

            migrationBuilder.DropColumn(
                name: "ColorIn",
                table: "Ads");

            migrationBuilder.DropColumn(
                name: "ColorOut",
                table: "Ads");

            migrationBuilder.DropColumn(
                name: "Cylinders",
                table: "Ads");

            migrationBuilder.DropColumn(
                name: "Faults",
                table: "Ads");

            migrationBuilder.DropColumn(
                name: "GeneratorType",
                table: "Ads");

            migrationBuilder.DropColumn(
                name: "Height",
                table: "Ads");

            migrationBuilder.DropColumn(
                name: "Kilometer",
                table: "Ads");

            migrationBuilder.DropColumn(
                name: "NormalOrSaylant",
                table: "Ads");

            migrationBuilder.DropColumn(
                name: "NumberOfParson",
                table: "Ads");

            migrationBuilder.DropColumn(
                name: "PublicStatus",
                table: "Ads");

            migrationBuilder.DropColumn(
                name: "Security",
                table: "Ads");

            migrationBuilder.DropColumn(
                name: "Size",
                table: "Ads");

            migrationBuilder.DropColumn(
                name: "Specifications",
                table: "Ads");

            migrationBuilder.DropColumn(
                name: "YearMake",
                table: "Ads");
        }
    }
}
