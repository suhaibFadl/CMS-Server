using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClinicsManagementSystem.Migrations
{
    /// <inheritdoc />
    public partial class ChangeClinicsDate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_PatientsClinics_PatientId",
                table: "PatientsClinics");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ExitDate",
                table: "PatientsClinics",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.CreateIndex(
                name: "IX_PatientsClinics_PatientId_ClinicId",
                table: "PatientsClinics",
                columns: new[] { "PatientId", "ClinicId" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_PatientsClinics_PatientId_ClinicId",
                table: "PatientsClinics");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ExitDate",
                table: "PatientsClinics",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PatientsClinics_PatientId",
                table: "PatientsClinics",
                column: "PatientId");
        }
    }
}
