using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClinicsManagementSystem.Migrations
{
    /// <inheritdoc />
    public partial class Initial9 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clinics_Cities_CityId1",
                table: "Clinics");

            migrationBuilder.DropIndex(
                name: "IX_Clinics_CityId1",
                table: "Clinics");

            migrationBuilder.DropColumn(
                name: "CityId1",
                table: "Clinics");

            migrationBuilder.AddColumn<int>(
                name: "Clinic",
                table: "Clinics",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Clinics_Clinic",
                table: "Clinics",
                column: "Clinic");

            migrationBuilder.AddForeignKey(
                name: "FK_Clinics_Cities_Clinic",
                table: "Clinics",
                column: "Clinic",
                principalTable: "Cities",
                principalColumn: "CityId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clinics_Cities_Clinic",
                table: "Clinics");

            migrationBuilder.DropIndex(
                name: "IX_Clinics_Clinic",
                table: "Clinics");

            migrationBuilder.DropColumn(
                name: "Clinic",
                table: "Clinics");

            migrationBuilder.AddColumn<int>(
                name: "CityId1",
                table: "Clinics",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Clinics_CityId1",
                table: "Clinics",
                column: "CityId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Clinics_Cities_CityId1",
                table: "Clinics",
                column: "CityId1",
                principalTable: "Cities",
                principalColumn: "CityId");
        }
    }
}
