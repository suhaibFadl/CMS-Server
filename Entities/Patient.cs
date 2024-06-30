using System.ComponentModel.DataAnnotations.Schema;

namespace ClinicsSystem.Models
{
    public class Patient
    {
        public int PatientId { get; set; }
        public string? Name { get; set; }
        public int NationalNo { get; set; }
        public int PassportNo { get; set; }

        public ICollection<PatientsClinics> PatientsClinics { get; set; } = new List<PatientsClinics>();
    }
}
