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
     
    }
}
