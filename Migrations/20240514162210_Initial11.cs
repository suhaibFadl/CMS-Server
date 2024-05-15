using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClinicsManagementSystem.Migrations
{
    /// <inheritdoc />
    public partial class Initial11 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clinics_Cities_Clinic",
                table: "Clinics");

            migrationBuilder.RenameColumn(
                name: "Clinic",
                table: "Clinics",
                newName: "CityId");

            migrationBuilder.RenameIndex(
                name: "IX_Clinics_Clinic",
                table: "Clinics",
                newName: "IX_Clinics_CityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Clinics_Cities_CityId",
                table: "Clinics",
                column: "CityId",
                principalTable: "Cities",
                principalColumn: "CityId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clinics_Cities_CityId",
                table: "Clinics");

            migrationBuilder.RenameColumn(
                name: "CityId",
                table: "Clinics",
                newName: "Clinic");

            migrationBuilder.RenameIndex(
                name: "IX_Clinics_CityId",
                table: "Clinics",
                newName: "IX_Clinics_Clinic");

            migrationBuilder.AddForeignKey(
                name: "FK_Clinics_Cities_Clinic",
                table: "Clinics",
                column: "Clinic",
                principalTable: "Cities",
                principalColumn: "CityId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
