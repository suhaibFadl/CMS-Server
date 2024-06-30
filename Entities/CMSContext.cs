using ClinicsSystem.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace ClinicsManagementSystem.Entities
{
    public class CMSContext: DbContext
    {
        public CMSContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<City> Cities { get; set; }
        public DbSet<Clinic> Clinics { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<PatientsClinics> PatientsClinics { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Clinic>()
                .HasOne(c => c.City)
                .WithMany(city => city.Clinics)
                .HasForeignKey(c => c.CityId);

            modelBuilder.Entity<PatientsClinics>()
                .HasOne(pc => pc.Patient)
                .WithMany(p => p.PatientsClinics)
                .HasForeignKey(pc => pc.PatientId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<PatientsClinics>()
                .HasOne(pc => pc.Clinic)
                .WithMany(p => p.PatientsClinics)
                .HasForeignKey(pc => pc.ClinicId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<PatientsClinics>()
            .HasIndex(pc => new { pc.PatientId, pc.ClinicId })
            .IsUnique();
            } 


        //public void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<City>()
        //        .HasMany(o => o.Clinics)             // Order has many OrderItems
        //        .WithOne(oi => oi.City)                 // OrderItem has one Order
        //        .HasForeignKey(oi => oi.City!.CityId);        // Foreign key is OrderId in OrderItem
        //}
    }
}
