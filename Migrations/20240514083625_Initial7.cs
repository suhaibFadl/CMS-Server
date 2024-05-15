using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClinicsManagementSystem.Migrations
{
    /// <inheritdoc />
    public partial class Initial7 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clinics_Cities_CityId",
                table: "Clinics");

            migrationBuilder.RenameColumn(
                name: "CityId",
                table: "Clinics",
                newName: "CityId1");

            migrationBuilder.RenameIndex(
                name: "IX_Clinics_CityId",
                table: "Clinics",
                newName: "IX_Clinics_CityId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Clinics_Cities_CityId1",
                table: "Clinics",
                column: "CityId1",
                principalTable: "Cities",
                principalColumn: "CityId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clinics_Cities_CityId1",
                table: "Clinics");

            migrationBuilder.RenameColumn(
                name: "CityId1",
                table: "Clinics",
                newName: "CityId");

            migrationBuilder.RenameIndex(
                name: "IX_Clinics_CityId1",
                table: "Clinics",
                newName: "IX_Clinics_CityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Clinics_Cities_CityId",
                table: "Clinics",
                column: "CityId",
                principalTable: "Cities",
                principalColumn: "CityId");
        }
    }
}
