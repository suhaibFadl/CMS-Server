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
                .HasOne(c => c.City) // Clinic has one City
                .WithMany(city => city.Clinics) // City has many Clinics
                .HasForeignKey(c => c.CityId); // Foreign key relationship
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
