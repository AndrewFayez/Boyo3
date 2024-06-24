using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BYO3WebAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddPackageforAds : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AdsPackage_Ads_AdsId",
                table: "AdsPackage");

            migrationBuilder.DropForeignKey(
                name: "FK_AdsPackage_Package_PackageId",
                table: "AdsPackage");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AdsPackage",
                table: "AdsPackage");

            migrationBuilder.RenameTable(
                name: "AdsPackage",
                newName: "AdsForPackage");

            migrationBuilder.RenameIndex(
                name: "IX_AdsPackage_AdsId",
                table: "AdsForPackage",
                newName: "IX_AdsForPackage_AdsId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AdsForPackage",
                table: "AdsForPackage",
                columns: new[] { "PackageId", "AdsId" });

            migrationBuilder.AddForeignKey(
                name: "FK_AdsForPackage_Ads_AdsId",
                table: "AdsForPackage",
                column: "AdsId",
                principalTable: "Ads",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AdsForPackage_Package_PackageId",
                table: "AdsForPackage",
                column: "PackageId",
                principalTable: "Package",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AdsForPackage_Ads_AdsId",
                table: "AdsForPackage");

            migrationBuilder.DropForeignKey(
                name: "FK_AdsForPackage_Package_PackageId",
                table: "AdsForPackage");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AdsForPackage",
                table: "AdsForPackage");

            migrationBuilder.RenameTable(
                name: "AdsForPackage",
                newName: "AdsPackage");

            migrationBuilder.RenameIndex(
                name: "IX_AdsForPackage_AdsId",
                table: "AdsPackage",
                newName: "IX_AdsPackage_AdsId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AdsPackage",
                table: "AdsPackage",
                columns: new[] { "PackageId", "AdsId" });

            migrationBuilder.AddForeignKey(
                name: "FK_AdsPackage_Ads_AdsId",
                table: "AdsPackage",
                column: "AdsId",
                principalTable: "Ads",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AdsPackage_Package_PackageId",
                table: "AdsPackage",
                column: "PackageId",
                principalTable: "Package",
                principalColumn: "Id");
        }
    }
}
