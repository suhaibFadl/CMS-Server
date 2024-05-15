using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClinicsManagementSystem.Migrations
{
    /// <inheritdoc />
    public partial class Initial6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CityId",
                table: "Clinics",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Clinics_CityId",
                table: "Clinics",
                column: "CityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Clinics_Cities_CityId",
                table: "Clinics",
                column: "CityId",
                principalTable: "Cities",
                principalColumn: "CityId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clinics_Cities_CityId",
                table: "Clinics");

            migrationBuilder.DropIndex(
                name: "IX_Clinics_CityId",
                table: "Clinics");

            migrationBuilder.DropColumn(
                name: "CityId",
                table: "Clinics");
        }
    }
}
