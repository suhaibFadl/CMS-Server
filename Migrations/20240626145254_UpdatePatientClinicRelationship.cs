using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClinicsManagementSystem.Migrations
{
    /// <inheritdoc />
    public partial class UpdatePatientClinicRelationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_PatientsClinics_PatientId",
                table: "PatientsClinics");

            migrationBuilder.DropColumn(
                name: "FileNo",
                table: "Patients");

            migrationBuilder.CreateIndex(
                name: "IX_PatientsClinics_PatientId",
                table: "PatientsClinics",
                column: "PatientId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_PatientsClinics_PatientId",
                table: "PatientsClinics");

            migrationBuilder.AddColumn<int>(
                name: "FileNo",
                table: "Patients",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_PatientsClinics_PatientId",
                table: "PatientsClinics",
                column: "PatientId",
                unique: true);
        }
    }
}
