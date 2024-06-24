using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BYO3WebAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddcolumnType4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Type4",
                table: "Ads",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Type4",
                table: "Ads");
        }
    }
}
