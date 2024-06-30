using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClinicsSystem.Models
{
    public class Clinic
    {
        [Key]
        public int ClinicId { get; set; }
        public string? Name { get; set; }
       
        [ForeignKey("City")]
        public int CityId { get; set; }

        // Navigation property
        public City? City { get; set; }

        public ICollection<PatientsClinics> PatientsClinics { get; set; } = new List<PatientsClinics>();

    }
}
