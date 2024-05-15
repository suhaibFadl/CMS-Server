using System.ComponentModel.DataAnnotations;

namespace ClinicsSystem.Models
{
    public class City
    {
        [Key]
        public int CityId { get; set; }
        public string Name { get; set; } = string.Empty;

        public ICollection<Clinic>? Clinics { get; set; }

    }
}
