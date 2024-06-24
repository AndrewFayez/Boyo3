using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BYO3WebAPI.Migrations
{
    /// <inheritdoc />
    public partial class addAdspackage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AdsPackage",
                columns: table => new
                {
                    AdsId = table.Column<int>(type: "int", nullable: false),
                    PackageId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdsPackage", x => new { x.PackageId, x.AdsId });
                    table.ForeignKey(
                        name: "FK_AdsPackage_Ads_AdsId",
                        column: x => x.AdsId,
                        principalTable: "Ads",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AdsPackage_Package_PackageId",
                        column: x => x.PackageId,
                        principalTable: "Package",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ServiceForPackage",
                columns: table => new
                {
                    ServiceId = table.Column<int>(type: "int", nullable: false),
                    ServicePackageId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceForPackage", x => new { x.ServiceId, x.ServicePackageId });
                    table.ForeignKey(
                        name: "FK_ServiceForPackage_ServicePackage_ServicePackageId",
                        column: x => x.ServicePackageId,
                        principalTable: "ServicePackage",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ServiceForPackage_Service_ServiceId",
                        column: x => x.ServiceId,
                        principalTable: "Service",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_AdsPackage_AdsId",
                table: "AdsPackage",
                column: "AdsId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceForPackage_ServicePackageId",
                table: "ServiceForPackage",
                column: "ServicePackageId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AdsPackage");

            migrationBuilder.DropTable(
                name: "ServiceForPackage");
        }
    }
}
