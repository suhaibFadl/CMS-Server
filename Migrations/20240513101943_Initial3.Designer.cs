﻿// <auto-generated />
using ClinicsManagementSystem.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ClinicsManagementSystem.Migrations
{
    [DbContext(typeof(CMSContext))]
    [Migration("20240513101943_Initial3")]
    partial class Initial3
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ClinicsSystem.Models.City", b =>
                {
                    b.Property<int>("CityId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CityId"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CityId");

                    b.ToTable("Cities");
                });

            modelBuilder.Entity("ClinicsSystem.Models.Clinic", b =>
                {
                    b.Property<int>("ClinicId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ClinicId"));

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ClinicId");

                    b.ToTable("Clinics");
                });

            modelBuilder.Entity("ClinicsSystem.Models.Patient", b =>
                {
                    b.Property<int>("PatientId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PatientId"));

                    b.Property<int>("FileNo")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NationalNo")
                        .HasColumnType("int");

                    b.Property<int>("PassportNo")
                        .HasColumnType("int");

                    b.HasKey("PatientId");

                    b.ToTable("Patients");
                });

            modelBuilder.Entity("ClinicsSystem.Models.PatientsClinics", b =>
                {
                    b.Property<int>("PatientsClinicsId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PatientsClinicsId"));

                    b.Property<int>("FileNo")
                        .HasColumnType("int");

                    b.Property<int>("FileStatus")
                        .HasColumnType("int");

                    b.HasKey("PatientsClinicsId");

                    b.ToTable("PatientsClinics");
                });
#pragma warning restore 612, 618
        }
    }
}
